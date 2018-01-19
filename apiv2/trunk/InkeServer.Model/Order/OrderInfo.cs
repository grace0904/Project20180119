using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    ///  订单详细信息
    /// </summary>
    public  class OrderInfo
    {
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string Card_Num { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string Member_Name { get; set; }
        /// <summary>
        /// 会员性别
        /// </summary>
        public string Member_Sex { get; set; }
        /// <summary>
        /// 会员手机号
        /// </summary>
        public string Member_MobilePhone { get; set; }
        /// <summary>
        /// 折扣类型名称
        /// </summary>
        public string Discount_Name { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shop_Name { get; set; }
        /// <summary>
        /// 座位名称
        /// </summary>
        public string Seat_Name { get; set; }
        /// <summary>
        /// 订单基础信息
        /// </summary>

        public Order Order { get; set; }
    }
}
