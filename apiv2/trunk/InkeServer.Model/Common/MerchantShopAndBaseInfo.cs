using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class MerchantShopAndBaseInfo:BaseRequest
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
        /// 类型ID
        /// </summary>
        public string MerchantBaseInfo_ID { get; set; }
    }
}
