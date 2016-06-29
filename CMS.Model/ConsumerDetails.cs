﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 商品消费查询.Model
{
    public class ConsumerDetails
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int CDID { get; set; }
        /// <summary>
        /// 账单编号
        /// </summary>
        public string  CBID { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public String ProName { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProdcutID { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public double CDPrice { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int CDAmount { get; set; }
        /// <summary>
        /// 优惠金额
        /// </summary>
        public int CDSale { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public double CDMoney { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        public int CDType { get; set; }
        /// <summary>
        /// 点单时间
        /// </summary>
        public string   CDDate { get; set; }
        /// <summary>
        /// 餐台名字
        /// </summary>
        public string Tname { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public string Pname { get; set; }


        /// <summary>
        /// 消费项目
        /// </summary>
        public string Name { get; set; }

    }
}
