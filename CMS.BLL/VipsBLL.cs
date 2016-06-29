using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using CMS.Model;
using CMS.DAL;

namespace CMS.BLL
{
    public static class VipsBLL
    {
        /// <summary>
        /// 查询会员折扣
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static String SelectCBD(String id)
        {
            return CMS.DAL.VipsDAL.SelectCBD(id).ToString();
        }

       /// <summary>
       /// 检索会员是否存在
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public static Boolean SelectID(String id)
        {
            SqlDataReader sdr = CMS.DAL.VipsDAL.SelectID(id);
            if (sdr.Read())
                return true;
            else
                return false;
        }


        public static List<VipGrade> selectvip()
        {
            return VipsDAL.selectvip();
        }
        public static bool insert(string jiname, string zhe)
        {
            int count = VipsDAL.insert(jiname, zhe);
            if (count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool update(VipGrade list)
        {

            int count = VipsDAL.update(list);
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
            int count = VipsDAL.database(id);
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
        /// 结账会员查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Vips Select(String id)
        {
            return CMS.DAL.VipsDAL.Select(id);
        }

        //查询全部会员信息
        public static List<Vips> select()
        {
            return VipsDAL.select();
        }

        //查询会员等级表
        public static List<VIPGrades> selVG()
        {
            return VipsDAL.selVG();
        }

        //查询最大的ID
        public static int selectID()
        {
            return VipsDAL.selectID();
        }
        //添加会员
        public static bool Insert(Vips v)
        {
            int count = VipsDAL.Insert(v);
            return count >= 1 ? true : false;

        }
        //修改会员
        public static bool upbyid(Vips v)
        {
            int count = VipsDAL.upbyid(v);
            return count >= 1 ? true : false;
        }
        //根据编号删除会员
        public static bool delete(int id)
        {
            int count = VipsDAL.delete(id);
            return count >= 1 ? true : false;
        }

        //根据编号或者姓名查询会员信息
        public static List<Vips> Sel(string Sid)
        {

            return VipsDAL.Sel(Sid);
        }
        public static List<Vips> Sel(int Sidi)
        {

            return VipsDAL.Sel(Sidi);
        }
    }
}
