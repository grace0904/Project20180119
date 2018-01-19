using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Enums
{
    /// <summary>
    /// 业务类型
    /// </summary>
    public enum BusinessClass : int
    {
        #region
        /// <summary>
        /// 开卡
        /// </summary>
        OpenCard = 1,
        /// <summary>
        /// 充值
        /// </summary>
        CardRecharge = 2,
        /// <summary>
        /// 消费
        /// </summary>
        CardConsume = 3,
        /// <summary>
        /// 项目充值
        /// </summary>
        CouponRecharge = 4,
        /// <summary>
        /// 积分兑换
        /// </summary>
        IntegralExchange = 5,
        /// <summary>
        /// 积分调整
        /// </summary>
        IntegralAdjust = 6,
        /// <summary>
        /// 自动促销
        /// </summary>
        AutoPromotion = 7,
        /// <summary>
        /// 预充值   
        /// </summary>
        PresetRecharge = 8,
        /// <summary>
        /// 批量优惠券充值
        /// </summary>
        BatchCouponRecharge = 9,
        /// <summary>
        /// 批量积分调整
        /// </summary>
        BatchIntegralAdjust = 10,
        /// <summary>
        /// 预约
        /// </summary>
        Reservation = 11,
        /// <summary>
        /// 挂帐
        /// </summary>
        Arrears = 12,
        /// <summary>
        /// 营销分析
        /// </summary>
        MarketingAnalyze = 13,
        /// <summary>
        /// 旧系统导入
        /// </summary>
        OldDataImport = 99,
        /// <summary>
        /// 退回
        /// </summary>
        Backed = 100
        #endregion
    }
}
