using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    /// <summary>
    /// 营业报表统计 服务接口类
    /// </summary>
    public interface IBusinessStatisticsService
    {
        /// <summary>
        /// 营业报表时间段
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataSet GetBusinessHours(BusinessHoursRequest model);
        /// <summary>
        /// 营业日期报表统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataSet GetBusinessDates(BusinessHoursRequest model);
        /// <summary>
        /// 优惠券使用统计(表格和饼状图)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<CouponMemoryUsageResult> GetCouponMemoryUsage(CouponMemoryUsageRequest model);
         /// <summary>
        /// 优惠券使用统计(柱状图)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        DataSet GetCouponMemoryUsageBar(CouponMemoryUsageBarRequest model);
        /// <summary>
        /// 产品统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<StatisticsProductResult> ReturnReportProductSalse(ProductSaleRequest model);
    }
}
