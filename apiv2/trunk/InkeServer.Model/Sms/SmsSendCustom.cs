using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
   public   class SmsSendCustom
    {
        /// <summary>
        /// 是否发送
        /// </summary>
        public int Send { get; set; }
        /// <summary>
        /// 短信内容
        /// </summary>
        public string SmsContent { get; set; }
        ///// <summary>
        ///// 短信条数
        ///// </summary>
        //public int SmsQuantity { get; set; }
        /// <summary>
        /// 短信类型
        /// </summary>
        public int SmsType { get; set; }
        ///// <summary>
        ///// 手机号码
        ///// </summary>
        //public string MobilePhone { get; set; }
    }
}
