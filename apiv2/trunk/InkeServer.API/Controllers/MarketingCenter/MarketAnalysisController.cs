using Inke.Common.Paginations;
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
using InkeServer.API.Filters;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 营销分析以及自定义营销中心 
    /// </summary>
    public class MarketAnalysisController : BaseController
    {
        // GET: MarketAnalysis
        #region Property

        [Inject]
        public IMarketAnalysisService MarketAnalysisService { get; set; }

        #endregion

        /// <summary>
        /// 分页查询营销分析集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetMarketAnalysisPageList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<MarketAnalysisQueryResult>>))]
        [HttpPost]
        public IHttpActionResult GetMarketAnalysisPageList(MarketAnalysisQueryRequest query)
        {
            IPaginationResult<MarketAnalysisQueryResult> result = MarketAnalysisService.Query(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 添加营销分析记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("添加营销分析记录")]
        [Route("api/v2/AddMarketAnalysis")]
        [ResponseType(typeof(BaseResult<MarketAnalysisID>))]
        [HttpPost]
        public IHttpActionResult AddMarketAnalysis(MarketAnalysisAddOrUpdateRequest param)
        {
            var result = MarketAnalysisService.Insert(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 修改营销分析记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改营销分析记录")]
        [Route("api/v2/UpdateMarketAnalysis")]
        [ResponseType(typeof(BaseResult<MarketAnalysisID>))]
        [HttpPost]
        public IHttpActionResult UpdateMarketAnalysis(MarketAnalysisAddOrUpdateRequest param)
        {
            var result = MarketAnalysisService.Update(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 删除营销分析记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("将营销分析记录标记为删除")]
        [Route("api/v2/DeleteMarketAnalysis")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteMarketAnalysis(OperationBaseRequest param)
        {
            MarketAnalysisService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 启用/停用营销分析记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("启用/停用营销分析记录")]
        [Route("api/v2/SetEnableMarketAnalysis")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult SetEnableMarketAnalysis(RecordIDAndStatusRequest param)
        {
            MarketAnalysisService.SetEnable(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 更新最新筛选结果
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("更新最新筛选结果")]
        [Route("api/v2/UpdateStatisticsTotal")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult UpdateStatisticsTotal(OperationBaseRequest param)
        {
            MarketAnalysisService.UpdateStatisticsTotal(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 获取营销分析记录详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetMarketAnalysisInfo")]
        [ResponseType(typeof(BaseResult<MarketAnalysisInfoResult>))]
        [HttpPost]
        public IHttpActionResult GetMarketAnalysisInfo(RecordIDRequest param)
        {
            MarketAnalysisInfoResult result = MarketAnalysisService.GetInfo(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 获取营销分析记录名称集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetMarketingAnalyzeNameList")]
        [ResponseType(typeof(BaseResult<List<MarketingAnalyzeIDAndName>>))]
        [HttpPost]
        public IHttpActionResult GetMarketingAnalyzeNameList(MarketingAnalyzeNameRequest param)
        {
            List<MarketingAnalyzeIDAndName> result = MarketAnalysisService.GetMarketingAnalyzeNameList(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 营销分析结果明细
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetMarketingAnalyzeResult")]
        [ResponseType(typeof(BaseResult<IPaginationResult<MarketingAnalyzeDetialsResult>>))]
        [HttpPost]
        public IHttpActionResult GetMarketingAnalyzeResult(MarketingAnalyzeDetailsRequest param)
        {
            IPaginationResult<MarketingAnalyzeDetialsResult> result = MarketAnalysisService.GetMarketingAnalyzeResult(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 营销分析结果明细 筛选重复名称
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetMarketingAnalyzeResultDistinct")]
        [ResponseType(typeof(BaseResult<IPaginationResult<MarketingAnalyzeDetialsResult>>))]
        [HttpPost]
        public IHttpActionResult GetMarketingAnalyzeResultDistinct(MarketingAnalyzeResultDistinctRequest param)
        {
            IPaginationResult<MarketingAnalyzeDetialsResult> result = MarketAnalysisService.GetMarketingAnalyzeResultDistinct(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 检查营销方案的可执行性,返回过期优惠券集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/CheckMarketAnalyzeExecutable")]
        [ResponseType(typeof(BaseResult<List<CouponIDAndName>>))]
        [HttpPost]
        public IHttpActionResult CheckMarketAnalyzeExecutable(RecordIDRequest param)
        {
            List<CouponIDAndName> result = MarketAnalysisService.CheckMarketAnalyzeExecutable(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 营销分析发放
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("营销分析发放")]
        [Route("api/v2/MarketingAnalyzeExec")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult MarketingAnalyzeExec(MarketingAnalyzeExecRequest param)
        {
            MarketAnalysisService.MarketingAnalyzeExec(param);
            return Json(MessageConverter.CompleteResult());
        }

        /// <summary>
        /// 分页查询营销分析发放记录集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetMarketingAnalyzeRecord")]
        [ResponseType(typeof(BaseResult<IPaginationResult<MarketingAnalyzeRecord>>))]
        [HttpPost]
        public IHttpActionResult GetMarketingAnalyzeRecord(MarketingAnalyzeRecordRequest query)
        {
            IPaginationResult<MarketingAnalyzeRecord> result = MarketAnalysisService.GetMarketingAnalyzeRecord(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 分页查询营销分析使用记录集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetMarketAnalysisCouponUsedRecord")]
        [ResponseType(typeof(BaseResult<IPaginationResult<MarketingAnalyzeCouponUsedRecord>>))]
        [HttpPost]
        public IHttpActionResult GetMarketAnalysisCouponUsedRecord(MarketingAnalyzeRecordRequest query)
        {
            IPaginationResult<MarketingAnalyzeCouponUsedRecord> result = MarketAnalysisService.GetMarketAnalysisCouponUsedRecord(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        ///营销分析首页统计
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetMarketingAnalyzeStatisticsTable")]
        [ResponseType(typeof(BaseResult<MarketAnalysisStstistics>))]
        [HttpPost]
        public IHttpActionResult GetMarketingAnalyzeStatisticsTable(PromotionStatisticsRequest query)
        {
            MarketAnalysisStstistics result = MarketAnalysisService.GetMarketingAnalyzeStatisticsTable(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        ///营销分析发放使用统计
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetMarketingAnalyzeRecordStatistics")]
        [ResponseType(typeof(BaseResult<MarketAnalysisStstistics>))]
        [HttpPost]
        public IHttpActionResult GetMarketingAnalyzeRecordStatistics(MarketingAnalyzeRecordRequest query)
        {
            MarketAnalysisStstistics result = MarketAnalysisService.GetMarketingAnalyzeRecordStatistics(query);
            return Json(result.CompleteResult());
        }
    }
}