using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IThirdPayService
    {
        /// <summary>
        /// 获取第三方分页查询结果
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<ThirdPayResult> GetThirdPayPage(ThirdPayRequest param);
    }
}
