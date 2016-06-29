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
    public static  class ProductsDAL
    {

        /// <summary>
        /// 查询所有商品信息
        /// </summary>
        /// <returns></returns>
        public static List<Products> selectAll()
        {   

            List<Products> list = new List<Products>();
            string sql = "select * from Products";
            SqlDataReader sdr = DBHelper.ExecuteReader(sql, null);
            while (sdr.Read())
            {
                Products type = new Products();
                type.ProductID = Convert.ToInt32(sdr["ProductID"].ToString());
                type.ProductName = sdr["ProductName"].ToString();
                type.PTID = Convert.ToInt32(sdr["PTID"].ToString());
                type.ProductJP = sdr["ProductJP"].ToString();
                type.ProductPrice = Convert.ToDouble ( sdr["ProductPrice"].ToString());
                list.Add(type);
            }
            sdr.Close();
            return list;
        }
        public static int  insert( Products list)
        {
           // List<Products> list = new List<Products>();
            string sql = "insert into  Products values(@ProductName,@PTID ,@ProductJP,@ProductPrice)";
            SqlParameter[] sps = new SqlParameter[]
            { 
            new SqlParameter("@ProductName",list.ProductName),
            new SqlParameter("@ProductJP",list.ProductJP),
            new SqlParameter("@PTID",list.PTID),
            new SqlParameter("@ProductPrice",list.ProductPrice)
            
            };
            int count = DBHelper.ExecuteNonQuery(sql,sps);
            return count;

        }
        public static int update(Products list)
        {
            string sql = "update Products set ProductName=@ProductName,PTID=@PTID,ProductJP=@ProductJP,ProductPrice=@ProductPrice where ProductID=@ProductID";

            SqlParameter[] sps = new SqlParameter[]
            { 
                new SqlParameter("@ProductID",list.ProductID),
            new SqlParameter("@ProductName",list.ProductName),     
            new SqlParameter("@PTID",list.PTID),
               new SqlParameter("@ProductJP",list.ProductJP),
            new SqlParameter("@ProductPrice",list.ProductPrice)
            
            };
            int count = DBHelper.ExecuteNonQuery(sql, sps);
            return count;
        
        }
        public static int database(string id)
        {
            string sql = "delete from Products where ProductID=@ProductID ";
            SqlParameter[] sps = new SqlParameter[]
            {
           new SqlParameter("@ProductID",id)
            
            };

            int count = DBHelper.ExecuteNonQuery(sql, sps);
            return count;
        
        }
        public static List<Products> selectname(int leiid)
        {
            List<Products> list = new List<Products>();

            string sql = "select * from Products where PTID=@id ";
           
            SqlParameter[] sps = new SqlParameter[]
            {           
            new SqlParameter("@id",leiid)
            };
            SqlDataReader sdr = DBHelper.ExecuteReader(sql, sps);
            while (sdr.Read())
            {
                Products type = new Products();
                type.ProductID = Convert.ToInt32(sdr["ProductID"].ToString());
                type.ProductName = sdr["ProductName"].ToString();
                type.PTID = Convert.ToInt32(sdr["PTID"].ToString());
                type.ProductJP = sdr["ProductJP"].ToString();
                type.ProductPrice = Convert.ToDouble(sdr["ProductPrice"].ToString());
                list.Add(type);
            }
            sdr.Close();
            return list;
        }
        public static List<Products> selectjp(string jp)
        {
            List<Products> list = new List<Products>();

            string sql = "select * from Products where ProductJP  like '%'+@id+'%' ";

            SqlParameter[] sps = new SqlParameter[]
            {           
            new SqlParameter("@id",jp)
            };
            SqlDataReader sdr = DBHelper.ExecuteReader(sql, sps);
            while (sdr.Read())
            {
                Products type = new Products();
                type.ProductID = Convert.ToInt32(sdr["ProductID"].ToString());
                type.ProductName = sdr["ProductName"].ToString();
                type.PTID = Convert.ToInt32(sdr["PTID"].ToString());
                type.ProductJP = sdr["ProductJP"].ToString();
                type.ProductPrice = Convert.ToDouble(sdr["ProductPrice"].ToString());
                list.Add(type);
            }
            sdr.Close();
            return list;
        }
       /// <summary>
       /// /根据编号查询简写
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public static Products select(int id)
        {
            string sql = "select * from   Products where  ProductID=@id";
            SqlParameter[] sps = new SqlParameter[]
            {
            new SqlParameter("@id",id)
            
            };
            Products type = new Products();
            SqlDataReader sdr = DBHelper.ExecuteReader(sql, sps);
            while (sdr.Read())
            {
               
                type.ProductID = Convert.ToInt32(sdr["ProductID"].ToString());
                type.ProductName = sdr["ProductName"].ToString();
                type.PTID = Convert.ToInt32(sdr["PTID"].ToString());
                type.ProductJP = sdr["ProductJP"].ToString();
                type.ProductPrice = Convert.ToDouble(sdr["ProductPrice"].ToString());
             
            
            }
            sdr.Close();
            return type;
        
        }
       
    }
}
