using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 会员和散客消费情况列
    /// </summary>
    public class MemberAnalysis
    {
        public DateTime? Title { get; set; }
        public decimal? MemberTotal { get; set; }
        public decimal? CustomerTotal { get; set; }
    }
}
