using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhongYue.SceneController
{
    public class SceneController_Loading : MonoBehaviour
    {
        public MyEnum.ScenesName m_ScenesName = MyEnum.ScenesName.Level_A1_Load;

        public UnityEngine.UI.Image m_ProgressImage;

        private int curProgressValue = 0;
        //异步对象
        private AsyncOperation operation;

        int progressValue = 100;

        private void Start()
        {
            LoadedScene(m_ScenesName);
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

        private void LoadedScene(MyEnum.ScenesName scenesName)
        {
            switch (scenesName)
            {
                case MyEnum.ScenesName.Level_A1_Load:
                    StartCoroutine(AsyncLoading((int)MyEnum.ScenesName.Level_A1_Load));
                    break;
            }
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
