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
    
    public partial class Bas_CardDiscountType
    {
        public string Discount_ID { get; set; }
        public string Discount_Name { get; set; }
        public decimal ConsumeGetIntegral { get; set; }
        public decimal ConsumeCash { get; set; }
        public decimal RechargeGetIntegral { get; set; }
        public decimal RechargeCash { get; set; }
        public decimal OpenCardGetIntegral { get; set; }
        public int Discount { get; set; }
        public int Apply { get; set; }
        public string Card_Pic { get; set; }
        public string Memo { get; set; }
        public Nullable<int> RechargeAutoUpdate { get; set; }
        public Nullable<decimal> RechargeMoney { get; set; }
        public string RechargeUpdateTo { get; set; }
        public Nullable<int> ConsumeAutoUpdate { get; set; }
        public Nullable<decimal> ConsumeMoney { get; set; }
        public string ConsumeUpdateTo { get; set; }
        public string Merchant_ID { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public Nullable<System.DateTime> OperationTime { get; set; }
        public string Operator { get; set; }
        public Nullable<int> Del { get; set; }
        public byte[] OptionTimestamp { get; set; }
    }
}