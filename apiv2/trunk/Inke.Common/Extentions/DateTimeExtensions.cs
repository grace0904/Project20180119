using System;

namespace System
{
    public static class DateTimeExtensions
    {
        public static string DefaultFormat(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
