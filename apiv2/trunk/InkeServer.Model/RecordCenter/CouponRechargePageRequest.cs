using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 优惠券充值记录查询 请求实体类
    /// </summary>
    public class CouponRechargePageRequest : PaginationRequest
    {
        #region
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID列表  以逗号隔开 如：ID1,ID2,ID3
        /// </summary>
        public string ShopGroup { get; set; }
        /// <summary>
        /// 业务号
        /// </summary>
        public string Business_Num { get; set; }
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string Card_Num { get; set; }
        /// <summary>
        /// 会员手机号
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 优惠券名称
        /// </summary>
        public string Coupon_Name { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? DateFrom { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? DateTo { get; set; }
       
        #endregion
    }
}
