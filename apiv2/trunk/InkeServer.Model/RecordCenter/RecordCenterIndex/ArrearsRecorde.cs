using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 挂账记录
    /// </summary>
    public class ArrearsRecorde
    {
        /// <summary>
        /// 挂账金额
        /// </summary>
        public decimal Arrears_Money { get; set; }
        /// <summary>
        /// 付款金额
        /// </summary>
        public decimal Pay_Money { get; set; }
    }
}
