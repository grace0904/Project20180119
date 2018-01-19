using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IArrearsRecordService
    {
        /// <summary>
        /// 获取挂账记录分页信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<ArrearsRecordResult> GetArrearsListPage(ArrearsRecordRequest param);
        /// <summary>
        /// 根据ID获取挂账记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ArrearsRecordResult GetArrearsListbyID(RecordIDRequest param);
    }
}
