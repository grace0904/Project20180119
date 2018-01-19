using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    /// <summary>
    /// 跨店结算服务接口类
    /// </summary>
    public interface ICrossShopSettlementService
    {
        /// <summary>
        /// 充值扣费结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        DataSet GetRechargeDeductionSettlement(StatisticsByTImeRequest param);
        /// <summary>
        /// 优惠券结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<CouponSettlementResult> GetCouponSettlement(StatisticsByTImeRequest param);
    }
}
