using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 系统短信模板ID和名称 返回对象
    /// </summary>
    public class SmsTemplateIDAndName
    {
        /// <summary>
        /// 短信模板ID
        /// </summary>
        public string SmsTemplate_ID { get; set; }
        /// <summary>
        /// 短信模板名称
        /// </summary>
        public string SmsTemplate_Name { get; set; }
    }
}
