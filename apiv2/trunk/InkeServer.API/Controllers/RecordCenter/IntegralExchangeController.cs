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
    /// 积分兑换记录
    /// </summary>
    public class IntegralExchangeController : BaseController
    {
        #region Property

        [Inject]
        public IIntegralExchangeService IntegralExchangeService { get; set; }

        #endregion
        /// <summary>
        /// 分页查询积分兑换记录
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetIntegralExchangePage")]
        [ResponseType(typeof(BaseResult<IPaginationResult<IntegralExchangePageResult>>))]
        [HttpPost]
        public IHttpActionResult GetIntegralExchangePage(IntegralExchangePageRequest query)
        {
            IPaginationResult<IntegralExchangePageResult> result = IntegralExchangeService.GetIntegralExchangePage(query);
            return Json(result.CompleteResult());
        }
    }
}