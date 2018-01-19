using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IAutoPromotionService
    {
        /// <summary>
        /// 分页查询 自动促销集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<AutoPromotionQueryResult> Query(AutoPromotionQueryRequest param);
        /// <summary>
        /// 直接删除自动促销记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Delete(OperationBaseRequest param);
        /// <summary>
        /// 启用/停用自动促销记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool SetEnable(RecordIDAndStatusRequest param);
        /// <summary>
        /// 新增自动促销记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Insert(AddAndUpdatePromotionRequest param);
        /// <summary>
        /// 修改自动促销记录信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Update(AddAndUpdatePromotionRequest param);
        /// <summary>
        /// 获取自动促销详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        AutoPromotionInfoResult GetAutoPromotionInfo(RecordIDRequest param);
        /// <summary>
        /// 获取自动促销名称集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<AutoPromotionName> GetAutoPromotionNameList(MerchantIdRequest param);
        /// <summary>
        /// 分页查询 自动促销发放记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<PromotionRecord> GetAutoPromotionRecord(PromotionRecordSearch param);
        /// <summary>
        /// 分页查询 自动促销优惠券 使用记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<PromotionCouponUsedRecord> GetAutoPromotionCouponUsedRecord(PromotionRecordSearch param);
        /// <summary>
        /// 自动促销首页统计表数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<PromotionStatistics> GetPromotionStatisticsTable(PromotionStatisticsRequest param);
        /// <summary>
        /// 自动促销 发放使用统计 表数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        PromotionStatistics GetPromotionRecordStatisticsTable(PromotionRecordSearch param);
    }
}
