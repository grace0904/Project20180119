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
    public class SeatClassController : BaseController
    {
        #region Property

        [Inject]
        public ISeatClassService SeatClassService { get; set; }

        #endregion

        /// <summary>
        /// 分页查询座位类型信息
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/GetSeatClassInfo")]
        [ResponseType(typeof(BaseResult<IPaginationResult<SeatClassQueryResult>>))]
        [HttpPost]
        public IHttpActionResult GetSeatClassInfo(SeatClassQueryRequest query)
        {
            IPaginationResult<SeatClassQueryResult> result = SeatClassService.Query(query);
            return Json(result.CompleteResult());
        }


        ///<summary>
        /// 新增座位类型
        /// </summary>
        /// <returns></returns>
        [OperationLog("新增座位类型")]
        [Route("api/v2/SeatClassInfoInsert")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult SeatClassInfoInsert(SeatClassInsert param)
        {
            SeatClassService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }

        ///<summary>
        /// 修改座位类型
        /// </summary>
        /// <returns></returns>
        [OperationLog("修改座位类型")]
        [Route("api/v2/SeatClassInfoUpdate")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult SeatClassInfoUpdate(SeatClassUpdate param)
        {
            SeatClassService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }

        ///<summary>
        /// 删除座位类型
        /// </summary>
        /// <returns></returns>
        [OperationLog("删除座位类型")]
        [Route("api/v2/SeatClassInfoDelete")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult SeatClassInfoDelete(OperationBaseRequest param)
        {
            SeatClassService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }

        ///<summary>
        /// 获取座位ID及名称
        /// </summary>
        /// <returns></returns>
        [OperationLog("获取座位ID及名称")]
        [Route("api/v2/GetSeatClassIdAndName")]
        [ResponseType(typeof(BaseResult<SeatClassQueryResult>))]
        [HttpPost]
        public IHttpActionResult GetShopIdAndName(RecordIDRequest param)
        {
            SeatClassQueryResult shopidandname = SeatClassService.GetSeatClassIdAndName(param);
            return Json(shopidandname.CompleteResult());
        }
    }
}