using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 商品消费查询.Model
{
   public  class ConsumerBill
    {
       /// <summary>
       /// 账单编号
       /// </summary>
       public string CBID { get; set; }
       /// <summary>
       /// 餐桌编号
       /// </summary>
       public int TableID { get; set; }
       /// <summary>
       /// 顾客人数
       /// </summary>
       public int CBAmount { get; set; }
       /// <summary>
       /// 会员编号
       /// </summary>
       public string VipID { get; set; }
       /// <summary>
       /// 会员折扣率
       /// </summary>
       public int CBDiscount { get; set; }
       /// <summary>
       /// 开单时间
       /// </summary>
       public string CBStartDate { get; set; }
       /// <summary>
       /// 结账时间
       /// </summary>
       public string CBEndDate { get; set; }
       /// <summary>
       /// 收银员编号
       /// </summary>
       public int AdminID { get; set; }
       /// <summary>
       /// 消费金额
       /// </summary>
       public int CBSale { get; set; }
       /// <summary>
       /// 是否结账
       /// </summary>
       public int CBClose { get; set; }

       /// <summary>
       /// 会员编号
       /// </summary>
       public int VID { get; set; }
       /// <summary>
       /// 会员姓名
       /// </summary>
       public string VipName { get; set; }
       /// <summary>
       /// 实收金额
       /// </summary>
       public int money { get; set; }

       public String TName { get; set; }
    }
}
