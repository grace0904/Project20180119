using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 就餐人数 结果集 饼图
    /// </summary>
    public class NumberOfDinersResult
    {
        /// <summary>
        /// 0至3人
        /// </summary>
        public int? Min0Max3 { get; set; }
        /// <summary>
        /// 4至6人
        /// </summary>
        public int? Min4Max6 { get; set; }
        /// <summary>
        /// 7至9人
        /// </summary>
        public int? Min7Max9 { get; set; }
        /// <summary>
        /// 10至13人
        /// </summary>
        public int? Min10Max13 { get; set; }
        /// <summary>
        /// 14人以上
        /// </summary>
        public int? Min14 { get; set; }
    }
}
