using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace zhongYue.SceneController
{
    public class SceneController_Connect : MonoBehaviour
    {
        public MyEnum.ScenesType m_ScenesType = MyEnum.ScenesType.None;

        private void LoadedScene(MyEnum.ScenesType scenesType)
        {
            switch (scenesType)
            {
                case MyEnum.ScenesType.Loading:
                    //StartCoroutine(AsyncLoading((int)MyEnum.ScenesType.Loading));
                    break;
            }
        }
    }
}
