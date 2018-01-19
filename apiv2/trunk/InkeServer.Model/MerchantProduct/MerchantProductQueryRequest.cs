using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class MerchantProductQueryRequest : PaginationRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }

        /// <summary>
        /// 产品种类ID
        /// </summary>
        public string MerchantBaseInfo_ID { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 最高价格
        /// </summary>
        public decimal? BPrice { get; set; }
        /// <summary>
        /// 最低价格
        /// </summary>
        public decimal? SPrice { get; set; }
    }
}
