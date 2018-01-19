using Inke.Common.Paginations;
using InkeServer.Attributes;
using InkeServer.Model;
using InkeServer.Service;
using System.Web.Http;
using System.Web.Http.Description;
using InkeServer.GlobalVariable;
using System.Collections.Generic;
using InkeServer.API.Filters;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 商家产品
    /// </summary>
    public class MerchantProductController : BaseController
    {
        // GET: MerchantProduct
        #region Property

        [Inject]
        public IMerchantProductService MerchantProductService { get; set; }

        #endregion
        /// <summary>
        /// 分页查询商家产品集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetMerchantProductPageList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<MerchantProductInfoResult>>))]
        [HttpPost]
        public IHttpActionResult GetMerchantProductPageList(MerchantProductQueryRequest query)
        {
            IPaginationResult<MerchantProductInfoResult> result = MerchantProductService.Query(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 根据商家ID和类型获取商家产品列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetMerchantProductList")]
        [ResponseType(typeof(BaseResult<List<MerchantProductInfoResult>>))]
        [HttpPost]
        public IHttpActionResult GetMerchantProductList(MerchantAndBaseInfoRequest param)
        {
            List<MerchantProductInfoResult> result = MerchantProductService.GetList(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 删除商家产品记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("把商家产品标记为删除")]
        [Route("api/v2/DeleteMerchantProducts")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteMerchantProducts(OperationBaseRequest param)
        {
            MerchantProductService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 获取商家产品详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetMerchantProductInfo")]
        [ResponseType(typeof(BaseResult<MerchantProductInfoResult>))]
        [HttpPost]
        public IHttpActionResult GetMerchantProductInfo(GetProductInfoRequest param)
        {
            MerchantProductInfoResult result = MerchantProductService.GetInfo(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 添加商家产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("新增商家产品")]
        [Route("api/v2/AddMerchantProduct")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult AddMerchantProduct(AddOrUpdateMerchantProduct param)
        {
            MerchantProductService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 修改商家产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改商家产品")]
        [Route("api/v2/UpdateMerchantProduct")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult UpdateMerchantProduct(AddOrUpdateMerchantProduct param)
        {
            MerchantProductService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 获取店铺尚未拥有的商家产品列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetMerchantProductByShopID")]
        [ResponseType(typeof(BaseResult<List<MerchantProductInfo>>))]
        [HttpPost]
        public IHttpActionResult GetMerchantProductByShopID(MerchantShopAndBaseInfo param)
        {
            List<MerchantProductInfo> list = MerchantProductService.GetMerchantProductByShopID(param);
            return Json(list.CompleteResult());
        }
        
    }
}