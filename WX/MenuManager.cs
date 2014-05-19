using System;
using System.Collections.Generic;
using System.Text;

namespace WX
{
  public  class MenuManager
  {
      /// <summary>
      /// 获取菜单
      /// </summary>
      public static string GetMenu()
      {
          string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", Common.GetAccessToken());

          return HttpUtility.GetData(url);
      }
      /// <summary>
      /// 创建菜单
      /// </summary>
      public static void CreateMenu(string filePath)
      {
          string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", Common.GetAccessToken());

          HttpUtility.SendHttpRequest(url, Common.Read(filePath));
      }
      /// <summary>
      /// 删除菜单
      /// </summary>
      public static void DeleteMenu()
      {
          string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", Common.GetAccessToken());
          HttpUtility.GetData(url);
      }
     
    }
}
