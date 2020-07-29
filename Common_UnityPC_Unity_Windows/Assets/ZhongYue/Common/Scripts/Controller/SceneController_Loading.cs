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
        //�첽����
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

            //ʵʱ���»�������ͼƬ��fillAmountֵ 
            m_ProgressImage.fillAmount = curProgressValue / 100f;

            if (curProgressValue == 100)
            {
                //�����Զ����س���
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
            //�첽��ȡ����
            operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
            //��ֹ����������Զ��л�
            operation.allowSceneActivation = false;

            yield return operation; ;
        }
    }
}
