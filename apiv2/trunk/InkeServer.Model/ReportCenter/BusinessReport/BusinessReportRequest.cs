using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 营业报表请求类
    /// </summary>
    public class BusinessReportRequest : BaseRequest
    {
        #region
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID 用逗号隔开 如：ID1,ID2,ID3
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime DateForm { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime DateTo { get; set; }
        /// <summary>
        /// 会员性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 折扣类型ID
        /// </summary>
        public string Discount_ID { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string Operator { get; set; }
        #endregion
    }

}
