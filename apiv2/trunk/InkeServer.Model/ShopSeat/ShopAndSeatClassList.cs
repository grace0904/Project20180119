using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopAndSeatClassList
    { 
        /// <summary>
        /// 店铺ID和名称
        /// </summary>
        public ShopIdAndName ShopInfo { get; set; }

        /// <summary>
        /// 该店铺下座位类型集合
        /// </summary>
        public List<ShopSeatClassInfo> ShopSeatTypeAndIDList = new List<ShopSeatClassInfo>();
    }
}
