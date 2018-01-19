using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 会员增长统计 结果集
    /// </summary>
    public class MembershipGrowthResult
    {
        /// <summary>
        /// 标题
        /// </summary>
        public DateTime? Title { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int? Total { get; set; }

    }
}
