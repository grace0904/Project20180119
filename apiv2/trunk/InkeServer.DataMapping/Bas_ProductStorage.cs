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
    
    public partial class Bas_ProductStorage
    {
        public string ProductStorage_ID { get; set; }
        public string ShopProduct_ID { get; set; }
        public string Product_ID { get; set; }
        public int StorageNum { get; set; }
        public decimal ProductPrice { get; set; }
        public Nullable<System.DateTime> StarageTime { get; set; }
        public string ProductStorageBatch_ID { get; set; }
        public Nullable<int> LowerLimit { get; set; }
        public string Memo { get; set; }
        public string Merchant_ID { get; set; }
        public string Shop_ID { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public Nullable<System.DateTime> OperationTime { get; set; }
        public string Opertaor { get; set; }
        public Nullable<int> Del { get; set; }
    }
}
