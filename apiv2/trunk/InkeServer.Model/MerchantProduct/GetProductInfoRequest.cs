using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 获取商家产品详细信息 请求类
    /// </summary>
    public class GetProductInfoRequest : BaseRequest
    {
        ///// <summary>
        ///// 当前账号ID
        ///// </summary>
        //public string LoginAccount_ID { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public string Product_ID { get; set; }
    }
}
