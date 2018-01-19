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
using System.IO;
using System.Text;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 自动促销
    /// </summary>
    public class AutoPromotionController : BaseController
    {
        // GET: AutoPromotion
        #region Property

        [Inject]
        public IAutoPromotionService AutoPromotionService { get; set; }

        #endregion

        /// <summary>
        /// 分页查询自动促销集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetAutoPromotionPageList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<AutoPromotionQueryResult>>))]
        [HttpPost]
        public IHttpActionResult GetAutoPromotionPageList(AutoPromotionQueryRequest query)
        {
            IPaginationResult<AutoPromotionQueryResult> result = AutoPromotionService.Query(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 添加自动促销记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("添加自动促销记录")]
        [Route("api/v2/AddAutoPromotion")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult AddAutoPromotion(AddAndUpdatePromotionRequest param)
        {
            AutoPromotionService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 修改自动促销
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改自动促销")]
        [Route("api/v2/UpdateAutoPromotion")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult UpdateAutoPromotion(AddAndUpdatePromotionRequest param)
        {
            AutoPromotionService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 删除自动促销
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("直接删除自动促销")]
        [Route("api/v2/DeleteAutoPromotion")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteAutoPromotion(OperationBaseRequest param)
        {
            AutoPromotionService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 启用/停用自动促销
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("启用/停用自动促销")]
        [Route("api/v2/SetEnableAutoPromotion")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult SetEnableAutoPromotion(RecordIDAndStatusRequest param)
        {
            AutoPromotionService.SetEnable(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 获取自动促销详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetAutoPromotionInfo")]
        [ResponseType(typeof(BaseResult<AutoPromotionInfoResult>))]
        [HttpPost]
        public IHttpActionResult GetAutoPromotionInfo(RecordIDRequest param)
        {
            AutoPromotionInfoResult info = AutoPromotionService.GetAutoPromotionInfo(param);
            return Json(info.CompleteResult());
        }
        /// <summary>
        /// 获取自动促销名称集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetAutoPromotionNameList")]
        [ResponseType(typeof(BaseResult<List<AutoPromotionName>>))]
        [HttpPost]
        public IHttpActionResult GetAutoPromotionNameList(MerchantIdRequest param)
        {
            List<AutoPromotionName> info = AutoPromotionService.GetAutoPromotionNameList(param);
            return Json(info.CompleteResult());
        }
        /// <summary>
        ///分页查询 自动促销发放记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetAutoPromotionRecord")]
        [ResponseType(typeof(BaseResult<IPaginationResult<PromotionRecord>>))]
        [HttpPost]
        public IHttpActionResult GetAutoPromotionRecord(PromotionRecordSearch param)
        {
            IPaginationResult<PromotionRecord> info = AutoPromotionService.GetAutoPromotionRecord(param);
            return Json(info.CompleteResult());
        }
        /// <summary>
        ///自动促销使用记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetAutoPromotionCouponUsedRecord")]
        [ResponseType(typeof(BaseResult<IPaginationResult<PromotionCouponUsedRecord>>))]
        [HttpPost]
        public IHttpActionResult GetAutoPromotionCouponUsedRecord(PromotionRecordSearch param)
        {
            IPaginationResult<PromotionCouponUsedRecord> info = AutoPromotionService.GetAutoPromotionCouponUsedRecord(param);
            return Json(info.CompleteResult());
        }
        /// <summary>
        ///自动促销首页统计
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetPromotionStatisticsTable")]
        [ResponseType(typeof(BaseResult<List<PromotionStatistics>>))]
        [HttpPost]
        public IHttpActionResult GetPromotionStatisticsTable(PromotionStatisticsRequest param)
        {
            List<PromotionStatistics> info = AutoPromotionService.GetPromotionStatisticsTable(param);
            return Json(info.CompleteResult());
        }
        /// <summary>
        ///自动促销发放使用统计
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetPromotionRecordStatisticsTable")]
        [ResponseType(typeof(BaseResult<PromotionStatistics>))]
        [HttpPost]
        public IHttpActionResult GetPromotionRecordStatisticsTable(PromotionRecordSearch param)
        {
            PromotionStatistics info = AutoPromotionService.GetPromotionRecordStatisticsTable(param);
            return Json(info.CompleteResult());
        }
    }
}