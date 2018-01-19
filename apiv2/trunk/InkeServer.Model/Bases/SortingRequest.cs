using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 排序请求
    /// </summary>
    public class SortingRequest
    {
        /// <summary>
        /// 排序字段(枚举值)
        /// </summary>
        public int OrderField { get; set; }

        /// <summary>
        /// 排序方式(1: asc, 2: desc)
        /// </summary>
        public int OrderDirection { get; set; }
    }
}
