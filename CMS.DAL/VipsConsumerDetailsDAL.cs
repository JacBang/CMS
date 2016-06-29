using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Model;
using System.Data.SqlClient;

namespace CMS.DAL
{
   public static  class VipsConsumerDetailsDAL
    {
       //查询会员消费项目编号查询
       public static List<ConsumerDetail> SelCD(string Cid)
       {
           List<ConsumerDetail> list = new List<ConsumerDetail>();
           string sql = string.Format(@"select ProductName,CDAmount,CDPrice from Products  a
 inner join ProductType b on a.ProductID=b.PTID
inner join ConsumerDetail c on  a.ProductID=c.ProdcutID
inner join ConsumerBill d on c.CBID=d.CBID where d.CBID=@Cid");
           SqlParameter[] sps = new SqlParameter[]
          {
          new SqlParameter ("@Cid",Cid )
          };
           SqlDataReader sdr = DBHelper.ExecuteReader(sql,sps );
           while (sdr.Read())
           {
               ConsumerDetail Cd = new ConsumerDetail();
               Cd.Name = sdr["ProductName"].ToString();
               Cd.CDAmount =Convert.ToInt32 ( sdr["CDAmount"]);
               Cd.CDPrice = Convert.ToInt32 (sdr["CDPrice"]);
               list.Add(Cd);
           }
           sdr.Close();
           return list;

       }
    }
}
