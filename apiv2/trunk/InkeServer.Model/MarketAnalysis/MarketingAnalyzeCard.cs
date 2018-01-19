using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 要发放的卡列表
    /// </summary>
    public class MarketingAnalyzeCard
    {
        /// <summary>
        /// Card_ID
        /// </summary>
        public string Card_ID { get; set; }
        /// <summary>
        /// Member_ID
        /// </summary>
        public string Member_ID { get; set; }
        /// <summary>
        /// Card_ID
        /// </summary>
        public string Card_BusinessID { get; set; }
    }
}
