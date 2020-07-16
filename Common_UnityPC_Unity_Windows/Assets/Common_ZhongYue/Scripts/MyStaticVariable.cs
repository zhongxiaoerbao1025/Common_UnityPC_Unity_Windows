/*
 * 作者：钟樾
 * 时间：2020年2月19日
 * 备注：静态变量
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyStaticVariable
{
    public static int m_NextSceneIndex = 0;
    public static string m_NextSceneName = "";
    public static int m_StreetlightIndex = 0;

    /// <summary> 照明 </summary>
    public static bool m_Light = true;

    /// <summary> 监控 </summary>
    public static bool m_Monitor = true;

    /// <summary> 信息发布 </summary>
    public static bool m_Information = true;

    /// <summary> WIFI </summary>
    public static bool m_WIFI = true;

    /// <summary> 广播 </summary>
    public static bool m_Broadcast = true;

    /// <summary> 环境监测 </summary>
    public static bool m_HuanJing = true;

    /// <summary> 一键报警 </summary>
    public static bool m_BaoJing = true;

    /// <summary> 充电桩 </summary>
    public static bool m_ChongDian = true;

    /// <summary> 基站 </summary>
    public static bool m_JiZhan = true;
}
