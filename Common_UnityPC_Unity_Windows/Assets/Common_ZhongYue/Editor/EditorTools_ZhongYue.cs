/// <summary>
/// 作者：钟樾
/// 备注：钟樾的Unity Editor Tools
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace zhongYue_Base
{
    public class EditorTools_ZhongYue
    {
        #region 打印出选择物体的长度
        //在“菜单栏”进行操作
        [MenuItem("钟樾的工具/当前选择的数量", true, 11)]
        static bool ShowLengthValidata()
        {
            //如果当前没有选择object，则无法点击该工具
            if (Selection.objects.Length > 0) { return true; }
            else { return false; }
        }
        [MenuItem("钟樾的工具/当前选择的数量 %L", false, 11)]
        static void ShowLength()
        {
            //显示选择物体的数量
            Debug.Log("长度：" + Selection.objects.Length);
        }

        //在“Hierarchy栏”进行操作
        [MenuItem("GameObject/钟樾的工具/当前选择的数量", true, 11)]
        static bool GameObjectShowLengthValidata()
        {
            //如果当前没有选择object，则无法点击该工具
            if (Selection.objects.Length > 0) { return true; }
            else { return false; }
        }
        [MenuItem("GameObject/钟樾的工具/当前选择的数量", false, 11)]
        static void GameObjectShowLength()
        {
            //显示选择物体的数量
            Debug.Log("长度：" + Selection.objects.Length);
        }
        #endregion

        #region 删除操作
        [MenuItem("GameObject/钟樾的工具/我的删除", true, 11)]
        static bool MyDeleteValidata()  //验证是否可用
        {
            //如果当前没有选择object，则无法点击该工具
            if (Selection.objects.Length > 0) { return true; }
            else { return false; }
        }
        [MenuItem("GameObject/钟樾的工具/我的删除", false, 11)]
        static void MyDelete() //如果可用，就调用
        {
            foreach (Object obj in Selection.objects)
            {
                //删除操作(不可被撤销)
                //GameObject.DestroyImmediate(obj);

                //删除操作(可被撤销)
                Undo.DestroyObjectImmediate(obj);
            }
        }
        #endregion
    }
}