/*
 * 时间：
 * 作者：
 * 备注：辅助Example_XML
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZhongYue.Example
{
    public class Example_XmlModel
    {
        public Example_XmlModel() { }

        private string bookType;
        public string BookType
        {
            get { return bookType; }
            set { bookType = value; }
        }

        private string bookISBN;
        public string BookISBN
        {
            get { return bookISBN; }
            set { bookISBN = value; }
        }

        private string bookName;
        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }

        private string bookAuthor;
        public string BookAuthor
        {
            get { return bookAuthor; }
            set { bookAuthor = value; }
        }

        private double bookPrice;
        public double BookPrice
        {
            get { return bookPrice; }
            set { bookPrice = value; }
        }
    }
}