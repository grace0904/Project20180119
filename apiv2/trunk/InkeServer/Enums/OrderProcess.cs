using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Enums
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderProcess : int
    {
        /// <summary>
        /// 新订单(待处理)
        /// </summary>
        NewOrder = 0,
        /// <summary>
        /// 结帐中
        /// </summary>
        Cashier = 1,
        /// <summary>
        /// 完成
        /// </summary>
        Completed = 9,
        #region
        /// <summary>
        /// 待配送(已处理)
        /// </summary>
        UnDelivery = 2,
        /// <summary>
        /// 已配送(配送中)
        /// </summary>
        Deliveryed = 3,
        /// <summary>
        /// 已取消
        /// </summary>
        Canceled = 4,

        /// <summary>
        /// 已退单
        /// </summary>
        Backed = 5,
        /// <summary>
        /// 拒绝接单
        /// </summary>
        Refuse = 6,
        ///// <summary>
        ///// 退单申请中
        ///// </summary>
        //Backing = 7,
        /// <summary>
        /// 未下单(未支付或支付失败的单)
        /// </summary>
        NotOrder = 8,
        #endregion
    }
}
