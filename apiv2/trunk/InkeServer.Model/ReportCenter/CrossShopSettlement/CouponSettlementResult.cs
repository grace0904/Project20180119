using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 优惠券结算 结果返回类
    /// </summary>
    public class CouponSettlementResult
    {
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shop_Name { get; set; }
        /// <summary>
        /// 优惠券名称
        /// </summary>
        public string Coupon_Name { get; set; }
        /// <summary>
        /// 剩余数量
        /// </summary>
        public int? Unused { get; set; }
        /// <summary>
        /// 抵扣数量
        /// </summary>
        public int? Used { get; set; }
        /// <summary>
        /// 未兑的
        /// </summary>
        public int? Overdue { get; set; }
        /// <summary>
        /// 总共
        /// </summary>
        public int? Total { get; set; }
    }
}
