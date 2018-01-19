using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IIntegralExchangeService
    {
        /// <summary>
        /// 分页获取积分兑换结果
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<IntegralExchangePageResult> GetIntegralExchangePage(IntegralExchangePageRequest param);
    }
}
