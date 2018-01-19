using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IRecordCenterIndexService
    {
        /// <summary>
        /// 获取记录中心首页相关信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        RecordCenterIndexResult GetRecordCenterIndexInfo(RecordCenterIndexRequest param);
    }
}
