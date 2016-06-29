using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Model;
using System.Data.SqlClient;

namespace CMS.DAL
{
    public static class RoomTypeDAL
    {
        /// <summary>
        /// 房间类型查询
        /// </summary>
        /// <returns></returns>
        public static List<RoomType> Select()
        {
            List<RoomType> list = new List<RoomType>();
            String Sql = "select * from RoomType";
            SqlDataReader sdr = DBHelper.ExecuteReader(Sql);
            while (sdr.Read())
            {
                RoomType r = new RoomType();
                r.RTID = sdr["RTID"].ToString();
                r.RTName = sdr["RTName"].ToString();
                r.RTConsume = sdr["RTConsume"].ToString();
                r.RTIsDisCount = sdr["RTIsDisCount"].ToString();
                r.RTMount = sdr["RTMount"].ToString();
                list.Add(r);
            }
            sdr.Close();
            return list;
        }
        /// <summary>
        /// 餐桌人数查询
        /// </summary>
        /// <returns></returns>
        public static List<String> Select(String id)
        {
            List<String> list = new List<String>();
            String Sql = "select RTName,RTMount from tables a inner join RoomType b on a.RTID=b.RTID where tableid=@id";
            SqlParameter[] Sps = new SqlParameter[] { new SqlParameter("@id", id) };
            SqlDataReader sdr = DBHelper.ExecuteReader(Sql, Sps);
            while (sdr.Read())
            {
                list.Add(sdr["RTName"].ToString());
                list.Add(sdr["RTMount"].ToString());
            }
            sdr.Close();
            return list;
        }

        public static List<RoomType> selectall()
        {
            List<RoomType> list = new List<RoomType>();
            string sql = "select * from RoomType ";

            SqlDataReader sdr = DBHelper.ExecuteReader(sql, null);
            while (sdr.Read())
            {
                RoomType p = new RoomType();
                p.RTName = sdr["RTName"].ToString();
                p.RTID = sdr["RTID"].ToString();

                //  p.TableArea = sdr["TableArea"].ToString();
                p.RTMount = sdr["RTMount"].ToString();
                list.Add(p);
            }
            sdr.Close();
            return list;
        }

        public static int insert(string name, string shu)
        {
            string sql = "insert into RoomType  values(@name,null,null,@shu) ";
            SqlParameter[] sps = new SqlParameter[]
       {
       new SqlParameter("@name",name),
       new SqlParameter("@shu",shu)
       
       };
            int count = DBHelper.ExecuteNonQuery(sql, sps);

            return count;

        }

        public static int update(string name, string id, string newname)
        {
            string sql = "update  RoomType set RTMount=@id ,RTName=@newname where RTName=@name";
            SqlParameter[] sps = new SqlParameter[]
       {
       new SqlParameter("@name",name),
         new SqlParameter("@newname",newname),
       new SqlParameter("@id",id)
       
       };
            int count = DBHelper.ExecuteNonQuery(sql, sps);

            return count;

        }
        public static int database(string id)
        {
            string sql = "delete from RoomType where rtname=@id ";
            SqlParameter[] sps = new SqlParameter[]
       {
       new SqlParameter("@id",id)
       
       };
            int count = DBHelper.ExecuteNonQuery(sql, sps);

            return count;

        }
    }
}
