using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Model;
using CMS.DAL;
using 商品消费查询.Model;

namespace CMS.BLL
{
   public static    class VipsConsumerBillBLL
    {
         //查询会员消费信息
       public static List<ConsumerBill> select()
       {
           return VipsConsumerBillDAL.select();
       }
              //根据会员姓名查询会员信息
       public static List<ConsumerBill> Selname(string name, string sj, string sji)
       {
           return VipsConsumerBillDAL.Selname(name ,sj,sji);
       }

              //根据会员编号查询会员信息
       public static List<ConsumerBill> Selbid(int bid, string sj, string sji)
       {
           return VipsConsumerBillDAL.Selbid (bid , sj, sji);
       }
    }
}
