using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Manager
{
    public class Manager_UI_Dropdown : MonoBehaviour
    {
        private UnityEngine.UI.Dropdown _Dropdown;

        protected virtual void Start()
        {
            _Dropdown = GetComponent<UnityEngine.UI.Dropdown>();
            _Dropdown.onValueChanged.AddListener(DropdownValueChanged);
        }

        protected virtual void DropdownValueChanged(int arg0) { }
    }
}
