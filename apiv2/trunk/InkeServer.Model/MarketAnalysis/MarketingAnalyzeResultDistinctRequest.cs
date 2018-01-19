using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 营销分析结果明细  筛选 请求类
    /// </summary>
    public class MarketingAnalyzeResultDistinctRequest : PaginationRequest
    {
        /// <summary>
        /// 当前的MarketingAnalyze_ID
        /// </summary>
        public string MarketingAnalyze_ID { get; set; }

        /// <summary>
        /// 要筛选的MarketingAnalyze_ID   用逗号隔开
        /// </summary>
        public string DistinctMarketingAnalyze_ID { get; set; }
    }
}
