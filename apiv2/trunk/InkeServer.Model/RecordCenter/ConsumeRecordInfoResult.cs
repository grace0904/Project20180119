using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 消费记录详细信息 返回类
    /// </summary>
    public  class ConsumeRecordInfoResult
    {
        /// <summary>
        /// 订单详细信息
        /// </summary>
        public OrderInfo OrderInfo { get; set; }
        /// <summary>
        /// 调整历史列表
        /// </summary>
        public List<OrderInfo> HistoryOrderInfo { get; set; }
        /// <summary>
        /// 支付信息
        /// </summary>
        public List<OrderPay> OrderPay { get; set; }
        /// <summary>
        /// 会员卡下的优惠券
        /// </summary>
        public List<CardCouponInfo> CardCoupon { get; set; }
        /// <summary>
        /// 订单消费产品列表
        /// </summary>
        public List<OrderBasketInfo> OrderBasketInfo { get; set; }
        ///// <summary>
        ///// 短信
        ///// </summary>
        //public SmsSendCustom Sms { get; set; }
    }
}
