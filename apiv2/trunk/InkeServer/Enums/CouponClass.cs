using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Enums
{
    /// <summary>
    /// 优惠券类型
    /// </summary>
    public enum CouponClass : int
    {
        /// <summary>
        /// 产品券
        /// </summary>
        [Description("产品券")]
        Product = 1,
        /// <summary>
        /// 现金券
        /// </summary>
        [Description("现金券")]
        Cash = 2
    }
}
