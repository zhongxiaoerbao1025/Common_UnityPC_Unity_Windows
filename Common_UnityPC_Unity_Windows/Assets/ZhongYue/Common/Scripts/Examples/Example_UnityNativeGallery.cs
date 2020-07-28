using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Example
{
    public class Example_UnityNativeGallery : MonoBehaviour
    {
		public void UseExample()
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (Input.mousePosition.x < Screen.width / 3)
				{
					//截屏，并将其保存到库/照片
					StartCoroutine(TakeScreenshotAndSave());
				}
				else
				{
					//如果其他媒体在媒体库中选择照片，则搁置从媒体库中选择照片
					if (NativeGallery.IsMediaPickerBusy())
					{
						return;
					}

					if (Input.mousePosition.x < Screen.width * 2 / 3)
					{
						//从图库/照片中挑选png图片
						//Pick a PNG image from Gallery/Photos
						//如果选择的图片的宽度或高度大于512像素时，缩小图片
						// If the selected image's width and/or height is greater than 512px, down-scale the image
						PickImage(512);
					}
					else
					{
						//从图库/照片中，选择一个视频
						PickVideo();
					}
				}
			}
		}

		private IEnumerator TakeScreenshotAndSave()
		{
			yield return new WaitForEndOfFrame();

			Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
			ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
			ss.Apply();

			// Save the screenshot to Gallery/Photos
			Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, "GalleryTest", "Image.png"));

			// To avoid memory leaks
			Destroy(ss);
		}

		private void PickImage(int maxSize)
		{
			NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
			{
				Debug.Log("Image path: " + path);
				if (path != null)
				{
					// Create Texture from selected image
					Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
					if (texture == null)
					{
						Debug.Log("Couldn't load texture from " + path);
						return;
					}

					// Assign texture to a temporary quad and destroy it after 5 seconds
					GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
					quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
					quad.transform.forward = Camera.main.transform.forward;
					quad.transform.localScale = new Vector3(1f, texture.height / (float)texture.width, 1f);

					Material material = quad.GetComponent<Renderer>().material;
					if (!material.shader.isSupported) // happens when Standard shader is not included in the build
						material.shader = Shader.Find("Legacy Shaders/Diffuse");

					material.mainTexture = texture;

					Destroy(quad, 5f);

					// If a procedural texture is not destroyed manually, 
					// it will only be freed after a scene change
					Destroy(texture, 5f);
				}
			}, "Select a PNG image", "image/png");

			Debug.Log("Permission result: " + permission);
		}

		private void PickVideo()
		{
			NativeGallery.Permission permission = NativeGallery.GetVideoFromGallery((path) =>
			{
				Debug.Log("Video path: " + path);
				if (path != null)
				{
					// Play the selected video
					Handheld.PlayFullScreenMovie("file://" + path);
				}
			}, "Select a video");

			Debug.Log("Permission result: " + permission);
		}
	}
}