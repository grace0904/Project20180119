using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 根据商家ID和类型获取商家产品集合 请求类
    /// </summary>
    public class MerchantAndBaseInfoRequest : BaseRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }

        /// <summary>
        /// 类型ID
        /// </summary>
        public string MerchantBaseInfo_ID { get; set; }
    }
}
