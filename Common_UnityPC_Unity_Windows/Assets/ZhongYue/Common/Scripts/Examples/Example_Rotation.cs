/*
 * 时间：2020年7月16日
 * 作者：钟樾
 * 备注：自转
 */
using UnityEngine;
using System.Collections;

namespace ZhongYue.Example
{
    public class Example_Rotation : MonoBehaviour
    {
        public float m_RotationSpeed = 0f;

        void Update()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * m_RotationSpeed);
        }
    }
}
