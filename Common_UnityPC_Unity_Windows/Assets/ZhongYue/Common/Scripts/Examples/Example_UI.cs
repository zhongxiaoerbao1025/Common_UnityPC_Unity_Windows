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
        Text, Image, RawImage, Button, Toggle
    }
    public class Example_UI : MonoBehaviour
    {
        public UIType m_UIType = UIType.Text;
        [SerializeField]
        public UnityEngine.UI.Text m_Text;
        [SerializeField]
        public UnityEngine.UI.Image m_Image;
        [SerializeField]
        public UnityEngine.UI.RawImage m_RawImage;
        [SerializeField]
        public UnityEngine.UI.Button m_Button;
        [SerializeField]
        public UnityEngine.UI.Toggle m_Toggle;

        protected void Start()
        {
            switch(m_UIType)
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

                default:
                    break;
            }
        }

        protected virtual void ButtonOnClick() { }
    }
}