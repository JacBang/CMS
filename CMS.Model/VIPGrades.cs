using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Model
{
   public  class VIPGrades
    {
       /// <summary>
       /// 等级编号
       /// </summary>
       public int VGID { get; set; }
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
