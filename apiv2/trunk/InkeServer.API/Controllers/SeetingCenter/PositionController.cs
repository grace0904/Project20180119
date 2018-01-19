using Inke.Common.Paginations;
using InkeServer.Model;
using System.Web.Http;
using System.Web.Http.Description;
using InkeServer.GlobalVariable;
using InkeServer.Attributes;
using InkeServer.Service;
using System.Collections.Generic;
using InkeServer.API.Filters;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 商家职位
    /// </summary>
    public class PositionController : BaseController
    {
        // GET: Position
        #region Property

        [Inject]
        public IPositionService PositionService { get; set; }

        #endregion

        /// <summary>
        /// 分页查询商家职位
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetMerchantPositionPageList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<MerchantPositionInfo>>))]
        [HttpPost]
        public IHttpActionResult GetMerchantPositionPageList(MerchantIdPageRequest query)
        {
            IPaginationResult<MerchantPositionInfo> result = PositionService.Query(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 新增商家职位
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("新增商家职位")]
        [Route("api/v2/AddMerchantPosition")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult AddMerchantPosition(PositionAddOrUpdateRequest param)
        {
            PositionService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 修改商家职位
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改商家职位")]
        [Route("api/v2/UpdateMerchantPosition")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult UpdateMerchantPosition(PositionAddOrUpdateRequest param)
        {
            PositionService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 删除商家职位
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("把商家职位标记为删除")]
        [Route("api/v2/DeleteMerchantPosition")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteMerchantPosition(OperationBaseRequest param)
        {
            PositionService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }

        /// <summary>
        /// 获取商家职位 列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetMerchantPositionList")]
        [ResponseType(typeof(BaseResult<IList<MerchantPositionInfo>>))]
        [HttpPost]
        public IHttpActionResult GetMerchantPositionList(MerchantIdRequest param)
        {
            IList<MerchantPositionInfo> list = PositionService.GetList(param);
            return Json(list.CompleteResult());
        }
        /// <summary>
        ///   获取职位详细信息 包括（职位菜单权限）
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetPositionPowerInfo")]
        [ResponseType(typeof(BaseResult<ShopPositionPowerInfoResult>))]
        [HttpPost]
        public IHttpActionResult GetPositionPowerInfo(RecordIDRequest param)
        {
            ShopPositionPowerInfoResult info = PositionService.GetPositionPowerInfo(param);
            return Json(info.CompleteResult());
        }

        /// <summary>
        ///  查询商家对应的所有菜单权限
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetAllSysPowerInfo")]
        [ResponseType(typeof(BaseResult<List<SysPositionPower>>))]
        [HttpPost]
        public IHttpActionResult GetAllSysPowerInfo(MerchantIdRequest param)
        {
            List<SysPositionPower> info = PositionService.GetAllSysPowerList(param);
            return Json(info.CompleteResult());
        }
    }
}