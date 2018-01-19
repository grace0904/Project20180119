using System.Collections.Generic;

namespace Inke.Common.Paginations
{
    /// <summary>
    /// 分页结果集
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPaginationResult<T>
    {
        /// <summary>
        /// 结果集
        /// </summary>
        List<T> Items { get; }

        /// <summary>
        /// 数据总行数
        /// </summary>
        int TotalCount { get; }
    }
}