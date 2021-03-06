//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace InkeServer.DataMapping
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bas_MerchantConfig
    {
        public string MerchantConfig_ID { get; set; }
        public string Merchant_ID { get; set; }
        public string BusinessScope_ID { get; set; }
        public Nullable<int> SmsCount { get; set; }
        public Nullable<int> ConsumeAutoUpdate { get; set; }
        public Nullable<int> RechargeAutoUpdate { get; set; }
        public Nullable<int> Pop { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal IntegralRate { get; set; }
        public decimal CashRate { get; set; }
        public int IntegraClear { get; set; }
        public Nullable<System.DateTime> IntegraEndTime { get; set; }
        public Nullable<System.DateTime> IntegraClearTime { get; set; }
        public Nullable<int> IntegraClearBeforeSms { get; set; }
        public Nullable<int> IntegraClearBeforeDate { get; set; }
        public Nullable<int> IntegraClearFinishSms { get; set; }
        public Nullable<int> SpanMonthAdjust { get; set; }
        public Nullable<int> ConsumeInputType { get; set; }
        public Nullable<int> DeductMoneyAutoInput { get; set; }
        public Nullable<int> ShowAffirm { get; set; }
        public Nullable<int> OnlyCardConsume { get; set; }
        public Nullable<int> NotEditRate { get; set; }
        public Nullable<int> CanCloseIntegra { get; set; }
        public Nullable<int> MemberMultiCard { get; set; }
        public Nullable<int> CardNumberNull { get; set; }
        public Nullable<int> IntegraConvertManualInput { get; set; }
        public Nullable<int> OpenTakeAway { get; set; }
        public Nullable<int> OpenReservation { get; set; }
        public Nullable<int> OpenSelfOrder { get; set; }
        public Nullable<int> OpenSelfPay { get; set; }
        public string taste { get; set; }
        public string MainScope { get; set; }
        public string SpecialRequire { get; set; }
        public string Introduce { get; set; }
        public string Number { get; set; }
        public Nullable<int> ReduceMantissaSet { get; set; }
        public Nullable<System.DateTime> OperationTime { get; set; }
        public string Operator { get; set; }
        public byte[] OptionTimestamp { get; set; }
    }
}
