using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;

namespace Inke.Common.Helpers
{
    /// <summary>
    /// 根据枚举获取对应的值和描述内容
    /// </summary>
    public sealed class EnumHelper
    {
        EnumHelper() { }

        #region 把枚举转换为对象

        public class EnumInfo
        {
            private int _enumValue;
            private string _enumName;
            private string _enumDescript;

            public int EnumValue
            {
                get { return _enumValue; }
                set { _enumValue = value; }
            }
            public string EnumName
            {
                get { return _enumName; }
                set { _enumName = value; }
            }

            public string EnumDescript
            {
                get { return _enumDescript; }
                set { _enumDescript = value; }
            }

            public EnumInfo(int enumValue, string enumName, string enumDescript) 
            {
                _enumValue = enumValue;
                _enumName = enumName;
                _enumDescript = enumDescript;
            }
        }

        #endregion 
      
        /// <summary>  
        /// 扩展方法：根据枚举值得到属性Description中的描述, 如果没有定义此属性则返回空串  
        /// </summary>  
        /// <param name="value"></param>  
        /// <param name="enumType"></param>  
        /// <returns></returns>  
        public static String ToEnumDescriptionString(int value, Type enumType)
        {
            NameValueCollection nvc = GetNVCFromEnumValue(enumType);
            return nvc[value.ToString()];
        }

        /// <summary>  
        /// 根据枚举类型得到其所有的 值 与 枚举定义Description属性 的集合  
        /// </summary>  
        /// <param name="enumType"></param>  
        /// <returns></returns>  
        public static NameValueCollection GetNVCFromEnumValue(Type enumType)
        {
            NameValueCollection nvc = new NameValueCollection();
            Type typeDescription = typeof(DescriptionAttribute);
            System.Reflection.FieldInfo[] fields = enumType.GetFields();
            string strText = string.Empty;
            string strValue = string.Empty;
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    strValue = ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                        strText = aa.Description;
                    }
                    else
                    {
                        strText = "";
                    }
                    nvc.Add(strValue, strText);
                }
            }
            return nvc;
        }

        /// <summary>  
        /// 扩展方法：根据枚举值得到相应的枚举定义字符串  
        /// </summary>  
        /// <param name="value"></param>  
        /// <param name="enumType"></param>  
        /// <returns></returns>  
        public static String ToEnumValueString(int value, Type enumType)
        {
            NameValueCollection nvc = GetEnumStringFromEnumValue(enumType);
            return nvc[value.ToString()];
        }

        /// <summary>  
        /// 根据枚举类型得到其所有的 值 与 枚举定义字符串 的集合  
        /// </summary>  
        /// <param name="enumType"></param>  
        /// <returns></returns>  
        private static NameValueCollection GetEnumStringFromEnumValue(Type enumType)
        {
            NameValueCollection nvc = new NameValueCollection();
            Type typeDescription = typeof(DescriptionAttribute);
            System.Reflection.FieldInfo[] fields = enumType.GetFields();
            string strText = string.Empty;
            string strValue = string.Empty;
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    strValue = ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    nvc.Add(strValue, field.Name);
                }
            }
            return nvc;
        }

        /// <summary>
        /// 把枚举（描述|数字值）转换为josn格式
        /// </summary>
        /// <returns></returns>
        public static string GetEnumDescriptToJosn(Type enumType)
        {
            int[] values = (int[])Enum.GetValues(enumType);
            string[] pairs = new string[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                pairs[i] = string.Format("\"{0}\":\"{1}\"", ToEnumDescriptionString(values[i],enumType), values[i]);
            }

            return "{"+string.Join(",", pairs)+"}";
        }

        /// <summary>
        /// 把枚举（名称|数字值）转换为josn格式
        /// 在前端页面需要 JOSN.parse()
        /// </summary>
        /// <returns></returns>
        public static string GetEnumNameToJosn(Type enumType)
        {
            int[] values = (int[])Enum.GetValues(enumType);
            string[] names = Enum.GetNames(enumType);
            string[] pairs = new string[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                pairs[i] = string.Format("\"{0}\":\"{1}\"", names[i], values[i]);
            }

            return "{" + string.Join(",", pairs) + "}";
        }

        /// <summary>
        /// 把枚举转换为对象
        /// </summary>
        /// <returns></returns>
        public static List<EnumInfo> ConvertEnumToEntity(Type enumType) 
        {
            List<EnumInfo> objInfo=new List<EnumInfo>();
            int[] values = (int[])Enum.GetValues(enumType);
            string[] names = Enum.GetNames(enumType);
            for (int i = 0; i < values.Length; i++)
            {
                objInfo.Add(new EnumInfo(values[i], names[i],ToEnumDescriptionString(values[i],enumType)));
            }

            return objInfo;
        }
    }
}
