using InkeServer.Attributes;
using InkeServer.Enums;
using InkeServer.Model;
using InkeServer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Inke.Common.Extentions;
using InkeServer.GlobalVariable;
using InkeServer.API.Filters;
using Inke.Common.Paginations;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 套餐组产品
    /// </summary>
    public class ComboProductController : BaseController
    {
        // GET: ComboProduct
        #region Property

        [Inject]
        public IComboProductService ComboProductService { get; set; }

        #endregion

        /// <summary>
        /// 获取指定套餐组下的套餐产品列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetComboProductList")]
        [ResponseType(typeof(BaseResult<List<GetComboProductQueryResult>>))]
        [HttpPost]
        public IHttpActionResult GetComboProductList(GetComboProductListRequest param)
        {
            List<GetComboProductQueryResult> list = ComboProductService.GetListByComboGroupID(param);
            return Json(list.CompleteResult());
        }

        /// <summary>
        /// 分页获取指定套餐组下的套餐产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetComboProductListPage")]
        [ResponseType(typeof(BaseResult<IPaginationResult<GetComboProductQueryResult>>))]
        [HttpPost]
        public IHttpActionResult GetComboProductListPage(GetComboProductPageRequest param)
        {
            IPaginationResult<GetComboProductQueryResult> list = ComboProductService.GetListByComboGroupIDPage(param);
            return Json(list.CompleteResult());
        }

        /// <summary>
        /// 获取套餐产品信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetComboProductInfo")]
        [ResponseType(typeof(BaseResult<ComboGroupProductInfoResult>))]
        [HttpPost]
        public IHttpActionResult GetComboProductInfo(ComboGroupProductInfoRequest param)
        {
            ComboGroupProductInfoResult result = ComboProductService.GetInfo(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 添加套餐产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("新增套餐产品")]
        [Route("api/v2/AddComboProduct")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult AddComboProduct(AddOrUpdateComboProduct param)
        {
            ComboProductService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 修改套餐产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改套餐产品")]
        [Route("api/v2/UpdateComboProduct")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult UpdateComboProduct(AddOrUpdateComboProduct param)
        {
            ComboProductService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 删除套餐产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("彻底删除套餐产品")]
        [Route("api/v2/DeleteComboProduct")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteComboProduct(OperationBaseRequest param)
        {
            ComboProductService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }

    }
}