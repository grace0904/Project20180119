using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 分页获取优惠券集合 请求类
    /// </summary>
    public class CouponsQueryRequest : PaginationRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 优惠劵分类ID
        /// </summary>
        public string MerchantBaseInfo_ID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Coupon_Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Coupon_Name { get; set; }
        /// <summary>
        /// 价格--用于条件筛选
        /// </summary>
        public decimal? Coupon_BeginBuyPrice { get; set; }

        /// <summary>
        /// 价格-用于条件筛选
        /// </summary>
        public decimal? Coupon_EndBuyPrice { get; set; }
    }
}
