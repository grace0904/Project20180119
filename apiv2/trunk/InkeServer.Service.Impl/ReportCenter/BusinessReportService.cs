using InkeServer.DataMapping;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using InkeServer.Enums;
using AutoMapper;
using System.Data;
using System.Data.SqlClient;
using Inke.Common.Helpers;

namespace InkeServer.Service.Impl
{
    /// <summary>
    /// 营业报表服务类
    /// </summary>
    public class BusinessReportService : ServiceBase, IBusinessReportService
    {
        //标记为注入对象
        [InjectionConstructor]
        public BusinessReportService() { }
        /// <summary>
        /// 获取营业报表信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public BusinessReportResult GetBusinessReportInfo(BusinessReportRequest param)
        {
            BusinessReportResult result = new BusinessReportResult();
            SqlParameter[] para = new SqlParameter[] {
              new SqlParameter("@merchantid",param.Merchant_ID),
              new SqlParameter("@shopids",param.Shop_ID),             
              new SqlParameter("@begintime",param.DateForm),
              new SqlParameter("@endtime",param.DateTo),
              new SqlParameter("@discountid",param.Discount_ID),
              new SqlParameter("@sex",param.Sex),
              new SqlParameter("@operator",param.Operator)
             };
            DataSet ds = Entities.Database.SqlQueryForDynamic("Rpt_ReportBusiness", para);
            result = ds.Tables[0].ToList<BusinessReportResult>().First();
            return result;
        }
    }
}
