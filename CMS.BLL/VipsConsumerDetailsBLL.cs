using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Model;
using System.Data.SqlClient;
using System.Data;
using CMS.DAL;

namespace CMS.BLL
{
  public static   class VipsConsumerDetailsBLL
    {
             //查询会员消费项目编号查询
      public static List<ConsumerDetail> SelCD(string Cid)
      {
          return VipsConsumerDetailsDAL.SelCD(Cid );
      }
    }
}
