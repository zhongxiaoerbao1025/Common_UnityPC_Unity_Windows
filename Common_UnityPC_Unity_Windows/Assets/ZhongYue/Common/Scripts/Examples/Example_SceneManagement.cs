/*
 * 时间：2020年7月14日
 * 作者：钟樾
 * 备注：“Unity加载场景”的示例
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace ZhongYue.Example
{
    public class Example_SceneManagement
    {
        #region public

        /// <summary> 获取当前活动的场景的名字 </summary>
        public virtual string GetActiveScene()
        {
            UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            return scene.name;
        }

        /// <summary> 获取当前活动场景的 buildIndex </summary>
        public virtual int GetCurrentSceneIndex(int currentSceneIndex)
        {
            UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            return scene.buildIndex;
        }

        /// <summary> 加载第二个场景 </summary>
        public virtual void AddScene(bool isSceneLoad, int sceneIndex)
        {
            if (isSceneLoad == false)
            {
                //在当前场景中加载第二个场景
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
            }

            if (isSceneLoad == true)
            {
                //将新加载的场景更改为活动场景（如果场景已加载）
                UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(sceneIndex));
            }
        }

        /// <summary> 加载场景 </summary>
        public virtual void LoadScenes(string sceneName) { UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName); }
        public virtual void LoadScenes(int sceneIndex) { UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex); }

        /// <summary> 异步加载场景-常规 </summary>
        public virtual IEnumerator LoadSceneAsync(int sceneIndex)
        {
            //异步读取场景
            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
            //读取完毕后返回，系统进入C场景
            yield return async;
        }
        public virtual IEnumerator LoadSceneAsync(string sceneName)
        {
            //异步读取场景
            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            //读取完毕后返回，系统进入C场景
            yield return async;
        }

        /// <summary> 异步加载场景-进度条 </summary>
        public virtual IEnumerator LoadAsyncSceneEvent(string sceneName, bool isDone = false)
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return null;

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            //是否能够跳转到新加载的场景
            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    if (isDone == true)
                    {
                        asyncOperation.allowSceneActivation = true;
                    }
                }

                yield return null;
            }
        }
        public virtual IEnumerator LoadAsyncSceneEvent(int sceneIndex, bool isDone = false)
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return null;

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
            //是否能够跳转到新加载的场景
            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {
                if (asyncOperation.progress >= 0.9f)
                {
                    if (isDone == true)
                    {
                        asyncOperation.allowSceneActivation = true;
                    }
                }

                yield return null;
            }
        }

        /// <summary> 
        /// 添加一个委托，以便在加载场景时收到通知
        /// OnEnable时使用
        /// </summary>
        public virtual void SceneLoaded()
        {
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
        }

        /// <summary> 
        /// 添加一个委托，以便在卸载Scene时收到通知 
        /// 
        /// </summary>
        public virtual void SceneUnloaded()
        {
            UnityEngine.SceneManagement.SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        #endregion

        #region private

        /// <summary> 在加载场景时使用，收到通知 </summary>
        private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);
        }

        /// <summary> 在卸载Scene时使用，收到通知 </summary>
        private void OnSceneUnloaded(UnityEngine.SceneManagement.Scene current)
        {
            Debug.Log("OnSceneUnloaded: " + current);
        }

        #endregion

        #region 从SceneManager中移除场景
        //给定的场景名称可以是完整的场景路径，“构建设置”窗口中显示的路径，也可以是场景名称
        //如果仅给出场景名称，则将卸载匹配列表中的第一个场景
        //如果您有多个具有相同名称但路径不同的场景，则应使用完整的场景路径

        /// <summary>
        /// 销毁与给定场景关联的所有GameObject，并从SceneManager中移除场景
        /// </summary>
        /// <param name="sceneBuildIndex">BuildSettings中场景的索引</param>
        public virtual void UnloadSceneAsync(int sceneBuildIndex) { SceneManager.UnloadSceneAsync(sceneBuildIndex); }

        /// <summary>
        /// 销毁与给定场景关联的所有GameObject，并从SceneManager中移除场景
        /// </summary>
        /// <param name="sceneName">要卸载的场景的名称或路径</param>
        public virtual void UnloadSceneAsync(string sceneName) { SceneManager.UnloadSceneAsync(sceneName); }

        /// <summary>
        /// 销毁与给定场景关联的所有GameObject，并从SceneManager中移除场景
        /// </summary>
        /// <param name="scene">要卸载的场景</param>
        public virtual void UnloadSceneAsync(UnityEngine.SceneManagement.Scene scene) { SceneManager.UnloadSceneAsync(scene); }
        #endregion
    }
}