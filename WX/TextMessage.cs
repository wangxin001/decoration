using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace WX
{
  public  class TextMessage:Message
    {
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private string msgId;

        public string MsgId
        {
            get { return msgId; }
            set { msgId = value; }
        }
      /// <summary>
      /// 解析xml格式的字符串
      /// </summary>
      /// <param name="requestXml"></param>
      /// <returns></returns>
        public static TextMessage LoadFromXml(string requestXml)
        {
            TextMessage tm = new TextMessage();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(requestXml);
            XmlNode bodyNode = xmlDoc.ChildNodes[0];

            foreach (XmlNode xn in bodyNode.ChildNodes)
            {
                if (xn.Name.Equals("ToUserName"))
                {
                    tm.ToUserName = xn.InnerText;
                }
                if (xn.Name.Equals("FromUserName"))
                {
                    tm.FromUserName = xn.InnerText;
                }
                if (xn.Name.Equals("CreateTime"))
                {
                    tm.CreateTime = xn.InnerText;
                }
                if (xn.Name.Equals("MsgType"))
                {
                    tm.MsgType = xn.InnerText;
                }
                if (xn.Name.Equals("Content"))
                {
                    tm.Content = xn.InnerText;
                }
                if (xn.Name.Equals("MsgId"))
                {
                    tm.MsgId = xn.InnerText;
                }
            }
            return tm;
        }
      /// <summary>
      /// 组装返回给微信服务器的xml格式的字符串
      /// </summary>
      /// <returns></returns>
        public  string GenerateContent()
        {
            string sendData = "";
            sendData += "<xml>";
            sendData += string.Format("<ToUserName><![CDATA[{0}]]></ToUserName>", this.ToUserName);
            sendData += string.Format("<FromUserName><![CDATA[{0}]]></FromUserName>", this.FromUserName);
            sendData += string.Format("<CreateTime>{0}</CreateTime>", DateTime.Now.Ticks);
            sendData += "<MsgType><![CDATA[text]]></MsgType>";
            sendData += string.Format("<Content><![CDATA[{0}]]></Content>", this.Content);
            sendData += "</xml>";
            return sendData;
        }
    }
}
