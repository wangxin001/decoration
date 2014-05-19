using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Dal;
namespace WX
{
    public class MessageHandler : IHandler
    {
        /// <summary>
        /// 请求的xml
        /// </summary>
        private string RequestXml { get; set; }
        /// <summary>
        /// 构造函数同时传入参数
        /// </summary>
        /// <param name="requestXml"></param>
        public MessageHandler(string requestXml)
        {
            this.RequestXml = requestXml;
        }
        /// <summary>
        /// 处理消息
        /// </summary>
        /// <returns></returns>
        public string HandleRequest()
        {
            StringBuilder str = new StringBuilder();
            //int[] actions = { 1, 2, 3, 4, 5, 6 };
            string response = string.Empty;
            TextMessage tm = TextMessage.LoadFromXml(RequestXml);
            string content = tm.Content.Trim();
            if (string.IsNullOrEmpty(content))
            {
                str.Append("您什么都没输入，没法帮您啊，%>_<%。");
            }
            else
            {
                //在缓存中取出用户上一步的操作
                object action = CacheClient.Client().Get(tm.FromUserName.ToLower());
                if (action == null)
                {
                    int key = -1;
                    if (Int32.TryParse(content, out key) == true && key >= 1 && key <= 6)
                    {
                        switch (key)
                        {
                            case 1: response = "<a href=\"http://test.shuzhengtech.com/publicweb/DesignCase.aspx\">点击查看设计案例</a>"; break;
                            case 4: response = "<a href=\"http://test.shuzhengtech.com/publicweb/Register.aspx\">点击加入我们</a>"; break;
                        }
                    }
                    else
                    {


                        str.Append("请输入有效数字选择您需要的服务:\n");
                        str.Append("1、设计咨询\n");
                        str.Append("2、订单咨询\n");
                        str.Append("3、我的家装\n");
                        str.Append("4、业主注册\n");
                        str.Append("5、投诉\n");
                        str.Append("6、报修\n");

                    }
                }
                else
                {
                    //注册
                    if (((Process)(action)) == Process.waitInputTel)
                    {
                        if (!content.ToLower().Equals("n"))
                        {
                            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^1\\d{10}$");

                            if (content.Length == 11 && regex.Match(content).Success)
                            {
                                UserDao ud = new UserDao();
                                User user = new User();
                                user.Tel = content;
                                user.OpenId = tm.FromUserName;
                                bool rs = ud.insertUser(user);
                                if (rs)
                                {
                                    str.Append("注册成功!");
                                    CacheClient.Client().Remove(tm.FromUserName.ToLower());
                                }
                                else
                                {
                                    str.Append("系统忙请稍再试!");
                                }
                            }
                            else
                            {
                                str.Append("请输入有效的手机号码!\n回复N退出注册操作!");

                            }
                        }
                        else
                        {

                            CacheClient.Client().Remove(tm.FromUserName.ToLower());
                            str.Append("已退出注册操作!\n");
                        }

                    }
                    //报修
                    if (((Process)(action)) == Process.repair)
                    {
                        if (!content.ToLower().Equals("n"))
                        {
                            str.Append(String.Format("您的报修内容为:{0}", content));
                            str.Append("\n");
                            str.Append("我们已记录您的报修内容,稍后会有专人跟您联系!您可继续输入您的问题或回复N退出报修操作!");
                        }
                        else
                        {
                            CacheClient.Client().Remove(tm.FromUserName.ToLower());
                            str.Append("您已退出报修操作!\n");
                        }
                    }
                    //投诉
                    if (((Process)(action))==Process.complain)
                    {
                        if (!content.ToLower().Equals("n"))
                        {
                            str.Append(String.Format("您的报修内容为:{0}", content));
                            str.Append("\n");
                            str.Append("我们已记录您的投诉内容,稍后会有专人跟您联系!您可继续输入您的问题或回复N退出报修操作!");
                        }
                        else
                        {
                            CacheClient.Client().Remove(tm.FromUserName.ToLower());
                            str.Append("您已退出投诉操作!\n");
                        }
                    }
                }

            }
            tm.Content = str.ToString();
            //进行发送者、接收者转换
            string temp = tm.ToUserName;
            tm.ToUserName = tm.FromUserName;
            tm.FromUserName = temp;
            response = tm.GenerateContent();
            return response;
        }
    }
}
