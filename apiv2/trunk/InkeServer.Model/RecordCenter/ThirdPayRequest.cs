using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ThirdPayRequest : PaginationRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ThirdPay_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? BusinessClass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? PayStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? PayType { get; set; }
        /// <summary>
        /// 业务号
        /// </summary>
        public string PayBussinessNum { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_IDList { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 金额起始
        /// </summary>
        public decimal? MoneyForm { get; set; }
        /// <summary>
        /// 金额结束
        /// </summary>
        public decimal? MoneyTo { get; set; }
        /// <summary>
        /// 日期起始
        /// </summary>
        public DateTime? DateForm { get; set; }
        /// <summary>
        /// 日期结束
        /// </summary>
        public DateTime? DateTo { get; set; }
    }
}
