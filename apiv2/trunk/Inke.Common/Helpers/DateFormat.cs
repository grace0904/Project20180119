using System;

namespace Inke.Common.Helpers
{
    public class DateFormat
    {
        /// <summary>
        /// 格式化日期为纯日期格式（yyyy-MM-dd）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime FormatDateToDate(string dateTime)
        {
            DateTime result=Convert.ToDateTime("1900-01-01");

            return result;
        }

        /// <summary>
        /// 格式化日期为纯日期格式（yyyy-MM-dd 00:00:00）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DateTime FormatDateToDateTime(string dateTime)
        { 
            DateTime result=Convert.ToDateTime("1900-01-01");

            return result;
        }
    }
}
