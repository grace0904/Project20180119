using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 营销分析/自定义营销活动 添加和更改 请求类
    /// </summary>
    public class MarketAnalysisAddOrUpdateRequest:BaseRequest
    {
        /// <summary>
        /// 赠送优惠券列表 
        /// </summary>
        public List<GivenCouponInfo> CouponList = new List<GivenCouponInfo>();
        /// <summary>
        /// 店铺列表   使用逗号隔开
        /// </summary>
        public string ShopIds { get; set; }
        #region model
        /// <summary> 
        ///  MarketingAnalyze_ID 
        ///</summary> 
        public string MarketingAnalyze_ID { get; set; }
        /// <summary> 
        ///  方案名称 
        ///</summary> 
        public string MarketingAnalyze_Name { get; set; }

        /// <summary> 
        ///  商家ID 
        ///</summary> 
        public string Merchant_ID { get; set; }

        /// <summary> 
        ///  是否自动执行  0否 1是   
        ///</summary> 
        public int AutoExec { get; set; }
        /// <summary> 
        ///  年龄开始     
        ///</summary> 
        public int AgeStart { get; set; }
        /// <summary> 
        ///  年龄结束 
        ///</summary> 
        public int AgeEnd { get; set; }
        /// <summary> 
        ///  性别 0 不限    1男  2女 
        ///</summary> 
        public int Sex { get; set; }
        /// <summary> 
        ///  折扣类型ID 
        ///</summary> 
        public string CardDiscountType_ID { get; set; }
        /// <summary> 
        ///  会员卡剩余积分 开始 
        ///</summary> 
        public decimal ResidueIntegralStart { get; set; }
        /// <summary> 
        ///  会员卡剩余积分  结束 
        ///</summary> 
        public decimal ResidueIntegralEnd { get; set; }
        /// <summary> 
        ///  会员卡剩余金额开始 
        ///</summary> 
        public decimal ResidueMoneyStart { get; set; }
        /// <summary> 
        ///  会员卡剩余金额结束 
        ///</summary> 
        public decimal ResidueMoneyEnd { get; set; }
        /// <summary> 
        ///  是否勾选开卡日期  0否 1是 
        ///</summary> 
        public int OpenCardValidity { get; set; }
        /// <summary> 
        ///  开卡日期开始 
        ///</summary> 
        public DateTime? OpenCardDateStart { get; set; }
        /// <summary> 
        ///  开卡日期结束 
        ///</summary> 
        public DateTime? OpenCardDateEnd { get; set; }
        /// <summary> 
        ///  是否勾选了生日  0否 1是 
        ///</summary> 
        public int BirthdayValidity { get; set; }
        /// <summary> 
        ///  生日开始 
        ///</summary> 
        public string BirthdayStart { get; set; }
        /// <summary> 
        ///  生日结束 
        ///</summary> 
        public string BirthdayEnd { get; set; }
        /// <summary> 
        ///  消费日期开始 
        ///</summary> 
        public DateTime? ConsumeDateStart { get; set; }
        /// <summary> 
        ///  消费日期结束 
        ///</summary> 
        public DateTime? ConsumeDateEnd { get; set; }
        /// <summary> 
        ///  消费次数开始 
        ///</summary> 
        public int ConsumeCountStart { get; set; }
        /// <summary> 
        ///  消费次数 结束 
        ///</summary> 
        public int ConsumeCountEnd { get; set; }
        /// <summary> 
        ///  单笔消费金额开始 
        ///</summary> 
        public decimal SimpleConsumeMoneyStart { get; set; }
        /// <summary> 
        ///  单笔消费金额结束 
        ///</summary> 
        public decimal SimpleConsumeMoneyEnd { get; set; }
        /// <summary> 
        ///  累计消费金额开始 
        ///</summary> 
        public decimal CountCunsumeMoneyStart { get; set; }
        /// <summary> 
        ///  累计消费金额结束 
        ///</summary> 
        public decimal CountCunsumeMoneyEnd { get; set; }
        /// <summary> 
        ///  充值次数开始 
        ///</summary> 
        public int RechargeCountStart { get; set; }
        /// <summary> 
        ///  充值次数结束 
        ///</summary> 
        public int RechargeCountEnd { get; set; }
        /// <summary> 
        ///  单次充值金额开始 
        ///</summary> 
        public decimal SimpleRechargeMoneyStart { get; set; }
        /// <summary> 
        ///  单次充值金额结束 
        ///</summary> 
        public decimal SimpleRechargeMoneyEnd { get; set; }
        /// <summary> 
        ///  累计充值金额开始 
        ///</summary> 
        public decimal CountRechargeMoneyStart { get; set; }
        /// <summary> 
        ///  累计充值金额 
        ///</summary> 
        public decimal CountRechargeMoneyEnd { get; set; }
        /// <summary> 
        ///  单次消费人数 开始 
        ///</summary> 
        public int SimpleConsumePeopleStart { get; set; }
        /// <summary> 
        ///  单次消费人数 结束 
        ///</summary> 
        public int SimpleConsumePeopleEnd { get; set; }
        /// <summary> 
        ///  积分抵扣次数 开始 
        ///</summary> 
        public int CountIntegralDeductionStart { get; set; }
        /// <summary> 
        ///  积分抵扣次数 结束 
        ///</summary> 
        public int CountIntegralDeductionEnd { get; set; }
        /// <summary> 
        ///  会员未消费天数 
        ///</summary> 
        public int NotConsumeDay { get; set; }
        /// <summary> 
        ///  累计积分 开始 
        ///</summary> 
        public decimal IntegralTotalStart { get; set; }
        /// <summary> 
        ///  累计积分 结束 
        ///</summary> 
        public decimal IntegralTotalEnd { get; set; }
        /// <summary> 
        ///  消费产品ID 空为不限 
        ///</summary> 
        public string ConsumeProduct_ID { get; set; }
        /// <summary> 
        ///  消费产品开始 
        ///</summary> 
        public int CountConsumeProductStart { get; set; }
        /// <summary> 
        ///  消费产品结束 
        ///</summary> 
        public int CountConsumeProductEnd { get; set; }
        /// <summary> 
        ///  消费优惠券ID 
        ///</summary> 
        public string ConsumeCoupon_ID { get; set; }
        /// <summary> 
        ///  记录统计的个数 
        ///</summary> 
        public int StatisticsTotal { get; set; }
        /// <summary> 
        ///  赠送积分 
        ///</summary> 
        public decimal GivenIntegral { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        #endregion
    }
}
