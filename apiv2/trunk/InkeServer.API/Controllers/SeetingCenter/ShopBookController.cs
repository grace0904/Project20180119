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
    /// 预约设置
    /// </summary>
    public class ShopBookController : BaseController
    {
        // GET: Employee
        #region Property

        [Inject]
        public IShopBookService ShopBookService { get; set; }

        #endregion

        /// <summary>
        /// 获取相关预约信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetShopBookInfo")]
        [ResponseType(typeof(BaseResult<ShopBookResult>))]
        [HttpPost]
        public IHttpActionResult GetShopBookInfo(ShopIdRequest param)
        {
            ShopBookResult result = ShopBookService.GetShopBookInfo(param);
            return Json(result.CompleteResult());
        }

        ///<summary>
        /// 修改店铺预约信息
        /// </summary>
        /// <returns></returns>
        [OperationLog("修改店铺预约信息")]
        [Route("api/v2/ShopBookUpdate")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopBookUpdate(ShopBookUpdate param)
        {
            ShopBookService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
    }
}
