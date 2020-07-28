/*
 * 时间：2020年7月14日
 * 作者：钟樾
 * 备注：“UI”示例
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Example
{
    public enum UIType
    {
        Text, Image, RawImage, Button, Toggle, Dropdown
    }
    public class Example_UI : MonoBehaviour
    {
        public UIType m_UIType = UIType.Text;
        [HideInInspector]
        public UnityEngine.UI.Text m_Text;
        [HideInInspector]
        public UnityEngine.UI.Image m_Image;
        [HideInInspector]
        public UnityEngine.UI.RawImage m_RawImage;
        [HideInInspector]
        public UnityEngine.UI.Button m_Button;
        [HideInInspector]
        public UnityEngine.UI.Toggle m_Toggle;

        private UnityEngine.UI.Slider m_Slider;

        public UnityEngine.UI.Dropdown m_Dropdown;

        /// <summary> 按钮的点击事件 </summary>
        protected virtual void ButtonOnClick() { }
        /// <summary> 事件："切换按钮的值改变时" </summary>
        protected virtual void ToggleValueChanged(UnityEngine.UI.Toggle change) { }
        protected virtual void SliderValueChanged(float arg) { }
        protected virtual void DropdownValueChanged(int arg0) { }

        protected void Start()
        {
            switch (m_UIType)
            {
                case UIType.Text:
                    m_Text = this.GetComponent<UnityEngine.UI.Text>();
                    break;

                case UIType.Image:
                    m_Image = this.GetComponent<UnityEngine.UI.Image>();
                    break;

                case UIType.RawImage:
                    m_RawImage = this.GetComponent<UnityEngine.UI.RawImage>();
                    break;

                case UIType.Button:
                    m_Button = this.GetComponent<UnityEngine.UI.Button>();
                    m_Button.onClick.AddListener(ButtonOnClick);
                    break;

                case UIType.Toggle:
                    m_Toggle = this.GetComponent<UnityEngine.UI.Toggle>();
                    m_Toggle.onValueChanged.AddListener(delegate { ToggleValueChanged(m_Toggle); });
                    break;

                case UIType.Dropdown:
                    m_Dropdown = GetComponent<UnityEngine.UI.Dropdown>();
                    m_Dropdown.onValueChanged.AddListener(DropdownValueChanged);
                    break;

                default:
                    break;
            }
        }
    }
}