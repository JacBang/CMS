using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Model;
using System.Data.SqlClient;
using System.Data;
using 商品消费查询.Model;

namespace CMS.DAL
{
   public static  class VipsConsumerBillDAL
    {
       //查询会员消费信息
       public static List<ConsumerBill> select()
       {
           List<ConsumerBill> list = new List<ConsumerBill>();
           string sql = string.Format(@"select a.VipID,VipName,CBID,VGDiscount*CBSale as money,CBSale from Vips a 
inner join ConsumerBill b on a.VipID=b.VipID
inner join VIPGrade c on a.GradeID=c.VGID ");
           SqlDataReader sdr = DBHelper.ExecuteReader(sql);
           while (sdr.Read())
           {
               ConsumerBill CB = new ConsumerBill();
               CB.VID = Convert.ToInt32(sdr["VipID"]);
               CB.VipName = sdr["VipName"].ToString();
               CB.CBID = sdr["CBID"].ToString();
               CB.money = Convert.ToInt32(sdr["money"]);
               CB.CBSale =Convert .ToInt32 ( sdr["CBSale"]);
               list.Add(CB );
           }
           sdr.Close();
           return list;
       }

       //根据会员姓名查询会员信息
       public static List<ConsumerBill> Selname(string name, string sj,string sji)
       {
           List<ConsumerBill> list = new List<ConsumerBill>();
           string sql = string.Format(@"select a.VipID,VipName,CBID,VGDiscount*CBSale as money,CBSale from Vips a 
inner join ConsumerBill b on a.VipID=b.VipID
inner join VIPGrade c on a.GradeID=c.VGID   where VipName like  '%'+@name+'%'  and CBStartDate between @sj  and @sji");
           SqlParameter[] sps = new SqlParameter[]
           {
           new SqlParameter ("@name",name ),
            new SqlParameter ("@sj",sj),
             new SqlParameter ("@sji",sji )
           };
           SqlDataReader sdr = DBHelper.ExecuteReader(sql,sps );
           while (sdr.Read())
           {
               ConsumerBill CB = new ConsumerBill();
               CB.VID = Convert.ToInt32(sdr["VipID"]);
               CB.VipName = sdr["VipName"].ToString();
               CB.CBID = sdr["CBID"].ToString();
               CB.money = Convert.ToInt32(sdr["money"]);
               CB.CBSale = Convert.ToInt32(sdr["CBSale"]);
               list.Add(CB);
           }
           sdr.Close();
           return list;
       }



       //根据会员编号查询会员信息
       public static List<ConsumerBill> Selbid(int  bid, string sj, string sji)
       {
           List<ConsumerBill> list = new List<ConsumerBill>();
           string sql = string.Format(@"select a.VipID,VipName,CBID,VGDiscount*CBSale as money,CBSale from Vips a 
inner join ConsumerBill b on a.VipID=b.VipID
inner join VIPGrade c on a.GradeID=c.VGID   where a.VipID  =@bid  and CBStartDate between @sj  and @sji");
           SqlParameter[] sps = new SqlParameter[]
           {
           new SqlParameter ("@bid",bid  ),
            new SqlParameter ("@sj",sj),
             new SqlParameter ("@sji",sji )
           };
           SqlDataReader sdr = DBHelper.ExecuteReader(sql, sps);
           while (sdr.Read())
           {
               ConsumerBill CB = new ConsumerBill();
               CB.VID = Convert.ToInt32(sdr["VipID"]);
               CB.VipName = sdr["VipName"].ToString();
               CB.CBID = sdr["CBID"].ToString();
               CB.money = Convert.ToInt32(sdr["money"]);
               CB.CBSale = Convert.ToInt32(sdr["CBSale"]);
               list.Add(CB);
           }
           sdr.Close();
           return list;
       }
    }
}
