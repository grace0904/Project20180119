using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class MerchantConfigInfo
    {
        #region
        public string MerchantConfig_ID { get; set; }
        public string Merchant_ID { get; set; }
        public string BusinessScope_ID { get; set; }
        public int? SmsCount { get; set; }
        public int? ConsumeAutoUpdate { get; set; }
        public int? RechargeAutoUpdate { get; set; }
        public int? Pop { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal IntegralRate { get; set; }
        public decimal CashRate { get; set; }
        public int IntegraClear { get; set; }
        public string IntegraEndTime { get; set; }
        public string IntegraClearTime { get; set; }
        public int? IntegraClearBeforeSms { get; set; }
        public int? IntegraClearBeforeDate { get; set; }
        public int? IntegraClearFinishSms { get; set; }
        public int? SpanMonthAdjust { get; set; }
        public int? ConsumeInputType { get; set; }
        public int? DeductMoneyAutoInput { get; set; }
        public int? ShowAffirm { get; set; }
        public int? OnlyCardConsume { get; set; }
        public int? NotEditRate { get; set; }
        public int? CanCloseIntegra { get; set; }
        public int? MemberMultiCard { get; set; }
        public int? CardNumberNull { get; set; }
        public int? IntegraConvertManualInput { get; set; }
        public int? OpenTakeAway { get; set; }
        public int? OpenReservation { get; set; }
        public int? OpenSelfOrder { get; set; }
        public int? OpenSelfPay { get; set; }
        public string Taste { get; set; }
        public string MainScope { get; set; }
        public string SpecialRequire { get; set; }
        public string Introduce { get; set; }
        public string Number { get; set; }
        public int? ReduceMantissaSet { get; set; }
        public string Operator { get; set; }
        /// <summary>
        /// 商家名称
        /// </summary>
        public string Merchant_Name { get; set; }

        /// <summary>
        /// 商家简称
        /// </summary>
        public string Merchant_ShortName { get; set; }
        #endregion
    }
}
