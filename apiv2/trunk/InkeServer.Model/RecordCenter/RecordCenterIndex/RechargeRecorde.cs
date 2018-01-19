using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 充值记录
    /// </summary>
    public class RechargeRecorde
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal RechargeMoney { get; set; }
        
    }
}
