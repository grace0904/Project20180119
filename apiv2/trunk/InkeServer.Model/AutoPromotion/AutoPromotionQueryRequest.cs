using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 分页获取自动促销列表集合 请求类
    /// </summary>
    public class AutoPromotionQueryRequest : PaginationRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }

        /// <summary>
        /// 自动促销类型
        /// </summary>
        public int PromotionType { get; set; }
    }
}
