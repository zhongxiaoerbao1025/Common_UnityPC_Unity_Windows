/*
 * ʱ�䣺2020��7��24��
 * ���ߣ�����
 * ��ע��ɾ��ָ���ļ��У������ļ����µ������ļ�
 */
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ZhongYue.Example
{
    public class Example_DeleteFolder : MonoBehaviour
    {
        /// <summary> ɾ���ļ����µ������ļ� </summary>
        /// <param name="dir"> �ļ���·�� </param>
        public static void DeleteFiles(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1) { fi.Attributes = FileAttributes.Normal; }
                    //ɾ�����е��ļ�
                    File.Delete(d);
                }
                else
                {
                    DirectoryInfo d1 = new DirectoryInfo(d);

                    //�ݹ�ɾ�����ļ���
                    if (d1.GetFiles().Length != 0) { DeleteFolders(d1.FullName); }
                    Directory.Delete(d);
                }
            }
        }

        /// <summary> ɾ���ļ��� </summary>
        /// <param name="dir"> �ļ���·�� </param>
        public static void DeleteFolders(string dir) { }
    }
}