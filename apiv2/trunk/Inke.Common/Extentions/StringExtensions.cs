using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// 字符串类扩展方法
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 判断字符串为NULL或""
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 判断字符串为非NULL或""
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool NotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static string FormatWith(this string str, params object[] args)
        {
            return string.Format(str, args);
        }

        public static bool IsMatch(this string s, string pattern)
        {
            if (s == null) return false;
            else return Regex.IsMatch(s, pattern);
        }

        public static string Match(this string s, string pattern)
        {
            if (s == null) return "";
            return Regex.Match(s, pattern).Value;
        }

        /// <summary>
        /// string formator,replece string.Format
        /// </summary>
        /// <example>string result = StrFormater.Format(@"Hello @Name! Welcome to C#!", new { Name = "World" });///</example>
        /// <param name="template"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Format(this string template, object data)
        {
            return Regex.Replace(template, @"@([\w\d]+)", match => GetValue(match, data));
        }

        static string GetValue(Match match, object data)
        {
            var paraName = match.Groups[1].Value;
            try
            {
                var proper = data.GetType().GetProperty(paraName);
                return proper.GetValue(data, null).ToString();
            }
            catch (Exception)
            {
                var errMsg = string.Format("没有发现'{0}'", paraName);
                throw new ArgumentException(errMsg);
            }
        }

        /// <summary>
        /// 长字符串截断缩略
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="length">最大长度</param>
        /// <param name="replace">替代文本</param>
        /// <returns></returns>
        public static string Contractions(this string s, int length = 50, string replace = "...")
        {
            return s.Length > length ? s.Substring(0, length) + replace : s;
        }
    }
}