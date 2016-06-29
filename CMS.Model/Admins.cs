using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Model
{
    /// <summary>
    /// 管理员用户
    /// </summary>
    public class Admins
    {
        /// <summary>
        /// 编号
        /// </summary>
        public String UserID { get; set; }
        /// <summary>
        /// 账户
        /// </summary>
        public String UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public String UserPwd { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public String UserCompellation { get; set; }
    }
}
