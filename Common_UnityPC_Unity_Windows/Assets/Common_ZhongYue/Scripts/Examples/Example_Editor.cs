using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_Editor : MonoBehaviour
{
    public int m_PlayerHp = 0;

    [ContextMenuItem("Add Mp(+10)", "AddMp")]//在变量的右键菜单显示
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
