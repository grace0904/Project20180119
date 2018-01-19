using InkeServer.DataMapping;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using AutoMapper;
using System.Data;
using System.Data.SqlClient;

namespace InkeServer.Service.Impl
{
    /// <summary>
    /// 门店数据分析服务类
    /// </summary>
    public class StoreDataAnalysisService : ServiceBase, IStoreDataAnalysisService
    {
        //标记为注入对象
        [InjectionConstructor]
        public StoreDataAnalysisService() { }

        /// <summary>
        /// 获取门店营业额统计
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<DataSet> GetStoreTurnoverInfo(StoreTurnoverAnalysisRequest param)
        {
            #region ef
            //StoreTurnoverAnalysisResult query = new StoreTurnoverAnalysisResult();

            //string[] analysis = param.Analysis.Split(',');
            //foreach (string item in analysis)
            //{
            //    int analy = Convert.ToInt32(item);
            //    var list = Entities.Rpt_StoreTurnoverAnalysis(param.Merchant_ID, param.Shop_IDs, analy, param.min, param.Max, param.Range, param.Rangetype, param.StartTime, param.EndTime);
            //    if (analy == 0)//会员与散客
            //        query.memberAnalysis = list.ToList().MapTo<MemberAnalysis>();
            //    if (analy == 1)//分析会员年龄
            //        query.ageRangeAnalysis = list.ToList().MapTo<AgeRangeAnalysis>();
            //    if (analy == 2)//分析会员性别
            //        query.sexAnalysis = list.ToList().MapTo<SexAnalysis>();
            //}
            //return query;
            #endregion
            SqlParameter[] para = new SqlParameter[] {
              new SqlParameter("@merchantid",param.Merchant_ID),
              new SqlParameter("@shopids",param.Shop_IDs),
              new SqlParameter("@analysis",param.Analysis),
              new SqlParameter("@min",param.min),
              new SqlParameter("@max",param.Max),
              new SqlParameter("@range",param.Range),
              new SqlParameter("@rangetype",param.Rangetype),
              new SqlParameter("@begintime",param.StartTime),
              new SqlParameter("@endtime",param.EndTime)
             };
            string[] analysis = param.Analysis.Split(',');
            List<DataSet> dslist = new List<DataSet>();
            for (int i = 0; i < analysis.Count(); i++)
            {
                para[2].Value = Convert.ToInt32(analysis[i]);
                DataSet ds = Entities.Database.SqlQueryForDynamic("Rpt_StoreTurnoverAnalysis", para);
                dslist.Add(ds);
            }
            return dslist;
        }
        /// <summary>
        /// 获取菜品销量排名信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<ProductSalesRankingResult> GetProductSalesRankingInfo(ProductSalesRankingRequest param)
        {
            List<ProductSalesRankingResult> query = Entities.Rpt_ProductSalesRanking(param.Merchant_ID, param.Shop_IDs, param.types, param.StartTime, param.EndTime, param.Sort).ToList().MapTo<ProductSalesRankingResult>();
            return query;
        }
        /// <summary>
        /// 获取客流量走势
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<DataSet> GetCustomerStreamAnalysis(CustomerStreamAnalysisRequest param)
        {
            SqlParameter[] para = new SqlParameter[] {
              new SqlParameter("@merchantid",param.Merchant_ID),
              new SqlParameter("@shopids",param.Shop_IDs),
              new SqlParameter("@analysis",param.Analysis),
              new SqlParameter("@min",param.min),
              new SqlParameter("@max",param.Max),
              new SqlParameter("@range",param.Range),
              new SqlParameter("@rangetype",param.Rangetype),
              new SqlParameter("@begintime",param.StartTime),
              new SqlParameter("@endtime",param.EndTime)
             };
            string[] analysis = param.Analysis.Split(',');
            List<DataSet> dslist = new List<DataSet>();
            for (int i = 0; i < analysis.Count(); i++)
            {
                para[2].Value = Convert.ToInt32(analysis[i]);
                DataSet ds = Entities.Database.SqlQueryForDynamic("Rpt_CustomerStreamAnalysis", para);
                dslist.Add(ds);
            }
            return dslist;
        }
        /// <summary>
        /// 获取时间段营业报表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<BusinessTimeSlotResult> GetBusinessTimeSlotReport(BusinessTimeSlotRequest param)
        {
            List<BusinessTimeSlotResult> query = Entities.Rpt_BusinessTimeSlot(param.Merchant_ID, param.Shop_IDs, param.Separator, param.StartTime, param.EndTime).ToList().MapTo<BusinessTimeSlotResult>();
            return query;
        }

        /// <summary>
        /// 获取会员增长统计信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<MembershipGrowthResult> GetMembershipGrowthInfo(MembershipGrowthRequest param)
        {
            List<MembershipGrowthResult> query = Entities.Rpt_MembershipGrowth(param.Merchant_ID, param.Shop_IDs, param.Rangetype, param.StartTime, param.EndTime).ToList().MapTo<MembershipGrowthResult>();
            return query;
        }
        /// <summary>
        /// 获取结算类型信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<PayTypeAnalysisResult> GetPayTypeAnalysisInfo(PayTypeAnalysisRequest param)
        {
            List<PayTypeAnalysisResult> query = Entities.Rpt_PayTypeAnalysis(param.Merchant_ID, param.Shop_IDs, param.StartTime, param.EndTime).ToList().MapTo<PayTypeAnalysisResult>();
            return query;
        }
        /// <summary>
        /// 获取就餐人数信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<NumberOfDinersResult> GetNumberOfDinersInfo(NumberOfDinersRequest param)
        {
            List<NumberOfDinersResult> query = Entities.Rpt_NumberOfDiners(param.Merchant_ID, param.Shop_IDs, param.StartTime, param.EndTime).ToList().MapTo<NumberOfDinersResult>();
            return query;
        }
        /// <summary>
        /// 获取翻台率信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataSet GetTableTurnoverRate(TableTurnoverRateRequest param)
        {
            SqlParameter[] para = new SqlParameter[] {
                   new SqlParameter("@merchantid",param.Merchant_ID),
                 new SqlParameter("@shopids", param.Shop_IDs),
                new SqlParameter("@CountType",param.CountType),
                new SqlParameter("@begintime",param.StartTime),
                new SqlParameter("@endtime ",param.EndTime)
             };

            DataSet ds = Entities.Database.SqlQueryForDynamic("Rpt_TableTurnoverRate", para);

            return ds;
        }
    }
}
