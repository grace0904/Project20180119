using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopSeatUpdate : BaseRequest
    {
        /// <summary>
        /// 座位ID
        /// </summary>
        [DisplayName("座位ID")]
        public string Seat_ID { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName("商家ID")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        [DisplayName("店铺ID")]
        public string Shop_ID { get; set; }
        /// <summary>
        /// 座位类型ID
        /// </summary>
        [DisplayName("座位类型ID")]
        public string ShopSeatClass_ID { get; set; }
        /// <summary>
        /// 座位名称
        /// </summary>
        [DisplayName("座位名称")]
        public string Seat_Name { get; set; }
        /// <summary>
        /// 座位数
        /// </summary>
        [DisplayName("座位数")]
        public int Seat_Num { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        public int? Seat_Order { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]
        public string Operator { get; set; }
    }
}
