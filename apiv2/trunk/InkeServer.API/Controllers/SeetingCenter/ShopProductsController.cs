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
    /// 店铺产品设置
    /// </summary>
    public class ShopProductsController : BaseController
    {
        #region Property

        [Inject]
        public IShopProductsService ShopProductsService { get; set; }

        #endregion

        /// <summary>
        /// 分页获取店铺产品相关详细信息
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetShopProductsPage")]
        [ResponseType(typeof(BaseResult<IPaginationResult<ShopProductPageResult>>))]
        [HttpPost]
        public IHttpActionResult GetShopProductsPage(ShopProductsRequest param)
        {
            IPaginationResult<ShopProductPageResult> shopIntegral = ShopProductsService.QueryShopAndProductList(param);
            return Json(shopIntegral.CompleteResult());
        }
        /// <summary>
        /// 分页获取没有该店铺的产品
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetShopAndProductNotExists")]
        [ResponseType(typeof(BaseResult<IPaginationResult<ShopProductPageResult>>))]
        [HttpPost]
        public IHttpActionResult GetShopAndProductNotExists(ShopProductsRequest param)
        {
            IPaginationResult<ShopProductPageResult> shopIntegral = ShopProductsService.QueryShopAndProductNotExists(param);
            return Json(shopIntegral.CompleteResult());
        }
        /// <summary>
        /// 根据ID获取店铺产品相关详细信息
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetShopProductsInfo")]
        [ResponseType(typeof(BaseResult<ShopProductPageResult>))]
        [HttpPost]
        public IHttpActionResult GetShopProductsInfo(RecordIDRequest param)
        {
            ShopProductPageResult shopIntegral = ShopProductsService.GetShopProductInfobyID(param.Record_ID);
            return Json(shopIntegral.CompleteResult());
        }

        ///<summary>
        /// 新增店铺产品
        /// </summary>
        /// <returns></returns>
        [OperationLog("新增店铺产品")]
        [Route("api/v2/ShopProductInsert")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopProductInsert(ShopProductInsert param)
        {
            ShopProductsService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }

        ///<summary>
        /// 批量新增店铺产品
        /// </summary>
        /// <returns></returns>
        [OperationLog("批量新增店铺产品")]
        [Route("api/v2/AddShopProductList")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult AddShopProductList(ShopProductInsertList param)
        {
            ShopProductsService.InsertList(param);
            return Json(MessageConverter.CompleteResult());
        }
        ///<summary>
        /// 批量删除店铺产品
        /// </summary>
        /// <returns></returns>
        [OperationLog("批量删除店铺产品")]
        [Route("api/v2/ShopProductDelete")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopProductDelete(OperationBaseRequest param)
        {
            ShopProductsService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }
        ///<summary>
        /// 修改店铺产品
        /// </summary>
        /// <returns></returns>
        [OperationLog("修改店铺产品")]
        [Route("api/v2/ShopProductUpdate")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopProductUpdate(ShopProductUpdate param)
        {
            ShopProductsService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
    }
}