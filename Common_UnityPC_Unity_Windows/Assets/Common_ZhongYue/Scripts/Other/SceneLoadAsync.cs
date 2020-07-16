/*
 * 作者：钟樾
 * 时间：2020年2月3日
 * 备注：过渡场景中，使用进度条，异步加载场景
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Scene
{
    public class SceneLoadAsync : MonoBehaviour
    {
        public UnityEngine.UI.Image m_ProgressImage;

        public int m_SceneIndex = 0;
        private string m_SceneName="";

        private int curProgressValue = 0;
        //异步对象
        private AsyncOperation operation;

        int progressValue = 100;

        private void Start()
        {
            //开启异步任务
            if (m_SceneName == "")
            {
                StartCoroutine(AsyncLoading(m_SceneIndex));
            }
            else
            {
                StartCoroutine(AsyncLoading(m_SceneName));
            }
        }

        private void Update()
        {
            if (curProgressValue < progressValue)
            {
                curProgressValue++;
            }

            //实时更新滑动进度图片的fillAmount值 
            m_ProgressImage.fillAmount = curProgressValue / 100f;

            if (curProgressValue == 100)
            {
                //启用自动加载场景
                operation.allowSceneActivation = true;
            }
        }

        private IEnumerator AsyncLoading(string sceneName)
        {
            //异步读取场景
            operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            //阻止当加载完成自动切换
            operation.allowSceneActivation = false;

            yield return operation;
        }
        private IEnumerator AsyncLoading(int sceneIndex)
        {
            //异步读取场景
            operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
            //阻止当加载完成自动切换
            operation.allowSceneActivation = false;

            yield return operation; ;
        }
    }
}