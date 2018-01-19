using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Enums
{
    /// <summary>
    /// 支付方式
    /// </summary>
    public enum PayType : int
    {
        #region
        /// <summary>
        /// 现金
        /// </summary>
        Cash = 1,
        /// <summary>
        /// 银行卡
        /// </summary>
        BankCard = 2,
        /// <summary>
        /// 会员卡
        /// </summary>
        MemberCard = 3,
        /// <summary>
        /// 支付宝
        /// </summary>
        AliPay = 4,
        /// <summary>
        /// 微信支付
        /// </summary>
        WeiXin = 5,
        /// <summary>
        /// 团购券
        /// </summary>
        Groupbuy = 6,
        ///// <summary>
        ///// 货到付款
        ///// </summary>
        //PayByDelivery = 7
        #endregion
    }
}
