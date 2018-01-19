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
    /// 会员卡折扣类型设置
    /// </summary>
    public class CardDiscountTypeController : BaseController
    {
        // GET: CardDiscountType
        #region Property

        [Inject]
        public ICardDiscountTypeService CardDiscountTypeService { get; set; }

        #endregion
        /// <summary>
        /// 分页查询会员卡折扣类型
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetCardDiscountTypePageList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<CardDiscountTypeInfo>>))]
        [HttpPost]
        public IHttpActionResult GetCardDiscountTypePageList(MerchantIdPageRequest query)
        {
            IPaginationResult<CardDiscountTypeInfo> result = CardDiscountTypeService.Query(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 获取会员卡折扣类型信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetCardDiscountTypeInfo")]
        [ResponseType(typeof(BaseResult<CardDiscountTypeInfo>))]
        [HttpPost]
        public IHttpActionResult GetCardDiscountTypeInfo(RecordIDRequest param)
        {
            CardDiscountTypeInfo result = CardDiscountTypeService.GetInfo(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 添加会员卡折扣类型
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("新增会员卡折扣类型")]
        [Route("api/v2/AddCardDiscountType")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult AddCardDiscountType(CardDiscountTypeAddOrUpdate param)
        {
            CardDiscountTypeService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 修改会员卡折扣类型
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改会员卡折扣类型")]
        [Route("api/v2/UpdateCardDiscountType")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult UpdateCardDiscountType(CardDiscountTypeAddOrUpdate param)
        {
            CardDiscountTypeService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 删除会员卡折扣类型
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("把会员卡折扣类型标记为删除")]
        [Route("api/v2/DeleteCardDiscountType")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteCardDiscountType(OperationBaseRequest param)
        {
            CardDiscountTypeService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }

        /// <summary>
        /// 获取商家下的会员卡折扣类型列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetCardDiscountTypeList")]
        [ResponseType(typeof(BaseResult<List<EmployeeInfo>>))]
        [HttpPost]
        public IHttpActionResult GetCardDiscountTypeList(MerchantIdRequest param)
        {
            List<CardDiscountTypeInfo> list = CardDiscountTypeService.GetList(param);
            return Json(list.CompleteResult());
        }
    }
}