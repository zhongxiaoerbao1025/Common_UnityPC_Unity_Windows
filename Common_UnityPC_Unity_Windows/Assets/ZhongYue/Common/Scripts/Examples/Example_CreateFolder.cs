/*
 * 时间：2020年7月14日
 * 作者：钟樾
 * 备注：“C#创建文件夹”的示例
 */
using UnityEngine;
using System.Collections;

namespace ZhongYue.Example
{
    public class Example_CreateFolder
    {
        /// <summary> 创建文件夹 </summary>
        public void CreateFolder(string targetPath)
        {
            string subPath = Application.dataPath + "/" + targetPath + "/";

            if (System.IO.Directory.Exists(subPath) == false)
            {
                System.IO.Directory.CreateDirectory(subPath);
            }
        }
    }
}