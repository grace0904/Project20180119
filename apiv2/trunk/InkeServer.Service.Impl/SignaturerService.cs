using Inke.Common.Helpers;
using InkeServer.DataMapping;
using InkeServer.Service;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace InkeServer.Service.Impl
{
    public class SignaturerService : ServiceBase, ISignaturerService
    {
        //标记为注入对象
        [InjectionConstructor]
        public SignaturerService() { }

        public bool IsValid<T>(T model)
        {
            #region IsValid

            SortedDictionary<string, string> datas = new SortedDictionary<string, string>();
            var props = model.GetType().GetProperties();
            foreach (PropertyInfo p in props)
            {
                if (!p.Name.ToUpper().Equals("APPKEY"))
                {
                    //对值类型进行序列化
                    datas.Add(p.Name.ToUpper(), JsonConvert.SerializeObject(p.GetValue(model, null)));
                    //datas.Add(p.Name.ToUpper(), p.GetValue(model) != null ? p.GetValue(model).ToString() : "");
                }
                else
                {
                    datas.Add(p.Name.ToUpper(), p.GetValue(model, null).ToString());
                }
            }

            if (datas["APPKEY"] == "") return false;
            if (datas["SIGN"] == "") return false;

            string clearText = GetClearText(datas, GetAppSecret(datas["APPKEY"]));
            //对序列化后的字符串进行排序
            char[] arr = clearText.ToCharArray();
            Array.Sort(arr);
            var str = new string(arr);
            string sign = MD5er.Encrypt(str.ToLower());
            //string sign = C_MD5er.Encrypt(str);

            return sign == datas["SIGN"].ToString().Replace('"', ' ').Trim();

            #endregion
        }
        
        #region Private

        /// <summary>
        /// 根据appKey获取对应的appSecret
        /// </summary>
        /// <param name="appKey"></param>
        /// <returns></returns>
        private string GetAppSecret(string appKey)
        {
            string appsecret = (from l in Entities.Bas_AppClients
                             where l.App_Key == appKey
                             select l.App_Secret).FirstOrDefault();
            return appsecret;
        }

        /// <summary>
        /// 拼接加密前字符串
        /// </summary>
        /// <param name="datas">请求参数对象</param>
        /// <returns>加密前字符串</returns>
        private static string GetClearText(SortedDictionary<string, string> datas, string secret)
        {
            string clearText = string.Empty;

            foreach (var data in datas)
            {
                if (data.Key.ToUpper() != "SIGN")
                {
                    clearText += string.Format("{0}={1}&", data.Key, data.Value);
                }
            }
            clearText += "AppSecret=" + secret;

            return clearText;
        }

        #endregion
    }
}
