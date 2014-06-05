using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using Model;
namespace WX
{
    public class EventHandler : IHandler
    {
        /// <summary>
        /// 请求的xml
        /// </summary>
        private string RequestXml { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="requestXml"></param>
        public EventHandler(string requestXml)
        {
            this.RequestXml = requestXml;
        }
        public string HandleRequest()
        {

            string response = string.Empty;
            EventMessage em = EventMessage.LoadFromXml(RequestXml);
            //用户订阅
            if (em.Event_.Equals("subscribe", StringComparison.OrdinalIgnoreCase))
            {

                response = SubscribeEventHandler(em);
            }
            //用户取消订阅
            if (em.Event_.Equals("unsubscribe", StringComparison.OrdinalIgnoreCase))
            {
            }
            //用户点击事件
            if (em.Event_.Equals("click", StringComparison.OrdinalIgnoreCase))
            {
                response = ClickEventHandler(em);
            }

            return response;
        }
        /// <summary>
        /// 关注
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        private string SubscribeEventHandler(EventMessage em)
        {
            //回复欢迎消息
            TextMessage tm = new TextMessage();
            tm.ToUserName = em.FromUserName;
            tm.FromUserName = em.ToUserName;
            tm.CreateTime = Common.getNowTimeString();
            StringBuilder str = new StringBuilder();
            str.Append("欢迎您关注邯郸业之峰微信服务,在本平台上提供了设计风格、我的家装、订单与投诉、报修等服务。！\n");
            str.Append("您也可以直接在本平台上直接进行咨询\n");
            str.Append("1、设计咨询\n");
            str.Append("2、订单咨询\n");
            str.Append("3、我的家装\n");
            str.Append("4、业主注册\n");
            str.Append("5、投诉\n");
            str.Append("6、报修\n");
            tm.Content =str.ToString() ;
            return tm.GenerateContent();
        }
        /// <summary>
        /// 处理点击事件
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        public string ClickEventHandler(EventMessage em)
        {
            string result = string.Empty;
            if (em != null && em.EventKey != null)
            {
                TextMessage tm = new TextMessage();
                tm.ToUserName = em.FromUserName;
                tm.FromUserName = em.ToUserName;
                tm.CreateTime = Common.getNowTimeString();
                switch (em.EventKey.ToLower())
                {
                    case "register":
                        result = register(em,tm);
                        break;
                    case "commentmydecoration":
                        result = commentMyDecoration(em, tm);
                        break;
                    case "mydecoration":
                        result = mydecoration(em, tm);
                        break;
                    case "currentprocess":
                        result = currentprocess(em, tm);
                        break;
                    case "repair":
                        result = repair(em, tm);
                        break;
                    case "complain":
                        result = complain(em, tm);
                        break;
                    case "activity":
                        ArticleMessage am = new ArticleMessage();
                        am.ToUserName = em.FromUserName;
                        am.FromUserName = em.ToUserName;
                        am.CreateTime = Common.getNowTimeString();
                        result = activity(em, am);
                        break;
                    

                }
            }

            return result;
        }
        private string activity(EventMessage em, ArticleMessage am)
        {
           
            am.Title = "第七届中国环保家装艺术节盛大启动";
            am.Description = "以 “环保家居，健康未来”为主题的 “第七届中国环保家装艺术节——暨‘欧盟项目’标准环保样板间限量征集月”将于2014年4月1日至4月30日在全国27个大中城市同时启动。本届环保家 装艺术节由中国建筑装饰协会住宅装饰装修委员会主办，《中国消费者报》担任首席监督媒体，中国环境科学学会、北京业之峰诺华装饰股份有限公司联合成立的室内装饰环保技术联合研究中心担任技术顾问，并得到了北京等地主流媒体及知名网站的大力支持。";
            am.PicUrl = "http://test.shuzhengtech.com/activityimg/activity.gif";
            am.Url = "http://test.shuzhengtech.com/publicweb/activity.aspx";
            List<ArticleMessage> list = new List<ArticleMessage>();
            list.Add(am);
            am.List.Add(am);
            return am.GenerateContent();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        private string register(EventMessage em,TextMessage tm)
        {
           
            StringBuilder str = new StringBuilder();
            UserDao ud=new UserDao();
            //回复注册消息
            if (ud.selectUser(em.FromUserName.ToLower()) == null) {            
            str.Append("欢迎您注册邯郸业之峰微信服务,在本平台上提供了设计风格、我的家装、订单与投诉、报修等服务。！\n");
            str.Append("在注册前请您阅读注册协议<a href=\"#\">注册协议</a>\n");
            str.Append("发送手机号完成注册!\n");
            str.Append("回复N,退出注册操作!\n");            
           
            CacheClient.Client().Insert(em.FromUserName.ToLower(),Process.waitInputTel, null, DateTime.Now.AddMinutes(30), System.Web.Caching.Cache.NoSlidingExpiration);
            }
            else
            {
                str.Append("您已经注册过了!");              
               
            }
            tm.Content = str.ToString();
            return tm.GenerateContent();
        }
        /// <summary>
        /// 评论我的家装
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        private string commentMyDecoration(EventMessage em,TextMessage tm)
        {
            return "";
        }
        /// <summary>
        /// 当前装修进度
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        private string mydecoration(EventMessage em,TextMessage tm)
        {
          
            StringBuilder str = new StringBuilder();
            UserDao ud = new UserDao();
            MyDecorationDao myDecorationDao = new MyDecorationDao();
            User user = ud.selectUser(em.FromUserName);
            if (user != null) { 
            MyDecoration myDecoration = myDecorationDao.selectMyDecorationByUserId(user.Id);
            if (myDecoration != null)
            {
                str.Append("您当前装修进度为:" + myDecoration.Process + "\n");
                str.Append("开始时间:" + (DateTime.Parse(myDecoration.CreateTime)).ToString("yyyy-MM-dd") + "\n");
                str.Append("预计完工时间:" + myDecoration.Endtime + "\n");
                str.Append("描述:" + myDecoration.Description + "\n");
                tm.Content = str.ToString();
            }
            else
            {
                tm.Content = "暂查不到数据!";
            }
            }
            else
            {
                tm.Content = "您还有没注册!请先注册!";
            }
            return tm.GenerateContent();
        }
        /// <summary>
        /// 我要保修
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        private string repair(EventMessage em,TextMessage tm)
        {
            CacheClient.Client().Insert(em.FromUserName.ToLower(), Process.repair, null, DateTime.Now.AddMinutes(30), System.Web.Caching.Cache.NoSlidingExpiration);
            tm.Content = "您已进入报修操作!\n请输入您的问题或上传图片\n回复N退出保修操作!";
            return tm.GenerateContent();
        }
        /// <summary>
        /// 查看我的家装
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        private string currentprocess(EventMessage em,TextMessage tm)
        {
            
            StringBuilder str = new StringBuilder();
            UserDao ud = new UserDao();
            MyDecorationDao myDecorationDao = new MyDecorationDao();
            User user = ud.selectUser(em.FromUserName);
            if (user != null) { 
            MyDecoration myDecoration = myDecorationDao.selectMyDecorationByUserId(user.Id);
            if (myDecoration != null)
            {
                str.Append("您当前装修进度为:" + myDecoration.Process + "\n");
                str.Append(string.Format("<a href=\"http://test.shuzhengtech.com/publicweb/MyDecoration.aspx?openId={0}\">点击查看详细</a>",em.FromUserName));
                tm.Content = str.ToString();
            }
            else
            {
               // tm.Content = "暂查不到数据!";
                str.Append("您当前装修进度为:竣工验收\n");
                str.Append(string.Format("<a href=\"http://test.shuzhengtech.com/publicweb/MyDecoration.aspx?openId={0}\">点击查看详细</a>", em.FromUserName));
                tm.Content = str.ToString();
            }
            }
            else
            {
                tm.Content = "您还有没注册!请先注册!";
            }
            return tm.GenerateContent();
        }
        /// <summary>
        /// 投诉
        /// </summary>
        /// <param name="em"></param>
        /// <returns></returns>
        private string complain(EventMessage em,TextMessage tm)
        {           
            CacheClient.Client().Insert(em.FromUserName.ToLower(), Process.complain, null, DateTime.Now.AddMinutes(30), System.Web.Caching.Cache.NoSlidingExpiration);
            tm.Content = "您已进入投诉操作!\n请输入您的投诉问题或上传图片\n回复N退出投诉操作!";
            return tm.GenerateContent();
        }
    }
}
