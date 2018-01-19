using System.ComponentModel;

namespace InkeServer.Model
{
    /// <summary>
    /// 分页请求基类，不可实例化
    /// </summary>
    public abstract class PaginationRequest :  BaseRequest
    {
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public SortingRequest[] SortingParameters { get; set; }
    }
}
