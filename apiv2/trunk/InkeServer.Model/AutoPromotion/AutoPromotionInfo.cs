using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
   public   class AutoPromotionInfo
    {
        /// <summary>
        /// 优惠劵集合
        /// </summary>
       public IList<GivenCouponInfo> CouponList { get; set; }
        /// <summary>
        /// 促销店铺
        /// </summary>
        public IList<string> ShopNames { get; set; }
        #region model

        /// <summary>
        /// 自动促销ID
        /// </summary>
        public string Promotion_ID { get; set; }

        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_Id { get; set; }

        /// <summary>
        /// 店铺ID-暂时留空
        /// </summary>
        public string Shop_Id { get; set; }

        /// <summary>
        /// 自动促销名称
        /// </summary>
        public string PromotionName { get; set; }

        /// <summary>
        /// 1新会员促销2充值促销3消费促销4积分促销5日期促销
        /// </summary>
        public int PromotionType { get; set; }

        /// <summary>
        /// 0 不有效期 1 限制有效期
        /// </summary>
        public int? ValidityType { get; set; }
        /// <summary>
        ///  是否可享受多次优惠  0否 1是
        /// </summary>
        public int? MultiplePromotion { get; set; }

        /// <summary>
        ///  是否设置会员生日时间时间段  0否 1是
        /// </summary>
        public int? ValidityBirthDay { get; set; }
        /// <summary>
        /// 会员生日时间时间段开始 
        /// </summary>
        public string BirthDayStartDate { get; set; }

        /// <summary>
        /// 会员生日时间时间段结束
        /// </summary>
        public string BirthDayEndDate { get; set; }
        /// <summary>
        /// 有效期起始
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// 有效期结束
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// 消费金额起止
        /// </summary>
        public decimal? ConsumeFrom { get; set; }

        /// <summary>
        /// 消费金额结束
        /// </summary>
        public decimal? ConsumeTo { get; set; }

        /// <summary>
        /// 积分总数起始
        /// </summary>
        public int? IntegralTotalFrom { get; set; }

        /// <summary>
        /// 积分总数结束
        /// </summary>
        public int? IntegralTotalTo { get; set; }

        /// <summary>
        /// 充值起始金额
        /// </summary>
        public decimal? ChargeAmountFrom { get; set; }

        /// <summary>
        /// 充值金额结束
        /// </summary>
        public decimal? ChargeAmountTo { get; set; }

        /// <summary>
        /// 节日名称
        /// </summary>
        public string FestivalName { get; set; }

        /// <summary>
        /// 节日促销日期
        /// </summary>
        public DateTime? FestivalDate { get; set; }

        /// <summary>
        /// 节日提前下发天数
        /// </summary>
        public int? BeforeDays { get; set; }

        /// <summary>
        /// 单品促销产品ID
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// 产品促销数量起始
        /// </summary>
        public int ProductQuantityFrom { get; set; }

        /// <summary>
        /// 产品促销数量结束
        /// </summary>
        public int ProductQuantityTo { get; set; }

        /// <summary>
        /// 促销有效店铺列表
        /// </summary>
        public string PromotionShopIds { get; set; }

        /// <summary>
        /// 0全部1男2女
        /// </summary>
        public int? PromotionGender { get; set; }

        /// <summary>
        /// 自动促销卡类型ID字符串：ID1，ID2
        /// </summary>
        public string PromotionCardTypeIds { get; set; }

        /// <summary>
        /// 0 所有会员  1 生日会员
        /// </summary>
        public int? MemberType { get; set; }

        /// <summary>
        /// 优惠劵ID
        /// </summary>
        public string Coupon_Id { get; set; }

        /// <summary>
        /// 优惠劵数量
        /// </summary>
        public int CouponQuantity { get; set; }

        /// <summary>
        /// 赠送积分数量
        /// </summary>
        public int? GivenIntegral { get; set; }

        /// <summary>
        /// 积分赠送倍数
        /// </summary>
        public int? GivenIntegralMultiple { get; set; }

        /// <summary>
        /// 0 停止 1 生效
        /// </summary>
        public int? State { get; set; }

        /// <summary>
        /// 累计时间开始
        /// </summary>
        public DateTime? TotalDateStart { get; set; }
        /// <summary>
        /// 操作时间结束
        /// </summary>
        public DateTime? TotalDateEnd { get; set; }

        /// <summary>
        /// 操作者
        /// </summary>
        public string Operator { get; set; }

        #endregion Model
    }
}
