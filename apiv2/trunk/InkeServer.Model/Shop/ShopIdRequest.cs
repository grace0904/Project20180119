using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopIdRequest : BaseRequest
    {
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
    }
}
