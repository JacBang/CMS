using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Model
{
    public class Tables
    {
        /// <summary>
        /// 餐桌ID
        /// </summary>
        public String TID { get; set; }
        /// <summary>
        /// 餐桌名
        /// </summary>
        public String TName { get; set; }
        /// <summary>
        /// 房间类型ID
        /// </summary>
        public String RTID { get; set; }
        /// <summary>
        /// 所在区域
        /// </summary>
        public String TArea { get; set; }
        /// <summary>
        /// 餐桌状态 0-可用，1-占用，2-预订，3-停用
        /// </summary>
        public String TState { get; set; }

        /// <summary>
        /// 餐桌编号
        /// </summary>
        public int TableID { get; set; }
        /// <summary>
        /// 餐桌名称
        /// </summary>
        public string TableName { get; set; }
        ///// <summary>
        ///// 房间类型
        ///// </summary>
        //public int RTID { get; set; }
        /// <summary>
        /// 所在区域
        /// </summary>
        public string TableArea { get; set; }
        /// <summary>
        /// 餐桌状态
        /// </summary>
        public int TableState { get; set; }





        /// <summary>
        /// 房间类型ID对应的名字
        /// </summary>
        public string idname { get; set; }

    }
}
