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
    
    public partial class Bas_AutoPromotion
    {
        public string Promotion_ID { get; set; }
        public string Merchant_Id { get; set; }
        public string Shop_Id { get; set; }
        public string PromotionName { get; set; }
        public int PromotionType { get; set; }
        public Nullable<int> MultiplePromotion { get; set; }
        public string BirthDayStartDate { get; set; }
        public string BirthDayEndDate { get; set; }
        public Nullable<int> ValidityBirthDay { get; set; }
        public Nullable<int> ValidityType { get; set; }
        public Nullable<System.DateTime> DateFrom { get; set; }
        public Nullable<System.DateTime> DateTo { get; set; }
        public Nullable<decimal> ConsumeFrom { get; set; }
        public Nullable<decimal> ConsumeTo { get; set; }
        public Nullable<int> IntegralTotalFrom { get; set; }
        public Nullable<int> IntegralTotalTo { get; set; }
        public Nullable<decimal> ChargeAmountFrom { get; set; }
        public Nullable<decimal> ChargeAmountTo { get; set; }
        public Nullable<System.DateTime> TotalDateStart { get; set; }
        public Nullable<System.DateTime> TotalDateEnd { get; set; }
        public string FestivalName { get; set; }
        public Nullable<System.DateTime> FestivalDate { get; set; }
        public Nullable<int> BeforeDays { get; set; }
        public string ProductId { get; set; }
        public Nullable<int> ProductQuantityFrom { get; set; }
        public Nullable<int> ProductQuantityTo { get; set; }
        public string PromotionShopIds { get; set; }
        public Nullable<int> PromotionGender { get; set; }
        public string PromotionCardTypeIds { get; set; }
        public Nullable<int> MemberType { get; set; }
        public string Coupon_Id { get; set; }
        public Nullable<int> CouponQuantity { get; set; }
        public Nullable<int> GivenIntegral { get; set; }
        public Nullable<int> GivenIntegralMultiple { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public Nullable<System.DateTime> OperationTime { get; set; }
        public string Operator { get; set; }
        public Nullable<System.DateTime> StartUseDate { get; set; }
        public Nullable<System.DateTime> LastExecDate { get; set; }
    }
}
