using Inke.Common.Paginations;
using InkeServer.Model;

namespace InkeServer.Service
{
    public interface ISysLogService
    {
        /// <summary>
        /// 插入一条日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Insert(SysLogInsert model);

        /// <summary>
        /// 分页查询日志列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IPaginationResult<SysLogInfo> Query(SysLogQueryRequest query);
    }
}
