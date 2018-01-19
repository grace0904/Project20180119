using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 优惠券使用情况 统计结果返回类 
    /// </summary>
    public class CouponMemoryUsageResult
    {
        /// <summary>
        /// 优惠券ID
        /// </summary>
        public string Coupon_ID { get; set; }
        /// <summary>
        /// 优惠券价格
        /// </summary>
        public decimal Coupon_BuyPrice { get; set; }

        /// <summary>
        /// 优惠券名称
        /// </summary>
        public string Coupon_Name { get; set; }
        /// <summary>
        /// 剩余数量
        /// </summary>
        public int Unused { get; set; }
        /// <summary>
        /// 剩余数量百分比
        /// </summary>
        public string UnusedPercent { get; set; }
        /// <summary>
        ///  使用数量
        /// </summary>
        public int Used { get; set; }
        /// <summary>
        ///使用数量百分比
        /// </summary>
        public string UsedPercent { get; set; }
        /// <summary>
        ///过期数量
        /// </summary>
        public int Overdue { get; set; }
        /// <summary>
        /// 过期数量百分比
        /// </summary>
        public string OverduePercent { get; set; }
        /// <summary>
        /// 总计
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 总计百分比
        /// </summary>
        public string TotalPercent { get; set; }
    }
}
