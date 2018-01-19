using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 营销方案名称查找
    /// </summary>
    public  class MarketingAnalyzeNameRequest:BaseRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 0是营销分析发放记录  1是自定义营销分析发放记录
        /// </summary>
        public int MarketingAnalyzeType { get; set; }
    }
}
