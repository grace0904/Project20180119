using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 会员卡下的优惠券 返回实体类
    /// </summary>
    public class CouponRechargeRecordInfoResult
    {
        #region Model
        /// <summary>
        /// ID
        /// </summary>
        public string CardCoupon_ID { get; set; }
        /// <summary>
        /// 优惠券ID
        /// </summary>
        public string Coupon_ID { get; set; }
        /// <summary>
        /// 优惠券名称
        /// </summary>
        public string Coupon_Name { get; set; }
        /// <summary>
        /// 优惠券状态 0 未使用 1 已使用 9 已过期
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? FDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? LDate { get; set; }
        /// <summary>
        /// 优惠券编号
        /// </summary>
        public string Coupon_Code { get; set; }
        /// <summary>
        /// 优惠券类型 1 产品券 2 代金券
        /// </summary>
        public int Coupon_Class { get; set; }
        /// <summary>
        /// 优惠券类型名称 1 产品券 2 代金券
        /// </summary>
        public string Coupon_ClassName { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public string Product_ID { get; set; }
        /// <summary>
        /// 消费使用类型 1 消费满 2 每消费
        /// </summary>
        public int Coupon_ConsumeClass { get; set; }
        /// <summary>
        /// 消费使用金额
        /// </summary>
        public decimal Coupon_Cash { get; set; }
        /// <summary>
        /// 消费使用张数
        /// </summary>
        public int Coupon_UserNum { get; set; }
        /// <summary>
        /// 优惠券单位
        /// </summary>
        public string Coupon_Unit { get; set; }
        /// <summary>
        /// 抵扣价格
        /// </summary>
        public decimal Coupon_DeductionPrice { get; set; }
        #endregion Model
    }
}
