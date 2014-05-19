using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using System.Web;
using LitJson;
using System.IO;
namespace WX
{
  public  class Common
    {
       
      public static string GetAccessToken()
      {
          string AppID = ConfigurationManager.AppSettings["AppID"].ToString();
          string AppSecret = ConfigurationManager.AppSettings["AppSecret"].ToString();
          string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", AppID, AppSecret);
          string result = HttpUtility.GetData(url);
          JsonData jsonData = JsonMapper.ToObject(result);
          return jsonData["access_token"].ToString();
          
      }
     public static string Read(string filePath)
      {
          
          StreamReader sr = new StreamReader(filePath, System.Text.Encoding.Default);
          String input = sr.ReadToEnd();
          sr.Close();
          return input;
      }
      public static string getNowTimeString()
      {
        return  DateTime.Now.Ticks.ToString();
      }
      public static string getTimeString(string formate)
      {
          return DateTime.Now.ToString(formate);
      }
      public void addCache(string key, object value)
      {
         
      }
    }
    public enum Process
    {
        /// <summary>
        /// 等待输入手机号
        /// </summary>
        waitInputTel=1,
        /// <summary>
        /// 我要保修
        /// </summary>
        repair=2,
        /// <summary>
        /// 投诉
        /// </summary>
        complain=3

    }
}
