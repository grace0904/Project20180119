using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IMemberCardService
    {
        /// <summary>
        /// 会员卡集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<MemberCardResult> GetMemberCardPage(MemberCardRequest param);
    }
}
