using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Model;
using CMS.DAL;

namespace CMS.BLL
{
    public static class TablesBLL
    {
        /// <summary>
        /// 餐台总数
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            return CMS.DAL.TablesDAL.Count();
        }
        /// <summary>
        /// 传入状态查询该状态餐台数量
        /// </summary>
        public static int Count(int state)
        {
            return CMS.DAL.TablesDAL.Count(state);
        }
        /// <summary>
        /// 上座率
        /// </summary>
        /// <returns></returns>
        public static Double Szl()
        {
            return CMS.DAL.TablesDAL.Szl();
        }


        public static List<Tables> SelectAll(String RTID)
        {
            return CMS.DAL.TablesDAL.SelectAll(RTID);
        }

        /// <summary>
        /// 餐桌状态
        /// </summary>
        public static int Zt(String tid)
        {
            return CMS.DAL.TablesDAL.Zt(tid);
        }

        /// <summary>
        /// 餐桌状态修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Boolean UPdate(String id, String state)
        {
            int count=CMS.DAL.TablesDAL.UPdate(id,state);
            if (count > 0)
                return true;
            else
                return false;
        }



        public static List<Tables> selectall()
        {
            return TablesDAL.selectall();
        }

        //更换餐台，可替换“1：可用”餐台
        public static List<RoomType> ChangeTable(int rtId, string tableArea)
        {
            return TablesDAL.ChangeTable(rtId, tableArea);
        }

        public static List<Tables> selectid(int id)
        {
            return TablesDAL.selectid(id);
        }
        public static bool insert(string name, string qu, int lei)
        {
            int b = TablesDAL.insert(name, qu, lei);
            if (b >= 1)
            {
                return true;
            }
            else
                return false;
        }
        public static bool database(string id)
        {
            int b = TablesDAL.database(id);
            if (b >= 1)
            {
                return true;
            }
            else
                return false;
        }
        public static bool updata(string name, string newname, string lou, int lei)
        {
            int b = TablesDAL.updata(name, newname, lou, lei);
            if (b >= 1)
            {
                return true;
            }
            else
                return false;
        }


    }
}
