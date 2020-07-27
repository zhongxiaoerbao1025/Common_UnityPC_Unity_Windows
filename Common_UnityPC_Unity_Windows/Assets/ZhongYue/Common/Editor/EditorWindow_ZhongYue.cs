/// <summary>
/// 作者：钟樾
/// 备注：创建自定义窗口
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace zhongYue_Base
{
    public class EditorWindow_ZhongYue : EditorWindow
    {
        #region 创建窗口
        [MenuItem("钟樾的工具/钟樾的窗口")]
        private static void CreateMyWindow()
        {
            Rect theRect = new Rect(0, 0, 300, 300);
            EditorWindow_ZhongYue window = (EditorWindow_ZhongYue)EditorWindow.GetWindowWithRect(typeof(EditorWindow_ZhongYue), theRect, false, "钟樾的窗口");
            window.Show();
        }
        #endregion

        private GameObject selection;

        private void OnGUI()
        {
            EditorGUILayout.HelpBox(("当前已选择 <" + Selection.objects.Length + "> 个对象"), MessageType.Warning);

            #region 查询脚本
            _ScriptFold = EditorGUILayout.Foldout(_ScriptFold, "查询脚本");

            if (_ScriptFold ? true : false)
            {
                GUILayout.Label("被查询的脚本：");
                scriptObj = (MonoScript)EditorGUILayout.ObjectField(scriptObj, typeof(MonoScript), true);

                if (GUILayout.Button("查找脚本"))
                {
                    results.Clear();
                    loopCount = 0;

                    for (int i = 0; i < Selection.gameObjects.Length; i++)
                    {
                        roots = Selection.gameObjects[i].transform.GetComponentsInChildren<Transform>();

                        FindScript(roots[0], i);
                    }
                }
            }
            #endregion


        }

        #region 查询某个脚本
        private bool _ScriptFold = true;

        int loopCount = 0;
        Transform[] roots = null;
        MonoScript scriptObj = null;
        List<Transform> results = new List<Transform>();

        void FindScript(Transform root, int i)
        {
            if (root != null && scriptObj != null)
            {
                loopCount++;

                if (root.GetComponent(scriptObj.GetClass()) != null)
                {
                    Debug.Log("查询到所验证脚本 <" + scriptObj.name + "> ,位于对象:" + root.gameObject.name + ",对象的路径为:" + Selection.gameObjects[i].name);
                }

                foreach (Transform t in root)
                {
                    FindScript(t, i);
                }
            }
        }
        #endregion

        private void OnInspectorUpdate()
        {
            this.Repaint();
        }
    }
}
