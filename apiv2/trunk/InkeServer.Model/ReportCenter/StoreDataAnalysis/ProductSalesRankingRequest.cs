using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 门店数据分析-菜品销量排行
    /// </summary>
    public class ProductSalesRankingRequest : BaseRequest
    {
        /// <summary>
        /// 商家ID ASC 升序  DESC降序
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 商家ID 
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// ShopID
        /// </summary>
        public string Shop_IDs { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string types { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
