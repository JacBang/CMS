using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using 商品消费查询.Model;

namespace CMS.DAL
{
    public static class ConsumerBillDAL
    {
        /// <summary>
        /// 查询最后一个账单ID
        /// </summary>
        /// <returns></returns>
        public static String SelectCBID()
        {
            String Sql = "select top 1 CBID from ConsumerBill order by CBID desc";
            return DBHelper.ExecuteScalar(Sql, null).ToString();
        }

        /// <summary>
        /// 添加账单
        /// </summary>
        /// <returns></returns>
        public static int InsertALL(String CBID, String TID, String CBA, String VID, String CBD, String CBSD, String AID, String CBS, String CBC)
        {
            String Sql = "insert into ConsumerBill values(@CBID,@TID,@CBA,@VID,@CBD,@CBSD,@CBED,@AID,@CBS,@CBC)";
            SqlParameter[] Sps = new SqlParameter[]
            {
                new SqlParameter("@CBID",CBID),
                new SqlParameter("@TID",TID),
                new SqlParameter("@CBA",CBA),
                new SqlParameter("@VID",VID),
                new SqlParameter("@CBD",CBD),
                new SqlParameter("@CBSD",CBSD),
                new SqlParameter("@CBED",DBNull.Value),
                new SqlParameter("@AID",AID),
                new SqlParameter("@CBS",CBS),
                new SqlParameter("@CBC",CBC)
            };
            return DBHelper.ExecuteNonQuery(Sql, Sps);

        }

        /// <summary>
        /// 查询当前餐台的账单ID
        /// </summary>
        /// <param name="Ct"></param>
        /// <returns></returns>
        public static String SelectCBID(String Ct)
        {
            String Sql = "select CBID from ConsumerBill where tableid=@ct and CBClose=0";
            SqlParameter[] Sps = new SqlParameter[] { new SqlParameter("@ct", Ct) };
            return DBHelper.ExecuteScalar(Sql, Sps).ToString();
        }

        /// <summary>
        /// 结账状态修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Update(String id)
        {
            String Sql = "update ConsumerBill set CBClose=1,CBEndDate=getdate() where CBID=@id";
            SqlParameter[] Sps = new SqlParameter[] { new SqlParameter("@id", id) };
            return DBHelper.ExecuteNonQuery(Sql, Sps);
        }

        /// <summary>
        /// 从A餐桌上的消费账单转移到B桌上，也就是客户换桌
        /// </summary>
        /// <param name="cbId">账单id</param>
        /// <param name="tableId">餐桌id</param>
        /// <returns></returns>
        public static int ChangeTable(string cbId, string tableId)
        {
            String Sql = "update ConsumerBill set TableID=@tableId where CBID=@cbId";
            SqlParameter[] Sps = new SqlParameter[] 
            { new SqlParameter("@cbId", cbId),
              new SqlParameter("@tableId", tableId)};
            return DBHelper.ExecuteNonQuery(Sql, Sps);
        }

        /// <summary>
        /// 查询所有已消费账单
        /// </summary>
        /// <returns></returns>
        public static List<ConsumerBill> SelectAll(String dtg, String dte)
        {
            String Sql = @"select a.*,b.tablename from ConsumerBill a inner join Tables b on a.tableid=b.tableid where a.CBClose=1
            and CBEndDate between cast(@dtg as datetime) and cast(@dte as datetime)";
            SqlParameter[] Sps = new SqlParameter[]
            {
                new SqlParameter("@dtg",dtg),
                new SqlParameter("@dte",dte)
            };
            SqlDataReader sdr = DBHelper.ExecuteReader(Sql, Sps);
            List<ConsumerBill> list = new List<ConsumerBill>();
            while (sdr.Read())
            {
                ConsumerBill c = new ConsumerBill();
                c.CBID = sdr["CBID"].ToString();
                c.TName = sdr["Tablename"].ToString();
                c.CBEndDate = sdr["CBEndDate"].ToString();
                c.CBSale = int.Parse(sdr["CBSale"].ToString());
                c.VipID = sdr["Vipid"].ToString();
                list.Add(c);
            }
            sdr.Close();
            return list;
        }


        /// <summary>
        /// 查询指定的已消费账单
        /// </summary>
        /// <returns></returns>
        public static List<ConsumerBill> SelectAll(String dateg, String datee, String Sk, String Ct)
        {
            String Sql = @"select a.*,b.tablename from ConsumerBill a 
inner join Tables b on a.tableid=b.tableid 
where a.AdminID=@sk and a.CBClose=1 and b.tablename like '%'+@ct+'%' and 
a.CBEndDate between @dtg and @dte";
            SqlParameter[] Sps = new SqlParameter[]
            {
                new SqlParameter("@sk",Sk),
                new SqlParameter("@ct",Ct),
                new SqlParameter("@dtg",dateg),
                new SqlParameter("@dte",datee),
            };
            List<ConsumerBill> list = new List<ConsumerBill>();
            SqlDataReader sdr = DBHelper.ExecuteReader(Sql, Sps);
            while (sdr.Read())
            {
                ConsumerBill c = new ConsumerBill();
                c.CBID = sdr["CBID"].ToString();
                c.TName = sdr["Tablename"].ToString();
                c.CBEndDate = sdr["CBEndDate"].ToString();
                c.CBSale = int.Parse(sdr["CBSale"].ToString());
                c.VipID = sdr["Vipid"].ToString();
                list.Add(c);
            }
            sdr.Close();
            return list;
        }
    }
}
