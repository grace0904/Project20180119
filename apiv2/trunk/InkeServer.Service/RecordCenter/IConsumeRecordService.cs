using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IConsumeRecordService
    {
        /// <summary>
        /// 获得查询消费记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<ConsumeRecordInfo> GetConsumeRecordList(ConsumeRecordRequest param);
        /// <summary>
        ///获得消费记录详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ConsumeRecordInfoResult GetConsumeRecordInfo(ConsumeRecordInfoRequest param);
    }
}
