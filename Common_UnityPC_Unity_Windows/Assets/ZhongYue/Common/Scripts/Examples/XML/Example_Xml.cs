/*
 * 时间：
 * 作者：
 * 备注：xml读写示例
 */
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace ZhongYue.Example
{
    public class Example_Xml : MonoBehaviour
    {
        private List<Example_XmlModel> _XmlModelList = new List<Example_XmlModel>();
                
        #region Read XML
        protected virtual void ReaderXml_1()
        {
            XmlReader reader = XmlReader.Create("books.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {

                }
            }
        }

        protected virtual void ReaderXml_2()
        {
            XmlReader reader = XmlReader.Create("books.xml");

            while (!reader.EOF)
            {
                //if we hit an element type, try and load it in the listbox

                //��whileѭ���У�ʹ��moveToContent()������������ΪXMLNodeType.Element������Ϊtitle�Ľڵ�
                if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == "title")
                {

                }
                else
                {
                    reader.Read();
                }
            }
        }

        protected virtual void ReaderXmlWithXmlDocument()
        {
            XmlDocument document = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//�����ĵ��е�ע��
            XmlReader reader = XmlReader.Create(@"\books.xml", settings);
            document.Load(reader);

            //ͨ������SelectSingleNode�õ�ָ���Ľ��
            XmlNode xmlNode = document.SelectSingleNode("bookstore");
            //�õ����ڵ�������ӽڵ�
            /*
             * XmlNode.Name//����ڵ������
             * XmlNode.Value//����ڵ��ֵ
             * XmlNode.ChildNodes//����ڵ�������ӽڵ�
             * XmlNode.ParentNode//����ڵ�ĸ��ڵ�
             */
            XmlNodeList xmlNodeList = xmlNode.ChildNodes;
            foreach (XmlNode node in xmlNodeList)
            {
                Example_XmlModel _XmlModel = new Example_XmlModel();
                //���ڵ�ת��ΪԪ�أ����ڵõ��ڵ������ֵ
                XmlElement xmlElement = (XmlElement)node;
                //�õ�Type��ISBN�������Ե�����ֵ
                _XmlModel.BookISBN = xmlElement.GetAttribute("ISBN").ToString();
                _XmlModel.BookType = xmlElement.GetAttribute("Type").ToString();
                //�õ�Book�ڵ�������ӽڵ�
                XmlNodeList list = xmlElement.ChildNodes;
                _XmlModel.BookName = list.Item(0).InnerText;
                _XmlModel.BookAuthor = list.Item(1).InnerText;
                _XmlModel.BookPrice = XmlConvert.ToDouble(list.Item(2).InnerText);
                _XmlModelList.Add(_XmlModel);
            }

            //�ر�reader
            reader.Close();
        }

        #endregion


        #region Write XML

        protected XmlWriterSettings settings;
        protected XmlWriter writer;

        #region 对xml文件进行编辑
        public virtual void WriteXml(string xmlName, string elementName, string attributeName, string attributeValue)
        {
            settings = new XmlWriterSettings();
            //元素是否应缩进
            settings.Indent = true;
            //把每个属性单独放在一行
            settings.NewLineOnAttributes = true;

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

        /// <summary> 编写xml文件应用示例 </summary>
        protected virtual void WriteXmlwithBookModel()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            XmlWriter writer = XmlWriter.Create(Application.dataPath + "/newbook.xml", settings);
            writer.WriteStartDocument();

            writer.WriteStartElement("book");
            writer.WriteAttributeString("genre", "Mystery");
            writer.WriteAttributeString("publicationdate", "2001");
            writer.WriteAttributeString("ISBN", "123");
            //
            writer.WriteElementString("title", "Case of the Missing Cookie");
            //
            writer.WriteStartElement("author");
            writer.WriteElementString("name", "Cookie Monster");
            writer.WriteEndElement();
            //
            writer.WriteElementString("price", "9.99");
            //
            writer.WriteEndElement();
            //
            writer.WriteEndDocument();

            //clean up
            writer.Flush();
            writer.Close();
        }
        #endregion
    }
}