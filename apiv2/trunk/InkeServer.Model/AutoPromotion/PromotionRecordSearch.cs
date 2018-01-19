using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 营销中心发放记录请求实体类
    /// </summary>
    public class PromotionRecordSearch : PaginationRequest
    {
        #region
        /// <summary>
        /// 方案类型
        /// </summary>
        public string PromotionType { get; set; }
        /// <summary>
        /// 方案ID
        /// </summary>
        public string Promotion_ID { get; set; }

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
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        #endregion
    }
}
