using System;
using System.Collections.Generic;
using System.Text;

namespace WX
{
  public  class ArticleMessage:Message
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string picUrl;

        public string PicUrl
        {
            get { return picUrl; }
            set { picUrl = value; }
        }
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private List<ArticleMessage> list=new List<ArticleMessage>();

        public List<ArticleMessage> List
        {
            get { return list; }
            set { list = value; }
        }
      /// <summary>
      /// 组装返回给微信服务器的xml格式的字符串
      /// </summary>
      /// <returns></returns>
      public string GenerateContent()
      {

          string sendData = "";
          sendData += "<xml>";
          sendData += string.Format("<ToUserName><![CDATA[{0}]]></ToUserName>", this.ToUserName);
          sendData += string.Format("<FromUserName><![CDATA[{0}]]></FromUserName>", this.FromUserName);
          sendData += string.Format("<CreateTime>{0}</CreateTime>", DateTime.Now.Ticks);
          sendData += "<MsgType><![CDATA[news]]></MsgType>";
          sendData += string.Format("<ArticleCount>{0}</ArticleCount>", list.Count.ToString());
          sendData += "<Articles>";
          for (int i = 0; i < list.Count; i++)
          {
              sendData += "<item>";
              sendData += string.Format("<Title><![CDATA[{0}]]></Title> ", list[i].Title);
              sendData += string.Format("<Description><![CDATA[{0}]]></Description>", list[i].Description);
              sendData += string.Format("<PicUrl><![CDATA[{0}]]></PicUrl>", list[i].PicUrl);
              sendData += string.Format("<Url><![CDATA[{0}]]></Url>", list[i].Url);
              sendData += "</item>";
          }
          sendData += "</Articles>";
          sendData += "</xml>";
          return sendData;
      }
    }
}
