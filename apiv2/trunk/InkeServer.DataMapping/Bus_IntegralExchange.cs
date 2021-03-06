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
    
    public partial class Bus_IntegralExchange
    {
        public string Exchange_ID { get; set; }
        public string Business_Num { get; set; }
        public string IntegralProduct_ID { get; set; }
        public string ShopIntegralProduct_ID { get; set; }
        public string Product_Name { get; set; }
        public Nullable<decimal> Product_Price { get; set; }
        public Nullable<int> ProductQuantity { get; set; }
        public string Coupon_ID { get; set; }
        public string Coupon_Name { get; set; }
        public Nullable<decimal> Coupon_Price { get; set; }
        public Nullable<int> CouponQuantity { get; set; }
        public Nullable<decimal> Exchange_Cash { get; set; }
        public decimal DeductIntegral { get; set; }
        public string Card_ID { get; set; }
        public string Card_BusinessID { get; set; }
        public string Member_ID { get; set; }
        public string User_ID { get; set; }
        public string Merchant_ID { get; set; }
        public string Shop_ID { get; set; }
        public string Memo { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public Nullable<System.DateTime> OperationTime { get; set; }
        public string Operator { get; set; }
        public string Terminal { get; set; }
        public Nullable<int> Del { get; set; }
        public Nullable<int> Adjust { get; set; }
    }
}
