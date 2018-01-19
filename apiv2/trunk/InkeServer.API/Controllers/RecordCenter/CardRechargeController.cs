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
    /// 充值记录
    /// </summary>
    public class CardRechargeController : BaseController
    {
        #region Property

        [Inject]
        public ICardRechargeService CardRechargeService { get; set; }

        #endregion
        /// <summary>
        /// 分页查询充值记录
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetRechargeRecordPage")]
        [ResponseType(typeof(BaseResult<IPaginationResult<CardRechargeRecordInfo>>))]
        [HttpPost]
        public IHttpActionResult GetRechargeRecordPage(CardRechargeRecordPageRequest query)
        {
            IPaginationResult<CardRechargeRecordInfo> result = CardRechargeService.GetRechargeRecordPage(query);
            return Json(result.CompleteResult());
        }

        /// <summary>
        /// 查看具体的充值记录信息
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetRechargeRecordInfo")]
        [ResponseType(typeof(BaseResult<CardRechargeRecordInfoResult>))]
        [HttpPost]
        public IHttpActionResult GetRechargeRecordInfo(CardRechargeRecordInfoRequest query)
        {
            CardRechargeRecordInfoResult result = CardRechargeService.GetRechargeRecordInfo(query);
            return Json(result.CompleteResult());
        }      
	}
}