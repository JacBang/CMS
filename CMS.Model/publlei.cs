using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Model
{
  public   class publlei
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public static  int VipID { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public static  string VipName { get; set; }
        /// <summary>
        /// 会员性别
        /// </summary>
        public static  string VipSex { get; set; }
        /// <summary>
        /// 等级ID
        /// </summary>
        public static  int GradeID { get; set; }
      /// <summary>
      /// 会员等级
      /// </summary>
        public static string Grname { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public static  string VipTel { get; set; }
        /// <summary>
        /// 办理日期
        /// </summary>
        public static  string VipStartDate { get; set; }
        /// <summary>
        /// 到期日期
        /// </summary>
        public static  string VipEndDate { get; set; }
    }
}
