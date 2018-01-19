using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 短信模版列表
    /// </summary>
    public class SmsTemplateList 
    {
        /// <summary>
        /// 短信模板ID
        /// </summary>
        public string SmsTemplate_ID { get; set; }
        /// <summary>
        /// 短信模板名称
        /// </summary>
        public string SmsTemplate_Name { get; set; }
        /// <summary>
        /// 短信模板ID
        /// </summary>
        ///        
        public string Custom_ID { get; set; }
        /// <summary>
        /// 发送类型 0 未设置(默认不发送) 1 发送 2 不发送
        /// </summary>
        public int Custom_Send { get; set; }
        /// <summary>
        /// 提前几天发送
        /// </summary>
        public int? Custom_SendDate { get; set; }
    }
}
