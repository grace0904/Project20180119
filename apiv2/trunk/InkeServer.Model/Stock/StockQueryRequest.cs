using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 分页查询入库记录 请求类
    /// </summary>
    public class StockQueryRequest : PaginationRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 产品分类
        /// </summary>
        public string MerchantBaseInfo_ID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Product_Name { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string Product_Code { get; set; }
        /// <summary>
        /// 统计开始时间
        /// </summary>
        public DateTime? DateFrom { get; set; }
        /// <summary>
        /// 统计结束时间
        /// </summary>
        public DateTime? DateTo { get; set; }
    }
}
