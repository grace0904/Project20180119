using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopBookUpdate : BaseRequest
    {
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 是否启用预约 0 否 1 是
        /// </summary>
        public bool BookStatus { get; set; }
        /// <summary>
        /// 是否启用预约点菜 0 否 1 是
        /// </summary>
        public bool BookBasketStatus { get; set; }
        /// <summary>
        /// 预点菜提前支付类型 1 固定金额 2 百分比
        /// </summary>
        public int AnticipationType { get; set; }
        /// <summary>
        /// 提前支付金额
        /// </summary>
        public decimal AnticipationAmount { get; set; }
        /// <summary>
        /// 提前支付比例
        /// </summary>
        public decimal AnticipationRate { get; set; }

        /// <summary>
        /// 外卖短信职员ID
        /// </summary>
        public string BookSmsEmployeeID { get; set; }
        /// <summary>
        /// 外卖短信自定义号码
        /// </summary>
        public string BookSmsTel { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
    }
}
