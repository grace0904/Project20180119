using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Inke.Common.Extentions
{
    public static class TypeExtentions
    {
        /// <summary>
        /// 结构类型转换
        /// </summary>
        /// <typeparam name="T">struct</typeparam>
        /// <param name="obj">要转换的对象</param>
        /// <returns></returns>
        public static T ConvertTo<T>(this object obj) where T : struct
        {
            try
            {
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            catch { return default(T); }
        }

        /// <summary>
        /// 类型尝试转换
        /// </summary>
        /// <typeparam name="T">struct</typeparam>
        /// <param name="obj">要转换的对象</param>
        /// <returns></returns>
        public static T ChangeType<T>(this object obj) where T : class
        {
            try
            {
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            catch { return default(T); }
        }

        /// <summary>
        /// 把源实例的属性值赋值到目标实例的属性中，不可读/写的属性无法赋值
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <param name="source">源实例</param>
        /// <param name="target">目标实例</param>
        /// <returns></returns>
        public static bool TypeAssign<T>(this T source, T target) where T : class
        {
            try
            {
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    if (!prop.CanRead || !prop.CanWrite)
                        continue;

                    prop.SetValue(target, prop.GetValue(source, null), null);
                }

                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 把源实例的属性值赋值到目标实例的属性中，不可读/写的属性无法赋值
        /// </summary>
        /// <typeparam name="T1">源实例类型</typeparam>
        /// <typeparam name="T2">目标实例类型</typeparam>
        /// <param name="source">源实例</param>
        /// <param name="target">目标实例</param>
        /// <returns></returns>
        public static void TypeAssign<T1, T2>(this T1 source, T2 target)
        {
            foreach (PropertyInfo prop in typeof(T1).GetProperties())
            {
                if (!prop.CanRead)
                    continue;

                foreach (PropertyInfo subProp in typeof(T2).GetProperties())
                {
                    if (!subProp.CanWrite || prop.Name != subProp.Name)
                        continue;

                    subProp.SetValue(target, prop.GetValue(source, null), null);
                }
            }
        }

        /// <summary>
        /// 获取byte数组转换为十六进制字符串
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static string ToHexString(this byte[] byteArray)
        {
            StringBuilder strHex = new StringBuilder();

            foreach (byte b in byteArray)
            {
                strHex.Append(b.ToString("X2", System.Globalization.CultureInfo.CurrentCulture));
            }

            return strHex.ToString();
        }

        /// <summary>
        /// 获取十六进制字符串转换为byte数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] FromHexString(this string hexString)
        {
            char[] charArray = hexString.ToCharArray();
            int len = charArray.Length / 2;
            byte[] byteArray = new byte[len];

            for (int i = 0; i < len; i++)
            {
                string str = charArray[i * 2].ToString() + charArray[i * 2 + 1].ToString();
                byteArray[i] = Convert.ToByte(str, 16);
            }

            return byteArray;
        }

        /// <summary>
        /// 字符串转换为Decimal，失败返回0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value)
        {
            return value.ToDecimal(0);
        }

        /// <summary>
        /// 字符串转换Decimal，如果失败使用指定值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value, decimal defaultValue)
        {
            if (value.IsNullOrEmpty() || value.Trim().Length >= 11
                || !Regex.IsMatch(value.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
                return defaultValue;

            Decimal result;

            if (Decimal.TryParse(value, out result))
                return result;
            else
                return defaultValue;
        }

        /// <summary>
        /// 字符串转换Int32，失败返回0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32(this string value)
        {
            return value.ToInt32(0);
        }

        /// <summary>
        /// 字符串转换Int32，失败返回指定值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt32(this string value, int defaultValue)
        {
            if (value.IsNullOrEmpty() || value.Trim().Length >= 11
                || !Regex.IsMatch(value.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
                return defaultValue;

            Int32 result;

            if (Int32.TryParse(value, out result))
                return result;

            return Convert.ToInt32(value.ToFloat(defaultValue));
        }

        /// <summary>
        /// 对象转换为Int32，失败返回0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32(this object value)
        {
            return value.ToInt32(0);
        }

        /// <summary>
        /// 对象转换为Int32，失败返回指定值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt32(this object value, int defaultValue)
        {
            if (null == value)
                return defaultValue;

            return ToInt32(value.ToString(), defaultValue);
        }

        /// <summary>
        /// 字符串转换为Float，失败返回0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ToFloat(this string value)
        {
            return value.ToFloat(0);
        }

        /// <summary>
        /// 字符串转换Float，失败返回指定值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float ToFloat(this string value, float defaultValue)
        {
            if (value.IsNullOrEmpty() || (value.Length > 10))
                return defaultValue;

            float result = defaultValue;

            if (value != null)
            {
                bool isFloat = Regex.IsMatch(value, @"^([-]|[0-9])[0-9]*(\.\w*)?$");

                if (isFloat)
                    float.TryParse(value, out result);
            }

            return result;
        }

        /// <summary>
        /// 字符串转换时间值，失败返回指定值
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string strDate, DateTime defaultValue)
        {
            if (strDate.IsNullOrEmpty())
                return defaultValue;

            DateTime result;

            if (DateTime.TryParse(strDate, out result))
                return result;

            return defaultValue;
        }

        /// <summary>
        /// 将时间转换为，{0}/年/月/日/时/分/秒 前
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string Formart(this DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;

            if (span.TotalDays > 60)
                return dt.ToShortDateString();

            if (span.TotalDays > 30)
                return "1月前发布";

            if (span.TotalDays > 14)
                return "2周前发布";

            if (span.TotalDays > 7)
                return "1周前发布";

            if (span.TotalDays > 1)
                return string.Format("{0}天前发布", (int)Math.Floor(span.TotalDays));

            if (span.TotalHours > 1)
                return string.Format("{0}小时前发布", (int)Math.Floor(span.TotalHours));

            if (span.TotalMinutes > 1)
                return string.Format("{0}分钟前发布", (int)Math.Floor(span.TotalMinutes));

            if (span.TotalSeconds >= 1)
                return string.Format("{0}秒前发布", (int)Math.Floor(span.TotalSeconds));

            return "1秒前发布";
        }

        /// <summary>
        /// 字符串转换为Decimal，失败返回0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string value)
        {
            return value.ToGuid(new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <summary>
        /// 字符串转换Decimal，如果失败使用指定值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string value, Guid defaultValue)
        {
            if (string.IsNullOrEmpty(value) || value.Trim().Length >= 37
                || !Regex.IsMatch(value.Trim(), @"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$"))
                return defaultValue;

            Guid result;

            if (Guid.TryParse(value, out result))
                return result;
            else
                return defaultValue;
        }


    }
}
