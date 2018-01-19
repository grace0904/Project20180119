using Inke.Common.Paginations;
using InkeServer.Attributes;
using InkeServer.Model;
using InkeServer.Service;
using System.Web.Http;
using System.Web.Http.Description;
using InkeServer.GlobalVariable;
using InkeServer.API.Filters;
using System.Collections.Generic;
using Inke.Common.Extentions;
using InkeServer.Enums;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 优惠券
    /// </summary>
    public class CouponsController : BaseController
    {
        // GET: Coupons
        #region Property

        [Inject]
        public ICouponsService CouponsService { get; set; }

        #endregion
        /// <summary>
        /// 分页查询优惠券集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetCouponsPageList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<CouponInfoResult>>))]
        [HttpPost]
        public IHttpActionResult GetCouponsPageList(CouponsQueryRequest query)
        {
            IPaginationResult<CouponInfoResult> result = CouponsService.Query(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 添加优惠券
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("添加优惠券")]
        [Route("api/v2/AddCoupons")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult AddCoupons(AddOrUpdateCouponsRequest param)
        {
            CouponsService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 修改商家积分产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改优惠券")]
        [Route("api/v2/UpdateCoupons")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult UpdateCoupons(AddOrUpdateCouponsRequest param)
        {
            CouponsService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 删除优惠券
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("把优惠券标记为删除")]
        [Route("api/v2/DeleteCoupons")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteCoupons(OperationBaseRequest param)
        {
            CouponsService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 获取优惠券详细信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetCouponsInfo")]
        [ResponseType(typeof(BaseResult<CouponInfoResult>))]
        [HttpPost]
        public IHttpActionResult GetCouponsInfo(RecordIDRequest query)
        {
            CouponInfoResult result = CouponsService.GetInfo(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 获取商家所有优惠券列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetCouponList")]
        [ResponseType(typeof(BaseResult<List<CouponInfo>>))]
        [HttpPost]
        public IHttpActionResult GetCouponList(MerchantIdRequest param)
        {
            List<CouponInfo> result = CouponsService.GetCouponList(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 获取可用优惠券集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetAvailableCouponList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<CouponInfoResult>>))]
        [HttpPost]
        public IHttpActionResult GetAvailableCouponList(AvailableCouponQueryRequest query)
        {
            IPaginationResult<CouponInfoResult> result = CouponsService.GetAvailableCouponList(query);
            return Json(result.CompleteResult());
        }
    }
}