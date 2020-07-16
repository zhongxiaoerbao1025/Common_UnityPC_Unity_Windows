/*
 * 
 * 
 * ��ע��XML�ļ��Ķ�дʾ��
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
    /// <summary>
    ///  ʹ�� XmlWriter �࣬��xmlд��һ�������ļ���StringBuilder��TextWriter����һ��XmlWriter������
    /// </summary>
    protected virtual void WriteXml()
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;//Ԫ���Ƿ�Ӧ����
        settings.NewLineOnAttributes = true;//��ÿ�����Ե�������һ��

        XmlWriter writer = XmlWriter.Create(Application.dataPath + "/newbook.xml", settings);
        writer.WriteStartDocument();//����ĵ�˵��
        Debug.Log("����XmlWriter�࣬����Xml�ĵ�");

        //��ʼ����Ԫ�غ�����
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
