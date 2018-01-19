using System;
using System.Linq;
using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// 枚举运算扩展
    /// </summary>
    public static class EnumExtensions
    {
        public static string Name(this Enum value)
        {
            try
            {
                return Enum.GetName(value.GetType(), value);
            }
            catch { return string.Empty; }
        }

        /// <summary>
        /// 获取枚举的Int转换值
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public static int Value(this Enum value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch { return -1; }
        }

        /// <summary>
        /// 获取枚举的T转换值
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public static T Value<T>(this Enum value) where T : struct
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch { return default(T); }
        }

        /// <summary>
        /// 将Int类型转换为枚举类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value)
        {
            return EnumExtensions.ToEnum<T>(value.ToString());
        }

        /// <summary>
        /// 将long类型转换为枚举类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this long value)
        {
            return EnumExtensions.ToEnum<T>(value.ToString());
        }

        /// <summary>
        /// 将short类型转换为枚举类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this short value)
        {
            return EnumExtensions.ToEnum<T>(value.ToString());
        }

        /// <summary>
        /// 将Byte类型转换为枚举类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this byte value)
        {
            return EnumExtensions.ToEnum<T>(value.ToString());
        }

        /// <summary>
        /// 将String类型转换为枚举类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch { return default(T); }
        }

        /// <summary>
        /// 判断"枚举组"中是否包含"枚举值"
        /// <para>1."枚举组"及"枚举值"必须为int类型或可转换为int类型</para>
        /// <para>2."枚举组"可作为位域（即一组标志）处理，即应用[Flags]标签</para>
        /// </summary>
        /// <param name="group">枚举组</param>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public static bool Contains(this Enum group, Enum value)
        {
            try
            {
                return (Convert.ToInt32(group) & Convert.ToInt32(value)) != 0;
            }
            catch { return false; }
        }

        /// <summary>
        /// 判断"枚举组"中是否包含"枚举值"
        /// <para>1."枚举组"及"枚举值"必须为int类型或可转换为int类型</para>
        /// <para>2."枚举组"可作为位域（即一组标志）处理，即应用[Flags]标签</para>
        /// </summary>
        /// <param name="group">枚举组</param>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public static bool Contains(this Enum group, int value)
        {
            try
            {
                return (Convert.ToInt32(group) & value) != 0;
            }
            catch { return false; }
        }

        /// <summary>
        /// 判断"枚举组"中是否包含"枚举值"
        /// <para>1."枚举组"及"枚举值"必须为int类型或可转换为int类型</para>
        /// <para>2."枚举组"可作为位域（即一组标志）处理，即应用[Flags]标签</para>
        /// </summary>
        /// <param name="group">枚举组值</param>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public static bool Contains(this int group, int value)
        {
            try
            {
                return (group & value) != 0;
            }
            catch { return false; }
        }

        /// <summary>
        /// 获取"枚举组的值"中的所有成员
        /// </summary>
        /// <typeparam name="T">成员的枚举类型</typeparam>
        /// <param name="group">枚举组的值</param>
        /// <returns></returns>
        public static List<T> Members<T>(this Enum group)
        {
            try
            {
                List<T> list = new List<T>();
                foreach (var item in Enum.GetValues(typeof(T)))
                {
                    int value = (int)item;
                    int groupValue = group.Value();
                    if ((groupValue & value) != 0)
                        list.Add((T)item);
                }

                return list;
            }
            catch { return new List<T>(); }
        }

        /// <summary>
        /// 获取"枚举组的值"中的所有成员
        /// </summary>
        /// <typeparam name="T">成员的枚举类型</typeparam>
        /// <param name="group">枚举组的值</param>
        /// <returns></returns>
        public static List<T> Members<T>(this int group)
        {
            try
            {
                List<T> list = new List<T>();
                foreach (var item in Enum.GetValues(typeof(T)))
                {
                    int value = (int)item;
                    if ((group & value) != 0)
                        list.Add((T)item);
                }

                return list;
            }
            catch { return new List<T>(); }
        }

        /// <summary>
        /// 获取"枚举组的值"中的所有成员
        /// </summary>
        /// <typeparam name="T">成员的枚举类型</typeparam>
        /// <param name="group">枚举组的值</param>
        /// <returns></returns>
        public static TMember Members<TGroup, TMember>(this string group)
        {
            try
            {
                return (TMember)Enum.Parse(
                    typeof(TMember),
                    ((TGroup)Enum.Parse(typeof(TGroup), group)).GetHashCode().ToString());
            }
            catch { return default(TMember); }
        }

        #region private

        public static T ToEnum<T>(object value)
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch { return default(T); }
        }

        #endregion
    }
}