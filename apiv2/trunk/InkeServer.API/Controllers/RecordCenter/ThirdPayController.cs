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
    /// 第三方支付记录
    /// </summary>
    public class ThirdPayController : BaseController
    {
        #region Property

        [Inject]
        public IThirdPayService ThirdPayService { get; set; }

        #endregion

        /// <summary>
        /// 获取第三方支付分页信息
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetThirdPayPage")]
        [ResponseType(typeof(BaseResult<IPaginationResult<ThirdPayResult>>))]
        [HttpPost]
        public IHttpActionResult GetThirdPayInfo(ThirdPayRequest param)
        {
            IPaginationResult<ThirdPayResult> arrearslist = ThirdPayService.GetThirdPayPage(param);
            return Json(arrearslist.CompleteResult());
        }
    }
}
