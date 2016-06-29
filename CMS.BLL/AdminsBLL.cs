using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Model;
using CMS.DAL;

namespace CMS.BLL
{
    public static class AdminsBLL
    {
        /// <summary>
        /// 用户类
        /// </summary>
        public static Admins Admins { get; set; }
        /// <summary>
        /// 判断登录是否成功
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static Admins Login(String Name, String Pwd)
        {
           return CMS.DAL.AdminsDAL.Login(Name, Pwd);
            

        }




        public static List<Admins> selectall()
        {
            return AdminsDAL.selectall();
        }
        public static bool insert(string name, string pwd, string UserCompellation)
        {
            int count = AdminsDAL.insert(name, pwd, UserCompellation);
            if (count >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        public static bool update(string name, string pname, string id)
        {
            int count = AdminsDAL.update(name, pname, id);
            if (count >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        public static bool database(string id)
        {
            int count = AdminsDAL.database(id);
            if (count >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <param name="pwdx"></param>
        /// <returns></returns>
        public static Boolean Update(String name, String pwd, String pwdx)
        {
            int count = CMS.DAL.AdminsDAL.Update(name,pwd,pwdx);
            if (count > 0)
                return true;
            else
                return false;
        }
    }
}
