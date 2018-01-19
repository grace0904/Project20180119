using System;

namespace InkeServer.Model
{
    /// <summary>
    /// 操作日志查询参数请求实体
    /// </summary>
    public class SysLogQueryRequest : PaginationRequest
    {
        #region Model

        /// <summary>
        /// 日志类型
        /// </summary>
        public int? SysLog_Type { get; set; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 查询时间范围-开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 查询时间范围-结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }

        #endregion
    }
}
