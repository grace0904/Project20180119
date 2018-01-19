using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 订单支付基础类
    /// </summary>
     [Serializable]
    public  class OrderPay
    {
        #region Model
        /// <summary>
        /// ID
        /// </summary>
        public string OrderPay_ID { get; set; }
        /// <summary>
        /// 支付方式 1 现金 2 银行卡 3 会员卡 4 支付宝 5 微信支付 6 团购券
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal PayMoney { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime PayTime { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public string Order_ID { get; set; }
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string Card_ID { get; set; }
        /// <summary>
        /// 业务卡号
        /// </summary>
        public string Card_BusinessID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string User_ID { get; set; }
        /// <summary>
        /// 微信支付订单号
        /// </summary>
        public string Pay_JyNum { get; set; }
        #endregion Model
    }
}
