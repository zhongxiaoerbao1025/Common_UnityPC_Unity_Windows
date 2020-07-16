using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Manager
{
    public class Manager_UI_Button : MonoBehaviour
    {
        private UnityEngine.UI.Button _Button;

        protected virtual void Start()
        {
            _Button = GetComponent<UnityEngine.UI.Button>();
            _Button.onClick.AddListener(ButtonOnClick);
        }

        /// <summary> 按钮的点击事件 </summary>
        protected virtual void ButtonOnClick() { }
    }
}
