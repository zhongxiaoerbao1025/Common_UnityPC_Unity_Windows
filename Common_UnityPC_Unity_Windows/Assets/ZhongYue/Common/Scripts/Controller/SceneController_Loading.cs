using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhongYue.SceneController
{
    public class SceneController_Loading : MonoBehaviour
    {
        public MyEnum.ScenesType m_ScenesType = MyEnum.ScenesType.None;

        public UnityEngine.UI.Image m_ProgressImage;

        private int curProgressValue = 0;
        //�첽����
        private AsyncOperation operation;

        int progressValue = 100;

        private void Start()
        {
            LoadedScene(m_ScenesType);
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

        private void LoadedScene(MyEnum.ScenesType scenesType)
        {
            switch (scenesType)
            {
                case MyEnum.ScenesType.Loading:
                    StartCoroutine(AsyncLoading((int)MyEnum.ScenesType.Loading));
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
