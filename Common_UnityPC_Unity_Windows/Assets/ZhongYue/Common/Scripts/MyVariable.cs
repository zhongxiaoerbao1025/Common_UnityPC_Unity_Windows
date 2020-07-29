/*
 * 作者：钟樾
 * 时间：2020年2月19日
 * 备注：变量
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVariable
{
    #region MyRegion
    //当前场景的名字
    private string _CurSceneName;
    /// <summary> 当前场景的名字 </summary>
    public string m_CurSceneName
    {
        get { return _CurSceneName; }
        set { _CurSceneName = value; }
    }

    //加载场景的名字
    private string _NextSceneName;
    /// <summary> 加载场景的名字 </summary>
    public string m_NextSceneName
    {
        get { return _NextSceneName; }
        set { _NextSceneName = value; }
    }
    #endregion
}
