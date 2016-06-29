using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Model;
using CMS.DAL;

namespace CMS.BLL
{
    public static class RoomTypeBLL
    {
        /// <summary>
        /// 房间类型查询
        /// </summary>
        /// <returns></returns>
        public static List<RoomType> Select()
        {
            return CMS.DAL.RoomTypeDAL.Select();
        }

        /// <summary>
        /// 餐桌人数查询
        /// </summary>
        /// <returns></returns>
        public static List<String> Select(String id)
        {
            return CMS.DAL.RoomTypeDAL.Select(id);
        }


        public static List<RoomType> selectall()
        {
            return RoomTypeDAL.selectall();
        }
        public static bool insert(string name, string shu)
        {
            int b = RoomTypeDAL.insert(name, shu);
            if (b >= 1)
            {
                return true;
            }
            else
                return false;
        }
        public static bool update(string name, string id, string newname)
        {
            int b = RoomTypeDAL.update(name, id, newname);
            if (b >= 1)
            {
                return true;
            }
            else
                return false;
        }
        public static bool database(string id)
        {

            int b = RoomTypeDAL.database(id);
            if (b >= 1)
            {
                return true;
            }
            else
                return false;
        }
    }
}
