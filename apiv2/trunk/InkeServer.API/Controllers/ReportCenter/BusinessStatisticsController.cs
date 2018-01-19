using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using InkeServer.GlobalVariable;
using InkeServer.Attributes;
using InkeServer.Service;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 营业报表统计
    /// </summary>
    public class BusinessStatisticsController : BaseController
    {
        // GET: BusinessStatistics
        #region Property

        [Inject]
        public IBusinessStatisticsService BusinessStatisticsService { get; set; }

        #endregion
        /// <summary>
        /// 营业报表时间段
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/BusinessHours")]
        [ResponseType(typeof(BaseResult<DataSet>))]
        [HttpPost]
        public IHttpActionResult BusinessHours(BusinessHoursRequest query)
        {
            DataSet result = BusinessStatisticsService.GetBusinessHours(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 营业日期报表统计
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/BusinessDates")]
        [ResponseType(typeof(BaseResult<DataSet>))]
        [HttpPost]
        public IHttpActionResult BusinessDates(BusinessHoursRequest query)
        {
            DataSet result = BusinessStatisticsService.GetBusinessDates(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 优惠券使用统计(表格和饼状图)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/CouponMemoryUsage")]
        [ResponseType(typeof(BaseResult<List<CouponMemoryUsageResult>>))]
        [HttpPost]
        public IHttpActionResult CouponMemoryUsage(CouponMemoryUsageRequest query)
        {
            List<CouponMemoryUsageResult> result = BusinessStatisticsService.GetCouponMemoryUsage(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 优惠券使用统计(柱状图)
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/CouponMemoryUsageBar")]
        [ResponseType(typeof(BaseResult<DataSet>))]
        [HttpPost]
        public IHttpActionResult CouponMemoryUsageBar(CouponMemoryUsageBarRequest query)
        {
            DataSet result = BusinessStatisticsService.GetCouponMemoryUsageBar(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 产品统计
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/ReportProductSalse")]
        [ResponseType(typeof(BaseResult<List<StatisticsProductResult>>))]
        [HttpPost]
        public IHttpActionResult ReportProductSalse(ProductSaleRequest query)
        {
            List<StatisticsProductResult> result = BusinessStatisticsService.ReturnReportProductSalse(query);
            return Json(result.CompleteResult());
        }
    }
}