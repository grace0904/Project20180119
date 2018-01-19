using System.ComponentModel;

namespace InkeServer.Model
{
    /// <summary>
    /// 接口请求基类，不可实例化
    /// </summary>
    public abstract class BaseRequest
    {
        /// <summary>
        /// Key
        /// </summary>
        [DisplayName("AppKey")]
        public string AppKey { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [DisplayName("Sign")]
        public string Sign { get; set; }
    }
}
