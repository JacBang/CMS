using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Model
{
    public class Vips
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public String VipID { get; set; }
        /// <summary>
        /// 会员名
        /// </summary>
        public String VipName { get; set; }
        /// <summary>
        /// 会员性别
        /// </summary>
        public String VipSex { get; set; }
        /// <summary>
        /// 等级ID
        /// </summary>
        public String GradeID { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public String VipTel { get; set; }
        /// <summary>
        /// 办理日期
        /// </summary>
        public String VipStartDate { get; set; }
        /// <summary>
        /// 到期日期
        /// </summary>
        public String VipEndDate { get; set; }
        /// <summary>
        /// 会员等级名
        /// </summary>
        public String VipGname { get; set; }
        /// <summary>
        /// 会员折扣率
        /// </summary>
        public String VipGD { get; set; }


        

        /// <summary>
        /// 等级名称
        /// </summary>
        public string VGName { get; set; }
        /// <summary>
        /// 等级折扣
        /// </summary>
        public double VGDiscount { get; set; }

    }
}
