using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class MerchantBaseQueryRequest : BaseRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 基础信息ID(BassInfo枚举)
        /// </summary>
        public int BaseInfoClass { get; set; }
    }
}
