using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 分页获取可用优惠券集合 请求类
    /// </summary>
    public class AvailableCouponQueryRequest : PaginationRequest
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
        /// 名称
        /// </summary>
        public string Coupon_Name { get; set; }
        /// <summary>
        /// 可用店铺 用逗号分隔
        /// </summary>
        public string Shop_ID { get; set; }
    }
}
