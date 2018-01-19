using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    ///门店数据分析-菜品销量排行结果集
    /// </summary>
    public class ProductSalesRankingResult
    {
        /// <summary>
        /// 菜品ID
        /// </summary>
        public string Product_ID { get; set; }
        /// <summary>
        /// 菜品名称
        /// </summary>
        public string Product_Name { get; set; }
        /// <summary>
        /// 排名
        /// </summary>
        public int? Ranking { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int? Total { get; set; }
        /// <summary>
        /// 百分率
        /// </summary>
        public string Percent { get; set; }
    }
}
