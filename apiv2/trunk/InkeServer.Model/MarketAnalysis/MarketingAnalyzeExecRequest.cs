using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 营销分析发放类
    /// </summary>
    public class MarketingAnalyzeExecRequest : BaseRequest
    {
        /// <summary>
        /// 要赠送的卡列表
        /// </summary>
        public List<MarketingAnalyzeCard> MarketingAnalyzeList = new List<MarketingAnalyzeCard>();
        /// <summary> 
        ///  MarketingAnalyze_ID 
        ///</summary> 
        public string MarketingAnalyze_ID { get; set; }
        /// <summary> 
        ///  商家ID 
        ///</summary> 
        public string Merchant_ID { get; set; }
        /// <summary> 
        ///  操作人
        ///</summary> 
        public string Operater { get; set; }
    }
}
