using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_LoadScenesEvent : MonoBehaviour
{

    /************************************* Mono *************************************/
    protected virtual void Awake()
    {
        Debug.Log("Awake");
    }

    protected virtual void OnEnable()
    {
        Debug.Log("OnEnable called");
        //添加一个委托，以便在加载场景时收到通知。
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;

    }

    protected virtual void Start()
    {
        Debug.Log("Start");
        // 添加一个委托，以便在卸载Scene时收到通知
        UnityEngine.SceneManagement.SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    protected virtual void Update()
    {

    }

    protected virtual void OnDisable()
    {
        Debug.Log("OnDisable");
        //添加一个委托，以便在加载场景时收到通知。
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    protected virtual void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }

    /************************************* 加载场景 *************************************/

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


    /************************************* 异步加载场景 *************************************/

    public virtual IEnumerator LoadSceneAsync(int nextSceneIndex)
    {
        //异步读取场景
        AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextSceneIndex);
        //读取完毕后返回，系统进入C场景
        yield return async;
    }

    /// <summary>
    /// 在后台异步加载场景
    /// </summary>
    /// <param name="nextSceneIndex"></param>
    /// <param name="isCanSwap">异步加载场景时，能否切换至下一场景</param>
    /// <returns></returns>
    public virtual IEnumerator LoadingSceneAsync(int nextSceneIndex,bool isCanSwap)
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        yield return null;

        AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextSceneIndex);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            if(asyncOperation.progress >= 0.9f)
            {
                if (isCanSwap)
                {
                    asyncOperation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }

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
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex,UnityEngine.SceneManagement.LoadSceneMode.Additive);
        }

        if (isSceneLoad == true)
        {
            //将新加载的场景更改为活动场景（如果场景已加载）
            UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(sceneIndex));
        }
    }


    /************************************* SceneManagement *************************************/

    /// <summary>
    /// 获取当前活动场景的 buildIndex
    /// </summary>
    /// <param name="currentSceneIndex"></param>
    public virtual int GetCurrentSceneIndex(int currentSceneIndex)
    {
        UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        return scene.buildIndex;
    }

    /// <summary>
    /// 添加一个委托，以便在加载场景时收到通知
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    /// <summary>
    /// 添加一个委托，以便在卸载Scene时收到通知
    /// </summary>
    void OnSceneUnloaded(UnityEngine.SceneManagement.Scene current)
    {
        Debug.Log("OnSceneUnloaded: " + current);
    }

    /// <summary>
    /// 获取当前活动的场景的名字
    /// </summary>
    /// <returns></returns>
    public static string GetActiveScene()
    {
        UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        return scene.name;
    }

        //给定的场景名称可以是完整的场景路径，“构建设置”窗口中显示的路径，也可以是场景名称
    //如果仅给出场景名称，则将卸载匹配列表中的第一个场景
    //如果您有多个具有相同名称但路径不同的场景，则应使用完整的场景路径

    /// <summary>
    /// 销毁与给定场景关联的所有GameObject，并从SceneManager中移除场景
    /// </summary>
    /// <param name="sceneBuildIndex">BuildSettings中场景的索引</param>
    public static void UnloadSceneAsync(int sceneBuildIndex) { UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneBuildIndex); }

    /// <summary>
    /// 销毁与给定场景关联的所有GameObject，并从SceneManager中移除场景
    /// </summary>
    /// <param name="sceneName">要卸载的场景的名称或路径</param>
    public static void UnloadSceneAsync(string sceneName) { UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName); }

    /// <summary>
    /// 销毁与给定场景关联的所有GameObject，并从SceneManager中移除场景
    /// </summary>
    /// <param name="scene">要卸载的场景</param>
    public static void UnloadSceneAsync(UnityEngine.SceneManagement.Scene scene) { UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene); }


}
