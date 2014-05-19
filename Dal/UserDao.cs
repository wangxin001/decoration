using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
namespace Dal
{
    /// <summary>
    /// 用户数据库操作类
    /// </summary>
  public  class UserDao
    {
      SQLHelper sqlHelper = null;
      public UserDao()
      {
          sqlHelper = new SQLHelper();
      }
      /// <summary>
      /// 用户注册
      /// </summary>
      /// <param name="user"></param>
      /// <returns>返回true 添加成功否则添加失败</returns>
      public bool insertUser(User user)
      {
          string sql = "INSERT INTO users(openid,tel) "
+ " VALUES(@openid,@tel)";
          Hashtable parameters = new Hashtable();
          parameters.Add("@openid", user.OpenId);
          parameters.Add("@tel", user.Tel);
        
       
          int rs = sqlHelper.ExecuteNonQuery(sql, parameters);
         
          return rs==1?true:false;
      }
      /// <summary>
      /// 用户注册
      /// </summary>
      /// <param name="tel"></param>
      /// <param name="openId"></param>
      /// <returns>false 已存在</returns>
      public bool isUserExist(string tel,string openId)
      {
          string sql = "SELECT ID FROM USERS WHERE TEL=@tel AND OPENID=@openId";
          Hashtable parameters = new Hashtable();
          parameters.Add("@tel", tel);
          parameters.Add("@openId", openId);
          DataTable table = sqlHelper.getDataTable(sql, parameters);
          if (table.Rows.Count != 0)
          {
              return false;
          }
          else
          {
              return true;
          }
      }
      public User selectUser(string openId)
      {

          string sql = "SELECT id,username,name,wxid FROM users WHERE openId=@openId  ";
          Hashtable parameters = new Hashtable();
          parameters.Add("@openId", openId);       
          DataTable table = sqlHelper.getDataTable(sql, parameters);
          if (table.Rows.Count == 0)
          {
              return null;
          }
          User user = new User();
          foreach (DataRow row in table.Rows)
          {
              user.Id = row["id"].ToString();
              user.Username = row["username"].ToString();
              user.Name = row["name"].ToString();
              user.Wxid = row["wxid"].ToString();

          }
          return user;
      }
      /// <summary>
      /// 用户登录
      /// </summary>
      /// <param name="username">用户名</param>
      /// <param name="password">密码</param>
      /// <returns>>返回true 登录成功否则添加失败</returns>
      public User selectUser(string username,string password)
      {

          string sql = "SELECT id,username,name,wxid FROM users WHERE username=@username and password=@password ";
          Hashtable parameters = new Hashtable();
          parameters.Add("@username",username);
          parameters.Add("@password",password);
          DataTable table = sqlHelper.getDataTable(sql, parameters);
          if (table.Rows.Count==0)
          {
              return null;
          }
          User user = new User();
          foreach (DataRow row in table.Rows)
          {
              user.Id=row["id"].ToString();
              user.Username = row["username"].ToString();
              user.Name = row["name"].ToString();
              user.Wxid = row["wxid"].ToString();

          }
          return user;
      }
      /// <summary>
      /// 验证用户名是否存在
      /// </summary>
      /// <param name="username">用户名</param>
      /// <returns>返回false 用户名已存在否则不存在</returns>
      public bool isUserNameExist(string username)
      {
          string sql = "SELECT id FROM users WHERE username=@username ";
          Hashtable parameters = new Hashtable();
          parameters.Add("@username", username);
         
          DataTable table = sqlHelper.getDataTable(sql, parameters);
          if (table.Rows.Count != 0)
          {
              return false;
          }
          else
          {
              return true;
          }
        
      }
    }
}
