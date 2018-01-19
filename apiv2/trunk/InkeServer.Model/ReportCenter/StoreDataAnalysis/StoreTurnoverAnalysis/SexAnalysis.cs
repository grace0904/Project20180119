using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 分析会员性别列
    /// </summary>
    public class SexAnalysis
    {
        public DateTime? Title { get; set; }
        public decimal? ManTotal { get; set; }
        public decimal? WomanTotal { get; set; }
    }
}
