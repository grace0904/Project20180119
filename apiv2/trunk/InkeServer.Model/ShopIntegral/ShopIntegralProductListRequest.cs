using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopIntegralProductListRequest : PaginationRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 当前登录账号ID
        /// </summary>
        public string Account_ID { get; set; }
        /// <summary>
        /// 产品种类ID
        /// </summary>
        public string MerchantBaseInfo_ID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }
    }
}
