using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using WX;
using System.Security;
using System.Security.Cryptography;
namespace decoration
{
    
    public partial class receiveMessage : System.Web.UI.Page
    {
        private const string Token = "yezhifengdecoration";
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Request.HttpMethod.ToLower() == "post")
            {
              string s = PostInput();
              string responseXml=  (HandlerFactory.create(s)).HandleRequest();
              HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
              HttpContext.Current.Response.Write(responseXml);
              HttpContext.Current.Response.End();
            }
            if (Request.HttpMethod.ToLower() == "get")
            {
                this.Valid();
            }

        }

        private void Valid()
        {
            string echoStr = Request.QueryString["echoStr"].ToString();
            if (CheckSignature())
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    Response.Write(echoStr);
                    Response.End();
                }
            }
        }

      /// 验证微信签名
    /// </summary>
    /// <returns></returns>
    private bool CheckSignature()
   {
       string signature = Request.QueryString["signature"].ToString();
       string timestamp = Request.QueryString["timestamp"].ToString();
       string nonce = Request.QueryString["nonce"].ToString();
       string[] ArrTmp = { Token, timestamp, nonce };
       Array.Sort(ArrTmp);//字典排序
       string tmpStr = string.Join("", ArrTmp);
       tmpStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");//对该字符串进行sha1加密
       tmpStr = tmpStr.ToLower();//对字符串中的字母部分进行小写转换，非字母字符不作处理
       if (tmpStr.Equals(signature,StringComparison.OrdinalIgnoreCase))//开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。开发者通过检验signature对请求进行校         验，若确认此次GET请求来自微信服务器，请原样返回echostr参数内容，则接入生效，否则接入失败
       {
           return true;
       }
       else {
            return false;
       }
    }

    /// <summary>
    /// 获取post返回来的数据
    /// </summary>
    /// <returns></returns>
    private string PostInput()
    {
        Stream s = System.Web.HttpContext.Current.Request.InputStream;
        byte[] b = new byte[s.Length];
        s.Read(b, 0, (int)s.Length);
        return Encoding.UTF8.GetString(b);
    }














    }
}