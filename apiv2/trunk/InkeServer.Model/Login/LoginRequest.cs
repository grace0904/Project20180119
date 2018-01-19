using System.Collections.Generic;
using System.ComponentModel;

namespace InkeServer.Model
{
    /// <summary>
    /// 登录请求
    /// </summary>
    public class LoginRequest : BaseRequest
    {
        #region Model

        /// <summary>
        /// 登录商家编号
        /// </summary>
        public string Merchant_Number { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Account_Login { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Account_Password { get; set; }

        /// <summary>
        /// 请求登录的终端
        /// </summary>
        public int TerminalType { get; set; }

        #endregion
    };
}
