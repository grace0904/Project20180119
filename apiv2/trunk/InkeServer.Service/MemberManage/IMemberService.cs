using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IMemberService
    {
        /// <summary>
        /// 分页查询 会员集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<MemberQueryResult> Query(MemberQueryRequest param);
    }
}
