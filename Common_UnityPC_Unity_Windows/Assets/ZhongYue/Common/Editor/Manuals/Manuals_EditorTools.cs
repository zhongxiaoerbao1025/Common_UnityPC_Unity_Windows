/// <summary>
/// ���ߣ�����
/// ��ע��Unity Editorѧϰ�ֲ�
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace zhongYue_Manual
{
    public class Manuals_EditorTools
    {
        //·��
        [MenuItem("StudyTest/test/test1")]
        static void Test() { }

        //���ȼ�
        [MenuItem("StudyTest/test1", false, 0)]
        static void Test1() { }

        //�������������뵽��GameObject�������ڡ�Hierarchy���Ҽ�ʱ�����Ĳ˵�������ʾ
        [MenuItem("GameObject/StudyTest", false, 11)]
        static void Tool() { }

        /// <summary>
        /// ��ĳ��������ĳЩ��ֵһ���Խ����޸�
        /// �����ڡ����á�����
        /// </summary>
        /// <param name="cmd"></param>
        [MenuItem("CONTEXT/PlayerHealth/Init")]//·����"CONTEXT/�����/������"
        static void Init(MenuCommand cmd)//MenuCommand�ǵ�ǰ���ڲ��������
        {
            //CompleteProject.PlayerHealth health = cmd.context as CompleteProject.PlayerHealth;
            //health.startingHealth = 200;
            //health.flashSpeed = 10;
        }

        /// <summary>
        /// ��ӿ�ݼ�
        /// </summary>
        /// % = ctrl, # = shift, & = alt
        [MenuItem("StudyTest/Hot Key %H")]
        //[MenuItem("StudyTest/Hot Key _H")]//���������ⰴ��ʱ����Ҫ����»���
        static void AddHotKey()
        {
            Debug.Log("�ȼ�����");
        }
    }
}
