using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 自动促销基础类
    /// </summary>
    public class AutoPromotion
    {
        #region Model

        /// <summary>
        /// 累计时间开始
        /// </summary>
        public DateTime? TotalDateStart
        {
            get;
            set;
        }

        public DateTime? TotalDateEnd
        {
            get;
            set;
        }

        /// <summary>
        /// 自动促销ID
        /// </summary>
        public string Promotion_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_Id
        {
            set;
            get;
        }
        /// <summary>
        /// 店铺ID-暂时留空
        /// </summary>
        public string Shop_Id
        {
            set;
            get;
        }
        /// <summary>
        /// 自动促销名称
        /// </summary>
        public string PromotionName
        {
            set;
            get;
        }
        /// <summary>
        /// 1新会员促销2充值促销3消费促销4积分促销5日期促销
        /// </summary>
        public int PromotionType
        {
            set;
            get;
        }
        /// <summary>
        /// 0 不有效期 1 限制有效期
        /// </summary>
        public int? ValidityType
        {
            set;
            get;
        }
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
        public DateTime? DateFrom
        {
            set;
            get;
        }
        /// <summary>
        /// 有效期结束
        /// </summary>
        public DateTime? DateTo
        {
            set;
            get;
        }
        /// <summary>
        /// 消费金额起止
        /// </summary>
        public decimal? ConsumeFrom
        {
            set;
            get;
        }
        /// <summary>
        /// 消费金额结束
        /// </summary>
        public decimal? ConsumeTo
        {
            set;
            get;
        }
        /// <summary>
        /// 积分总数起始
        /// </summary>
        public int? IntegralTotalFrom
        {
            set;
            get;
        }
        /// <summary>
        /// 积分总数结束
        /// </summary>
        public int? IntegralTotalTo
        {
            set;
            get;
        }
        /// <summary>
        /// 充值起始金额
        /// </summary>
        public decimal? ChargeAmountFrom
        {
            set;
            get;
        }
        /// <summary>
        /// 充值金额结束
        /// </summary>
        public decimal? ChargeAmountTo
        {
            set;
            get;
        }
        /// <summary>
        /// 节日名称
        /// </summary>
        public string FestivalName
        {
            set;
            get;
        }
        /// <summary>
        /// 节日促销日期
        /// </summary>
        public DateTime? FestivalDate
        {
            set;
            get;
        }
        /// <summary>
        /// 节日提前下发天数
        /// </summary>
        public int? BeforeDays
        {
            set;
            get;
        }



        /// <summary>
        /// 单品促销产品ID
        /// </summary>
        public string ProductId
        {
            set;
            get;
        }
        /// <summary>
        /// 产品促销数量起始
        /// </summary>
        public int? ProductQuantityFrom
        {
            set;
            get;
        }
        /// <summary>
        /// 产品促销数量结束
        /// </summary>
        public int? ProductQuantityTo
        {
            set;
            get;
        }
        /// <summary>
        /// 促销有效店铺列表-暂时留空
        /// </summary>
        public string PromotionShopIds
        {
            set;
            get;
        }
        /// <summary>
        /// 0全部1男2女
        /// </summary>
        public int? PromotionGender
        {
            set;
            get;
        }
        /// <summary>
        /// 自动促销卡类型ID字符串：ID1，ID2
        /// </summary>
        public string PromotionCardTypeIds
        {
            set;
            get;
        }
        /// <summary>
        /// 0 所有会员  1 生日会员
        /// </summary>
        public int? MemberType
        {
            set;
            get;
        }
        /// <summary>
        /// 优惠劵ID-暂时留空
        /// </summary>
        public string Coupon_Id
        {
            set;
            get;
        }
        /// <summary>
        /// 优惠劵数量-暂时留空
        /// </summary>
        public int? CouponQuantity
        {
            set;
            get;
        }
        /// <summary>
        /// 赠送积分数量
        /// </summary>
        public int? GivenIntegral
        {
            set;
            get;
        }
        /// <summary>
        /// 积分赠送倍数
        /// </summary>
        public int? GivenIntegralMultiple
        {
            set;
            get;
        }
        /// <summary>
        /// 0 停止 1 生效
        /// </summary>
        public int? State
        {
            set;
            get;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime
        {
            set;
            get;
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperationTime
        {
            set;
            get;
        }
        /// <summary>
        /// 操作者
        /// </summary>
        public string Operator
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartUseDate
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastExecDate
        {
            set;
            get;
        }
        #endregion Model
    }
}
