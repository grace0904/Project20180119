using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 结算类型 结果集
    /// </summary>
    public class PayTypeAnalysisResult
    {
        /// <summary>
        /// 现金
        /// </summary>
        public decimal? Cash { get; set; }
        /// <summary>
        /// 银行卡
        /// </summary>
        public decimal? Bank { get; set; }
        /// <summary>
        /// 会员卡
        /// </summary>
        public decimal? Member { get; set; }
        /// <summary>
        /// 支付宝
        /// </summary>
        public decimal? Alipay { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        public decimal? Wechat { get; set; }
        /// <summary>
        /// 团购
        /// </summary>
        public decimal? Group { get; set; }
    }
}
