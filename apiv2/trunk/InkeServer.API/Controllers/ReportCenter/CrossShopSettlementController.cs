using InkeServer.Attributes;
using InkeServer.Model;
using InkeServer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using InkeServer.GlobalVariable;
using System.Data;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 跨店结算
    /// </summary>
    public class CrossShopSettlementController : BaseController
    {
        // GET: CrossShopSettlement
         #region Property

        [Inject]
        public ICrossShopSettlementService CrossShopSettlementService { get; set; }

        #endregion

          /// <summary>
        /// 充值扣费结算
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/RechargeDeductionSettlement")]
        [ResponseType(typeof(BaseResult<DataSet>))]
        [HttpPost]
        public IHttpActionResult RechargeDeductionSettlement(StatisticsByTImeRequest query)
        {
            DataSet result = CrossShopSettlementService.GetRechargeDeductionSettlement(query);
            return Json(result.CompleteResult());
        }
        
         /// <summary>
        /// 优惠券结算
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/CouponSettlement")]
        [ResponseType(typeof(BaseResult<List<CouponSettlementResult>>))]
        [HttpPost]
        public IHttpActionResult CouponSettlement(StatisticsByTImeRequest query)
        {
            List<CouponSettlementResult> result = CrossShopSettlementService.GetCouponSettlement(query);
            return Json(result.CompleteResult());
        }
    }
}