using InkeServer.API.Filters;
using InkeServer.Attributes;
using InkeServer.GlobalVariable;
using InkeServer.Model;
using InkeServer.Service;
using System.Web.Http;
using System.Web.Http.Description;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 记录中心首页信息
    /// </summary>
    public class RecordCenterIndexController : BaseController
    {
        #region Property

        [Inject]
        public IRecordCenterIndexService RecordCenterIndexService { get; set; }

        #endregion

        ///<summary>
        ///获取记录中心首页信息
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/RecordCenterIndexInfo")]
        [ResponseType(typeof(BaseResult<RecordCenterIndexResult>))]
        [HttpPost]
        public IHttpActionResult RecordCenterIndexInfo(RecordCenterIndexRequest query)
        {
            RecordCenterIndexResult result = RecordCenterIndexService.GetRecordCenterIndexInfo(query);
            return Json(result.CompleteResult());
        }
    }
}