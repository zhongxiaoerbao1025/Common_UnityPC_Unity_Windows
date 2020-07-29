using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace zhongYue.SceneController
{
    public class SceneController_Error : MonoBehaviour
    {
        public MyEnum.ScenesName m_ScenesName = MyEnum.ScenesName.Level_A1_Load;

        private void LoadedScene(MyEnum.ScenesName scenesName)
        {
            switch (scenesName)
            {
                case MyEnum.ScenesName.Level_A1_Load:
                    //StartCoroutine(AsyncLoading((int)MyEnum.ScenesType.Loading));
                    break;
            }
        }
    }
}