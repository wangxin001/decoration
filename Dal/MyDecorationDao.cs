using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace Dal
{
   public class MyDecorationDao
    {
       SQLHelper sqlHelper = null;
       public MyDecorationDao()
      {
          sqlHelper = new SQLHelper();
      }
       /// <summary>
       /// 保存现在的家装状态
       /// </summary>
       /// <param name="myDecoration"></param>
       /// <returns></returns>
       public bool insertMyDecoration(MyDecoration myDecoration)
       {
           string sql = "insert into mydecoration(process,description,starttime,endtime,userid) values(@process,@description,@starttime,@endtime,@userid)";
           Hashtable parameters = new Hashtable();
           parameters.Add("@process",myDecoration.Process );
           parameters.Add("@description", myDecoration.Description);
           parameters.Add("@starttime", myDecoration.Starttime);
           parameters.Add("@endtime", myDecoration.Endtime);
           parameters.Add("@userid", myDecoration.UserId);
           int rs = sqlHelper.ExecuteNonQuery(sql, parameters);
           return rs == 1 ? true : false;

       }
       public MyDecoration selectMyDecorationByUserId(string userId)
       {
          
           string sql = "select TOP (1) id, process, description, starttime, endtime, userid,createtime from mydecoration where userid=@userid order by createTime desc";
           Hashtable parameters = new Hashtable();
           parameters.Add("@userid", userId);
           DataTable table = sqlHelper.getDataTable(sql, parameters);
           if (table.Rows.Count == 0)
           {
               return null;
           }
           MyDecoration myDecoration = new MyDecoration();
           foreach (DataRow row in table.Rows)
           {
               myDecoration.Id = row["id"].ToString();
               myDecoration.Process = row["process"].ToString();
               myDecoration.Starttime = row["starttime"].ToString();
               myDecoration.Endtime = row["endtime"].ToString();
               myDecoration.UserId = userId;
               myDecoration.CreateTime = row["createtime"].ToString();

           }
           
           return myDecoration;
       }
       public MyDecoration selectCurrentMyDecoration(string userId,string currentProcess)
       {

           string sql = "select * from mydecoration where userid=@userid and process=@currentProcess";
           Hashtable parameters = new Hashtable();
           parameters.Add("@userid", userId);
           parameters.Add("@currentProcess", currentProcess);
           DataTable table = sqlHelper.getDataTable(sql, parameters);
           if (table.Rows.Count == 0)
           {
               return null;
           }
           MyDecoration myDecoration = new MyDecoration();
           foreach (DataRow row in table.Rows)
           {

               myDecoration.Id = row["id"].ToString();
               myDecoration.Process = row["process"].ToString();
               myDecoration.Starttime = row["starttime"].ToString();
               myDecoration.Endtime = row["endtime"].ToString();
               myDecoration.UserId = userId;
               myDecoration.CreateTime = row["createtime"].ToString();

           }

           return myDecoration;
       }
    }
}
