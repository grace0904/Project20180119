using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 分析会员年龄列
    /// </summary>
    public class AgeRangeAnalysis
    {
        public DateTime? Title { get; set; }
        public decimal? AgeRange { get; set; }
        public string Turnover { get; set; }
    }
}
