using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 赠送优惠券
    /// </summary>
    public class GivenCouponInfo
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Coupon_Name { get; set; }
        /// <summary> 
        ///  Coupon_ID 
        ///</summary> 
        public string Coupon_ID { get; set; }
        /// <summary> 
        ///   优惠券数量 
        ///</summary> 
        public int CouponQuantity { get; set; }
    }
}
