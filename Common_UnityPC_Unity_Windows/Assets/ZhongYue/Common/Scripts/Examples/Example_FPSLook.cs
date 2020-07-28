using UnityEngine;
using System.Collections;

namespace ZhongYue.Example
{
    [RequireComponent(typeof(CharacterController))]
    public class Example_FPSLook : MonoBehaviour
    {
        /// <summary> ��Ұת���ٶ�-X�� </summary>
        [Tooltip("��Ұת���ٶ�-X��")]
        public float speedX = 10f;
        /// <summary> ��Ұת���ٶ�-Y�� </summary>
        [Tooltip("��Ұת���ٶ�-Y��")]
        public float speedY = 10f;

        /// <summary> ��С�۲췶Χ-X�� </summary>
        [Tooltip("��С�۲췶Χ-X��")]
        public float minY = -60f;
        /// <summary> ���۲췶Χ-Y�� </summary>
        [Tooltip("���۲췶Χ-Y�� ")]
        public float maxY = 60f;

        /// <summary> �۲�仯��-X��  </summary>
        private float rotationX;
        /// <summary> �۲�仯��-Y�� </summary>
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