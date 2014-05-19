using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace WX
{
  public  class CacheClient
    {
      public static System.Web.Caching.Cache Client()
      {
          return HttpRuntime.Cache;
      }
    }
}
