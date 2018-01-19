using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 优惠券使用统计   柱状图数据请求类
    /// </summary>
    public class CouponMemoryUsageBarRequest:BaseRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 'D' 日  'M'月 'Y'年
        /// </summary>
        public string Rangetype { get; set; }
        /// <summary>
        /// 优惠券ID
        /// </summary>
        public string CouponID { get; set; }
    }
}
