using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 余额记录
    /// </summary>
    public class CashRecorde
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal Cash { get; set; }
    }
}
