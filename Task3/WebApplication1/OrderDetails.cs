using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Task3
{
    [XmlRoot]
    public class OrderDetails
    {
        public OrderDetails()
        {
            Orders = new List<string>();
        }

        public OrderDetails(List<string> list)
        {
            Orders = list;
        }

        [XmlAttribute("OrderCount")]
        public string Count
        {
            get
            {
                return Orders.Count.ToString();
            }

            set { }// заглушка для сериализации
        }

        [XmlArray("Order")]
        [XmlArrayItem("Position")]
        public List<string> Orders {get; private set;}
    }
}