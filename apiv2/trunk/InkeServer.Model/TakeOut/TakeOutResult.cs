using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 外卖信息结果集
    /// </summary>
    public class TakeOutResult
    {
        #region Model

        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shop_Name { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? AddTime { get; set; }
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

        #endregion Model
        /// <summary>
        /// 店铺职员列表
        /// </summary>
        public List<EmployeePositionInfo> EmployeePositionInfo { get; set; }
    }
}
