using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Example
{
    [RequireComponent(typeof(CharacterController))]
    public class Example_FPSMove : MonoBehaviour
    {
        /// <summary> 移动速度 </summary>
        [Tooltip("移动速度")]
        public float m_MoveSpeed = 5.0f;
        /// <summary> Player摄像机 </summary>
        public Camera m_Camera;

        private CharacterController _CharacterController;

        protected virtual void Start()
        {
            _CharacterController = this.GetComponent<CharacterController>();
        }

        protected virtual void Update()
        {
            FreeMove();
        }

        /// <summary>
        /// 自由移动
        /// </summary>
        protected virtual void FreeMove()
        {
            //前后移动
            Vector3 forward = m_Camera.transform.TransformDirection(Vector3.forward);
            float curSpeed = m_MoveSpeed * Input.GetAxis("Vertical");
            _CharacterController.SimpleMove(forward * curSpeed);

            //左右移动
            Vector3 v = m_Camera.transform.TransformDirection(Vector3.right);
            float vSpeed = m_MoveSpeed * Input.GetAxis("Horizontal");
            _CharacterController.SimpleMove(v * vSpeed);
        }

        /// <summary>
        /// 瞬移
        /// </summary>
        public virtual void Teleport(Transform newTransform)
        {
            this.transform.position = newTransform.position;
            //this.transform.rotation = Mathf.Lerp(this.transform.rotation, newTransform.rotation, 2.0f);
        }

        private void MathfLerp(float a, float b)
        {

        }
    }
}
