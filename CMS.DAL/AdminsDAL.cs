using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Model;
using System.Data.SqlClient;

namespace CMS.DAL
{
    public static class AdminsDAL
    {
        /// <summary>
        /// 登录信息查询
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public static Admins Login(String Name, String Pwd)
        {
            String Sql = "select * from admins where username=@name and userpwd=@pwd";
            SqlParameter[] Sps = new SqlParameter[]
            {
                new SqlParameter("@name",Name),
                new SqlParameter("@pwd",Pwd)
            };
            SqlDataReader sdr = DBHelper.ExecuteReader(Sql,Sps);
            Admins admin = null;
            if (sdr.Read())
            {
                admin = new Admins();
                admin.UserID = sdr["userID"].ToString();
                admin.UserName = sdr["username"].ToString();
                admin.UserPwd = sdr["userPwd"].ToString();
                admin.UserCompellation = sdr["UserCompellation"].ToString();
            }
            sdr.Close();
            return admin;
        }



        public static List<Admins> selectall()
        {
            List<Admins> list = new List<Admins>();
            string sql = "select * from admins";
            SqlDataReader sdr = DBHelper.ExecuteReader(sql, null);
            while (sdr.Read())
            {
                Admins s = new Admins();
                s.UserID = sdr["UserID"].ToString();
                s.UserName = sdr["UserName"].ToString();
                // s.UserPWD = sdr["UserPWD"].ToString();
                s.UserCompellation = sdr["UserCompellation"].ToString();

                list.Add(s);


            }
            sdr.Close();
            return list;

        }
        public static int insert(string name, string pwd, string UserCompellation)
        {
            string sql = "insert  into  admins values(@name,@pwd,@UserCompellation)";
            SqlParameter[] sps = new SqlParameter[]
      {
      new SqlParameter ("@name",name),
      new SqlParameter ("@pwd",pwd),
      new SqlParameter("@UserCompellation",UserCompellation)
      
      };
            int count = DBHelper.ExecuteNonQuery(sql, sps);
            return count;

        }
        public static int update(string name, string pname, string id)
        {
            string sql = "update admins set UserName=@name,UserCompellation=@pname where UserID=@id";
            SqlParameter[] sps = new SqlParameter[]
          {
          
            new SqlParameter ("@name",name),
           new SqlParameter ("@pname",pname),
           new SqlParameter("@id",id)
      
          
          };
            int count = DBHelper.ExecuteNonQuery(sql, sps);
            return count;

        }
        public static int database(string id)
        {
            string sql = "delete from admins where UserID=@id ";
            SqlParameter[] sps = new SqlParameter[]
          {
              new SqlParameter("@id",id)
          };
            int count = DBHelper.ExecuteNonQuery(sql, sps);
            return count;

        }

        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <param name="pwdx"></param>
        /// <returns></returns>
        public static int Update(String name, String pwd, String pwdx)
        {
            String Sql = "update Admins set UserPWD=@pwdx where UserName=@name and UserPwd=@pwd";
            SqlParameter[] Sps = new SqlParameter[]
            {
                new SqlParameter("@name",name),
                new SqlParameter("@pwd",pwd),
                new SqlParameter("@pwdx",pwdx)
            };
            return DBHelper.ExecuteNonQuery(Sql, Sps);
        }
    }
}
