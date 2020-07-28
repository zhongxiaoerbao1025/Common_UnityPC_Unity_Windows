/// <summary>
///	作者：钟樾
///	时间：#CreatTime#
///	备注：Unity各平台持久化路径
///	</summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Notes
{
    public class Notes_Persistence : MonoBehaviour
    {
        /// <summary>
        /// 各平台的识别与操作
        /// </summary>
        protected virtual void Platform()
        {
#if UNITY_EDITOR
            Debug.Log("#define指令，用于从游戏代码中调用Unity Editor脚本");

#elif UNITY_EDITOR_WIN
    Debug.Log("Windows上编辑器代码的#define指令");

#elif UNITY_EDITOR_OSX
    Debug.Log("Mac OS X上编辑器代码的#define指令");

#elif UNITY_STANDALONE_OSX
    Debug.Log("#define指令，用于编译/执行专门用于Mac OS X的代码（包括Universal，PPC和Intel架构）");

#elif UNITY_STANDALONE_WIN
    Debug.Log("#define指令，用于专门为Windows独立应用程序编译/执行代码");

#elif UNITY_STANDALONE_LINUX
    Debug.Log("#define指令，用于专门为Linux独立应用程序编译/执行代码");

#elif UNITY_STANDALONE
    Debug.Log("#define指令，用于编译/执行任何独立平台（Mac OS X，Windows或Linux）的代码");

#elif UNITY_WII
    Debug.Log("#define指令，用于编译/执行Wii控制台的代码");

#elif UNITY_IOS
    Debug.Log("#define指令，用于编译/执行iOS平台的代码");

#elif UNITY_ANDROID
    Debug.Log("适用于Android平台的#define指令");

#elif UNITY_PS4
    Debug.Log("用于运行PlayStation 4代码的#define指令");

#elif UNITY_XBOXONE
    Debug.Log("用于执行Xbox One代码的#define指令");

#elif UNITY_TIZEN
    Debug.Log("Tizen平台的#define指令");

#elif UNITY_TVOS
    Debug.Log("Apple TV平台的#define指令");

#elif UNITY_WSA
    Debug.Log("通用Windows平台的#define指令。此外，NETFX_CORE是在针对.NET Core编译C＃文件和使用.NET脚本后端时定义的");

#elif UNITY_WSA_10_0
    Debug.Log("通用Windows平台的#define指令。另外，在针对.NET Core编译C＃文件时定义了WINDOWS_UWP");

#elif UNITY_WINRT
    Debug.Log("与UNITY_WSA相同");

#elif UNITY_WINRT_10_0
    Debug.Log("相当于UNITY_WSA_10_0");

#elif UNITY_WEBGL
    Debug.Log("WebGL的#define指令");

#elif UNITY_FACEBOOK
    Debug.Log("Facebook平台的#define指令（WebGL或Windows独立版）");

#elif UNITY_ADS
    Debug.Log("#define指令，用于从您的游戏代码中调用Unity Ads方法。5.2及更高版本");

#elif UNITY_ANALYTICS
    Debug.Log("#define指令，用于从游戏代码中调用Unity Analytics方法。5.2及更高版本");

#elif UNITY_ASSERTIONS
    Debug.Log("断言控制进程的#define指令");

#else
    Debug.Log("Any other platform");
             
#endif
        }



        /*Unity路径操作
         * 1.在项目根目录中创建Resources文件夹来保存文件
         *  可以使用Resources,Load("文件名字（注：不包括文件后缀名）")；把文件夹中的对象加载出来
         *  注：此方法可实现对文件实施“增删查找”等操作，但打包后不可以更改了
         *
         * 2.直接放在项目根路径下来保存文件
         *  在直接使用Applica.dataPath来读取文件进行操作
         *  注：移动端是没有访问权限的
         *  
         * 3.在项目根目录中创建StreamingAssets文件夹来保存文件
         *  可使用Applica.dataPath来读取文件进行操作，无法写入
         *  直接使用Application.streamingAssetsPath来读取文件进行操作
         *  注：此方法在PC/Mac电脑中可实现对文件实施“增删查找”等操作，但在移动端只支持读取操作
         * 
         * 4.使用Application.persistentDataPath来操作文件
         *  该文件存在手机沙盒中，因为不能直接存放文件，
         *      a.通过服务器直接下载保存到该位置，也可以通过Md5码对比下载更新新的资源
         *      b.没有服务器的，只有间接通过文件流的方式从本地读取并写入Application.persistentDataPath文件下，然后通过Application..persistentDataPath来读取操作
         *      注：在PC/Mac电脑以及Ipad、Iphone都可对文件进行任意操作，另外在IOS上该目录下的东西可以被ICloud自动备份
         * 
         * 5.使用Application.temporaryCachePath来操作文件
         *  操作方式和Application.persistentDataPath类似。除了在IOS上不能被ICloud自动备份
         * 
         * 6./sdcard/..路径
         *  表示Android手机的SD卡根目录
         *  
         *  7./storage/emulated/0/...路径
         *  表示Android手机的内置存储根目录
         * 
         */
    }
}