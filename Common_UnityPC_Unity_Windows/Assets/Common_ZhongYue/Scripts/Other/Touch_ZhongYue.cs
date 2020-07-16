/// <summary>
/// 备注：移动端触碰，使物体进行旋转缩放
/// </summary>
using UnityEngine;
using UnityEngine.EventSystems;

namespace ZhongYue
{
    public class Touch_ZhongYue : MonoBehaviour
    {
        /// <summary>上次触摸点1(手指1) </summary>
        private UnityEngine.Touch oldTouch1;
        /// <summary>上次触摸点2(手指2) </summary>
        private UnityEngine.Touch oldTouch2;


        /// <summary>最大倍数</summary>
        public float maxMultiple = 1.5f;
        /// <summary>最小倍数</summary>
        public float minMultiple = 0.7f;
        /// <summary> 旋转速率 </summary>
        public float m_RotationSpeed = 0.5f;

        /// <summary>用于显示滑动距离</summary>
        private float oldDis = 0;
        private float newDis = 0;
        private float scaler = 0;

        private GameObject canvas;

        private void Start()
        {
            //canvas = GameObject.FindObjectOfType<PrefabsController>().transform.Find("Canvas").gameObject;
        }

        void Update()
        {
            //没有触摸
            if (Input.touchCount <= 0)
            {
                if (canvas != null && !canvas.activeSelf) { canvas.SetActive(true); }
                return;
            }

            //屏幕被触碰
            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 /*&& Input.GetTouch(0).phase == TouchPhase.Began*/))
            {
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                { }
                else
                {
                    if (canvas != null) { canvas.SetActive(false); }
                    //单点触摸， 水平上下旋转
                    if (1 == Input.touchCount)
                    {
                        SingleTouch();
                    }

                    //多点触摸, 放大缩小
                    if (Input.touchCount > 1)
                    {
                        MultiTouch();
                    }
                }


            }
        }

        /// <summary>单点触碰</summary>
        public void SingleTouch()
        {
            UnityEngine.Touch touch = Input.GetTouch(0);
            Vector2 deltaPos = touch.deltaPosition;
            //X轴旋转
            transform.Rotate(Vector3.down * deltaPos.x * m_RotationSpeed, Space.World);
            //Y轴旋转
            //transform.Rotate(Vector3.right * deltaPos.y * m_RotationSpeed, Space.World);
        }

        /// <summary>多点触碰</summary>
        public void MultiTouch()
        {
            UnityEngine.Touch newTouch1 = Input.GetTouch(0);
            UnityEngine.Touch newTouch2 = Input.GetTouch(1);

            //第2点刚开始接触屏幕, 只记录，不做处理
            if (newTouch2.phase == TouchPhase.Began)
            {
                oldTouch2 = newTouch2;
                oldTouch1 = newTouch1;
                return;
            }

            //计算老的两点距离和新的两点间距离，变大要放大模型，变小要缩放模型
            float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
            float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);
            oldDis = oldDistance;
            newDis = newDistance;

            //两个距离之差，为正表示放大手势， 为负表示缩小手势
            float offset = newDistance - oldDistance;

            //放大因子， 一个像素按 0.01倍来算(100可调整)
            float scaleFactor = offset / 100f;
            Vector3 localScale = transform.localScale;
            Vector3 scale = new Vector3(localScale.x + scaleFactor,
                                        localScale.y + scaleFactor,
                                        localScale.z + scaleFactor);
            scaler = scaleFactor;

            //允许模型最小缩放到 minMultiple倍,最大放大maxMultiple
            if (scale.x > minMultiple && scale.y > minMultiple && scale.z > minMultiple)
            {
                //实用差值运算，模型平滑缩放
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(Mathf.Clamp(localScale.x + scaleFactor, minMultiple, maxMultiple),
                                                   Mathf.Clamp(localScale.y + scaleFactor, minMultiple, maxMultiple),
                                                   Mathf.Clamp(localScale.z + scaleFactor, minMultiple, maxMultiple)), 1f);
            }
            //记住最新的触摸点，下次使用
            oldTouch1 = newTouch1;
            oldTouch2 = newTouch2;
        }
    }
}