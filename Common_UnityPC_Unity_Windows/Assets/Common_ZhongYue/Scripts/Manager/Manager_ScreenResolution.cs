using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_ScreenResolution : MonoBehaviour
{
    #region 屏幕分辨率

    protected static Resolution[] resolutions;
    protected static int[] currentResolution;

    /// <summary>
    /// 显示器支持的所有全屏分辨率（只读）
    /// [0]-宽,[1]-高
    /// </summary>
    /// <returns></returns>
    public static Resolution[] ReturnAllResolution()
    {
        resolutions = UnityEngine.Screen.resolutions;
        return resolutions;
    }

    /// <summary>
    /// 切换屏幕分辨率
    /// </summary>
    public static void SwitchesResolution(int width, int height, bool fullscreen = true, int preferredRefreshRate = 60)
    {
        UnityEngine.Screen.SetResolution(width, height, fullscreen, preferredRefreshRate);
    }

    /// <summary>
    /// 当前屏幕分辨率（只读）
    /// 如果播放器在窗口模式下运行，则返回桌面的当前分辨率。
    /// 使用VR设备时，应使用VRSettings.eyeTextureWidth和VRSettings.eyeTextureHeight代替此设置
    /// </summary>
    public static int[] ReturnCurrentResolution()
    {
        currentResolution = new int[2];
        currentResolution[0] = UnityEngine.Screen.currentResolution.width;
        currentResolution[1] = UnityEngine.Screen.currentResolution.height;
        //Debug.Log(currentResolution[0] + "*" + currentResolution[1]);
        return currentResolution;
    }

    #endregion
}
