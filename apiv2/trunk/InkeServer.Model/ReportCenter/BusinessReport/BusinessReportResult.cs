using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 营业报表 结果集
    /// </summary>
    public class BusinessReportResult
    {
        #region 收入统计
        /// <summary>
        /// 现金支付数量
        /// </summary>
        public int CashPayQuantity { get; set; }
        /// <summary>
        /// 现金支付统计
        /// </summary>
        public decimal CashPayMoney { get; set; }
        /// <summary>
        /// 银行卡支付数量
        /// </summary>
        public int BankCardPayQuantity { get; set; }
        /// <summary>
        /// 银行卡支付统计
        /// </summary>
        public decimal BankCardPayMoney { get; set; }
        /// <summary>
        /// 会员卡支付数量
        /// </summary>
        public int MemberCardPayQuantity { get; set; }
        /// <summary>
        /// 会员卡支付统计
        /// </summary>
        public decimal MemberCardPayMoney { get; set; }
        /// <summary>
        /// 支付宝支付数量
        /// </summary>
        public int AliPayPayQuantity { get; set; }
        /// <summary>
        /// 支付宝支付统计
        /// </summary>
        public decimal AliPayPayMoney { get; set; }
        /// <summary>
        /// 微信支付数量
        /// </summary>
        public int WeiXinPayQuantity { get; set; }
        /// <summary>
        /// 微信支付统计
        /// </summary>
        public decimal WeiXinPayMoney { get; set; }
        /// <summary>
        /// 团购券支付数量
        /// </summary>
        public int GroupBuyPayQuantity { get; set; }
        /// <summary>
        /// 团购券支付统计
        /// </summary>
        public decimal GroupBuyPayMoney { get; set; }
        #region 充值统计(实收)

        /// <summary>
        /// 现金充值数量
        /// </summary>
        public int CashRechargeQuantity { get; set; }
        /// <summary>
        /// 现金充值总数
        /// </summary>
        public decimal CashRechargeMoney { get; set; }
        /// <summary>
        /// 现金充值赠送数量
        /// </summary>
        public int CashRechargeGivenQuantity { get; set; }
        /// <summary>
        /// 现金充值赠送
        /// </summary>
        public decimal CashRechargeGivenMoney { get; set; }

        /// <summary>
        /// 现金预充值数量
        /// </summary>
        public int CashPresetRechargeQuantity { get; set; }
        /// <summary>
        /// 现金预充值实收
        /// </summary>
        public decimal CashPresetRechargeMoney { get; set; }
        /// <summary>
        /// 银行卡预充值数量
        /// </summary>
        public int BankCardPresetRechargeQuantity { get; set; }
        /// <summary>
        /// 银行卡预充值实收
        /// </summary>
        public decimal BankCardPresetRechargeMoney { get; set; }

        /// <summary>
        /// 银行卡充值数量
        /// </summary>
        public int BankCardRechargeQuantity { get; set; }
        /// <summary>
        /// 银行卡充值总数
        /// </summary>
        public decimal BankCardRechargeMoney { get; set; }
        /// <summary>
        /// 银行卡充值赠送数量
        /// </summary>
        public int BankCardRechargeGivenQuantity { get; set; }
        /// <summary>
        /// 银行卡充值赠送
        /// </summary>
        public decimal BankCardRechargeGivenMoney { get; set; }



        #endregion

        #endregion

        #region 消费情况

        /// <summary>
        /// 会员消费数量
        /// </summary>
        public int MemberConsumeQuantity { get; set; }
        /// <summary>
        /// 会员消费统计
        /// </summary>
        public decimal MemberConsumeMoney { get; set; }
        /// <summary>
        /// 散客消费数量
        /// </summary>
        public int IndividualConsumeQuantity { get; set; }
        /// <summary>
        /// 散客消费统计
        /// </summary>
        public decimal IndividualConsumeMoney { get; set; }

        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal ConsumeMoney { get; set; }
        /// <summary>
        /// 赠送金额
        /// </summary>
        public decimal GivneMoney { get; set; }
        /// <summary>
        /// 抹零数量
        /// </summary>
        public int ReduceMantissaQuantity { get; set; }
        /// <summary>
        /// 抹零金额
        /// </summary>
        public decimal ReduceMantissaMoney { get; set; }
        /// <summary>
        /// 折扣抵扣数量
        /// </summary>
        public int DiscountQuantity { get; set; }
        /// <summary>
        /// 折扣抵扣金额
        /// </summary>
        public decimal DiscountMoney { get; set; }
        /// <summary>
        /// 优惠券抵扣数量
        /// </summary>
        public int CouponQuantity { get; set; }
        /// <summary>
        /// 优惠券抵扣金额
        /// </summary>
        public decimal CouponMoney { get; set; }
        /// <summary>
        /// 积分抵扣数量
        /// </summary>
        public int IntegralQuantity { get; set; }
        /// <summary>
        /// 积分抵扣金额
        /// </summary>
        public decimal IntegralMoney { get; set; }
        /// <summary>
        /// 折后金额
        /// </summary>
        public decimal FinalMoney { get; set; }
        /// <summary>
        /// 挂帐数量
        /// </summary>
        public int GuaZhangQuantity { get; set; }
        /// <summary>
        /// 挂帐金额
        /// </summary>
        public decimal GuaZhangMoney { get; set; }

        #endregion

        #region 订单信息
        //--------------订单信息--------------------
        /// <summary>
        /// 订单总数
        /// </summary>
        public int OrderTotal { get; set; }
        /// <summary>
        /// 单均消费
        /// </summary>
        public decimal OrderAverage { get; set; }
        /// <summary>
        /// 订单总人数
        /// </summary>
        public int OrderPeopleTotal { get; set; }
        /// <summary>
        /// 人均消费
        /// </summary>
        public decimal PeopleAverage { get; set; }

        #endregion

        #region 新增会员信息
        //---------------新增会员信息------------------------
        /// <summary>
        /// 新增会员总数
        /// </summary>
        public int NewMemberTotal { get; set; }
        /// <summary>
        /// 新增开卡总数
        /// </summary>
        public int OpenCardTotal { get; set; }


        #endregion

        #region 积分信息
        //-----------------积分信息-------------------------
        /// <summary>
        /// 消费获得积分
        /// </summary>
        public decimal ConsumeAddIntegral { get; set; }
        /// <summary>
        /// 充值获得积分
        /// </summary>
        public decimal RechargeAddIntegral { get; set; }
        /// <summary>
        /// 开卡获得积分
        /// </summary>
        public decimal OpenCardAddIntegral { get; set; }
        /// <summary>
        /// 开卡获得预充值积分
        /// </summary>
        public decimal OpenCardPresetAddIntegral { get; set; }
        /// <summary>
        /// 导入积分
        /// </summary>
        public decimal ImportAddIntegral { get; set; }
        /// <summary>
        /// 积分调整增加积分
        /// </summary>
        public decimal AdjustAddIntegral { get; set; }
        /// <summary>
        /// 自动促销增加积分
        /// </summary>
        public decimal AutoPromotionAddIntegral { get; set; }
        /// <summary>
        /// 兑换减少积分
        /// </summary>
        public decimal ExchangeIntegral { get; set; }
        /// <summary>
        /// 消费抵扣积分
        /// </summary>
        public decimal ConsumePayIntegral { get; set; }
        /// <summary>
        /// 积分调整减少积分
        /// </summary>
        public decimal AdjustReduceIntegral { get; set; }
        /// <summary>
        /// 清除积分
        /// </summary>
        public decimal ClearIntegral { get; set; }

        #endregion

        #region 会员信息
        //---------------------会员信息-------------------------
        /// <summary>
        /// 会员卡统计
        /// </summary>
        public int CardTotal { get; set; }
        /// <summary>
        /// 卡余额统计
        /// </summary>
        public decimal CashTotal { get; set; }
        /// <summary>
        /// 卡积分统计
        /// </summary>
        public decimal IntegralTotal { get; set; }
        /// <summary>
        /// 剩余优惠券总金额
        /// </summary>
        public decimal SurplusCardCouponMoneyTotal { get; set; }

        #endregion
    }
}
