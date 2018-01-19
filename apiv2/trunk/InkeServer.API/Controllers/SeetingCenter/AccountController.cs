using Inke.Common.Paginations;
using InkeServer.Attributes;
using InkeServer.Model;
using InkeServer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using InkeServer.GlobalVariable;
using System.Web.Http;
using InkeServer.API.Filters;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 账号设置
    /// </summary>
    public class AccountController : BaseController
    {
        // GET: Account
        #region Property

        [Inject]
        public IAccountService AccountService { get; set; }

        #endregion
        /// <summary>
        /// 分页查询员工账号集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetAccountPageList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<AccountInfoResult>>))]
        [HttpPost]
        public IHttpActionResult GetAccountPageList(AccountQueryRequest query)
        {
            IPaginationResult<AccountInfoResult> result = AccountService.Query(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 添加员工账号
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("添加员工账号")]
        [Route("api/v2/AddAccount")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult AddAccount(AddOrUpdateAccountRequest param)
        {
            AccountService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 修改员工账号
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改员工账号")]
        [Route("api/v2/UpdateAccount")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult UpdateAccount(AddOrUpdateAccountRequest param)
        {
            AccountService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 删除员工账号
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("把员工账号标记为删除")]
        [Route("api/v2/DeleteAccount")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteAccount(OperationBaseRequest param)
        {
            AccountService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }

        /// <summary>
        /// 获取员工账号详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetAccountInfo")]
        [ResponseType(typeof(BaseResult<AccountInfoResult>))]
        [HttpPost]
        public IHttpActionResult GetAccountInfo(RecordIDRequest param)
        {
            AccountInfoResult info = AccountService.GetInfo(param);
            return Json(info.CompleteResult());
        }
    }
}