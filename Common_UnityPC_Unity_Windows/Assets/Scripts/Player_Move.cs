using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 玩家移动控制 </summary>
public class Player_Move : Component
{
    public Transform[] m_PlayerTransform;

    public UnityEngine.UI.Button m_LeftButton;
    public UnityEngine.UI.Button m_RightButton;
    public UnityEngine.UI.Text m_IndexText;

    /// <summary> Image预制体，表示当前位置的标签 </summary>
    public GameObject m_ImagePrefab;

    private GameObject _MainCamera;

    /// <summary> 当前处于场景中的视角位置 </summary>
    private int _CurPosIndex = 0;
    /// <summary> 处于场景中的视角位置 </summary>
    private int _OldPosIndex = 0;
    /// <summary> 是否开启：平滑旋转 </summary>
    private bool _CanRotateLerp = false;

    //当前速度
    private Vector3 curVelocity = Vector3.zero;
    //平滑的时间
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
        //按钮监听
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
            //平滑旋转
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

    /// <summary> 角色瞬移事件 </summary>
    protected virtual void TeleportEvents(int oldPosIndex, int curPosIndex, Transform target)
    {
        if (curPosIndex != oldPosIndex)
        {
            _OldPosIndex = curPosIndex;
            //当前所在视角的指数
            m_IndexText.text = (curPosIndex + 1).ToString();
            //改变Player的位置
            _MainCamera.transform.position = target.position;

            //通过不同的颜色表示，当前所在的视角的指数
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

    /// <summary> 角色平滑位移事件 </summary>
    protected virtual void MoveLerpEvents(int oldPosIndex, int curPosIndex/*,Transform target*/)
    {
        if (curPosIndex != oldPosIndex)
        {
            _OldPosIndex = curPosIndex;
            //当前所在视角的指数
            m_IndexText.text = (curPosIndex + 1).ToString();
            //通过不同的颜色表示，当前所在的视角的指数
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

    /// <summary> 改变Text的文本内容 </summary>
    protected virtual void ChangeText(UnityEngine.UI.Text textUI, string text)
    {
        textUI.text = text;
    }

    /// <summary> 添加“视角的指数面板”预制体 </summary>
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