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
    
    public partial class Bas_Account
    {
        public string Account_ID { get; set; }
        public string Account_Login { get; set; }
        public string Account_Password { get; set; }
        public string Account_Memo { get; set; }
        public Nullable<int> Account_Status { get; set; }
        public Nullable<int> Account_LoginPOS { get; set; }
        public Nullable<int> Account_LoginKFT { get; set; }
        public Nullable<int> Account_LoginCRM { get; set; }
        public string Employee_ID { get; set; }
        public string Position_ID { get; set; }
        public string Merchant_ID { get; set; }
        public string Shop_ID { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public Nullable<System.DateTime> OperationTime { get; set; }
        public string Operator { get; set; }
        public Nullable<int> Del { get; set; }
        public byte[] OptionTimestamp { get; set; }
        public Nullable<int> Account_LoginINPOS { get; set; }
    }
}