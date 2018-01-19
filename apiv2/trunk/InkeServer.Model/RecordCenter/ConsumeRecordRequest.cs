using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 消费记录查找 请求实体类
    /// </summary>
    public class ConsumeRecordRequest : PaginationRequest
    {
        #region
        /// <summary>
        /// 订单ID
        /// </summary>
        public string Order_ID { get; set; }
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
        /// 消费金额起始
        /// </summary>
        public decimal? MoneyForm { get; set; }
        /// <summary>
        /// 消费金额结束
        /// </summary>
        public decimal? MoneyTo { get; set; }
        /// <summary>
        /// 消费日期起始
        /// </summary>
        public DateTime? DateForm { get; set; }
        /// <summary>
        /// 消费日期结束
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
        /// 店铺ID集合
        /// </summary>
        public string ShopGroup { get; set; }
        #endregion
    }
}
