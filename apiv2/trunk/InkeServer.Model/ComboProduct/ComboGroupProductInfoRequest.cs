using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 获取套餐产品详细信息
    /// </summary>
    public  class ComboGroupProductInfoRequest:BaseRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public string ComboProduct_ID { get; set; }
    }
}
