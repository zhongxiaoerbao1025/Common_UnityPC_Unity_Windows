using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Scene
{
    public class Scenes_Events : MonoBehaviour
    {
        #region Mono
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
        #endregion

        #region Events

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

        #endregion
    }
}