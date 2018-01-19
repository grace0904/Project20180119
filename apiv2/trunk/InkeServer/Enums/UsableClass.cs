using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Enums
{
    /// <summary>
    /// 可用店铺 类别说明
    /// </summary>
    public enum UsableClass : int
    {
        #region
        /// <summary>
        /// 帐号的可用店铺
        /// </summary>
        [Description("帐号的可用店铺")]
        Account = 1,
        /// <summary>
        /// 仅支持会员卡消费的店铺
        /// </summary>
        [Description("仅支持会员卡消费的店铺")]
        OnlyCardConsumeShop = 2,
        /// <summary>
        /// 优惠券可用店铺
        /// </summary>
        [Description("优惠券可用店铺")]
        Coupon = 3,
        /// <summary>
        /// 支持促销
        /// </summary>
        [Description("支持促销")]
        AutoPromotion = 4,
        /// <summary>
        /// 支持促销
        /// </summary>
        [Description("支持营销分析")]
        MarketingAnalyze = 5
        #endregion
    }
    
}
