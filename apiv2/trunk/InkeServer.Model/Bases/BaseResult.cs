using System;

namespace InkeServer.Model
{
    /// <summary>
    /// 接口返回基
    /// </summary>
    public class BaseResult
    {
        /// <summary>
        /// 操作码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 引起错误原因
        /// </summary>
        public string Cause { get; set; }
    }

    /// <summary>
    /// 接口返回基
    /// </summary>
    public class BaseResult<T> : BaseResult
    {
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
    }
}
