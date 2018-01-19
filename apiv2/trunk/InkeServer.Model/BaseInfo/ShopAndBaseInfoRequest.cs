using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopAndBaseInfoRequest : BaseRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName("商家ID")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        [DisplayName("店铺ID")]
        public string Account_ID { get; set; }
        /// <summary>
        /// 基础信息ID
        /// </summary>
        [DisplayName("基础信息ID")]
        public int BaseInfoClass_id { get; set; }
    }
}
