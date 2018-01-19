using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    /// <summary>
    /// 营销分析和自定义营销 服务接口类
    /// </summary>
    public interface IMarketAnalysisService
    {
        /// <summary>
        /// 分页查询 营销分析集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<MarketAnalysisQueryResult> Query(MarketAnalysisQueryRequest param);
        /// <summary>
        /// 将营销分析记录标记为删除
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Delete(OperationBaseRequest param);
        /// <summary>
        /// 启用/停用营销分析记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool SetEnable(RecordIDAndStatusRequest param);
        /// <summary>
        /// 新增营销分析记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        MarketAnalysisID Insert(MarketAnalysisAddOrUpdateRequest param);
        /// <summary>
        /// 修改营销分析记录信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        MarketAnalysisID Update(MarketAnalysisAddOrUpdateRequest param);
        /// <summary>
        /// 获取营销分析详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        MarketAnalysisInfoResult GetInfo(RecordIDRequest param);
        /// <summary>
        /// 更新最新筛选结果 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool UpdateStatisticsTotal(OperationBaseRequest param);
        /// <summary>
        /// 营销分析结果明细
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<MarketingAnalyzeDetialsResult> GetMarketingAnalyzeResult(MarketingAnalyzeDetailsRequest param);
        /// <summary>
        /// 获取营销分析名称集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<MarketingAnalyzeIDAndName> GetMarketingAnalyzeNameList(MarketingAnalyzeNameRequest param);
        /// <summary>
        /// 分页查询营销分析发放记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<MarketingAnalyzeRecord> GetMarketingAnalyzeRecord(MarketingAnalyzeRecordRequest param);
        /// <summary>
        /// 营销分析结果明细 筛选重复名称 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<MarketingAnalyzeDetialsResult> GetMarketingAnalyzeResultDistinct(MarketingAnalyzeResultDistinctRequest param);
        /// <summary>
        /// 检查营销方案的可执行性
        /// </summary>
        /// <param name="param"></param>
        /// <returns>返回过期优惠券集合</returns>
        List<CouponIDAndName> CheckMarketAnalyzeExecutable(RecordIDRequest param);
        /// <summary>
        /// 营销分析发放
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool MarketingAnalyzeExec(MarketingAnalyzeExecRequest param);
        /// <summary>
        /// 分页查询 营销分析 优惠券 使用记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<MarketingAnalyzeCouponUsedRecord> GetMarketAnalysisCouponUsedRecord(MarketingAnalyzeRecordRequest param);
        /// <summary>
        /// 营销分析首页统计图表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        MarketAnalysisStstistics GetMarketingAnalyzeStatisticsTable(PromotionStatisticsRequest param);
        /// <summary>
        /// 营销分析首页发放使用统计
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        MarketAnalysisStstistics GetMarketingAnalyzeRecordStatistics(MarketingAnalyzeRecordRequest param);
    }
}
