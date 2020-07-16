using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_UI_Toggle : MonoBehaviour
{
    protected UnityEngine.UI.Toggle _Toggle;

    protected virtual void Start()
    {
        _Toggle = this.GetComponent<UnityEngine.UI.Toggle>();
        _Toggle.onValueChanged.AddListener(delegate { ToggleValueChanged(_Toggle); });
    }

    /// <summary>�¼���"�л���ť��ֵ�ı�ʱ"</summary>
    protected virtual void ToggleValueChanged(UnityEngine.UI.Toggle change) { }
}
