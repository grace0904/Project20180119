using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 发放记录 返回类 
    /// </summary>
    public  class MarketingAnalyzeRecord
    {
        /// <summary>
        /// ID
        /// </summary>
        public string MarketingAnalyzeRecord_ID { get; set; }

        /// <summary>
        /// 营销分析名称
        /// </summary>
        public string MarketingAnalyze_Name { get; set; }

        /// <summary>
        /// 赠送积分
        /// </summary>
        public decimal? GivenIntegral { get; set; }

        /// <summary>
        /// 赠送优惠券名称
        /// </summary>
        public List<string > Coupon_Name { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string Card_Num { get; set; }

        /// <summary>
        /// 会员姓名
        /// </summary>
        public string Member_Name { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Member_MobilePhone { get; set; }
        /// <summary>
        /// 发放时间
        /// </summary>
        public DateTime? ExecuteTime { get; set; }
    }
}
