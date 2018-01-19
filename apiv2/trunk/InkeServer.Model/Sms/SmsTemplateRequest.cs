using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 取得短信模板 请求类
    /// </summary>
    public class SmsTemplateRequest : BaseRequest
    {
        #region Model
        /// <summary>
        /// 商家编号
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 短信模板类型
        /// </summary>
        public int SmsType { get; set; }


        #endregion


    }
}
