using InkeServer.Attributes;
using InkeServer.Model;
using InkeServer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InkeServer.GlobalVariable;
using InkeServer.API.Filters;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 外卖设置
    /// </summary>
    public class TakeOutController : BaseController
    {
        // GET: Employee
        #region Property

        [Inject]
        public ITakeOutService TakeOutService { get; set; }

        #endregion

        /// <summary>
        /// 获取相关外卖信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetTakeOutInfo")]
        [ResponseType(typeof(BaseResult<TakeOutResult>))]
        [HttpPost]
        public IHttpActionResult GetTakeOutInfo(ShopIdRequest param)
        {
            TakeOutResult result = TakeOutService.GetTakeOutInfo(param);
            return Json(result.CompleteResult());
        }

        ///<summary>
        /// 修改店铺外卖信息
        /// </summary>
        /// <returns></returns>
        [OperationLog("修改店铺外卖信息")]
        [Route("api/v2/ShopTakeOutUpdate")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopTakeOutUpdate(TakeOutUpdate param)
        {
            TakeOutService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
    }
}
