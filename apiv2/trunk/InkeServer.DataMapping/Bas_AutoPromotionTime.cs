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
    
    public partial class Bas_AutoPromotionTime
    {
        public string AutoPromotionTime_Id { get; set; }
        public string AutoPromotion_Id { get; set; }
        public int TimeType { get; set; }
        public string Weekday { get; set; }
        public string MonthDay { get; set; }
        public string YearMonth { get; set; }
        public string YearDay { get; set; }
        public string HourBegin { get; set; }
        public string MinuteBegin { get; set; }
        public string HourEnd { get; set; }
        public string MinuteEnd { get; set; }
        public System.DateTime AddTime { get; set; }
        public int Status { get; set; }
    }
}