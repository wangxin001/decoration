using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace WX
{
    public class MsgType
    {
        public static string LoadFromXml(string requestXml)
        {
          
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(requestXml);
            XmlNode bodyNode = xmlDoc.ChildNodes[0];
            string type = string.Empty;
            foreach (XmlNode xn in bodyNode.ChildNodes)
            {
               
                if (xn.Name.Equals("MsgType"))
                {
                    type= xn.InnerText;
                  
                }
               
            }
            return type;
        }
        public enum MsgTypeEnum
        {

            Text, Image, Location, Link, Event, Music, News

        }
    }
}
