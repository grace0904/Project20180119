using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 分页查询 营销分析/自定义营销集合  请求类
    /// </summary>
    public class MarketAnalysisQueryRequest : PaginationRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }


        /// <summary>
        /// 是否是自动执行 0否(营销分析) 1是（自定义营销）
        /// </summary>
        public int AutoExec { get; set; }
    }
}
