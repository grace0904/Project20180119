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
using Inke.Common.Extentions;
using InkeServer.Enums;
using InkeServer.API.Filters;


namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 商家设置
    /// </summary>
    public class MerchantConfigController : BaseController
    {
        // GET: MerchantConfig
        #region Property

        [Inject]
        public IMerchantConfigService MerchantConfigService { get; set; }

        #endregion
        /// <summary>
        /// 获取商家设置详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetMerchantconfig")]
        [ResponseType(typeof(BaseResult<MerchantConfigData>))]
        [HttpPost]
        public IHttpActionResult GetMerchantconfig(MerchantIdRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            MerchantConfigData result = MerchantConfigService.GetMerchantconfig(param.Merchant_ID);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// PC端修改一条商家配置记录
        /// </summary>
        ///  <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改商家配置记录")]
        [Route("api/v2/UpdageMerchantConfigPc")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult UpdageMerchantConfigPc(MerchantConfigUpdateRequest param)
        {
            MerchantConfigService.UpdatePc(param);
            return Json(MessageConverter.CompleteResult());
        }
    }
}