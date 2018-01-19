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
using InkeServer.API.Filters;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 商家积分产品
    /// </summary>
    public class MerchantScoreProductController : BaseController
    {
        // GET: MerchantScoreProduct
        #region Property

        [Inject]
        public IMerchantScoreProductService MerchantScoreProductService { get; set; }

        #endregion
        /// <summary>
        /// 分页查询商家积分产品集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetMerchantScoreProductPageList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<MerchantScoreProductInfoResult>>))]
        [HttpPost]
        public IHttpActionResult GetMerchantScoreProductPageList(MerchantScoreProductQueyRequest query)
        {
            IPaginationResult<MerchantScoreProductInfoResult> result = MerchantScoreProductService.Query(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 添加商家积分产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("添加商家积分产品")]
        [Route("api/v2/AddMerchantScoreProduct")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult AddMerchantScoreProduct(AddOrUpdateMerchantScoreProduct param)
        {
            MerchantScoreProductService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 修改商家积分产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改商家积分产品")]
        [Route("api/v2/UpdateMerchantScoreProduct")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult UpdateMerchantScoreProduct(AddOrUpdateMerchantScoreProduct param)
        {
            MerchantScoreProductService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 删除商家积分产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("把商家积分产品标记为删除")]
        [Route("api/v2/DeleteMerchantScoreProduct")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteMerchantScoreProduct(OperationBaseRequest param)
        {
            MerchantScoreProductService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }

        /// <summary>
        /// 获取商家积分产品详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetMerchantScoreProductInfo")]
        [ResponseType(typeof(BaseResult<MerchantScoreProductInfoResult>))]
        [HttpPost]
        public IHttpActionResult GetMerchantScoreProductInfo(RecordIDRequest param)
        {
            MerchantScoreProductInfoResult info = MerchantScoreProductService.GetInfo(param);
            return Json(info.CompleteResult());
        }

        /// <summary>
        /// 获取店铺尚未拥有的商家积分产品列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetMerchantScoreProductByShopID")]
        [ResponseType(typeof(BaseResult<List<MerchantScoreProductInfo>>))]
        [HttpPost]
        public IHttpActionResult GetMerchantScoreProductByShopID(MerchantShopAndBaseInfo param)
        {
            List<MerchantScoreProductInfo> list = MerchantScoreProductService.GetMerchantScoreProductByShopID(param);
            return Json(list.CompleteResult());
        }
    }
}