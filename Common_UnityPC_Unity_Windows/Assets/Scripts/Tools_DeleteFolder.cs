using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ZhongYue.Tools
{
    /// <summary>
    /// 删除指定文件夹，或者文件夹下的所有文件
    /// </summary>
    public class Tools_DeleteFolder
    {

        /// <summary> 删除文件夹下的所有文件 </summary>
        /// <param name="dir"> 文件夹路径 </param>
        public static void DeleteFiles(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1) { fi.Attributes = FileAttributes.Normal; }
                    //删除其中的文件
                    File.Delete(d);
                }
                else
                {
                    DirectoryInfo d1 = new DirectoryInfo(d);

                    //递归删除子文件夹
                    if (d1.GetFiles().Length != 0) { DeleteFolders(d1.FullName); }
                    Directory.Delete(d);
                }
            }
        }

        /// <summary> 删除文件夹 </summary>
        /// <param name="dir"> 文件夹路径 </param>
        public static void DeleteFolders(string dir) { }
    }
}