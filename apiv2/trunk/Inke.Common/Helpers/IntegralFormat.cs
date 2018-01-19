using System;

namespace Inke.Common.Helpers
{
    public static class IntegralFormat
    {
        public static string IntegralSub(this decimal num, int pointleng)
        {
            int index = num.ToString().IndexOf('.');
            if (index != -1)
            {
                string reStr = num.ToString("0.00000000000000000000").Substring(0, index + pointleng + 1);
                return Convert.ToDecimal(reStr).ToString("0.0");
            }
            else
            {
                return num.ToString("0.0");
            }
        }
    }
}
