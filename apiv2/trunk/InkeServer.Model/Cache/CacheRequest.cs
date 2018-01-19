
namespace InkeServer.Model
{
    public class CacheRequest : BaseRequest
    {
        /// <summary>
        /// 登录商家编号
        /// </summary>
        public string Merchant_Number { get; set; }

        /// <summary>
        /// 登录用户名
        /// </summary>
        public string Account_Login { get; set; }

        /// <summary>
        /// 请求登录的终端
        /// </summary>
        public int TerminalType { get; set; }
    }
}
