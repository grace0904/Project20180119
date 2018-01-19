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

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 会员
    /// </summary>
    public class MemberController : BaseController
    {
        // GET: Member
        #region Property

        [Inject]
        public IMemberService MemberService { get; set; }

        #endregion
        /// <summary>
        /// 分页查询会员集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetMemberPageList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<MemberQueryResult>>))]
        [HttpPost]
        public IHttpActionResult GetMemberPageList(MemberQueryRequest query)
        {
            IPaginationResult<MemberQueryResult> result = MemberService.Query(query);
            return Json(result.CompleteResult());
        }
    }
}