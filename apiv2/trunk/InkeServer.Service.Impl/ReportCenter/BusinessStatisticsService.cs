using InkeServer.DataMapping;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inke.Common.Extentions;
using InkeServer.Enums;
using AutoMapper;
using Inke.Common.Exceptions;

namespace InkeServer.Service.Impl
{
    /// <summary>
    /// 营业报表统计 服务类 
    /// </summary>
    public class BusinessStatisticsService : ServiceBase, IBusinessStatisticsService
    {
        //标记为注入对象
        [InjectionConstructor]
        public BusinessStatisticsService() { }
        /// <summary>
        /// 营业报表时间段(同一天不同时段,否则会超时)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet GetBusinessHours(BusinessHoursRequest model)
        {
            model.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //bug (同一天不同时段,否则会超时)
            #region ado.net
            SqlParameter[] iData = new SqlParameter[5] 
            { 
                new SqlParameter("@merchantid",model.Merchant_ID),
                 new SqlParameter("@shopids",string.IsNullOrEmpty(model.Shop_IDs)?"":model.Shop_IDs),
                  new SqlParameter("@separator", model.Separator),
                   new SqlParameter("@begintime",model.StartTime),
                    new SqlParameter("@endtime ",model.EndTime)
            };
            DataSet ds = Entities.Database.SqlQueryForDynamic("Rpt_BusinessHours", iData);
            iData = null;
            return ds;
            #endregion

        }
        /// <summary>
        /// 营业日期报表统计(日期间隔5天以上会超时)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet GetBusinessDates(BusinessHoursRequest model)
        {
            model.MustNotNull(ResultCode.ArgumentsMiss.Name());
            if (model.Separator < 1)
                throw new BusinessException(ResultCode.EimeIntervalLessThan1.Name());
            // bug  (日期间隔5天以上会超时)
            #region ado.net
            SqlParameter[] iData = new SqlParameter[5] 
            { 
                new SqlParameter("@merchantid",model.Merchant_ID),
                 new SqlParameter("@shopids",string.IsNullOrEmpty(model.Shop_IDs)?"":model.Shop_IDs),
                  new SqlParameter("@separator", model.Separator),
                   new SqlParameter("@begintime",model.StartTime),
                    new SqlParameter("@endtime ",model.EndTime)
            };

            DataSet ds = Entities.Database.SqlQueryForDynamic("Rpt_BusinessDates", iData);
            iData = null;
            return ds;
            #endregion

        }
        /// <summary>
        /// 优惠券使用统计(表格和饼状图)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<CouponMemoryUsageResult> GetCouponMemoryUsage(CouponMemoryUsageRequest model)
        {
            model.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var result = Entities.Rpt_CouponMemoryUsage(model.Merchant_ID, model.StartTime, model.EndTime);
            if (result == null)
            {
                return new List<CouponMemoryUsageResult>();
            }
            return result.ToList().MapTo<CouponMemoryUsageResult>();
        }
        /// <summary>
        /// 优惠券使用统计(柱状图)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet GetCouponMemoryUsageBar(CouponMemoryUsageBarRequest model)
        {
            model.MustNotNull(ResultCode.ArgumentsMiss.Name());
            #region ado.net
            SqlParameter[] iData = new SqlParameter[5] 
            { 
                new SqlParameter("@merchantid",model.Merchant_ID),
                new SqlParameter("@couponid",model.CouponID),
                 new SqlParameter("@rangetype",model.Rangetype),
                new SqlParameter("@begintime",model.StartTime),
                new SqlParameter("@endtime ",model.EndTime),
            };

            DataSet ds = Entities.Database.SqlQueryForDynamic("Rpt_CouponMemoryUsageByCouponID", iData);
            iData = null;
            return ds;
            #endregion
        }
        /// <summary>
        /// 产品统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<StatisticsProductResult> ReturnReportProductSalse(ProductSaleRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            var query = Entities.Rpt_ProductSalse(param.Merchant_ID, param.Shop_ID, param.DateForm.ToString(), param.DateTo.ToString(), param.MerchantBaseInfo_ID, param.SortType);

            if (query == null)
            {
                return new List<StatisticsProductResult>();
            }
            return query.ToList().MapTo<StatisticsProductResult>();
        }
    }
}
