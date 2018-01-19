using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 优惠券基础类
    /// </summary>
    [Serializable]
    public class CouponInfo
    {
        #region Model
        /// <summary>
        /// ID
        /// </summary>
        public string Coupon_ID { get; set; }
        /// <summary>
        /// 优惠劵种类ID-生日劵，红包劵，代金券等
        /// </summary>
        public string MerchantBaseInfo_ID { get; set; }
        /// <summary>
        /// 优惠券名称
        /// </summary>
        public string Coupon_Name { get; set; }
        /// <summary>
        /// 优惠券编号
        /// </summary>
        public string Coupon_Code { get; set; }
        /// <summary>
        /// 优惠券简码
        /// </summary>
        public string Coupon_BriefCode { get; set; }
        /// <summary>
        /// 优惠券类型 1 产品券 2 代金券
        /// </summary>
        public int Coupon_Class { get; set; }
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
        /// 购买价格
        /// </summary>
        public decimal Coupon_BuyPrice { get; set; }
        /// <summary>
        /// 抵扣价格
        /// </summary>
        public decimal Coupon_DeductionPrice { get; set; }
        /// <summary>
        /// 有效期类型 0 不限有效期 1 按日期 2 按天数
        /// </summary>
        public int Coupon_Validity { get; set; }
        /// <summary>
        /// 有效期起始日期
        /// </summary>
        public DateTime? Coupon_FDate { get; set; }
        /// <summary>
        /// 有效期结束日期
        /// </summary>
        public DateTime? Coupon_LDate { get; set; }
        /// <summary>
        /// 有效期天数
        /// </summary>
        public int? Coupon_DateNum { get; set; }
        /// <summary>
        /// 允许积分兑换 0 否 1 是
        /// </summary>
        public int Coupon_IntegralExchange { get; set; }
        /// <summary>
        /// 兑换所需积分
        /// </summary>
        public decimal? Coupon_Integral { get; set; }
        /// <summary>
        /// 优惠券图片大
        /// </summary>
        public string Coupon_BPic { get; set; }
        /// <summary>
        /// 优惠券图片小
        /// </summary>
        public string Coupon_SPic { get; set; }
        /// <summary>
        /// 优惠券状态 0 停用 1 正常
        /// </summary>
        public int Coupon_Status { get; set; }
        /// <summary>
        /// 所属商家
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperationTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 已删除 1-是，0-否 
        /// </summary>
        public int? Del { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
   
    
        #endregion Model
        
    }
}
