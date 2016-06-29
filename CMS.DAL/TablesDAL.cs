using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using CMS.Model;

namespace CMS.DAL
{
    public static class TablesDAL
    {
        /// <summary>
        /// 总行数
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            String Sql = "select count(*) from Tables";
            return int.Parse(DBHelper.ExecuteScalar(Sql).ToString());
        }
        /// <summary>
        /// 传入状态查询该状态餐台数量
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static int Count(int state)
        {
            String Sql = "select count(*) from Tables where TableState=@state";
            SqlParameter[] Sps = new SqlParameter[]
            {
                new SqlParameter("@state",state)
            };
            return int.Parse(DBHelper.ExecuteScalar(Sql,Sps).ToString());
        }
        /// <summary>
        /// 上座率
        /// </summary>
        /// <returns></returns>
        public static Double Szl()
        {
            String Sql = "select count(*) from Tables where TableState=1";
            Double zy = Double.Parse(DBHelper.ExecuteScalar(Sql).ToString());
            String Sql2 = "select count(*) from Tables ";
            Double ky = Double.Parse(DBHelper.ExecuteScalar(Sql2).ToString());
            return zy / ky;
        }

        /// <summary>
        /// 餐桌查询
        /// </summary>
        /// <returns></returns>
        public static List<Tables> SelectAll(String RTID)
        {
            String Sql = "select * from Tables where RTID=@RTID";
            SqlParameter[] Sps = new SqlParameter[] { new SqlParameter("@RTID", RTID) };
            List<Tables> list = new List<Tables>();
            SqlDataReader sdr = DBHelper.ExecuteReader(Sql, Sps);
            while (sdr.Read())
            {
                Tables t = new Tables();
                t.TID = sdr["TableID"].ToString();
                t.TName = sdr["TableName"].ToString();
                t.RTID = sdr["RTID"].ToString();
                t.TArea = sdr["TableArea"].ToString();
                t.TState = sdr["TableState"].ToString();
                list.Add(t);
            }
            sdr.Close();
            return list;
        }

        public static int Zt(String tid)
        {
            String Sql = "select TableState from Tables where tableid=@tid";
            SqlParameter[] Sps = new SqlParameter[] { new SqlParameter("@tid",tid)};
            return int.Parse(DBHelper.ExecuteScalar(Sql, Sps).ToString());
            
        }
        /// <summary>
        /// 餐桌状态修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int UPdate(String id,String state)
        {
            String Sql="update Tables set Tablestate=@state where TableID=@id";
            SqlParameter[] Sps = new SqlParameter[] 
            { 
                new SqlParameter("@id",id),
                new SqlParameter("@state",state)
            };
            return DBHelper.ExecuteNonQuery(Sql, Sps);
        }


        public static List<Tables> selectall()
        {
            List<Tables> list = new List<Tables>();
            string sql = "select * from RoomType a inner join tables b on a.rtid=b.rtid";
            SqlDataReader sdr = DBHelper.ExecuteReader(sql, null);
            while (sdr.Read())
            {
                Tables t = new Tables();
                t.TName = sdr["TableName"].ToString();
                t.RTID = sdr["RTID"].ToString();

                t.idname = sdr["rtname"].ToString();
                t.TArea = sdr["TableArea"].ToString();
                string a = sdr["TableState"].ToString();
                if (a == "0")
                {
                    t.TState = "可用";
                }
                else if (a == "1")
                {

                    t.TState = "占用";
                }
                else
                {
                    t.TState = "预定";

                }
                list.Add(t);

            }
            sdr.Close();
            return list;
        }

        //更换餐台，可替换“1：可用”餐台
        public static List<RoomType> ChangeTable(int rtId, string tableArea)
        {
            List<RoomType> list = new List<RoomType>();
            string sql = "select TableID,TableName from Tables where RTID = @rtId and TableArea = @tableArea and TableState = 0";
            SqlParameter[] Sps = new SqlParameter[] 
            { 
                new SqlParameter("@rtId",rtId),
                new SqlParameter("@tableArea",tableArea)
            };
            SqlDataReader sdr = DBHelper.ExecuteReader(sql, Sps);
            while (sdr.Read())
            {
                RoomType p = new RoomType();
                p.RTName = sdr["TableName"].ToString();
                p.RTID = sdr["TableID"].ToString();
                list.Add(p);
            }
            sdr.Close();
            return list;
        }

        //控件按下事件
        public static List<Tables> selectid(int id)
        {

            List<Tables> list = new List<Tables>();
            string sql = "select * from RoomType a inner join tables b on a.rtid=b.rtid where a.rtid=@name";
            SqlParameter[] sps = new SqlParameter[]
           { 
              new SqlParameter("@name",id)
           };
            SqlDataReader sdr = DBHelper.ExecuteReader(sql, sps);
            while (sdr.Read())
            {
                Tables t = new Tables();
                t.TName = sdr["TableName"].ToString();
                t.RTID = sdr["RTID"].ToString();

                t.idname = sdr["rtname"].ToString();
                t.TArea = sdr["TableArea"].ToString();
                string a = sdr["TableState"].ToString();
                if (a == "0")
                {
                    t.TState = "可用";
                }
                else if (a == "1")
                {

                    t.TState = "占用";
                }
                else
                {
                    t.TState = "预定";

                }
                list.Add(t);

            }
            sdr.Close();
            return list;
        }
        public static int insert(string name, string qu, int lei)
        {
            string sql = "insert into tables values(@name,@lei,@qu,0) ";
            SqlParameter[] sps = new SqlParameter[]
           {
           new SqlParameter ("@name",name),
           new SqlParameter("@lei",lei),
           new SqlParameter("@qu",qu)
           
           };
            int count = DBHelper.ExecuteNonQuery(sql, sps);

            return count;
        }
        public static int database(string id)
        {
            string sql = "delete from tables where TableName=@id ";
            SqlParameter[] sps = new SqlParameter[]
           {
           
           new SqlParameter("@id",id)
           };
            int count = DBHelper.ExecuteNonQuery(sql, sps);

            return count;
        }
        public static int updata(string name, string newname, string lou, int lei)
        {

            string sql = "update  tables set tablename=@newname ,RTID=@lei,TableArea=@lou where tablename=@name ";
            SqlParameter[] sps = new SqlParameter[]
           {
           new SqlParameter ("@name",name),
             new SqlParameter ("@newname",newname),
               new SqlParameter ("@lou",lou),
                 new SqlParameter ("@lei",lei)
           
           
           
           };
            int count = DBHelper.ExecuteNonQuery(sql, sps);

            return count;

        }

    }
}
