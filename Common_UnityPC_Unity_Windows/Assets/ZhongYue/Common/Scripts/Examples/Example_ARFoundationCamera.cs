/*
 * 时间：2020年7月16日
 * 作者：钟樾
 * 备注：“ARFoundation的相机控制”示例
 */

using UnityEngine;
using System.Collections;
//using UnityEngine.XR.ARFoundation;
//using UnityEngine.XR.ARSubsystems;

namespace ZhongYue.Example
{
    public class Example_ARFoundationCamera
    {
        private Camera m_ARCamera;
        // private ARCameraManager _ARCameraManager;

        /// <summary> 改变摄像机的朝向 </summary>
        public void FacingDirection()
        {
            /*
            if (_ARCameraManager.currentFacingDirection == CameraFacingDirection.User)
            {
                _ARCameraManager.requestedFacingDirection = CameraFacingDirection.World;
            }
            else if (_ARCameraManager.currentFacingDirection == CameraFacingDirection.World)
           {
                _ARCameraManager.requestedFacingDirection = CameraFacingDirection.User;
            }
            */
        }
    }
}