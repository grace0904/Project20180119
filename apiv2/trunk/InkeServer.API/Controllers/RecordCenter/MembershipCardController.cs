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
    /// 会员卡记录
    /// </summary>
    public class MembershipCardController : BaseController
    {
        #region Property

        [Inject]
        public IMembershipCardService MembershipCardService { get; set; }

        #endregion

        /// <summary>
        /// 分页查询会员卡记录
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetMembershipCardPage")]
        [ResponseType(typeof(BaseResult<IPaginationResult<MembershipCardPageResult>>))]
        [HttpPost]
        public IHttpActionResult GetMembershipCardPage(MembershipCardPageRequest query)
        {
            IPaginationResult<MembershipCardPageResult> result = MembershipCardService.MembershipCardPage(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 根据ID获取会员卡记录
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetMembershipCardbyID")]
        [ResponseType(typeof(BaseResult<MembershipCardPageResult>))]
        [HttpPost]
        public IHttpActionResult GetMembershipCardbyID(RecordIDRequest query)
        {
            MembershipCardPageResult result = MembershipCardService.MembershipCardbyID(query);
            return Json(result.CompleteResult());
        }
    }
}