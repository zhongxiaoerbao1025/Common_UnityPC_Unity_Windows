using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 坐标转换
/// 世界坐标、屏幕坐标、相机坐标的转换
/// </summary>
public class Manager_AxisSwitch : MonoBehaviour
{
    #region Screen(屏幕空间)的位置转换

    /// <summary>
    /// 将位置从屏幕空间转换为视口空间
    /// </summary>
    public void ScreenToViewportPoint() { }

    /// <summary>
    /// 将屏幕空间的位置转换为世界空间
    /// 屏幕空间以像素为单位定义。
    /// 屏幕的左下角是（0,0）; 右上角是（pixelWidth，pixelHeight）; z位置是相机的世界单位。
    /// </summary>
    public void ScreenToWorldPoint() { }

    #endregion

    #region Viewport(视口空间)的位置转换

    /// <summary>
    /// 将视口空间中的位置转换为屏幕空间
    /// </summary>
    public void ViewportToScreenPoint() { }

    /// <summary>
    /// 将视口空间中的位置转换为世界空间
    /// </summary>
    public void ViewportToWorldPoint() { }

    #endregion

    #region World(世界空间)的位置转换

    /// <summary>
    /// 将世界空间的位置转换为屏幕空间
    /// </summary>
    public Vector3 WorldToScreenPoint(Transform target, Camera camera)
    {
        if (target != null && camera != null)
        {
            Vector3 screenPos = camera.WorldToScreenPoint(target.position);
            return screenPos;
        }
        else
        {
            Debug.LogError("位置转换出错!");
            return Vector3.zero;
        }
    }

    /// <summary>
    /// 将世界空间的位置转换为视口空间
    /// </summary>
    public Vector3 WorldToViewportPoint(Transform target, Camera camera)
    {
        if (target != null && camera != null)
        {
            Vector3 viewPos = camera.WorldToViewportPoint(target.position);
            return viewPos;
        }
        else
        {
            Debug.LogError("位置转换出错!");
            return Vector3.zero;
        }
    }

    #endregion
}
