using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 结果明细请求类
    /// </summary>
    public class MarketingAnalyzeDetailsRequest : PaginationRequest
    {
        /// <summary>
        /// 营销分析ID
        /// </summary>
        public string MarketingAnalyze_ID { get; set; }
    }
}
