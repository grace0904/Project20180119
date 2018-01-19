using InkeServer.DataMapping;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inke.Common.Extentions;
using InkeServer.Enums;
using AutoMapper;
using System.Data.SqlClient;
using System.Data;
namespace InkeServer.Service.Impl
{
    /// <summary>
    /// 跨店结算服务类 
    /// </summary>
    public class CrossShopSettlementService : ServiceBase, ICrossShopSettlementService
    {
        //标记为注入对象
        [InjectionConstructor]
        public CrossShopSettlementService() { }
        /// <summary>
        /// 充值扣费结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataSet GetRechargeDeductionSettlement(StatisticsByTImeRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            #region GetNextResult不可用
            //var result1 = Entities.Rpt_RechargeDeductionSettlement(param.Merchant_ID, param.Shop_IDs, param.StartTime, param.EndTime);
            //if (result1 == null)
            //{
            //    return result;
            //}
            //result.RechargeDeductionTatolTable = result1.FirstOrDefault().MapTo<RechargeDeductionTatolTable>();
            //var result2 = result1.GetNextResult<Result_CardRechargeRecord>();
            //if (result2 != null)
            //{
            //    result.CardRechargeTable = result2.ToList();
            //}
            //var result3 = result1.GetNextResult<Result_CardRechargeRecord>().GetNextResult<Result_OrderPay>();
            //if (result3 != null)
            //{
            //    result.OrderPayTable = result3.ToList();
            //}
            #endregion
            SqlParameter[] para = new SqlParameter[] {
              new SqlParameter("@merchantid",param.Merchant_ID),
              new SqlParameter("@shopids",param.Shop_IDs),
              new SqlParameter("@begintime",param.StartTime),
              new SqlParameter("@endtime",param.EndTime)
             };
            DataSet ds = Entities.Database.SqlQueryForDynamic("Rpt_RechargeDeductionSettlement", para);
            para = null;
            return ds;
        }
        /// <summary>
        /// 优惠券结算
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<CouponSettlementResult> GetCouponSettlement(StatisticsByTImeRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var result = Entities.Rpt_CouponSettlement(param.Merchant_ID, param.Shop_IDs, param.StartTime, param.EndTime);
            if (result == null)
            {
                return new List<CouponSettlementResult>(); ;
            }
            return result.ToList().MapTo<CouponSettlementResult>();
        }
    }
}
