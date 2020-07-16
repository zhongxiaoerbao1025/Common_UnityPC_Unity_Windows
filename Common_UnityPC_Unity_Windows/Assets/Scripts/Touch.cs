/// <summary>
/// 备注：移动端触碰，使物体进行旋转缩放
/// </summary>
using UnityEngine;
using UnityEngine.EventSystems;

public class Touch : MonoBehaviour
{
    /*
    public Transform target;//用于绑定参照物对象
    public float distance = 10.0f;//缩放系数

    //左右滑动移动速度
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;

    //缩放限制系数
    public float yMinLimit = -20;
    public float yMaxLimit = 80;

    //摄像头的位置
    public float x = 0;
    public float y = 0;

    //记录上一次手机触摸位置判断用户是在左放大还是缩小手势
    private Vector2 oldPosition1;
    private Vector2 oldPosition2;

    private Rigidbody rigi;

    //初始化游戏信息设置
    void Start()
    {
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Make the rigid body not change rotation
        if (rigi)
        {
            rigi.freezeRotation = true;
        }
    }

    void Update()
    {
        //判断触摸数量为单点触摸
        if (Input.touchCount == 1)
        {
            //触摸类型为移动触摸
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //根据触摸点计算X与Y位置
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            }
        }

        //判断触摸数量为多点触摸
        if (Input.touchCount > 1)
        {
            //前两只手指触摸类型都为移动触摸
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                //计算出当前两点触摸点的位置
                var tempPosition1 = Input.GetTouch(0).position;
                var tempPosition2 = Input.GetTouch(1).position;
                //函数返回真为放大，返回假为缩小
                if (isEnlarge(oldPosition1, oldPosition2, tempPosition1, tempPosition2))
                {
                    //放大系数超过3以后不允许继续放大
                    //这里的数据是根据我项目中的模型而调节的，大家可以自己任意修改
                    if (distance > 3)
                    {
                        distance -= 0.5f;
                    }
                }
                else
                {
                    //缩小洗漱返回18.5后不允许继续缩小
                    //这里的数据是根据我项目中的模型而调节的，大家可以自己任意修改
                    if (distance < 18.5)
                    {
                        distance += 0.5f;
                    }
                }
                //备份上一次触摸点的位置，用于对比
                oldPosition1 = tempPosition1;
                oldPosition2 = tempPosition2;
            }
        }
    }

    //函数返回真为放大，返回假为缩小
    bool isEnlarge(Vector2 oP1, Vector2 oP2, Vector2 nP1, Vector2 nP2)
    {
        //函数传入上一次触摸两点的位置与本次触摸两点的位置计算出用户的手势
        var leng1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
        var leng2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));
        if (leng1 < leng2)
        {
            //放大手势
            return true;
        }
        else
        {
            //缩小手势
            return false;
        }
    }

    //Update方法一旦调用结束以后进入这里算出重置摄像机的位置
    void LateUpdate()
    {

        //target为我们绑定的箱子变量，缩放旋转的参照物
        if (target)
        {

            //重置摄像机的位置
            y = ClampAngle(y, yMinLimit, yMaxLimit);
            var rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }*/

    /// <summary>上次触摸点1(手指1) </summary>
    private UnityEngine.Touch oldTouch1;
    /// <summary>上次触摸点2(手指2) </summary>
    private UnityEngine.Touch oldTouch2;


    /// <summary>最大倍数</summary>
    private float maxMultiple = 3.0f;
    /// <summary>最小倍数</summary>
    private float minMultiple = 0.7f;

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
            if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
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
        transform.Rotate(Vector3.down * deltaPos.x, Space.World);
        transform.Rotate(Vector3.right * deltaPos.y, Space.World);
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
