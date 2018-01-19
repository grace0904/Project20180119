using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public  class GetComboProductListRequest:BaseRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 套餐组别ID
        /// </summary>
        public string ComboGroup_ID { get; set; }
    }
}
