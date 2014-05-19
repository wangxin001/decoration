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
    /// 设计师数据库操作类
    /// </summary>
  public  class DesignerDao
    {
      SQLHelper sqlHelper = null;
      public DesignerDao()
      {
          sqlHelper = new SQLHelper();
      }
      /// <summary>
      /// 根据id查询设计师详细信息
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public Designer getDesignerById(string id)
      {
         


          string sql = "SELECT * FROM designer WHERE id=@id ";
          Hashtable parameters = new Hashtable();
          parameters.Add("@id", id);
          DataTable table = sqlHelper.getDataTable(sql, parameters);
          if (table.Rows.Count == 0)
          {
              return null;
          }
          Designer designer = new Designer();
          foreach (DataRow row in table.Rows)
          {
              designer.Id = row["id"].ToString();
              designer.Company= row["company"].ToString();
              designer.Tel = row["tel"].ToString();
              designer.Sjxy = row["sjxy"].ToString();
              designer.Sjln = row["sjln"].ToString();
              designer.Works = row["works"].ToString();
              designer.Summary = row["summary"].ToString();
              designer.Pic = row["pic"].ToString();
              designer.Area = row["area"].ToString();
              designer.Name = row["name"].ToString();
          }
          
          return designer;

      }
      /// <summary>
      /// 根据所在地区获得该地区的所有设计师
      /// </summary>
      /// <param name="company"></param>
      /// <returns></returns>
      public List<Designer> getDesignersByArea(string area)
      {
          List<Designer> list = new List<Designer>();
          string sql = "SELECT * FROM designer WHERE area=@area";
          Hashtable parameters = new Hashtable();
          parameters.Add("@area", area);
          DataTable table = sqlHelper.getDataTable(sql, parameters);
          if (table.Rows.Count == 0)
          {
              return null;
          }
        
          foreach (DataRow row in table.Rows)
          {
              Designer designer = new Designer();
              designer.Id = row["id"].ToString();
              designer.Company = row["company"].ToString();
              designer.Tel = row["tel"].ToString();
              designer.Sjxy = row["sjxy"].ToString();
              designer.Sjln = row["sjln"].ToString();
              designer.Works = row["works"].ToString();
              designer.Summary = row["summary"].ToString();
              designer.Pic = row["pic"].ToString();
              designer.Area = row["area"].ToString();
              designer.Name = row["name"].ToString();
              list.Add(designer);

          }
          
          return list;
      }
      /// <summary>
      /// 添加设计师信息
      /// </summary>
      /// <param name="designer"></param>
      /// <returns></returns>
      public bool insertDesigner(Designer designer)
      {
          string sql = "INSERT INTO designer(company,tel,sjxy,sjln,works,summary,pic,area,name) "
+ " VALUES(@company,@tel,@sjxy,@sjln,@works,@summary,@pic,@area,@name)";
          Hashtable parameters = new Hashtable();
          parameters.Add("@company", designer.Company);
          parameters.Add("@tel", designer.Tel);
          parameters.Add("@sjxy", designer.Sjxy);
          parameters.Add("@sjln", designer.Sjln);
          parameters.Add("@works", designer.Works);
          parameters.Add("@summary", designer.Summary);
          parameters.Add("@pic", designer.Pic);
          parameters.Add("@area", designer.Area);
          parameters.Add("@name", designer.Name);
         
         
          int rs = sqlHelper.ExecuteNonQuery(sql, parameters);

          return rs == 1 ? true : false;
      } 
      /// <summary>
      /// 根据id删除设计师信息
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public bool delDesigner(string id)
      {
          string sql = "delete from designer where id=@id";
          Hashtable parameters = new Hashtable();
          parameters.Add("@id",id);
          int rs = sqlHelper.ExecuteNonQuery(sql, parameters);
          return rs == 1 ? true : false;
      }
    }
}
