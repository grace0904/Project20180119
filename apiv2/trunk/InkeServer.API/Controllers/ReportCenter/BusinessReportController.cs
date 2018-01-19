using InkeServer.API.Filters;
using InkeServer.Attributes;
using InkeServer.GlobalVariable;
using InkeServer.Model;
using InkeServer.Service;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Web.Http.Description;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 营业报表
    /// </summary>
    public class BusinessReportController : BaseController
    {
          #region Property

        [Inject]
        public IBusinessReportService BusinessReportService { get; set; }

        #endregion

        ///<summary>
        /// 获取营业报表信息
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetGetBusinessReportReport")]
        [ResponseType(typeof(BaseResult<BusinessReportResult>))]
        [HttpPost]
        public IHttpActionResult GetGetBusinessReportReport(BusinessReportRequest query)
        {
            BusinessReportResult result = BusinessReportService.GetBusinessReportInfo(query);
            return Json(result.CompleteResult());
        }        
    }
}