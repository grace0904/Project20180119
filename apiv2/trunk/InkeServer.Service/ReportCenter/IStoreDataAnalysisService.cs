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
    /// 门店数据分析 服务接口类
    /// </summary>
    public interface IStoreDataAnalysisService
    {
        /// <summary>
        /// 获取菜品销售排行
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<ProductSalesRankingResult> GetProductSalesRankingInfo(ProductSalesRankingRequest param);
        /// <summary>
        /// 获取门店营业额分析
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<DataSet> GetStoreTurnoverInfo(StoreTurnoverAnalysisRequest param);
        /// <summary>
        /// 获取客流量走势
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<DataSet> GetCustomerStreamAnalysis(CustomerStreamAnalysisRequest param);
        /// <summary>
        /// 获取时间段营业报表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<BusinessTimeSlotResult> GetBusinessTimeSlotReport(BusinessTimeSlotRequest param);
        /// <summary>
        /// 获取会员增长统计信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<MembershipGrowthResult> GetMembershipGrowthInfo(MembershipGrowthRequest param);
        /// <summary>
        /// 获取结算类型信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<PayTypeAnalysisResult> GetPayTypeAnalysisInfo(PayTypeAnalysisRequest param);
        /// <summary>
        /// 获取就餐人数信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<NumberOfDinersResult> GetNumberOfDinersInfo(NumberOfDinersRequest param);
        /// <summary>
        /// 获取翻台率信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        DataSet GetTableTurnoverRate(TableTurnoverRateRequest param);
    }
}
