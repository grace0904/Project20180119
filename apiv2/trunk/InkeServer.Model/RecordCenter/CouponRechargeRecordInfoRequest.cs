using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 优惠券信息 请求类
    /// </summary>
    public class CouponRechargeRecordInfoRequest : BaseRequest
    {
        /// <summary>
        /// 商家 ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 记录ID
        /// </summary>
        public string CouponRecord_ID { get; set; }
    }
}
