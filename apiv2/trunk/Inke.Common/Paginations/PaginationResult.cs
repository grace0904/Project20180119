using System.Collections.Generic;

namespace Inke.Common.Paginations
{
    /// <summary>
    /// 分页结果集
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginationResult<T> : IPaginationResult<T>
    {
        /// <summary>
        /// 结果集
        /// </summary>
        public List<T> Items { get; set; }

        /// <summary>
        /// 数据总行数
        /// </summary>
        public int TotalCount { get; set; }
    }
}