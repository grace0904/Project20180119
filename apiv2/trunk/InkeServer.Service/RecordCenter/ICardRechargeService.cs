using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface ICardRechargeService
    {
        /// <summary>
        /// 获取充值记录分页查询结果
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<CardRechargeRecordInfo> GetRechargeRecordPage(CardRechargeRecordPageRequest param);
        /// <summary>
        ///获取充值记录相关信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        CardRechargeRecordInfoResult GetRechargeRecordInfo(CardRechargeRecordInfoRequest param);
    }
}
