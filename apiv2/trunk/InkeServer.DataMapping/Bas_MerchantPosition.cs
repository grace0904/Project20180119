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
    
    public partial class Bas_MerchantPosition
    {
        public string Position_ID { get; set; }
        public string Position_Code { get; set; }
        public string Position_Name { get; set; }
        public string Position_Parent { get; set; }
        public string Merchant_ID { get; set; }
        public string Shop_ID { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public Nullable<System.DateTime> OperationTime { get; set; }
        public string Operator { get; set; }
        public Nullable<int> Del { get; set; }
        public byte[] OptionTimestamp { get; set; }
    }
}
