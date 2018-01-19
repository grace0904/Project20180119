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
    /// 店铺设置
    /// </summary>
    public class ShopController : BaseController
    {

        #region Property

        [Inject]
        public IShopService ShopService { get; set; }

        #endregion
        /// <summary>
        /// 获取指定商家的店铺列表(店铺名、 ID)
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetShopIdAndName")]
        [ResponseType(typeof(BaseResult<List<ShopIdAndName>>))]
        [HttpPost]
        public IHttpActionResult GetShopIdAndName(MerchantIdRequest param)
        {
            List<ShopIdAndName> shopidandname = ShopService.GetShopIdAndName(param.Merchant_ID);
            return Json(shopidandname.CompleteResult());
        }
        ///<summary>
        /// 获取店铺信息
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetShopInfo")]
        [ResponseType(typeof(BaseResult<ShopInfo>))]
        [HttpPost]
        public IHttpActionResult GetShopIdAndName(ShopIdRequest param)
        {
            ShopInfo shopidandname = ShopService.GetShopInfo(param.Shop_ID);
            return Json(shopidandname.CompleteResult());
        }

        ///<summary>
        /// 店铺设置修改保存
        /// </summary>
        /// <returns></returns>
        [OperationLog("店铺设置修改保存")]
        [Route("api/v2/ShopInfoUpdate")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopInfoUpdate(ShopUpdate param)
        {
            ShopService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
	}
}