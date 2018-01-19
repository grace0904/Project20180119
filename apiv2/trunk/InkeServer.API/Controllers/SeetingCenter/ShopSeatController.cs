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
    /// 座位设置
    /// </summary>
    public class ShopSeatController : BaseController
    {
        #region Property

        [Inject]
        public IShopSeatService ShopSeatService { get; set; }

        #endregion

        ///<summary>
        /// 查询店铺及座位类型列表
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/QueryShopSeatClass")]
        [ResponseType(typeof(BaseResult<List<SeatClassIdAndName>>))]
        [HttpPost]
        public IHttpActionResult QueryShopSeatClass(MerchantAndShopIdRequest query)
        {
            List<SeatClassIdAndName> result = ShopSeatService.QueryShopSeatClass(query);
            return Json(result.CompleteResult());
        }    

        /// <summary>
        /// 分页查询店铺及座位信息列表
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetShopSeatInfoPage")]
        [ResponseType(typeof(BaseResult<IPaginationResult<ShopSeatInfoResult>>))]
        [HttpPost]
        public IHttpActionResult GetShopSeatInfoPage(ShopSeatInfoRequest query)
        {
            IPaginationResult<ShopSeatInfoResult> result = ShopSeatService.Query(query);
            return Json(result.CompleteResult());
        }

        ///<summary>
        /// 新增座位资料
        /// </summary>
        /// <returns></returns>
        [OperationLog("新增座位资料")]
        [Route("api/v2/ShopSeatInsert")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopSeatInsert(ShopSeatInsert param)
        {
            ShopSeatService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }

        ///<summary>
        /// 修改座位资料
        /// </summary>
        /// <returns></returns>
        [OperationLog("修改座位资料")]
        [Route("api/v2/ShopSeatUpdate")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopSeatUpdate(ShopSeatUpdate param)
        {
            ShopSeatService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }

        ///<summary>
        /// 删除座位资料
        /// </summary>
        /// <returns></returns>
        [OperationLog("删除座位资料")]
        [Route("api/v2/ShopSeatDelete")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult ShopSeatDelete(OperationBaseRequest param)
        {
            ShopSeatService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }

        ///<summary>
        /// 根据ID查询座位信息列表
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/QuerySeatInfobyID")]
        [ResponseType(typeof(BaseResult<ShopSeatInfobyIDResult>))]
        [HttpPost]
        public IHttpActionResult QuerySeatInfobyID(RecordIDRequest query)
        {
            ShopSeatInfobyIDResult result = ShopSeatService.GetMerchantBaseInfo(query.Record_ID);
            return Json(result.CompleteResult());
        }    
	}
}