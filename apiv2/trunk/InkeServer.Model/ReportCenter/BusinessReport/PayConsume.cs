using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
   public class PayConsume
    {
       /// <summary>
       /// 总数
       /// </summary>
       public decimal PayCount { get; set; }
       /// <summary>
       /// 金额
       /// </summary>
       public decimal PayMoney { get; set; }
       /// <summary>
       /// 类型
       /// </summary>
        public int PayType { get; set; }
    }
}
