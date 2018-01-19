using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 根据主键操作 通用请求类
    /// </summary>
    public class OperationBaseRequest : BaseRequest
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        [DisplayName("记录ID")]
        public string Record_ID { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]
        public string Operator { get; set; }
    }
}
