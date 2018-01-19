using InkeServer.API.Filters;
using InkeServer.Attributes;
using InkeServer.GlobalVariable;
using InkeServer.Model;
using InkeServer.Service;
using System.Web.Http;
using System.Web.Http.Description;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 登录控制器
    /// </summary>
    public class LoginController : BaseController
    {
        #region Property

        [Inject]
        public ILoginService LoginService { get; set; }

        #endregion

        ///<summary>
        /// 登录查询
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/Login")]
        [ResponseType(typeof(BaseResult<LoginResult>))]
        [HttpPost]
        public IHttpActionResult Login(LoginRequest query)
        {
            LoginResult result = LoginService.Login(query);
            return Json(result.CompleteResult());
        }
    }
}