using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CMS.DAL
{
    /// <summary>
    /// sql操作类库
    /// </summary>
    public static class DBHelper
    {
        /// <summary>
        /// sql链接
        /// </summary>
        public static String ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="Sql">sql语句</param>
        /// <returns>返回值</returns>
        public static int ExecuteNonQuery(String Sql)
        {
            return ExecuteNonQuery(Sql,null);
        }
        public static int ExecuteNonQuery(String Sql, SqlParameter[] Sps)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnString))
            {
                conn.Open();
                SqlCommand CMSd = new SqlCommand(Sql,conn);
                if (Sps != null)
                    CMSd.Parameters.AddRange(Sps);
                return CMSd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ListView查询
        /// </summary>
        /// <param name="Sql">sql语句</param>
        /// <returns>返回值</returns>
        public static SqlDataReader ExecuteReader(String Sql)
        {
            return ExecuteReader(Sql,null);
        }
        public static SqlDataReader ExecuteReader(String Sql,SqlParameter[] Sps)
        {
            SqlConnection conn = new SqlConnection(DBHelper.ConnString);
            conn.Open();
            SqlCommand CMSd = new SqlCommand(Sql, conn);
            if (Sps != null)
                CMSd.Parameters.AddRange(Sps);
            return CMSd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// DataGridView查询
        /// </summary>
        /// <param name="Sql">sql语句</param>
        /// <returns>返回值</returns>
        public static DataSet ExecuteDataSet(String Sql)
        {
            return ExecuteDataSet(Sql, null);
        }
        public static DataSet ExecuteDataSet(String Sql, SqlParameter[] Sps)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.ConnString))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(Sql, conn);
                if (Sps != null)
                    sda.SelectCommand.Parameters.AddRange(Sps);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// 单值查询
        /// </summary>
        /// <param name="Sql">sql语句</param>
        /// <returns>返回值</returns>
        public static object ExecuteScalar(String Sql)
        {
            return ExecuteScalar(Sql, null);
        }
        public static object ExecuteScalar(String Sql, SqlParameter[] Sps)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlCommand CMSd = new SqlCommand(Sql, conn);
                if (Sps != null)
                    CMSd.Parameters.AddRange(Sps);
                return CMSd.ExecuteScalar();
            }
        }
                
        

    }
}
