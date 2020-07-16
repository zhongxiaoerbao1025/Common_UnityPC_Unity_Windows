/// <summary>
/// ���ߣ���   ��
/// ʱ�䣺2018-07-13 14:12:50
/// ��ע�������Ի���,�Լ��Ի����еİ�����Ϣ��������Ϣ����ʾ��Ϣ��������
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace zhongYue_Manual
{
    public class Manuals_ScriptableWizard : ScriptableWizard
    {
        /// <summary>
        /// �����Ի���
        /// </summary>
        [MenuItem("StudyTest/Create Wizard", false, 0)]
        static void CreateWizard()
        {
            ScriptableWizard.DisplayWizard<Manuals_ScriptableWizard>("#�Ի���ı�ǩ#", "#CreateButton#", "#OtherButton#");
        }

        public int Hp = 2;
        public int Mp = 1;

        private const string hp = "Hp";
        private const string mp = "Mp";

        /// <summary>
        /// �Ի��򱻴�ʱ������
        /// </summary>
        private void OnEnable()
        {
            //��ȡ���������
            Hp = EditorPrefs.GetInt(hp, Hp);
            Mp = EditorPrefs.GetInt(mp, Mp);
        }


        #region �����OnGUI()�����ڶԻ����У�����ʹ��CreatButton�ȶԻ������е�һЩUI
        //private void OnGUI()
        //{

        //}

        /// <summary>
        /// ���Create��ť�ĵ������رյ�ǰ�Ի���
        /// </summary>
        private void OnWizardCreate()
        {
            Debug.Log("Create��ť�����");

            GameObject[] cube = Selection.gameObjects;

            //������
            EditorUtility.DisplayProgressBar("����", "0/" + cube.Length + "����޸�", 0);
            int count = 0;

            foreach (GameObject go in cube)
            {
                try
                {
                    //��ȡ��ѡ�����ϵĽű�

                    //��¼���������㳷��
                    //Undo.RecordObject(ch, "change Hp and Mp");

                    //ch.m_PlayerHp += Hp;
                    //ch.m_PlayerMp += Mp;
                }
                catch
                {
                    Debug.Log("���GameObject�ϲ��ܻ�ȡ����CubeHealth��");
                }

                //������
                count++;
                EditorUtility.DisplayProgressBar("����", count + "/" + cube.Length + "����޸�", (float)count / cube.Length);
            }

            //����������ɺ󣬹رս�������ʾ
            EditorUtility.ClearProgressBar();

            //��ʾ��Ϣ
            ShowNotification(new GUIContent(Selection.gameObjects.Length + "����Ϸ�����ֵ���޸���"));

            //�������ݣ������´ε���ʱ��Ƶ���޸�����ͬ��ֵ
            EditorPrefs.SetInt(hp, Hp);
            EditorPrefs.SetInt(mp, Mp);
        }

        /// <summary>
        /// ��ť������󲻻�رնԻ���
        /// </summary>
        private void OnWizardOtherButton()
        {
            //�ڴ����ĶԻ�������ʾ��ʾ��Ϣ
            ShowNotification(new GUIContent(Selection.gameObjects.Length + "����Ϸ�����ֵ���޸���"));
            OnWizardCreate();
            Debug.Log("Other Button�������");
        }
        #endregion

        /// <summary>
        /// ���Զ���Ի��򣬻��޸��ֶε�ֵʱ������
        /// </summary>
        private void OnWizardUpdate()
        {
            helpString = null;
            errorString = null;

            if (Selection.gameObjects.Length > 0)
            {
                helpString = "��ǰѡ����" + Selection.gameObjects.Length + "������";
            }
            else
            {
                errorString = "������ѡ��һ��GameObject";
            }
        }
        
        /// <summary>
        /// ��ѡ���GameObject�����ı�ʱ������
        /// </summary>
        private void OnSelectionChange()
        {
            OnWizardUpdate();
        }

        #region �ο�
        ///// <summary>
        ///// �༭�Լ��ı༭��GUI
        ///// </summary>
        //private void OnGUI()
        //{

        //}

        ///// <summary>
        ///// ���Create��ť��,���÷������رնԻ���
        ///// </summary>
        //private void OnWizardCreate()
        //{
        //    Debug.Log("Create��ť�����");
        //}

        ///// <summary>
        ///// ���OtherButton��ť�󣬵���
        ///// </summary>
        //private void OnWizardOtherButton()
        //{

        //}

        ///// <summary>
        ///// ���Ի����е����ݷ����ı�ʱ������
        ///// </summary>
        //private void OnWizardUpdate()
        //{

        //}

        ///// <summary>
        ///// �Ի��򱻹ر�ʱ������
        ///// </summary>
        //private void OnDestroy()
        //{

        //}

        ///// <summary>
        ///// ���ű������󳬳���Χʱ�������ô˺�����
        ///// ����������ʱҲ���Ե����������ҿ��������κ�������롣
        ///// ������ɺ����¼��ؽű�ʱ��������OnDisable��Ȼ���ڼ��ؽű������OnEnable
        ///// </summary>
        //private void OnDisable()
        //{

        //}

        ///// <summary>
        ///// �Ի��򱻴�ʱ������
        ///// </summary>
        //private void OnEnable()
        //{

        //}

        ///// <summary>
        ///// ���ڻ�ý���ʱ������
        ///// </summary>
        //private void OnFocus()
        //{

        //}

        ///// <summary>
        ///// ����ʧȥ����ʱ������
        ///// </summary>
        //private void OnLostFocus()
        //{

        //}

        ///// <summary>
        ///// ��GameObject�����ѡȡ�󣬵���
        ///// </summary>
        //private void OnSelectionChange()
        //{

        //}
        #endregion
    }
}