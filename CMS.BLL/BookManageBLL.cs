using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CMS.BLL
{
    public class BookManageBLL
    {
        static SqlConnection sqlconn;
        SqlCommand cmd;
        SqlParameter para;
        static DataSet SqlDataSet;
        public BookManageBLL()
        {
            try
            {
                sqlconn = new SqlConnection(@"server=.;uid=sa;pwd=sa;database=EatingTradDB;");
                sqlconn.Open();
                cmd = sqlconn.CreateCommand();
            }
            catch (Exception ex)
            {
               
            }
        }

        public static DataSet Select(string TableName, string[] columns, string[] data)
        {
            try
            {
                string cmd = "select * from " + TableName + " where ";
                int i;
                for (i = 0; i < columns.Length; i++)
                {
                    cmd += columns[i] + "=" + "'" + data[i] + "'";
                    if (i < columns.Length - 1)
                        cmd += " and ";
                }
                
                SqlDataAdapter thisAdapter = new SqlDataAdapter(cmd, sqlconn);
                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, TableName);
                return thisDataSet;
            }
            catch (Exception ex) { throw; return null; }
        }

        public static Boolean Delete(string TableName, string[] columns, string[] data)
        {
            try
            {
                string cmd = "delete from " + TableName + " where ";
                string condition = "=";
                int i;
                for (i = 0; i < columns.Length; i++)
                {
                    cmd += columns[i] + condition + "'" + data[i] + "'";
                    if (i < columns.Length - 1)
                        cmd += " and ";

                }
                SqlCommand sqlcmd = new SqlCommand(cmd, sqlconn);
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) {  return false; }
        }

        public static Boolean Add(string TableName, string[] columns, string[] data)
        {
            try
            {
                string cmd = "insert into " + TableName + "(";
                int i;
                for (i = 0; i < columns.Length; i++)
                {
                    cmd += columns[i];
                    if (i < columns.Length - 1)
                        cmd += ",";
                }
                cmd += ") ";
                cmd += "values (";
                for (i = 0; i < data.Length; i++)
                {
                    cmd += "'" + data[i] + "'";
                    if (i < data.Length - 1)
                        cmd += ",";
                }
                cmd += ")";
                //  MessageBox.Show(cmd);
                SqlCommand sqlcmd = new SqlCommand(cmd, sqlconn);
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) {  return false; }
        }

        public static Boolean Updata(string TableName, string[] columns, string[] data, string[] Condition, string[] ConditionData)
        {
            try
            {
                string cmd = "update " + TableName + " set ";
                int i;
                for (i = 0; i < columns.Length; i++)
                {
                    cmd += columns[i] + "=" + "'" + data[i] + "'";
                    if (i < columns.Length - 1)
                        cmd += " , ";
                }
                cmd += " where ";
                for (i = 0; i < Condition.Length; i++)
                {
                    cmd += Condition[i] + "=" + "'" + ConditionData[i] + "'";
                    if (i < Condition.Length - 1)
                        cmd += " and ";
                }
                //   MessageBox.Show(cmd);
                SqlCommand sqlcmd = new SqlCommand(cmd, sqlconn);
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) {  return false; }
        }

        //public static DataSet Getselect(string tablename)
        //{
        //    string yy = "select * from " + tablename;
        //    SqlDataAdapter obj = new SqlDataAdapter(yy, sqlconn);
        //    SqlDataSet = new DataSet();
        //    obj.Fill(SqlDataSet, "table");
        //    return SqlDataSet;
        //}

        public static DataSet ygpselect(string TableName, string[] columns, string[] data)
        {
            try
            {
                string cmd = "select * from " + TableName + " where ";
                int i;
                for (i = 0; i < columns.Length; i++)
                {
                    cmd += columns[i] + " like " + "'%" + data[i] + "%'";
                    if (i < columns.Length - 1)
                        cmd += " or ";
                }
                // MessageBox.Show(cmd);
                SqlDataAdapter thisAdapter = new SqlDataAdapter(cmd, sqlconn);
                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, TableName);

                return thisDataSet;
            }
            catch (Exception ex) {  return null; }
        }


        //---------------------------------
        //-----外卖打包
        //---------------------------------

        public static DataSet Getselect(string tablename)
        {
            string yy = "select * from " + tablename;
            SqlDataAdapter obj = new SqlDataAdapter(yy, sqlconn);
            SqlDataSet = new DataSet();
            obj.Fill(SqlDataSet, "table");
            return SqlDataSet;
        }


        //快速开单
        public static void ygpupdate(string nomber, string yui)
        {
            string yy = "update 餐房 set 餐台状态='" + yui + "' where 餐台号='" + nomber + "'";
            SqlDataAdapter obj = new SqlDataAdapter(yy, sqlconn);
            SqlDataSet = new DataSet();
            obj.Fill(SqlDataSet, "table");
        }
    }
}
