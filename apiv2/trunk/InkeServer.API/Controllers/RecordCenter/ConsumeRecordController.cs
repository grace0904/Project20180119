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
using Inke.Common.Paginations;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 消费记录
    /// </summary>
    public class ConsumeRecordController : BaseController
    {
        // GET: ConsumeRecord
        #region Property

        [Inject]
        public IConsumeRecordService ConsumeRecordService { get; set; }

        #endregion

        ///<summary>
        /// 获得查询消费记录
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetConsumeRecordData")]
        [ResponseType(typeof(BaseResult<IPaginationResult<ConsumeRecordInfo>>))]
        [HttpPost]
        public IHttpActionResult GetConsumeRecordData(ConsumeRecordRequest query)
        {
            IPaginationResult<ConsumeRecordInfo> result = ConsumeRecordService.GetConsumeRecordList(query);
            return Json(result.CompleteResult());
        }
        ///<summary>
        /// 获得消费记录详细信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetConsumeRecordInfo")]
        [ResponseType(typeof(BaseResult<ConsumeRecordInfoResult>))]
        [HttpPost]
        public IHttpActionResult GetConsumeRecordInfo(ConsumeRecordInfoRequest query)
        {
            ConsumeRecordInfoResult result = ConsumeRecordService.GetConsumeRecordInfo(query);
            return Json(result.CompleteResult());
        }
    }
}