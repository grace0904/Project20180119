using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class RecordCenterIndexResult
    {
        /// <summary>
        /// 消费记录
        /// </summary>
        public List<ExpenseCalendar> expensecalendar = new List<ExpenseCalendar>();
        /// <summary>
        /// 挂账记录
        /// </summary>
        public List<ArrearsRecorde> arrearsrecorde = new List<ArrearsRecorde>();
        /// <summary>
        /// 充值前三
        /// </summary>
        public List<RechargeRecorde> rechargerecorde = new List<RechargeRecorde>();
        /// <summary>
        /// 会员时间段内充值金额
        /// </summary>
        public decimal? RechargeTotal { get; set; }
        /// <summary>
        ///余额记录--不受时间限制的结果
        /// </summary>
        public decimal? Cash { get; set; }
        /// <summary>
        /// 兑换记录--产品
        /// </summary>
        public List<ExchangeRecorde> exchangeproduct = new List<ExchangeRecorde>();
        /// <summary>
        /// 兑换记录--优惠券
        /// </summary>
        public List<ExchangeRecorde> exchangecoupon = new List<ExchangeRecorde>();
    }
}
