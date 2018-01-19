using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 自动促销时间表 基础类 
    /// </summary>
    public class AutoPromotionTime
    {
        #region Model
        /// <summary>
        /// 
        /// </summary>
        public string AutoPromotionTime_Id
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string AutoPromotion_Id
        {
            set;
            get;
        }
        /// <summary>
        /// 1：周，2：月，3：年
        /// </summary>
        public int TimeType
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Weekday
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string MonthDay
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string YearMonth
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string YearDay
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string HourBegin
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string MinuteBegin
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string HourEnd
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string MinuteEnd
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set;
            get;
        }
        #endregion Model
    }
}
