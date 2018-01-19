using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class TakeOutUpdate : BaseRequest
    {
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 起送价
        /// </summary>
        public decimal Deliveryamount { get; set; }
        /// <summary>
        /// 配送费
        /// </summary>
        public decimal Takeoutcost { get; set; }
        /// <summary>
        /// 外卖开始时间
        /// </summary>
        public string TakeOutTimeBegin { get; set; }
        /// <summary>
        /// 外卖结束时间
        /// </summary>
        public string TakeOutTimeEnd { get; set; }
        /// <summary>
        /// 外卖短信职员ID
        /// </summary>
        public string TakeOutSmsEmployeeID { get; set; }
        /// <summary>
        /// 外卖短信自定义号码
        /// </summary>
        public string TakeOutSmsTel { get; set; }

        /// <summary>
        /// 是否启用外卖 0 否 1 是
        /// </summary>
        public bool TakeOutStatus { get; set; }

        /// <summary>
        /// 是否支持货到付款 0 否 1 是
        /// </summary>
        public bool PayOnDelivery { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
    }
}
