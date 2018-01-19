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
    /// 挂账记录
    /// </summary>
    public class ArrearsRecordController : BaseController
    {  
        #region Property

        [Inject]
        public IArrearsRecordService ArrearsRecordService { get; set; }

        #endregion
        
        /// <summary>
        /// 获取挂账记录分页信息
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetArrearsList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<ArrearsRecordResult>>))]
        [HttpPost]
        public IHttpActionResult GetArrearsList(ArrearsRecordRequest param)
        {
            IPaginationResult<ArrearsRecordResult> arrearslist = ArrearsRecordService.GetArrearsListPage(param);
            return Json(arrearslist.CompleteResult());
        }
        /// <summary>
        /// 根据ID获取挂账记录
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetArrearsListbyID")]
        [ResponseType(typeof(BaseResult<ArrearsRecordResult>))]
        [HttpPost]
        public IHttpActionResult GetArrearsListbyID(RecordIDRequest param)
        {
            ArrearsRecordResult arrearslist = ArrearsRecordService.GetArrearsListbyID(param);
            return Json(arrearslist.CompleteResult());
        }
    }
}