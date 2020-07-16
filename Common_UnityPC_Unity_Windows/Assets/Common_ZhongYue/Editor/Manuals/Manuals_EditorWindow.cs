/// <summary>
/// ���ߣ���   ��
/// ʱ�䣺2018-07-13 15:41:27
/// ��ע�������Զ��崰�� 
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace zhongYue_Manual
{
    public class Manuals_EditorWindow : EditorWindow
    {
        bool groundEnable = false;
        float value1 = 0f;

        [MenuItem("StudyTest/My Window")]
        private static void ShowMyWindow()
        {
            Rect theRect = new Rect(0, 0, 500, 500);
            //�����Զ��崰�ڷ���һ��ֻ�ܴ���һ��
            //Manual_3 window = (Manual_3)EditorWindow.GetWindowWithRect(typeof(Manual_3), theRect, true, "�ҵĴ���");//��������
            Manuals_EditorWindow window = (Manuals_EditorWindow)EditorWindow.GetWindowWithRect(typeof(Manuals_EditorWindow), theRect, false, "�ҵĴ���");
            //ѡ�����
            //Manual_3 window = EditorWindow.GetWindow<Manual_3>();
            window.Show();

            //�����Զ��崰�ڷ����������Դ���������
            //Manual_3.CreateInstance<Manual_3>().Show();
        }

        private string name = "gameObject";

        private void OnGUI()
        {
            if (GUILayout.Button("��֪ͨ", GUILayout.Width(220)))
            {
                this.ShowNotification(new GUIContent("֪ͨ������"));
            }
            if (GUILayout.Button("�ر�֪ͨ", GUILayout.Width(220)))
            {
                this.RemoveNotification();
            }

            GUILayout.Label("�����ǻ�������");
            groundEnable = EditorGUILayout.BeginToggleGroup("����", groundEnable);
            value1 = EditorGUILayout.FloatField("ֵ1", value1);
            EditorGUILayout.EndToggleGroup();

            name = GUILayout.TextField(name);
            if (GUILayout.Button("����һ��GameObject"))
            {
                //����һ��GameObejct
                GameObject go = new GameObject(name);
                //��¼���������㳷��
                Undo.RegisterCreatedObjectUndo(go, "Create GameObject");
            }
        }

        /// <summary>
        /// ���ڻ�ý����ʱ�����
        /// </summary>
        private void OnFocus()
        {

        }

        /// <summary>
        /// ����ʧȥ�����ʱ�����
        /// </summary>
        private void OnLostFocus()
        {

        }

        /// <summary>
        /// ������Ķ������ı�ʱ������
        /// </summary>
        private void OnHierarchyChange()
        {

        }

        /// <summary>
        /// ��Ŀ���Ķ������ı�ʱ������
        /// </summary>
        private void OnProjectChange()
        {

        }

        /// <summary>
        /// �����屻ѡ��ʱ������
        /// </summary>
        private void OnSelectionChange()
        {

        }

        /// <summary>
        /// �����ڱ��ر�ʱ,����
        /// </summary>
        private void OnDestroy()
        {

        }
    }
}
