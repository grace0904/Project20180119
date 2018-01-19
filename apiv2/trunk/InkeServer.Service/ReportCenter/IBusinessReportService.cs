using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    /// <summary>
    /// 营业报表 接口服务类
    /// </summary>
    public  interface IBusinessReportService
    {
        /// <summary>
        /// 获取营业报表信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        BusinessReportResult GetBusinessReportInfo(BusinessReportRequest param);
    }
}
