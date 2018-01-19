using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 启用/停用自动促销记录 请求类
    /// </summary>
    public class RecordIDAndStatusRequest : BaseRequest
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
        /// <summary>
        /// 状态1-启用，0-停用
        /// </summary>
        [DisplayName("状态")]
        public int Status { get; set; }
    }
}
