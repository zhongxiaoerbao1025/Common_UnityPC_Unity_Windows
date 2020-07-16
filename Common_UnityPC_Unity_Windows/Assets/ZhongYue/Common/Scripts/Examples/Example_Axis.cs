/*
 * 时间：2020年7月16日
 * 作者：钟樾
 * 备注：世界坐标、屏幕坐标、相机坐标的相互转换
 */
using UnityEngine;
using System.Collections;

namespace ZhongYue.Example
{
    public class Example_Axis
    {
        static Vector2 screenPos;
        static Matrix4x4 m;
        static Vector3 p;
        public static float distance = -1.0f;

        /// <summary>
        /// 世界坐标转屏幕坐标
        /// </summary>
        public static Vector2 AxisWorldToScreen(Transform target)
        {
            screenPos = Camera.main.WorldToScreenPoint(target.position);
            return screenPos;
        }

        /// <summary>
        /// 将位置从:屏幕空间-->视口空间
        /// 屏幕空间以像素为单位定义。屏幕的左下角是（0,0）; 右上角是（pixelWidth，pixelHeight）。z位置是相机的世界单位。
        /// </summary>
        void ScreenToViewportPoint() { }

        /// <summary>将位置从:屏幕空间-->世界空间</summary>
        void ScreenToWorldPoint() { }

        /// <summary>将位置从:视口空间-->屏幕空间</summary>
        void ViewportToScreenPoint() { }

        /// <summary>将位置从:视口空间-->世界空间</summary>
        void ViewportToWorldPoint() { }

        /// <summary>将位置从:世界空间-->屏幕空间</summary>
        void WorldToScreenPoint() { }

        /// <summary>将位置从:世界空间-->视口空间</summary>
        void WorldToViewportPoint() { }

        /// <summary>
        /// 从相机空间转换为世界空间的矩阵（只读）。
        /// 用它来计算世界上特定相机空间点的位置。
        /// 请注意，相机空间与OpenGL约定相匹配：相机的前向是负Z轴。这与Unity的惯例不同，其中forward是正Z轴。
        /// </summary>
        private static void OnDrawGizmosSelected()
        {
            m = Camera.main.cameraToWorldMatrix;
            p = m.MultiplyPoint(new Vector3(0, 0, distance));
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(p, 0.2f);
        }

    }
}