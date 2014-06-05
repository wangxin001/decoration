using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Dal;
using LitJson;
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
            if (String.IsNullOrEmpty(content))
            {
                str.Append("您什么都没输入，没法帮您啊，%>_<%。");
            } //地里位置查询
            else if (content.Length > 2 &&content.Contains("附近")&& content.IndexOf("附近") != 0&&!content.Substring(content.Length-2).Equals("附近"))
            {
                string location=String.Empty ,q= String.Empty;
                try
                {

              
                 location = content.Substring(0, content.IndexOf("附近"));
                 q = content.Substring(content.IndexOf("附近") + 2);
                //AC3ac99bf990cf59ca736131dc60f761
                //获取位置坐标
          
                string url0 = String.Format("http://api.map.baidu.com/geocoder/v2/?ak=AC3ac99bf990cf59ca736131dc60f761&output=json&address={0}&city={1}", location, "北京市");
                string data0 = HttpUtility.GetData(url0);
                JsonData jsonData0 = JsonMapper.ToObject(data0);
                string status0 = jsonData0["status"].ToString();
                if (status0.Equals("0"))
                {
                    JsonData result = jsonData0["result"];
                    JsonData locations = result["location"];
                    string lat = locations["lat"].ToString();
                    string lng = locations["lng"].ToString();


                    //AC3ac99bf990cf59ca736131dc60f761
                    string url = String.Format("http://api.map.baidu.com/place/v2/search?ak=AC3ac99bf990cf59ca736131dc60f761&output=json&query={0}&page_size=9&page_num=0&scope=2&location={1},{2}&radius=5000", q, lat, lng);
                    string data = HttpUtility.GetData(url);
                    JsonData jsonData = JsonMapper.ToObject(data);
                    string status = jsonData["status"].ToString();
                    string message = jsonData["message"].ToString();
                    string total = jsonData["total"].ToString();
                    if (total.Equals("0") || !status.Equals("0"))
                    {
                        str.Append("附近未找到" + content.Substring(2) + "!" );
                    }
                    else
                        if (status.Equals("0") && !total.Equals("0"))
                        {
                            return getLocationData(jsonData, tm, content);
                        }
                }
                else
                {
                    str.Append("未能查询到" + location+"的地理坐标!");
                }
                      }catch(Exception e)
                {
                    str.Append(e.Message + location+"="+q);
                }
            }

            else if (content.Length > 2 && content.Substring(0, 2).Equals("附近"))
            {
                LocationMessage locationMessage = (LocationMessage)CacheClient.Client().Get(tm.FromUserName.ToLower() + Process.myLocation);
                if (locationMessage != null)
                {


                    try
                    {

                        //AC3ac99bf990cf59ca736131dc60f761
                        string url = String.Format("http://api.map.baidu.com/place/v2/search?ak=AC3ac99bf990cf59ca736131dc60f761&output=json&query={0}&page_size=9&page_num=0&scope=2&location={1},{2}&radius=5000", content.Substring(2), locationMessage.Lat, locationMessage.Lng);
                        string result = HttpUtility.GetData(url);
                        JsonData jsonData = JsonMapper.ToObject(result);
                        string status = jsonData["status"].ToString();
                        string message = jsonData["message"].ToString();
                        string total = jsonData["total"].ToString();
                        if (total.Equals("0") || !status.Equals("0"))
                        {
                            str.Append("附近未找到" + content.Substring(2) + "!" );
                        }
                        else
                            if (status.Equals("0") && !total.Equals("0"))
                            {
                                return getLocationData(jsonData,tm,content);
                            }

                    }
                    catch (Exception e)
                    {
                        str.Append(e.Message);
                    }
                }
                else
                {
                    str.Append("未获取到您的地里位置信息!\n");
                    str.Append("点击下方“+”号，发送您的地里位置!");
                }
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
                    if (((Process)(action)) == Process.complain)
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

        private string getLocationData(JsonData jsonData,TextMessage tm,string content)
        {

            List<LocationMessage> list = new List<LocationMessage>();
            JsonData results = jsonData["results"];
            foreach (JsonData item in results)
            {
                string itemStr = JsonMapper.ToJson(item);
                LocationMessage lm = new LocationMessage();
                lm.Name = item["name"].ToString();
                lm.Address = item["address"].ToString();
                lm.Uid = item["uid"].ToString();
                if (itemStr.Contains("telephone"))
                {

                    lm.Telephone = item["telephone"].ToString();
                }

                JsonData locations = item["location"];
                lm.Lat = locations["lat"].ToString();
                lm.Lng = locations["lng"].ToString();
                if (itemStr.IndexOf("detail_info") > -1)
                {
                    JsonData detail_info = item["detail_info"];
                    if (itemStr.IndexOf("distance") > -1)
                    {
                        lm.Distance = detail_info["distance"].ToString();
                    }
                    if (itemStr.IndexOf("detail_url") > -1)
                    {
                        lm.Url = detail_info["detail_url"].ToString();
                    }



                }

                list.Add(lm);




            }

            List<ArticleMessage> amList = new List<ArticleMessage>();
            ArticleMessage am = null;
            am = new ArticleMessage();
            am.ToUserName = tm.FromUserName;
            am.FromUserName = tm.ToUserName;
            am.CreateTime = Common.getNowTimeString();
            am.Title = "结果如下：";
            am.PicUrl = "http://test.shuzhengtech.com/image/jiage.gif";
            amList.Add(am);
            foreach (LocationMessage item in list)
            {

                am = new ArticleMessage();
                am.ToUserName = tm.FromUserName;
                am.FromUserName = tm.ToUserName;
                am.CreateTime = Common.getNowTimeString();
                am.Title = "【" + item.Name + "】<" + item.Distance + ">" + item.Address + "\n" + item.Telephone;
                am.Description = "";
              //  am.PicUrl = "http://test.shuzhengtech.com/image/jiage.gif";
                am.Url = item.Url;
                //am.PicUrl = "";
                amList.Add(am);



            }
            am.List = amList;
            return am.GenerateContent();
        }
    }
}
