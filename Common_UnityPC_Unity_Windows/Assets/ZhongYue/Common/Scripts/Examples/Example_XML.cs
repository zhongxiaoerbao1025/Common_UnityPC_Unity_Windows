/*
 * 时间：2020年7月14日
 * 作者：钟樾
 * 备注：“使用C#对XML文件进行读写”的示例
 */
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace ZhongYue.Example
{
    public class Example_XML
    {
        protected XmlWriterSettings settings;
        protected XmlWriter writer;

        #region 对xml文件进行编辑
        public virtual void WriteXml(string xmlName,string elementName, string attributeName,string attributeValue)
        {
            settings = new XmlWriterSettings();
            settings.Indent = true;//元素是否应缩进
            settings.NewLineOnAttributes = true;//把每个属性单独放在一行

            using (writer)
            {
                writer = XmlWriter.Create(xmlName, settings);
                //开始-添加文档说明
                writer.WriteStartDocument();
                #region 创建元素和属性(可嵌套)
                //元素
                writer.WriteStartElement(elementName);
                //属性
                writer.WriteElementString(attributeName, attributeValue);
               //结束创建
                writer.WriteEndElement();
                #endregion
                //结束-添加文档说明
                writer.WriteEndDocument();

                //clean up
                writer.Flush();
                writer.Close();
            }
        }
            #endregion

            #region 读取xml文件中的数据

            #endregion
        }
}
