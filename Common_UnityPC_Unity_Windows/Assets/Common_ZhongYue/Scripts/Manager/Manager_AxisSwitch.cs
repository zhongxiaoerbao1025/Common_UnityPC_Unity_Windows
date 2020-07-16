using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ת��
/// �������ꡢ��Ļ���ꡢ��������ת��
/// </summary>
public class Manager_AxisSwitch : MonoBehaviour
{
    #region Screen(��Ļ�ռ�)��λ��ת��

    /// <summary>
    /// ��λ�ô���Ļ�ռ�ת��Ϊ�ӿڿռ�
    /// </summary>
    public void ScreenToViewportPoint() { }

    /// <summary>
    /// ����Ļ�ռ��λ��ת��Ϊ����ռ�
    /// ��Ļ�ռ�������Ϊ��λ���塣
    /// ��Ļ�����½��ǣ�0,0��; ���Ͻ��ǣ�pixelWidth��pixelHeight��; zλ������������絥λ��
    /// </summary>
    public void ScreenToWorldPoint() { }

    #endregion

    #region Viewport(�ӿڿռ�)��λ��ת��

    /// <summary>
    /// ���ӿڿռ��е�λ��ת��Ϊ��Ļ�ռ�
    /// </summary>
    public void ViewportToScreenPoint() { }

    /// <summary>
    /// ���ӿڿռ��е�λ��ת��Ϊ����ռ�
    /// </summary>
    public void ViewportToWorldPoint() { }

    #endregion

    #region World(����ռ�)��λ��ת��

    /// <summary>
    /// ������ռ��λ��ת��Ϊ��Ļ�ռ�
    /// </summary>
    public Vector3 WorldToScreenPoint(Transform target, Camera camera)
    {
        if (target != null && camera != null)
        {
            Vector3 screenPos = camera.WorldToScreenPoint(target.position);
            return screenPos;
        }
        else
        {
            Debug.LogError("λ��ת������!");
            return Vector3.zero;
        }
    }

    /// <summary>
    /// ������ռ��λ��ת��Ϊ�ӿڿռ�
    /// </summary>
    public Vector3 WorldToViewportPoint(Transform target, Camera camera)
    {
        if (target != null && camera != null)
        {
            Vector3 viewPos = camera.WorldToViewportPoint(target.position);
            return viewPos;
        }
        else
        {
            Debug.LogError("λ��ת������!");
            return Vector3.zero;
        }
    }

    #endregion
}
