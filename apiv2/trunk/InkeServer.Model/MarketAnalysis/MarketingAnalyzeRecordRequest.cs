using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    ///  发放记录查找
    /// </summary>
    public class MarketingAnalyzeRecordRequest : PaginationRequest
    {
        #region
        /// <summary>
        /// 0是营销分析发放记录  1是自定义营销分析发放记录
        /// </summary>
        public int MarketingAnalyzeType { get; set; }
        /// <summary>
        /// 方案ID
        /// </summary>
        public string MarketingAnalyze_ID { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 发放日期起始
        /// </summary>
        public DateTime? DateForm { get; set; }
        /// <summary>
        /// 发放日期结束
        /// </summary>
        public DateTime? DateTo { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string Member_Name { get; set; }
        public string Merchant_ID { get; set; }
        #endregion
    }
}
