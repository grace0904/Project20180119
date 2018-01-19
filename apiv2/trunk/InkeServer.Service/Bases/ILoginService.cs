using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface ILoginService
    {   
        /// <summary>
        /// 验证登录帐号密码并返回系统初始化参数
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        LoginResult Login(LoginRequest query);
    }
}
