using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopProductInsert : BaseRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
       [DisplayName("商家ID")]
        public string Merchant_ID { get; set; }

        /// <summary>
        /// 店铺ID 用逗号隔开 如：ID1,ID2
        /// </summary>
       [DisplayName("店铺ID")]
       public string ShopIDList { get; set; }

        /// <summary>
        /// 产品ID 用逗号隔开 如：ID1,ID2
        /// </summary>
       [DisplayName("产品ID")]
       public string ProductIDList { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
       [DisplayName("操作人")]
       public string Operator { get; set; }
    }
}
