using System;
using System.Collections.Generic;
using System.Text;

namespace WX
{
  public  class Message
    {
      /// <summary>
        /// 消息创建时间 （整型）
      /// </summary>
        private string createTime;

      
        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
      /// <summary>
        /// 发送方帐号（一个OpenID）
      /// </summary>
        private string fromUserName;

    
        public string FromUserName
        {
            get { return fromUserName; }
            set { fromUserName = value; }
        }
        /// <summary>
        /// 消息类型
        /// </summary>
        private string msgType;

        public string MsgType
        {
            get { return msgType; }
            set { msgType = value; }
        }
        private string template;

        public string Template
        {
            get { return template; }
            set { template = value; }
        }
      /// <summary>
        /// 开发者微信号
      /// </summary>
        private string toUserName;

        public string ToUserName
        {
            get { return toUserName; }
            set { toUserName = value; }
        }

    }
}
