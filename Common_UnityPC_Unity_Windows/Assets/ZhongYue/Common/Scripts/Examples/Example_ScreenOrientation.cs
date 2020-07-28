/*
 * 时间：2020年07月09日
 * 作者：钟樾
 * 备注：移动设备的屏幕旋转
 */
using UnityEngine;
using System.Collections;

namespace ZhongYue.Example
{
    public class Example_ScreenOrientation : MonoBehaviour
    {
        [Tooltip("纵向")]
        public bool m_AllowedPortrait = true;
        [Tooltip("纵向，上下颠倒")]
        public bool m_AllowedPortraitUpsideDown = true;
        [Tooltip("横向，从纵向逆时针旋转")]
        public bool m_AllowedLandscapeLeft = true;
        [Tooltip("横向，从纵向顺时针旋转")]
        public bool m_AllowedLandscapeRight = true;

        private void Start()
        {
            ScreenOrientationSetting(
                m_AllowedPortrait,
                m_AllowedPortraitUpsideDown,
                m_AllowedLandscapeLeft,
                m_AllowedLandscapeRight);
        }

        /// <summary> 仅纵向 </summary>
        protected virtual void OnlyPortrait() { Screen.orientation = UnityEngine.ScreenOrientation.Portrait; }

        /// <summary> 仅纵向，上下颠倒 </summary>
        protected virtual void OnlyUpsideDown() { Screen.orientation = UnityEngine.ScreenOrientation.PortraitUpsideDown; }

        /// <summary> 仅横向，从纵向逆时针旋转 </summary>
        protected virtual void OnlyLandscapeLeft() { Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft; }

        /// <summary> 仅横向，从纵向顺时针旋转 </summary>
        protected virtual void OnlyLandscapeRight() { Screen.orientation = UnityEngine.ScreenOrientation.LandscapeRight; }

        /// <summary> 自定义屏幕旋转设定 </summary>
        protected virtual void ScreenOrientationSetting(bool portrait, bool upsideDown, bool left, bool right)
        {
            Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;

            Screen.autorotateToPortrait = portrait;
            Screen.autorotateToPortraitUpsideDown = upsideDown;
            Screen.autorotateToLandscapeLeft = left;
            Screen.autorotateToLandscapeRight = right;
        }
    }
}
