using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Model;
using System.Data.SqlClient;
using CMS.DAL;
using 商品管理.Model;

namespace 商品管理.DAL
{
    public class ProductTypeDAL
    {

        public static List<ProductType> selectall()
        {

            List<ProductType> list = new List<ProductType>();
            string sql = "select * from ProductType";
            SqlDataReader sdr = DBHelper.ExecuteReader(sql, null);
            while (sdr.Read())
            {
                ProductType type = new ProductType();
                type.id = Convert.ToInt32(sdr["ptid"].ToString());
                type.name = sdr["ptname"].ToString();
                list.Add(type);
            }
            sdr.Close();
            return list;

        }
        public static int insert(string name)
        {
            string sql = "insert into  ProductType values(@name) ";
            SqlParameter[] sps = new SqlParameter[]
            {
            
            new SqlParameter("@name",name)
            };
            int count = DBHelper.ExecuteNonQuery(sql,sps);
         
            return count;
        }
        public static int update(string   id,string name)
        {
            string sql = "update ProductType set ptname=@name where ptid=@id";
            SqlParameter[] sps = new SqlParameter[]
            {
                new SqlParameter("@name",name),
            new SqlParameter("@id",id)
            };
            int count = DBHelper.ExecuteNonQuery(sql, sps);
            return count;
        }
        public static int  database(string id)
        {
            string sql = "delete from ProductType where ptid=@id ";
            SqlParameter[] sps = new SqlParameter[]
            {
            
            new SqlParameter("@id",id)

            };
            int count = DBHelper.ExecuteNonQuery(sql,sps);
            return count;
        
        
        }



    }
}
