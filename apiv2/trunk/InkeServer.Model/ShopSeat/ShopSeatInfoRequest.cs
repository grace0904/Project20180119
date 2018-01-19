using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopSeatInfoRequest : PaginationRequest
    {
        /// <summary>
        ///店铺ID列表
        /// </summary>
        public string ShopIDList { get; set; }
        /// <summary>
        ///座位类型ID
        /// </summary>
        public string ShopSeatClassID { get; set; }
    }
}
