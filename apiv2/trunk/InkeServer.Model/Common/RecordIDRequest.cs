using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 根据主键操作 通用查询请求类
    /// </summary>
    public class RecordIDRequest : BaseRequest
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public string Record_ID { get; set; }
    }
}
