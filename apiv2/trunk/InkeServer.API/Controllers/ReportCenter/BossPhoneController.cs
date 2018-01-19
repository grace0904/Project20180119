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
    /// 老板手机报表
    /// </summary>
    public class BossPhoneController : BaseController
    {
        #region Property

        [Inject]
        public IBossPhoneService BossPhoneService { get; set; }

        #endregion

        ///<summary>
        /// 获取老板手机报表列表
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetBossPhoneReport")]
        [ResponseType(typeof(BaseResult<List<BossReportRecordResult>>))]
        [HttpPost]
        public IHttpActionResult GetBossPhoneReport(MerchantIdRequest query)
        {
            List<BossReportRecordResult> result = BossPhoneService.GetBossReportRecord(query);
            return Json(result.CompleteResult());
        }
        ///<summary>
        /// 新增老板手机报表
        /// </summary>
        /// <returns></returns>
        [OperationLog("新增老板手机报表")]
        [Route("api/v2/BossPhoneInsert")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopSeatInsert(BossPhoneInsert param)
        {
            BossPhoneService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }

        ///<summary>
        /// 修改老板手机报表
        /// </summary>
        /// <returns></returns>
        [OperationLog("修改老板手机报表")]
        [Route("api/v2/BossPhoneUpdate")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopSeatUpdate(BossPhoneUpdate param)
        {
            BossPhoneService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }

        ///<summary>
        /// 删除老板手机报表
        /// </summary>
        /// <returns></returns>
        [OperationLog("删除老板手机报表")]
        [Route("api/v2/BossPhoneDelete")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopSeatDelete(OperationBaseRequest param)
        {
            BossPhoneService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 根据ID查询老板报表信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetBossPhoneReportInfo")]
        [ResponseType(typeof(BaseResult<BossReportRecordInfoResult>))]
        [HttpPost]
        public IHttpActionResult GetBossPhoneReportInfo(RecordIDRequest query)
        {
            BossReportRecordInfoResult result = BossPhoneService.GetBossReportInfo(query.Record_ID);
            return Json(result.CompleteResult());
        }
    }
}