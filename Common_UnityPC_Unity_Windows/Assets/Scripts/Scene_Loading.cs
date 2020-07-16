using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Scene
{
    /// <summary>
    /// 使用进度条，异步加载场景
    /// 可使用此脚本
    /// </summary>
    public class Scene_Loading : MonoBehaviour
    {
        public UnityEngine.UI.Image m_Image;
        //异步对象
        private AsyncOperation async;
        //读取场景的进度，它的取值范围在0-1之间
        private int progress = 0;

        private void Start()
        {
            //开启异步任务
            StartCoroutine(loadScene(MyArgs.m_NextScene));
        }

        private void Update()
        {
            progress = (int)(async.progress * 100);
            m_Image.fillAmount = progress;
        }

        private IEnumerator loadScene(string nextScene)
        {
            //异步读取场景
            async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextScene);
            //读取完毕后返回，系统会自动进入C场景
            yield return async;
        }
    }
}