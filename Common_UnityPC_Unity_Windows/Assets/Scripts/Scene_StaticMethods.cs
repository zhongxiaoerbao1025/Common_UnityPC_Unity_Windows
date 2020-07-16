using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZhongYue.Scene
{
    public class Scenes_StaticMethods : MonoBehaviour
    {
        #region 获取场景信息
        /// <summary>
        /// 获取当前活动的场景的名字
        /// </summary>
        /// <returns></returns>
        public static string GetActiveScene()
        {
            UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            return scene.name;
        }
        #endregion

        #region 加载场景
        /// <summary>
        /// 正常加载场景
        /// </summary>
        /// <param name="nextName">需要加载的场景的名字</param>
        public static void LoadScenesNormal(string nextName) { UnityEngine.SceneManagement.SceneManager.LoadScene(nextName); }

        /// <summary>
        /// 正常加载场景
        /// </summary>
        /// <param name="nextIndex">需要加载的场景的指数</param>
        public static void LoadScenesNormal(int nextIndex) { UnityEngine.SceneManagement.SceneManager.LoadScene(nextIndex); }

        /// <summary>
        /// 异步加载场景-常规
        /// </summary>
        /// <param name="sceneName"></param>
        public void LoadSceneAsyncNormal(string sceneName)
        {
            StartCoroutine(LoadAsyncSceneNormal(sceneName));
        }
        private IEnumerator LoadAsyncSceneNormal(string sceneName)
        {
            AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

        /// <summary>
        /// 异步加载场景-事件（示例）
        /// </summary>
        /// <param name="sceneName"></param>
        public void LoadSceneAsyncEvent(string sceneName)
        {
            StartCoroutine(LoadAsyncSceneEvent(sceneName));
        }
        protected virtual IEnumerator LoadAsyncSceneEvent(string sceneName)
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
                    //例如:当动画播放完成后，再跳转场景
                    if (transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
                    {
                        asyncOperation.allowSceneActivation = true;
                    }
                }

                yield return null;
            }
        }
        #endregion

        #region 将场景设置为活动
        /// <summary>
        /// 加载第二个场景
        /// </summary>
        /// <param name="isSceneLoad"></param>
        /// <param name="sceneIndex"></param>
        public static void AddScene(bool isSceneLoad, int sceneIndex)
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
        #endregion

        #region 从SceneManager中移除场景
        //给定的场景名称可以是完整的场景路径，“构建设置”窗口中显示的路径，也可以是场景名称
        //如果仅给出场景名称，则将卸载匹配列表中的第一个场景
        //如果您有多个具有相同名称但路径不同的场景，则应使用完整的场景路径

        /// <summary>
        /// 销毁与给定场景关联的所有GameObject，并从SceneManager中移除场景
        /// </summary>
        /// <param name="sceneBuildIndex">BuildSettings中场景的索引</param>
        public static void UnloadSceneAsync(int sceneBuildIndex) { SceneManager.UnloadSceneAsync(sceneBuildIndex); }

        /// <summary>
        /// 销毁与给定场景关联的所有GameObject，并从SceneManager中移除场景
        /// </summary>
        /// <param name="sceneName">要卸载的场景的名称或路径</param>
        public static void UnloadSceneAsync(string sceneName) { SceneManager.UnloadSceneAsync(sceneName); }

        /// <summary>
        /// 销毁与给定场景关联的所有GameObject，并从SceneManager中移除场景
        /// </summary>
        /// <param name="scene">要卸载的场景</param>
        public static void UnloadSceneAsync(UnityEngine.SceneManagement.Scene scene) { SceneManager.UnloadSceneAsync(scene); }
        #endregion
    }
}
