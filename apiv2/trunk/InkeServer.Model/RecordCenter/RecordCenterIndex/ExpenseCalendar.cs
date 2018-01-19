using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 消费记录
    /// </summary>
    public class ExpenseCalendar
    {
        /// <summary>
        /// 消费总额
        /// </summary>
        public decimal TotalConsume { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal CustomConsume { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal MemberConsume { get; set; }
    }
}
