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
    /// 基础设置
    /// </summary>
    public class MerchantBaseController : BaseController
    {
        #region Property

        [Inject]
        public IMerchantBaseService MerchantBaseService { get; set; }

        #endregion

        /// <summary>
        /// 分页查询基础信息列表
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetMerchantBaseInfo")]
        [ResponseType(typeof(BaseResult<IPaginationResult<MerchantBaseQueryResult>>))]
        [HttpPost]
        public IHttpActionResult GetMerchantBaseInfo(MerchantBasePageQueryRequest query)
        {
            IPaginationResult<MerchantBaseQueryResult> result = MerchantBaseService.GetMerchantBaseInfoPage(query);
            return Json(result.CompleteResult());
        }

        /// <summary>
        /// 获取基础信息列表
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetMerchantBaseInfoList")]
        [ResponseType(typeof(BaseResult<MerchantBaseQueryResult>))]
        [HttpPost]
        public IHttpActionResult GetMerchantBaseInfoList(MerchantBaseQueryRequest param)
        {
            List<MerchantBaseQueryResult> result = MerchantBaseService.GetMerchantBaseInfoList(param);
            return Json(result.CompleteResult());
        }

        /// <summary>
        /// 通过id获取单条基础信息列表
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetMerchantBaseInfobyID")]
        [ResponseType(typeof(BaseResult<MerchantBaseQueryResult>))]
        [HttpPost]
        public IHttpActionResult GetMerchantBaseInfobyID(RecordIDRequest param)
        {
            MerchantBaseQueryResult result = MerchantBaseService.GetMerchantBaseInfo(param.Record_ID);
            return Json(result.CompleteResult());
        }

        ///<summary>
        /// 新增基础资料
        /// </summary>
        /// <returns></returns>
        [OperationLog("新增基础资料")]
        [Route("api/v2/MerchantBaseInfoInsert")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult MerchantBaseInfoInsert(MerchantBaseInsert param)
        {
            MerchantBaseService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }

        ///<summary>
        /// 修改基础资料
        /// </summary>
        /// <returns></returns>
        [OperationLog("修改基础资料")]
        [Route("api/v2/MerchantBaseInfoUpdate")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult MerchantBaseInfoUpdate(MerchantBaseUpdate param)
        {
            MerchantBaseService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }

        ///<summary>
        /// 删除基础资料
        /// </summary>
        /// <returns></returns>
        [OperationLog("删除基础资料")]
        [Route("api/v2/MerchantBaseInfoDelete")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult MerchantBaseInfoDelete(OperationBaseRequest param)
        {
            MerchantBaseService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }

    }
}