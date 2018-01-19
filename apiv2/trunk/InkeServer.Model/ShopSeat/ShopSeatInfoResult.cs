using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopSeatInfoResult
    {
         /// <summary>
        /// ID
        /// </summary>
        public string Seat_ID{get;set;}
        /// <summary>
        /// 座位名称
        /// </summary>
        public string Seat_Name { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shop_Name { get; set; }
       
        /// <summary>
        /// 座位数
        /// </summary>
        public int Seat_Num { get; set; }
        /// <summary>
        /// 座位类型名称
        /// </summary>
        public string ShopSeatClass_Name { get; set; }
        /// <summary>
        /// 座位类型
        /// </summary>
        public string ShopSeatClass_ID { get; set; }
        
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OptionTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
       
    }
}
