//================================
//作者：钟   樾
//时间：2018-07-17 16:02:44
//备注：
//================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EExample
{
    jump,
    walk,
    run
};

[AddComponentMenu("Scripts/ExampleView")]//通过菜单栏的Component,快速挂载
[RequireComponent(typeof(Rigidbody))]//挂载脚本时，同时挂载一个Rigidbody

public class ExampleView : MonoBehaviour
{
    public int m_PlayerHp = 0;

    [ContextMenuItem("Add Mp(+10)","AddMp")]//在变量的右键菜单显示
    public int m_PlayerMp = 0;
	
    void AddMp()
    {
        m_PlayerMp += 10;
    }

    [ContextMenu("Add Hp(+10)")]//在脚本的右键菜单显示
    void AddHp()
    {
        m_PlayerHp += 10;
    }

    #region 改变Inspector中，变量的显示方式
    public Texture _Texture;
    public float _SliderValue = 0.1f;
    #endregion
}
