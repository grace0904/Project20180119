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
    /// 套餐组类别
    /// </summary>
    public class ComboGroupController : BaseController
    {
        // GET: ComboGroup
        #region Property

        [Inject]
        public IComboGroupService ComboGroupService { get; set; }

        #endregion

        /// <summary>
        /// 分页查询套餐组别 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetComboGroupPageList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<ComboGroupInfo>>))]
        [HttpPost]
        public IHttpActionResult GetComboGroupPageList(MerchantIdPageRequest query)
        {
            IPaginationResult<ComboGroupInfo> result = ComboGroupService.Query(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 查询套餐组别 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetComboGroupList")]
        [ResponseType(typeof(BaseResult<List<ComboGroupInfo>>))]
        [HttpPost]
        public IHttpActionResult GetComboGroupList(MerchantIdRequest query)
        {
            List<ComboGroupInfo> result = ComboGroupService.ComboGroupInfoQuery(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 获取套餐组别信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetComboGroupInfo")]
        [ResponseType(typeof(BaseResult<ComboGroupInfo>))]
        [HttpPost]
        public IHttpActionResult GetComboGroupInfo(RecordIDRequest param)
        {
            ComboGroupInfo result = ComboGroupService.GetInfo(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 添加套餐组别
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("新增套餐组类别")]
        [Route("api/v2/AddComboGroup")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult AddComboGroup(AddOrUpdateComboGroupRequest param)
        {
            ComboGroupService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 修改套餐组类别
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改套餐组类别")]
        [Route("api/v2/UpdateComboGroup")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult UpdateComboGroup(AddOrUpdateComboGroupRequest param)
        {
            ComboGroupService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 删除套餐组类别
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("把套餐组类别标记为删除")]
        [Route("api/v2/DeleteComboGroup")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteComboGroup(OperationBaseRequest param)
        {
            ComboGroupService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 获取套餐产品的套餐分组及商家的套餐分组列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetProductComboListAndMerchantComboList")]
        [ResponseType(typeof(BaseResult<ProComboListAndMerComboListData>))]
        [HttpPost]
        public IHttpActionResult GetProductComboListAndMerchantComboList(GetProductInfoRequest param)
        {
            ProComboListAndMerComboListData result = ComboGroupService.GetProductComboListAndMerchantComboList(param);
            return Json(result.CompleteResult());
        }
    }
}