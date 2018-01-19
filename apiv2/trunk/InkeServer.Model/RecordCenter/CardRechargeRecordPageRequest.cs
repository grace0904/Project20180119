using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 充值记录分页查询请求
    /// </summary>
    public class CardRechargeRecordPageRequest : PaginationRequest
    {
        #region
        /// <summary>
        /// 是否是调整记录 0 否 1 是
        /// </summary>
        public int IsAdjust { get; set; }
        /// <summary>
        /// 业务号
        /// </summary>
        public string Business_Num { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        public string Member_ID { get; set; }
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string Card_Num { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 充值金额起始
        /// </summary>
        public decimal? MoneyForm { get; set; }
        /// <summary>
        /// 充值金额结束
        /// </summary>
        public decimal? MoneyTo { get; set; }
        /// <summary>
        /// 充值日期起始
        /// </summary>
        public DateTime? DateForm { get; set; }
        /// <summary>
        /// 充值日期结束
        /// </summary>
        public DateTime? DateTo { get; set; }     
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string Member_Name { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID组
        /// </summary>
        public string Shop_IDList { get; set; }
        #endregion
    }
}
