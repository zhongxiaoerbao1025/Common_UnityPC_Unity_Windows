using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue
{
    public class SceneLoading_Init : MonoBehaviour
    {
        public int m_LoadingSceneIndex = 1;

        void Start()
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(m_LoadingSceneIndex);
        }
    }
}
