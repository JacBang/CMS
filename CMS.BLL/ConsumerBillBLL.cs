using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 商品消费查询.Model;

namespace CMS.BLL
{
    public static class ConsumerBillBLL
    {
        /// <summary>
        /// 查询最后一个账单ID
        /// </summary>
        /// <returns></returns>
        public static String SelectCBID()
        {
            return CMS.DAL.ConsumerBillDAL.SelectCBID();
        }

        /// <summary>
        /// 添加账单
        /// </summary>
        /// <param name="CBID"></param>
        /// <param name="TID"></param>
        /// <param name="CBA"></param>
        /// <param name="VID"></param>
        /// <param name="CBD"></param>
        /// <param name="CBSD"></param>
        /// <param name="CBED"></param>
        /// <param name="AID"></param>
        /// <param name="CBS"></param>
        /// <param name="CBC"></param>
        /// <returns></returns>
        public static Boolean InsertALL(String CBID, String TID, String CBA, String VID, String CBD, String CBSD, String AID, String CBS, String CBC)
        {
            int count = CMS.DAL.ConsumerBillDAL.InsertALL(CBID, TID, CBA, VID, CBD, CBSD, AID, CBS, CBC);
            if (count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 查询当前餐台的账单ID
        /// </summary>
        public static String SelectCBID(String Ct)
        {
            return CMS.DAL.ConsumerBillDAL.SelectCBID(Ct);
        }

        /// <summary>
        /// 结账状态修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Boolean Update(String id)
        {
            int count = CMS.DAL.ConsumerBillDAL.Update(id);
            if (count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 从A餐桌上的消费账单转移到B桌上，也就是客户换桌
        /// </summary>
        /// <param name="cbId">账单id</param>
        /// <param name="tableId">餐桌id</param>
        /// <returns></returns>
        public static Boolean ChangeTable(string cbId, string tableId)
        {
            int count = CMS.DAL.ConsumerBillDAL.ChangeTable(cbId, tableId);
            if (count > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// 查询所有已消费账单
        /// </summary>
        /// <returns></returns>
        public static List<ConsumerBill> SelectAll(String dtg,String dte)
        {
            return CMS.DAL.ConsumerBillDAL.SelectAll(dtg,dte);
        }

         /// <summary>
        /// 查询指定的已消费账单
        /// </summary>
        /// <returns></returns>
        public static List<ConsumerBill> SelectAll(String dateg, String datee, String Sk, String Ct)
        {
            return CMS.DAL.ConsumerBillDAL.SelectAll(dateg, datee, Sk, Ct);
        }
    }
}
