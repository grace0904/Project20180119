using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 订单菜品详细信息
    /// </summary>
    public class OrderBasketInfo
    {
        /// <summary>
        /// 店铺产品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否允许打折
        /// </summary>
        public int Discount { get; set; }
        /// <summary>
        /// 套餐ID
        /// </summary>
        public int IsCombo { get; set; }
        /// <summary>
        ///  菜品基础信息
        /// </summary>
        public OrderBasket OrderBasket { get; set; }
    }
}
