using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class StoreTurnoverAnalysisResult
    {
        /// <summary>
        /// 会员和散客消费情况列表
        /// </summary>
        public List<MemberAnalysis> memberAnalysis { get; set; }
        /// <summary>
        /// 分析会员年龄
        /// </summary>
        public List<AgeRangeAnalysis> ageRangeAnalysis { get; set; }
        /// <summary>
        /// 分析会员性别
        /// </summary>
        public List<SexAnalysis> sexAnalysis { get; set; }
    }
}
