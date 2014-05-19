using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Collections;
namespace Dal
{
    public class SQLHelper
    {

        private SqlConnection conn = null;
       

        public SqlConnection getSqlConnection2()
        {
            string CONNSTR = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            conn = new SqlConnection(CONNSTR);
            conn.Open();
            return conn;
        }
        private SqlConnection getSqlConnection()
        {
            string CONNSTR = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            conn = new SqlConnection(CONNSTR);
            conn.Open();
            return conn;
        }


        /// <summary>
        /// 执行传入的增删改sql语句
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>返回执行的记录数</returns>
        public int ExecuteNonQuery(string sql, Hashtable parameters)
        {
            int res = 0;
            SqlConnection conn = this.getSqlConnection();
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd = this.addParameter(cmd,parameters);
                res = cmd.ExecuteNonQuery();
            }


            return res;
        }
        private SqlCommand addParameter(SqlCommand cmd, Hashtable parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                foreach (DictionaryEntry de in parameters)
                {
                    cmd.Parameters.Add(new SqlParameter(de.Key.ToString(), de.Value.ToString()));
                }
            }
            return cmd;
        }

        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable getDataTable(string sql, Hashtable parameters)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = this.getSqlConnection();
            using (connection)
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd = this.addParameter(cmd, parameters);
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                dataTable.Load(reader);

            }



            return dataTable;
        }
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable getDataTableProc(string procName, Hashtable parameters)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = this.getSqlConnection();
            using (connection)
            {
                SqlCommand cmd = new SqlCommand(procName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd = this.addParameter(cmd, parameters);
                SqlDataReader reader = null;
                reader = cmd.ExecuteReader();
                dataTable.Load(reader);

            }



            return dataTable;
        }
        public SqlDataReader getSqlDataReader(string sql, Hashtable parameters)
        {
            SqlDataReader reader = null;
            SqlConnection connection = this.getSqlConnection();
         
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd = this.addParameter(cmd, parameters);
                reader = cmd.ExecuteReader();
         
            return reader;
        }

    }
}
