using Inke.Common.Paginations;
using InkeServer.API.Filters;
using InkeServer.Attributes;
using InkeServer.GlobalVariable;
using InkeServer.Model;
using InkeServer.Service;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 优惠券记录
    /// </summary>
    public class CouponRecordController : BaseController
    {
        #region Property

        [Inject]
        public ICouponRechargeSercice CouponRechargeSercice { get; set; }

        #endregion

        /// <summary>
        /// 获取优惠券记录分页信息
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetCouponRechargePage")]
        [ResponseType(typeof(BaseResult<IPaginationResult<CouponRechargePageResult>>))]
        [HttpPost]
        public IHttpActionResult GetCouponRechargePage(CouponRechargePageRequest param)
        {
            IPaginationResult<CouponRechargePageResult> couponrecordlist = CouponRechargeSercice.GetCouponRechargeListPage(param);
            return Json(couponrecordlist.CompleteResult());
        }
        /// <summary>
        /// 获取优惠券信息根据记录ID获取
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetCouponRechargeInfoList")]
        [ResponseType(typeof(BaseResult<List<CouponRechargeRecordInfoResult>>))]
        [HttpPost]
        public IHttpActionResult GetCouponRechargeInfoList(CouponRechargeRecordInfoRequest param)
        {
            List<CouponRechargeRecordInfoResult> couponrecordlist = CouponRechargeSercice.GetCouponRechargeRecordbyID(param);
            return Json(couponrecordlist.CompleteResult());
        }      
    }
}