/*
 * 时间：2020年7月14日
 * 作者：钟樾
 * 备注：“屏幕相关应用”的示例
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Example
{
    public class Example_Screen
    {
        protected Resolution[] resolutions;
        protected int[] currentResolution;


        /// <summary>
        /// 显示器支持的所有全屏分辨率（只读）
        /// [0]-宽,[1]-高
        /// </summary>
        /// <returns></returns>
        public virtual Resolution[] ReturnAllResolution()
        {
            resolutions = Screen.resolutions;
            return resolutions;
        }

        /// <summary>
        /// 切换屏幕分辨率
        /// </summary>
        public virtual void SwitchesResolution(int width, int height, bool fullscreen = true, int preferredRefreshRate = 60)
        {
            Screen.SetResolution(width, height, fullscreen, preferredRefreshRate);
        }

        /// <summary>
        /// 当前屏幕分辨率（只读）
        /// 如果播放器在窗口模式下运行，则返回桌面的当前分辨率。
        /// 使用VR设备时，应使用VRSettings.eyeTextureWidth和VRSettings.eyeTextureHeight代替此设置
        /// </summary>
        public virtual int[] ReturnCurrentResolution()
        {
            currentResolution = new int[2];
            currentResolution[0] = Screen.currentResolution.width;
            currentResolution[1] = Screen.currentResolution.height;
            //Debug.Log(currentResolution[0] + "*" + currentResolution[1]);
            return currentResolution;
        }
    }
}