using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
namespace WX
{
   public class EventMessage:Message
    {
       /// <summary>
        /// 事件类型，subscribe(订阅)、unsubscribe(取消订阅)
       /// </summary>
        private string event_;

        public string Event_
        {
            get { return event_; }
            set { event_ = value; }
        }
       /// <summary>
        /// 事件KEY值
       /// </summary>
        private string eventKey;

        public string EventKey
        {
            get { return eventKey; }
            set { eventKey = value; }
        }
       /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
       /// </summary>
        private string ticket;

        public string Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }
        /// <summary>
        /// 解析xml格式的字符串
        /// </summary>
        /// <param name="requestXml"></param>
        /// <returns></returns>
        public static EventMessage LoadFromXml(string requestXml)
        {
            EventMessage tm = new EventMessage();
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
                if (xn.Name.Equals("Event"))
                {
                    tm.Event_ = xn.InnerText;
                  
                }
                if (xn.Name.Equals("EventKey"))
                {
                    tm.EventKey = xn.InnerText;

                }
               
            }
            return tm;
        }
        ///// <summary>
        ///// 组装返回给微信服务器的xml格式的字符串
        ///// </summary>
        ///// <returns></returns>
        //public string GenerateContent()
        //{
        //    string sendData = "";
        //    sendData += "<xml>";
        //    sendData += string.Format("<ToUserName><![CDATA[{0}]]></ToUserName>", this.ToUserName);
        //    sendData += string.Format("<FromUserName><![CDATA[{0}]]></FromUserName>", this.FromUserName);
        //    sendData += string.Format("<CreateTime>{0}</CreateTime>", DateTime.Now.Ticks);
        //    sendData += "<MsgType><![CDATA[text]]></MsgType>";
        //    sendData += string.Format("<Content><![CDATA[{0}]]></Content>", this.Content);
        //    sendData += "</xml>";
        //    return sendData;
        //}
    }
}
