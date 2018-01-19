using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    /// <summary>
    /// 库存管理 服务接口类
    /// </summary>
    public interface IStockServie
    {
        /// <summary>
        /// 分页查询 入库记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<StockQueryResult> Query(StockQueryRequest param);
        /// <summary>
        /// 添加入库
        /// </summary>
        /// <param name="param"></param>
        StorageBatchID Add(AddOrUpdateStockRequest param);
        /// <summary>
        /// 修改入库信息
        /// </summary>
        /// <param name="param"></param>
        StorageBatchID Update(AddOrUpdateStockRequest param);
        /// <summary>
        /// 删除入库记录
        /// </summary>
        /// <param name="param"></param>
        void Delete(OperationBaseRequest param);
        /// <summary>
        /// 根据主键ID获得入库单详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        StockInfoResult GetInfo(RecordIDRequest param);
        /// <summary>
        /// 产品库存统计
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<StorageStatisticsResult> GetStorageStatisticsData(StockQueryRequest param);
    }
}
