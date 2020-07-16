/*
 * 时间：
 * 作者：
 * 备注：对指定相机进行截图
 */

using UnityEngine;
using System.Collections;

namespace ZhongYue.Example
{
    public class Example_Screenshot
    {
        // 创建一个RenderTexture对象
        private RenderTexture rt;
        private Texture2D screenShot;
        private byte[] bytes;
        private string filename;

        /// <summary> 对相机截图 </summary>
        /// <returns>The screenshot2.</returns>
        /// <param name="camera">Camera.要被截屏的相机</param>
        /// <param name="rect">Rect.截屏的区域</param>
        public virtual Texture2D CaptureCamera(Camera camera, Rect rect, string path)
        {
            rt = new RenderTexture((int)rect.width, (int)rect.height, 24);

            // 临时设置相关相机的targetTexture为rt, 并手动渲染相关相机
            camera.targetTexture = rt;
            camera.Render();
            //ps: --- 如果这样加上第二个相机，可以实现只截图某几个指定的相机一起看到的图像
            //ps: camera2.targetTexture = rt;
            //ps: camera2.Render();
            //ps: -------------------------------------------------------------------

            // 激活这个rt, 并从中读取像素。
            RenderTexture.active = rt;
            screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);

            screenShot.ReadPixels(rect, 0, 0);// 注：这个时候，它是从RenderTexture.active中读取像素
            screenShot.Apply();

            // 重置相关参数，以使用camera继续在屏幕上显示
            camera.targetTexture = null;
            //ps: camera2.targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            GameObject.Destroy(rt);

            // 最后将这些纹理数据，成一个png图片文件
            bytes = screenShot.EncodeToPNG();
            filename = path;
            System.IO.File.WriteAllBytes(filename, bytes);
            Resources.UnloadUnusedAssets();
            return screenShot;
        }

        /// <summary> unity默认的截图方式 </summary>
        /// <param name="path">截图文件存储位置</param>
        public virtual void CapruerScreen(string path)
        {
            ScreenCapture.CaptureScreenshot(path);
        }
    }
}