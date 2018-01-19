using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 营销分析/自定义营销返回记录实体类
    /// </summary>
    public class MarketAnalysisQueryResult
    {
        /// <summary> 
        ///  状态
        ///</summary> 
        public int State { get; set; }
        /// <summary> 
        ///  MarketingAnalyze_ID  
        ///</summary> 
        public string MarketingAnalyze_ID { get; set; }
        /// <summary>
        /// 方案名称
        /// </summary>
        public string MarketingAnalyze_Name { get; set; }

        /// <summary>
        /// 所属店铺
        /// </summary>
        public List<string> ShopNames { get; set; }
        /// <summary>
        /// 筛选结果
        /// </summary>
        public int? StatisticsTotal { get; set; }
        /// <summary>
        /// 发放次数
        /// </summary>
        public int? IssueTotal { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime? OperationTime { get; set; }
    }
}
