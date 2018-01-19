using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IMembershipCardService
    {
        /// <summary>
        /// 分页获取会员卡记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<MembershipCardPageResult> MembershipCardPage(MembershipCardPageRequest param);
        /// <summary>
        /// 根据ID获取会员卡记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        MembershipCardPageResult MembershipCardbyID(RecordIDRequest param);
    }
}