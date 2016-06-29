using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Model
{
    /// <summary>
    /// 房间类型
    /// </summary>
    public class RoomType
    {
        /// <summary>
        /// 编号
        /// </summary>
        public String RTID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public String RTName { get; set; }
        /// <summary>
        /// 最低消费
        /// </summary>
        public String RTConsume { get; set; }
        /// <summary>
        /// 是否打折，0-False，1-True
        /// </summary>
        public String RTIsDisCount { get; set; }
        /// <summary>
        /// 容纳人数
        /// </summary>
        public String RTMount { get; set; }

        ////楼层
        public string TableArea { get; set; }
    }
}
