using Inke.Common.Paginations;
using InkeServer.API.Filters;
using InkeServer.Attributes;
using InkeServer.GlobalVariable;
using InkeServer.Model;
using InkeServer.Service;
using System.Web.Http;
using System.Web.Http.Description;

namespace InkeServer.API.Controllers
{
    public class SysLogController : BaseController
    {
        #region Property

        [Inject]
        public ISysLogService SysLogService { get; set; }

        #endregion

        /// <summary>
        /// 分页查询日志列表
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/SysLogQuery")]
        [ResponseType(typeof(BaseResult<IPaginationResult<SysLogInfo>>))]
        [HttpPost]
        public IHttpActionResult SysLogQuery(SysLogQueryRequest query)
        {
            IPaginationResult<SysLogInfo> result = SysLogService.Query(query);
             return Json(result.CompleteResult());
        }
    }
}