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
    /// 库存中心
    /// </summary>
    public class StockController : BaseController
    {
        // GET: Stock
        #region Property

        [Inject]
        public IStockServie StockServie { get; set; }

        #endregion
        /// <summary>
        /// 分页查询入库记录集合
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetStockPageList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<StockQueryResult>>))]
        [HttpPost]
        public IHttpActionResult GetStockPageList(StockQueryRequest query)
        {
            IPaginationResult<StockQueryResult> result = StockServie.Query(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 添加入库记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("添加入库记录")]
        [Route("api/v2/AddStock")]
        [ResponseType(typeof(BaseResult<StorageBatchID>))]
        [HttpPost]
        public IHttpActionResult AddStock(AddOrUpdateStockRequest param)
        {
            StorageBatchID result = StockServie.Add(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 修改入库记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改入库记录")]
        [Route("api/v2/UpdateStock")]
        [ResponseType(typeof(BaseResult<StorageBatchID>))]
        [HttpPost]
        public IHttpActionResult UpdateStock(AddOrUpdateStockRequest param)
        {
            StorageBatchID result = StockServie.Update(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 删除入库记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("删除入库记录")]
        [Route("api/v2/DeleteStock")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteStock(OperationBaseRequest param)
        {
            StockServie.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 获取入库单详细记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetStockInfo")]
        [ResponseType(typeof(BaseResult<StockInfoResult>))]
        [HttpPost]
        public IHttpActionResult GetStockInfo(RecordIDRequest param)
        {
            StockInfoResult result = StockServie.GetInfo(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 产品库存统计
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetStorageStatisticsData")]
        [ResponseType(typeof(BaseResult<IPaginationResult<StorageStatisticsResult>>))]
        [HttpPost]
        public IHttpActionResult GetStorageStatisticsData(StockQueryRequest query)
        {
            IPaginationResult<StorageStatisticsResult> result = StockServie.GetStorageStatisticsData(query);
            return Json(result.CompleteResult());
        }
    }
}