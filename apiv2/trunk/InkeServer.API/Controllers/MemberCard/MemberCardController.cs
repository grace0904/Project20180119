using Inke.Common.Paginations;
using InkeServer.Model;
using System.Web.Http;
using System.Web.Http.Description;
using InkeServer.GlobalVariable;
using InkeServer.Attributes;
using InkeServer.Service;
using System.Collections.Generic;
using InkeServer.API.Filters;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 会员卡记录
    /// </summary>
    public class MemberCardController : BaseController
    { 
        // GET: MarketAnalysis
        #region Property

        [Inject]
        public IMemberCardService MemberCardService { get; set; }

        #endregion

        /// <summary>
        /// 分页查询会员卡记录
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetMemberCardPage")]
        [ResponseType(typeof(BaseResult<IPaginationResult<MemberCardResult>>))]
        [HttpPost]
        public IHttpActionResult GetMemberCardPage(MemberCardRequest query)
        {
            IPaginationResult<MemberCardResult> result = MemberCardService.GetMemberCardPage(query);
            return Json(result.CompleteResult());
        }
    }
}
