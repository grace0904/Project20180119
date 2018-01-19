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
    /// 积分调整记录
    /// </summary>
    public class IntegralAdjustController : BaseController
    {
        #region Property

        [Inject]
        public IIntegralAdjustService IntegralAdjustService { get; set; }

        #endregion
        /// <summary>
        /// 分页查询积分调整记录
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetIntegralAdjustPage")]
        [ResponseType(typeof(BaseResult<IPaginationResult<IntegralAdjustPageResult>>))]
        [HttpPost]
        public IHttpActionResult GetIntegralAdjustPage(IntegralAdjustPageRequest query)
        {
            IPaginationResult<IntegralAdjustPageResult> result = IntegralAdjustService.GetIntegralAdjustPage(query);
            return Json(result.CompleteResult());
        }
    }
}