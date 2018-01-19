using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 添加/修改 优惠券请求类
    /// </summary>
    public class AddOrUpdateCouponsRequest : BaseRequest
    {
        /// <summary>
        /// 优惠劵可用店铺ID拼接字符串（,隔开）例如：ID1,ID2
        /// </summary>
        [DisplayName("优惠劵可用店铺")]
        public string UsableShopList { get; set; }
        #region Model
        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public string Coupon_ID { get; set; }
        /// <summary>
        /// 优惠劵种类ID-生日劵，红包劵，代金券等
        /// </summary>
        [DisplayName("优惠劵种类")]
        public string MerchantBaseInfo_ID { get; set; }
        /// <summary>
        /// 优惠券名称
        /// </summary>
        [DisplayName("优惠券名称")]
        public string Coupon_Name { get; set; }
        /// <summary>
        /// 优惠券编号
        /// </summary>
        [DisplayName("优惠券编号")]
        public string Coupon_Code { get; set; }
        /// <summary>
        /// 优惠券简码
        /// </summary>
        [DisplayName("优惠券简码")]
        public string Coupon_BriefCode { get; set; }
        /// <summary>
        /// 优惠券类型 1 产品券 2 代金券
        /// </summary>
        [DisplayName("优惠券类型")]
        public int Coupon_Class { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        [DisplayName("产品ID")]
        public string Product_ID { get; set; }
        /// <summary>
        /// 消费使用类型 1 消费满 2 每消费
        /// </summary>
        [DisplayName("消费使用类型")]
        public int Coupon_ConsumeClass { get; set; }
        /// <summary>
        /// 消费使用金额
        /// </summary>
        [DisplayName("消费使用金额")]
        public decimal Coupon_Cash { get; set; }
        /// <summary>
        /// 消费使用张数
        /// </summary>
        [DisplayName("消费使用张数")]
        public int Coupon_UserNum { get; set; }
        /// <summary>
        /// 优惠券单位
        /// </summary>
        [DisplayName("优惠券单位")]
        public string Coupon_Unit { get; set; }
        /// <summary>
        /// 购买价格
        /// </summary>
        [DisplayName("购买价格")]
        public decimal Coupon_BuyPrice { get; set; }
        /// <summary>
        /// 抵扣价格
        /// </summary>
        [DisplayName("抵扣价格")]
        public decimal Coupon_DeductionPrice { get; set; }
        /// <summary>
        /// 有效期类型 0 不限有效期 1 按日期 2 按天数
        /// </summary>
        [DisplayName("有效期类型")]
        public int Coupon_Validity { get; set; }
        /// <summary>
        /// 有效期起始日期
        /// </summary>
        [DisplayName("有效期起始日期")]
        public DateTime? Coupon_FDate { get; set; }
        /// <summary>
        /// 有效期结束日期
        /// </summary>
        [DisplayName("有效期结束日期")]
        public DateTime? Coupon_LDate { get; set; }
        /// <summary>
        /// 有效期天数
        /// </summary>
        [DisplayName("有效期天数")]
        public int? Coupon_DateNum { get; set; }
        /// <summary>
        /// 允许积分兑换 0 否 1 是
        /// </summary>
        [DisplayName("允许积分兑换")]
        public int Coupon_IntegralExchange { get; set; }
        /// <summary>
        /// 兑换所需积分
        /// </summary>
        [DisplayName("兑换所需积分")]
        public decimal? Coupon_Integral { get; set; }
        /// <summary>
        /// 优惠券图片大
        /// </summary>
        [DisplayName("优惠券图片大")]
        public string Coupon_BPic { get; set; }
        /// <summary>
        /// 优惠券图片小
        /// </summary>
        [DisplayName("优惠券图片小")]
        public string Coupon_SPic { get; set; }
        /// <summary>
        /// 优惠券状态 0 停用 1 正常
        /// </summary>
        [DisplayName("优惠券状态")]
        public int Coupon_Status { get; set; }
        /// <summary>
        /// 所属商家
        /// </summary>
        [DisplayName("所属商家")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]
        public string Operator { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string Memo { get; set; }


        #endregion Model
    }
}
