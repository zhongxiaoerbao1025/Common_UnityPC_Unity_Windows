using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_Editor : MonoBehaviour
{
    public int m_PlayerHp = 0;

    [ContextMenuItem("Add Mp(+10)", "AddMp")]//�ڱ������Ҽ��˵���ʾ
    public int m_PlayerMp = 0;

    void AddMp()
    {
        m_PlayerMp += 10;
    }

    [ContextMenu("Add Hp(+10)")]//�ڽű����Ҽ��˵���ʾ
    void AddHp()
    {
        m_PlayerHp += 10;
    }

    #region �ı�Inspector�У���������ʾ��ʽ
    public Texture _Texture;
    public float _SliderValue = 0.1f;
    #endregion
}
