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
    /// 店铺积分产品
    /// </summary>
    public class ShopIntegralController : BaseController
    {
        #region Property

        [Inject]
        public IShopIntegralService ShopIntegralService { get; set; }

        #endregion
        
        /// <summary>
        /// 获取积分产品相关详细信息
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetShopIntegralProductsPage")]
        [ResponseType(typeof(BaseResult<IPaginationResult<ShopIntegralProductsResult>>))]
        [HttpPost]
        public IHttpActionResult GetShopIntegralProductsPage(ShopProductsRequest param)
        {
            IPaginationResult<ShopIntegralProductsResult> shopIntegral = ShopIntegralService.QueryShopAndProductList(param);
            return Json(shopIntegral.CompleteResult());
        }
        /// <summary>
        /// 根据ID获取积分产品相关详细信息
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetShopIntegralProductsInfo")]
        [ResponseType(typeof(BaseResult<ShopIntegralProductsResult>))]
        [HttpPost]
        public IHttpActionResult GetShopIntegralProductsInfo(RecordIDRequest param)
        {
            ShopIntegralProductsResult shopIntegral = ShopIntegralService.GetShopIntegralInfobyID(param.Record_ID);
            return Json(shopIntegral.CompleteResult());
        }
        ///<summary>
        /// 批量新增店铺积分产品
        /// </summary>
        /// <returns></returns>
        [OperationLog("批量新增店铺积分产品")]
        [Route("api/v2/ShopIntegralProductInsert")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopIntegralProductInsert(ShopProductInsert param)
        {
            ShopIntegralService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }
        ///<summary>
        /// 批量删除店铺积分产品
        /// </summary>
        /// <returns></returns>
        [OperationLog("批量删除店铺积分产品")]
        [Route("api/v2/ShopIntegralProductDelete")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopIntegralProductDelete(OperationBaseRequest param)
        {
            ShopIntegralService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }
        ///<summary>
        /// 修改店铺积分产品
        /// </summary>
        /// <returns></returns>
        [OperationLog("修改店铺积分产品")]
        [Route("api/v2/ShopIntegralProductUpdate")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopIntegralProductUpdate(ShopIntegralProductsUpdate param)
        {
            ShopIntegralService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
	}
}