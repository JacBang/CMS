using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.DAL;
using 商品消费查询.Model;

namespace CMS.BLL
{
    public static  class CDBLL
    {
        public static List<ConsumerDetails> Select(string sj, string sji)
        {
            return CDDAL.Select( sj ,sji );

        }

        public static List<ConsumerDetails> SelectbyTname(string sj, string sji, string name)
        {
            return CDDAL.SelectbyTname(sj ,sji ,name  );
        }

        public static List<ConsumerDetails> SelectbyPname(string sj,string sji,string names)
        {
            return CDDAL.SelectbyPname(sj,sji,names);
        }

        /// <summary>
       /// 查询指定账单的消费信息
       /// </summary>
       /// <returns></returns>
        public static List<ConsumerDetails> SelectX(String cbid)
        {
            return CMS.DAL.CDDAL.SelectX(cbid);
        }

        /// <summary>
       /// 添加消费详单
       /// </summary>
        public static Boolean Insert(ConsumerDetails c)
        {
            int count = CMS.DAL.CDDAL.Insert(c);
            if (count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 修改消费类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Boolean Update(String id)
        {
            int count = CMS.DAL.CDDAL.Update(id);
            if (count > 0)
                return true;
            else
                return false;
        }
    }
}
