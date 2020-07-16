/// <summary>
/// 备注：在创建脚本时，获取当前时间，并记录在创建的脚本中
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;

public class ScriptCreatInit : UnityEditor.AssetModificationProcessor
{
    private static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        if (path.EndsWith(".cs"))
        {
            string strContent = File.ReadAllText(path);
            strContent = strContent.Replace("#CreateTime#", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            File.WriteAllText(path, strContent);
            AssetDatabase.Refresh();
        }
    }
}
