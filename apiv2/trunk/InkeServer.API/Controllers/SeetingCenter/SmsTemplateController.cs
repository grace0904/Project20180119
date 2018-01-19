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
    /// 短信设置
    /// </summary>
    public class SmsTemplateController : BaseController
    {
        #region Property

        [Inject]
        public ISmsTemplateService SmsTemplateService { get; set; }

        #endregion

        ///<summary>
        /// 短信模板ID与名称列表
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/SmsTemplateIDAndName")]
        [ResponseType(typeof(List<SmsTemplateIDAndName>))]
        [HttpPost]
        public IHttpActionResult SmsTemplateIDAndName(MerchantIdRequest query)
        {
            List<SmsTemplateIDAndName> result = SmsTemplateService.GetSmsTemplateIDAndName(query);
            return Json(result.CompleteResult());
        }

        ///<summary>
        /// 短信模板详细信息查询
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetSmsTemplateInfo")]
        [ResponseType(typeof(SmsTemplateCustom))]
        [HttpPost]
        public IHttpActionResult GetSmsTemplateInfo(SmsTemplateRequest query)
        {
            SmsTemplateCustom result = SmsTemplateService.SmsTemplateCustom(query);
            return Json(result.CompleteResult());
        }

        ///<summary>
        /// 短信模板列表查询
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/SmsTemplateListQuery")]
        [ResponseType(typeof(List<SmsTemplateList>))]
        [HttpPost]
        public IHttpActionResult SmsTemplateListQuery(MerchantIdRequest query)
        {
            List<SmsTemplateList> result = SmsTemplateService.GetSmsTemplateList(query);
            return Json(result.CompleteResult());
        }

        ///<summary>
        /// 短信模板修改保存
        /// </summary>
        /// <returns></returns>
        [OperationLog("短信模板修改保存")]
        [Route("api/v2/SmsTemplateUpdata")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult SmsTemplateUpdata(SmsTemplateUpdate param)
        {
            SmsTemplateService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
	}
}