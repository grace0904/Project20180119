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
    
    public partial class Bas_AppClients
    {
        public string App_ID { get; set; }
        public string App_Name { get; set; }
        public string App_Key { get; set; }
        public string App_Secret { get; set; }
        public string App_Linkman { get; set; }
        public string App_LinkPhone { get; set; }
        public string App_Memo { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> OperationTime { get; set; }
        public string Operator { get; set; }
        public byte[] OptionTimestamp { get; set; }
        public Nullable<int> Del { get; set; }
    }
}
