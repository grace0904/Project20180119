using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 挂帐记录
    /// </summary>
    public class ArrearsRecordInfo
    {
        #region Model
        public string Arrears_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Member_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Order_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Arrears_Money { get; set; }
        /// <summary>
        /// 挂帐状态 1 正常 2 已结帐
        /// </summary>
        public int? Arrears_Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public int? PayType { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal? PayMoney { get; set; }
        /// <summary>
        /// 支付会员卡ID
        /// </summary>
        public string Pay_Card_ID { get; set; }
        /// <summary>
        /// 支付备注
        /// </summary>
        public string PayMemo { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime? PayTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Adjust { get; set; }
        #endregion Model
    }
}
