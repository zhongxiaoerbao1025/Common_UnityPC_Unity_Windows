/*
 * 
 * 
 * 备注：XML文件的读写示例
 */
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Example_Xml : MonoBehaviour
{
    private List<Example_XmlModel> _XmlModelList = new List<Example_XmlModel>();

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            WriteXml();
        }
    }

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

            //在while循环中，使用moveToContent()方法查找类型为XMLNodeType.Element、名称为title的节点
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
        settings.IgnoreComments = true;//忽略文档中的注释
        XmlReader reader = XmlReader.Create(@"\books.xml", settings);
        document.Load(reader);

        //通过调用SelectSingleNode得到指定的结点
        XmlNode xmlNode = document.SelectSingleNode("bookstore");
        //得到根节点的所有子节点
        /*
         * XmlNode.Name//这个节点的名称
         * XmlNode.Value//这个节点的值
         * XmlNode.ChildNodes//这个节点的所有子节点
         * XmlNode.ParentNode//这个节点的父节点
         */
        XmlNodeList xmlNodeList = xmlNode.ChildNodes;
        foreach (XmlNode node in xmlNodeList)
        {
            Example_XmlModel _XmlModel = new Example_XmlModel();
            //将节点转换为元素，便于得到节点的属性值
            XmlElement xmlElement = (XmlElement)node;
            //得到Type和ISBN两个属性的属性值
            _XmlModel.BookISBN = xmlElement.GetAttribute("ISBN").ToString();
            _XmlModel.BookType = xmlElement.GetAttribute("Type").ToString();
            //得到Book节点的所有子节点
            XmlNodeList list = xmlElement.ChildNodes;
            _XmlModel.BookName = list.Item(0).InnerText;
            _XmlModel.BookAuthor = list.Item(1).InnerText;
            _XmlModel.BookPrice = XmlConvert.ToDouble(list.Item(2).InnerText);
            _XmlModelList.Add(_XmlModel);
        }

        //关闭reader
        reader.Close();
    }

    #endregion


    #region Write XML
    /// <summary>
    ///  使用 XmlWriter 类，把xml写入一个流、文件、StringBuilder、TextWriter或另一个XmlWriter对象中
    /// </summary>
    protected virtual void WriteXml()
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;//元素是否应缩进
        settings.NewLineOnAttributes = true;//把每个属性单独放在一行

        XmlWriter writer = XmlWriter.Create(Application.dataPath + "/newbook.xml", settings);
        writer.WriteStartDocument();//添加文档说明
        Debug.Log("利用XmlWriter类，创建Xml文档");

        //开始创建元素和属性
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
