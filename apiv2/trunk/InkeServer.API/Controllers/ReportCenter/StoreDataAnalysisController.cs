using InkeServer.API.Filters;
using InkeServer.Attributes;
using InkeServer.GlobalVariable;
using InkeServer.Model;
using InkeServer.Service;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Web.Http.Description;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 门店数据分析
    /// </summary>
    public class StoreDataAnalysisController : BaseController
    {
        #region Property

        [Inject]
        public IStoreDataAnalysisService StoreDataAnalysisService { get; set; }

        #endregion

        ///<summary>
        /// 查询门店营业额统计信息
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetStoreTurnoverAnalysisInfo")]
        [ResponseType(typeof(BaseResult<List<DataSet>>))]
        [HttpPost]
        public IHttpActionResult GetStoreTurnoverAnalysisInfo(StoreTurnoverAnalysisRequest query)
        {
            List<DataSet> result = StoreDataAnalysisService.GetStoreTurnoverInfo(query);
            return Json(result.CompleteResult());
        }

        ///<summary>
        /// 查询菜品销售排行
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetProductSalesRankingInfo")]
        [ResponseType(typeof(BaseResult<List<ProductSalesRankingResult>>))]
        [HttpPost]
        public IHttpActionResult GetProductSalesRankingInfo(ProductSalesRankingRequest query)
        {
            List<ProductSalesRankingResult> result = StoreDataAnalysisService.GetProductSalesRankingInfo(query);
            return Json(result.CompleteResult());
        }

        /// <summary>
        /// 获取客流量走势
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetCustomerStreamInfo")]
        [ResponseType(typeof(BaseResult<List<DataSet>>))]
        [HttpPost]
        public IHttpActionResult GetCustomerStreamInfo(CustomerStreamAnalysisRequest query)
        {
            List<DataSet> result = StoreDataAnalysisService.GetCustomerStreamAnalysis(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 获取时间段营业报表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetBusinessTimeSlotInfo")]
        [ResponseType(typeof(BaseResult<List<BusinessTimeSlotResult>>))]
        [HttpPost]
        public IHttpActionResult GetBusinessTimeSlotInfo(BusinessTimeSlotRequest query)
        {
            List<BusinessTimeSlotResult> result = StoreDataAnalysisService.GetBusinessTimeSlotReport(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 获取会员增长统计信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetMembershipGrowthReport")]
        [ResponseType(typeof(BaseResult<List<MembershipGrowthResult>>))]
        [HttpPost]
        public IHttpActionResult GetMembershipGrowthReport(MembershipGrowthRequest query)
        {
            List<MembershipGrowthResult> result = StoreDataAnalysisService.GetMembershipGrowthInfo(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 获取结算类型信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetPayTypeAnalysisReport")]
        [ResponseType(typeof(BaseResult<List<PayTypeAnalysisRequest>>))]
        [HttpPost]
        public IHttpActionResult GetPayTypeAnalysisReport(PayTypeAnalysisRequest query)
        {
            List<PayTypeAnalysisResult> result = StoreDataAnalysisService.GetPayTypeAnalysisInfo(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 获取就餐人数信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetNumberOfDinersReport")]
        [ResponseType(typeof(BaseResult<List<NumberOfDinersResult>>))]
        [HttpPost]
        public IHttpActionResult GetNumberOfDinersReport(NumberOfDinersRequest query)
        {
            List<NumberOfDinersResult> result = StoreDataAnalysisService.GetNumberOfDinersInfo(query);
            return Json(result.CompleteResult());
        }
         /// <summary>
        /// 获取翻台率信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetTableTurnoverRateReport")]
        [ResponseType(typeof(BaseResult<DataSet>))]
        [HttpPost]
        public IHttpActionResult GetTableTurnoverRateReport(TableTurnoverRateRequest query)
        {
            DataSet result = StoreDataAnalysisService.GetTableTurnoverRate(query);
            return Json(result.CompleteResult());
        }
    }
}