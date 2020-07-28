using UnityEngine;
using System.Collections;

namespace ZhongYue.Example
{
    [RequireComponent(typeof(CharacterController))]
    public class Example_FPSLook : MonoBehaviour
    {
        /// <summary> 视野转动速度-X轴 </summary>
        [Tooltip("视野转动速度-X轴")]
        public float speedX = 10f;
        /// <summary> 视野转动速度-Y轴 </summary>
        [Tooltip("视野转动速度-Y轴")]
        public float speedY = 10f;

        /// <summary> 最小观察范围-X轴 </summary>
        [Tooltip("最小观察范围-X轴")]
        public float minY = -60f;
        /// <summary> 最大观察范围-Y轴 </summary>
        [Tooltip("最大观察范围-Y轴 ")]
        public float maxY = 60f;

        /// <summary> 观察变化量-X轴  </summary>
        private float rotationX;
        /// <summary> 观察变化量-Y轴 </summary>
        private float rotationY;

        // Start is called before the first frame update
        protected virtual void Start()
        {

        }

        // Update is called once per frame
        protected virtual void LateUpdate()
        {
            if (Input.GetMouseButton(1))
            {
                Look();
            }
        }

        protected virtual void Look()
        {
            rotationX += Input.GetAxis("Mouse X") * speedX;

            if (MyArgs.IsAddRotate)
            {
                MyArgs.IsAddRotate = false;
                rotationX += MyArgs.RotateValue_Y;
                print(1111);
            }
            rotationY += Input.GetAxis("Mouse Y") * speedY;


            if (rotationX < 0)
            {
                rotationX += 360;
            }

            if (rotationX > 360)
            {
                rotationX -= 360;
            }

            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }
}