using System;
using System.Collections.Generic;
using System.Text;

namespace WX
{
   public class LinkMessage:Message
    {
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string msgId;

        public string MsgId
        {
            get { return msgId; }
            set { msgId = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
       public string GenerateContent()
       {
           string sendData = "";
           sendData += "<xml>";
           sendData += string.Format("<ToUserName><![CDATA[{0}]]></ToUserName>", this.ToUserName);
           sendData += string.Format("<FromUserName><![CDATA[{0}]]></FromUserName>", this.FromUserName);
           sendData += string.Format("<CreateTime>{0}</CreateTime>", DateTime.Now.Ticks);
           sendData += "<MsgType><![CDATA[text]]></MsgType>";
           sendData += string.Format("<Content><![CDATA[{0}]]></Content>", "");
           sendData += "</xml>";
           return sendData;
       }
    }
}
