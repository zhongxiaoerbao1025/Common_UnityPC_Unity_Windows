/*
 * ʱ�䣺2020��7��24��
 * ���ߣ�����
 * ��ע����ɫ������֮���ƽ������
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Example
{
    public class Example_Teleport : MonoBehaviour
    {
        public Transform[] m_PlayerTransform;

        public UnityEngine.UI.Button m_LeftButton;
        public UnityEngine.UI.Button m_RightButton;
        public UnityEngine.UI.Text m_IndexText;
        public GameObject m_ImagePrefab;

        private GameObject _Player;

        /// <summary> ��ǰ���ڳ����е��ӽ�λ�� </summary>
        private int _CurPosIndex = 0;
        /// <summary> ���ڳ����е��ӽ�λ�� </summary>
        private int _OldPosIndex = 0;
        /// <summary> �Ƿ�����ƽ����ת </summary>
        private bool _CanRotateLerp = false;

        private void Start()
        {
            m_LeftButton.onClick.AddListener(LeftButtonClick);
            m_RightButton.onClick.AddListener(RightButtonClick);

            _Player = GameObject.Find("Player");

            AddImagePrefabs(m_ImagePrefab, this.transform.Find("Bottom").transform);

            TeleportEvents(0, 0, m_PlayerTransform[0]);
        }

        void LateUpdate()
        {
            if (Input.GetMouseButtonDown(1))
            {
                _CanRotateLerp = false;
                //_Player.transform.rotation = _Player.transform.rotation;
            }

            if (_CanRotateLerp)
            {
                //ƽ����ת
                _Player.transform.rotation = Quaternion.Slerp(_Player.transform.rotation, m_PlayerTransform[_CurPosIndex].rotation, Time.deltaTime * 1.0f);
            }
        }

        public virtual void LeftButtonClick()
        {
            if (_CurPosIndex > 0) { _CurPosIndex--; }
            _CanRotateLerp = true;
            TeleportEvents(_OldPosIndex, _CurPosIndex, m_PlayerTransform[_CurPosIndex]);
        }

        public virtual void RightButtonClick()
        {
            if (_CurPosIndex < m_PlayerTransform.Length - 1) { _CurPosIndex++; }
            _CanRotateLerp = true;
            TeleportEvents(_OldPosIndex, _CurPosIndex, m_PlayerTransform[_CurPosIndex]);
        }

        protected virtual void TeleportEvents(int oldPosIndex, int curPosIndex, Transform newTransform)
        {
            if (curPosIndex != oldPosIndex)
            {
                _OldPosIndex = curPosIndex;
                //��ǰ�����ӽǵ�ָ��
                m_IndexText.text = (curPosIndex + 1).ToString();
                //�ı�Player��λ��
                _Player.transform.position = newTransform.position;

                //ͨ����ͬ����ɫ��ʾ����ǰ���ڵ��ӽǵ�ָ��
                for (int i = 0; i < this.transform.Find("Bottom").childCount; i++)
                {
                    this.transform.Find("Bottom").GetChild(i).GetComponent<UnityEngine.UI.Image>().color = Color.red;
                }
                this.transform.Find("Bottom").GetChild(curPosIndex).GetComponent<UnityEngine.UI.Image>().color = Color.blue;

                //Args.RotateValue_Y = m_PlayerTransform[_CurPosIndex].rotation.y - _Player.transform.rotation.y;
                MyArgs.RotateValue_Y = m_PlayerTransform[_CurPosIndex].rotation.eulerAngles.y - _Player.transform.rotation.eulerAngles.y;
                Debug.Log(MyArgs.RotateValue_Y);
                MyArgs.IsAddRotate = true;
            }
        }

        protected virtual void ChangeText(UnityEngine.UI.Text textUI, string text)
        {
            textUI.text = text;
        }

        /// <summary>
        /// ��ӡ��ӽǵ�ָ����塱Ԥ����
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="parent"></param>
        protected virtual void AddImagePrefabs(GameObject prefab, Transform parent)
        {
            for (int i = 0; i < m_PlayerTransform.Length; i++)
            {
                GameObject image = Instantiate(prefab);
                image.transform.SetParent(parent, false);
                image.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = (i + 1).ToString();
            }
        }
    }
}