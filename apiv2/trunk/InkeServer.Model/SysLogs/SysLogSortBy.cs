
namespace InkeServer.Model
{
    /// <summary>
    /// 日志排序方式枚举
    /// </summary>
    public enum SysLogSortBy : int
    {
        /// <summary>
        /// ID
        /// </summary>
        SysLog_ID = 1,
        /// <summary>
        /// 日志类型
        /// </summary>
        SysLog_Type = 2,
        /// <summary>
        /// 操作时间
        /// </summary>
        AddTime = 3,
        /// <summary>
        /// 操作人
        /// </summary>
        Operator = 4
    }
}
