using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Example
{
    public class Example_PlayerMove : MonoBehaviour
    {
        public Transform[] m_PlayerTransform;

        public UnityEngine.UI.Button m_LeftButton;
        public UnityEngine.UI.Button m_RightButton;
        public UnityEngine.UI.Text m_IndexText;

        /// <summary> ImageԤ���壬��ʾ��ǰλ�õı�ǩ </summary>
        public GameObject m_ImagePrefab;

        private GameObject _MainCamera;

        /// <summary> ��ǰ���ڳ����е��ӽ�λ�� </summary>
        private int _CurPosIndex = 0;
        /// <summary> ���ڳ����е��ӽ�λ�� </summary>
        private int _OldPosIndex = 0;
        /// <summary> �Ƿ����ƽ����ת </summary>
        private bool _CanRotateLerp = false;

        //��ǰ�ٶ�
        private Vector3 curVelocity = Vector3.zero;
        //ƽ����ʱ��
        private float smoothTime = 1;

        /// <summary> ReferenceCollector </summary>
        //private ReferenceCollector rc;

        public void Awake()
        {
            if (m_PlayerTransform.Length == 0)
            {
                for (int i = 0; i < _MainCamera.transform.Find("Position").childCount; i++)
                {
                    m_PlayerTransform[i] = _MainCamera.transform.Find("Position/Pos_" + i);
                }
            }

            _MainCamera = GameObject.FindWithTag("MainCamera");

            AddImagePrefabs(m_ImagePrefab, _MainCamera.transform.Find("Bottom").transform);

            MoveLerpEvents(0, 0);
        }

        public void Start()
        {
            //��ť����
            m_LeftButton.onClick.AddListener(LeftButtonClick);
            m_RightButton.onClick.AddListener(RightButtonClick);

        }

        public void LateUpdate()
        {
            if (Input.GetMouseButtonDown(1))
            {
                _CanRotateLerp = false;
                //_Player.transform.rotation = _Player.transform.rotation;
            }

            if (_CanRotateLerp)
            {
                //ƽ����ת
                _MainCamera.transform.rotation = Quaternion.Slerp(_MainCamera.transform.rotation, m_PlayerTransform[_CurPosIndex].rotation, Time.deltaTime * 1.0f);
            }

            if (Vector3.Distance(_MainCamera.transform.position, m_PlayerTransform[_CurPosIndex].position) > 0.2f)
            {
                _MainCamera.transform.position = Vector3.SmoothDamp(_MainCamera.transform.position, m_PlayerTransform[_CurPosIndex].position, ref curVelocity, smoothTime);
            }
            //else { _Player.transform.position = m_PlayerTransform[_CurPosIndex].position; }
        }

        public virtual void LeftButtonClick()
        {
            if (_CurPosIndex > 0) { _CurPosIndex--; }
            _CanRotateLerp = true;
            //TeleportEvents(_OldPosIndex,_CurPosIndex, m_PlayerTransform[_CurPosIndex]);
            MoveLerpEvents(_OldPosIndex, _CurPosIndex);
        }

        public virtual void RightButtonClick()
        {
            if (_CurPosIndex < m_PlayerTransform.Length - 1) { _CurPosIndex++; }
            _CanRotateLerp = true;
            //TeleportEvents(_OldPosIndex, _CurPosIndex, m_PlayerTransform[_CurPosIndex]);
            MoveLerpEvents(_OldPosIndex, _CurPosIndex);
        }

        /// <summary> ��ɫ˲���¼� </summary>
        protected virtual void TeleportEvents(int oldPosIndex, int curPosIndex, Transform target)
        {
            if (curPosIndex != oldPosIndex)
            {
                _OldPosIndex = curPosIndex;
                //��ǰ�����ӽǵ�ָ��
                m_IndexText.text = (curPosIndex + 1).ToString();
                //�ı�Player��λ��
                _MainCamera.transform.position = target.position;

                //ͨ����ͬ����ɫ��ʾ����ǰ���ڵ��ӽǵ�ָ��
                for (int i = 0; i < _MainCamera.transform.Find("Bottom").childCount; i++)
                {
                    _MainCamera.transform.Find("Bottom").GetChild(i).GetComponent<UnityEngine.UI.Image>().color = Color.red;
                }
                _MainCamera.transform.Find("Bottom").GetChild(curPosIndex).GetComponent<UnityEngine.UI.Image>().color = Color.blue;

                //Args.RotateValue_Y = m_PlayerTransform[_CurPosIndex].rotation.y - _Player.transform.rotation.y;
                MyArgs.RotateValue_Y = m_PlayerTransform[_CurPosIndex].rotation.eulerAngles.y - _MainCamera.transform.rotation.eulerAngles.y;
                Debug.Log(MyArgs.RotateValue_Y);
                MyArgs.IsAddRotate = true;
            }
        }

        /// <summary> ��ɫƽ��λ���¼� </summary>
        protected virtual void MoveLerpEvents(int oldPosIndex, int curPosIndex/*,Transform target*/)
        {
            if (curPosIndex != oldPosIndex)
            {
                _OldPosIndex = curPosIndex;
                //��ǰ�����ӽǵ�ָ��
                m_IndexText.text = (curPosIndex + 1).ToString();
                //ͨ����ͬ����ɫ��ʾ����ǰ���ڵ��ӽǵ�ָ��
                for (int i = 0; i < _MainCamera.transform.Find("Bottom").childCount; i++)
                {
                    _MainCamera.transform.Find("Bottom").GetChild(i).GetComponent<UnityEngine.UI.Image>().color = Color.red;
                }
                _MainCamera.transform.Find("Bottom").GetChild(curPosIndex).GetComponent<UnityEngine.UI.Image>().color = Color.blue;

                MyArgs.RotateValue_Y = m_PlayerTransform[_CurPosIndex].rotation.eulerAngles.y - _MainCamera.transform.rotation.eulerAngles.y;

                //Debug.Log(Args.RotateValue_Y);
                MyArgs.IsAddRotate = true;
            }
        }

        /// <summary> �ı�Text���ı����� </summary>
        protected virtual void ChangeText(UnityEngine.UI.Text textUI, string text)
        {
            textUI.text = text;
        }

        /// <summary> ��ӡ��ӽǵ�ָ����塱Ԥ���� </summary>
        protected virtual void AddImagePrefabs(GameObject prefab, Transform parent)
        {
            for (int i = 0; i < m_PlayerTransform.Length; i++)
            {
                GameObject image = GameObject.Instantiate(prefab);
                image.transform.SetParent(parent, false);
                image.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = (i + 1).ToString();
            }
        }
    }
}