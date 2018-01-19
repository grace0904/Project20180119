using Inke.Common.Paginations;
using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inke.Common.Extentions;
using EntityFramework.Extensions;
using Inke.Common.Exceptions;
using System.Transactions;
using AutoMapper;
using System.Data.Entity;
using Inke.Common.Helpers;

namespace InkeServer.Service.Impl
{
    /// <summary>
    /// 营销分析和自定义营销 服务类
    /// </summary>
    public class MarketAnalysisService : ServiceBase, IMarketAnalysisService
    {
        //标记为注入对象
        [InjectionConstructor]
        public MarketAnalysisService() { }
        /// <summary>
        /// 分页查询 营销分析集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<MarketAnalysisQueryResult> Query(MarketAnalysisQueryRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from a in Entities.Bas_MarketingAnalyze
                         where a.Del != 1 && a.Merchant_ID.Equals(param.Merchant_ID) && a.AutoExec == param.AutoExec
                         select new MarketAnalysisQueryResult
                         {
                             ShopNames = (from t in Entities.Bas_Shop
                                          where (from t1 in Entities.Bas_UsableShop
                                                 where t1.Record_ID == a.MarketingAnalyze_ID && t1.Merchant_ID == a.Merchant_ID
                                                 select t1.Shop_ID).Contains(t.Shop_ID)
                                          select t.Shop_Name).ToList(),
                             MarketingAnalyze_Name = a.MarketingAnalyze_Name,
                             MarketingAnalyze_ID = a.MarketingAnalyze_ID,
                             StatisticsTotal = a.StatisticsTotal == null ? 0 : a.StatisticsTotal,
                             IssueTotal = a.IssueTotal == null ? 0 : a.IssueTotal,
                             Operator = a.Operator,
                             State = a.State,
                             OperationTime = a.OperationTime
                         });


            KeySelectors<MarketAnalysisQueryResult, DefaultSortBy> _keySelectors =
            new KeySelectors<MarketAnalysisQueryResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.OperationTime);
            return QueryPaginate<MarketAnalysisQueryResult, MarketAnalysisQueryResult>(query, param, _keySelectors);
            #endregion
        }
        /// <summary>
        /// 将营销分析记录标记为删除
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Delete(OperationBaseRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            using (var scope = new TransactionScope())
            {
                if (!string.IsNullOrEmpty(param.Record_ID))
                {
                    param.Record_ID = string.Join(",", param.Record_ID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                }
                int row = Entities.Bas_MarketingAnalyze
                .Where(t => param.Record_ID.Contains(t.MarketingAnalyze_ID))
                .Update(t => new Bas_MarketingAnalyze { Del = 1, OperationTime = DateTime.Now, LastExeTime = DateTime.Now });

                //删除优惠券赠送记录
                int type = (int)GivenCouponType.MarketingAnalyze;
                Entities.Bas_GivenCoupon.Where(t => param.Record_ID.Contains(t.Record_ID) && t.GivenCoupon_Type == type).Delete();
                //删除可用店铺记录
                int shoptype = (int)UsableClass.MarketingAnalyze;
                Entities.Bas_UsableShop.Where(t => param.Record_ID.Contains(t.Record_ID) && t.UsableClass == shoptype).Delete();
                if (row == 0)
                    throw new BusinessException(ResultCode.DeleteFaild.Name());
                scope.Complete();
            }

            return true;
        }

        /// <summary>
        /// 启用/停用营销分析记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool SetEnable(RecordIDAndStatusRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            if (!string.IsNullOrEmpty(param.Record_ID))
            {
                param.Record_ID = string.Join(",", param.Record_ID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }
            int row = Entities.Bas_MarketingAnalyze
                   .Where(t => param.Record_ID.Contains(t.MarketingAnalyze_ID))
                   .Update(t => new Bas_MarketingAnalyze { State = param.Status, OperationTime = DateTime.Now });

            if (row == 0)
                throw new BusinessException(ResultCode.OperationFaild.Name());
            return true;
        }
        /// <summary>
        /// 是否存在名称相同的记录 
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistNames(string merchantId, string name, int type, string id = "")
        {
            var info = (from a in Entities.Bas_MarketingAnalyze where a.Del != 1 && a.Merchant_ID == merchantId && a.AutoExec == type && a.MarketingAnalyze_ID != id && a.MarketingAnalyze_Name == name select a).FirstOrDefault();
            return info != null;
        }
        /// <summary>
        /// 新增营销分析记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public MarketAnalysisID Insert(MarketAnalysisAddOrUpdateRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            MarketAnalysisID result = new MarketAnalysisID();
            using (var scope = new TransactionScope())
            {
                param.AutoExec = param.AutoExec <= 0 ? 0 : 1;
                if (ExistNames(param.Merchant_ID, param.MarketingAnalyze_Name, param.AutoExec, ""))
                    throw new BusinessException(ResultCode.NameExisted.Name());
                //处理model
                var dataid = Inke.Common.Helpers.GUID.CreateGUID();
                Bas_MarketingAnalyze model = param.MapTo<Bas_MarketingAnalyze>();
                model.MarketingAnalyze_ID = dataid;
                model.AddTime = DateTime.Now;
                model.OperationTime = DateTime.Now;
                model.Del = 0;
                model.State = 1;
                model.LastExeTime = DateTime.Now;
                //发放次数
                model.IssueTotal = 0;
                Entities.Bas_MarketingAnalyze.Add(model);
                //先插入到数据库
                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.AddFaild.Name());

                //插入优惠券使用数据
                if (param.CouponList != null && param.CouponList.Count > 0)
                {
                    var list = param.CouponList.MapTo<Bas_GivenCoupon>();
                    if (list.Count > 0)
                    {
                        foreach (var coupon in list)
                        {
                            coupon.GivenCoupon_ID = Inke.Common.Helpers.GUID.CreateGUID();
                            coupon.Record_ID = model.MarketingAnalyze_ID;
                            coupon.GivenCoupon_Type = (int)GivenCouponType.MarketingAnalyze;
                            coupon.Merchant_ID = model.Merchant_ID;
                            coupon.AddTime = DateTime.Now;
                        }
                        Entities.Bas_GivenCoupon.AddRange(list);
                    }
                }
                //插入可用店铺列表 
                #region 插入可用店铺列表
                if (!string.IsNullOrEmpty(param.ShopIds))
                {
                    string[] idList = param.ShopIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    var list = new List<Bas_UsableShop>();
                    foreach (var id in idList)
                    {
                        Bas_UsableShop shop = new Bas_UsableShop();
                        shop.UsableShop_ID = Inke.Common.Helpers.GUID.CreateGUID();
                        shop.UsableClass = (int)UsableClass.MarketingAnalyze;
                        shop.Record_ID = model.MarketingAnalyze_ID;
                        shop.Merchant_ID = model.Merchant_ID;
                        shop.Shop_ID = id;
                        shop.Status = 1;
                        shop.Memo = "";
                        list.Add(shop);
                    }
                    if (list.Count > 0)
                    {
                        Entities.Bas_UsableShop.AddRange(list);
                    }
                }
                #endregion
                //保存
                Entities.SaveChanges();

                result.MarketingAnalyze_ID = model.MarketingAnalyze_ID;
                scope.Complete();
            }
            return result;
        }

        /// <summary>
        /// 修改营销分析记录信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public MarketAnalysisID Update(MarketAnalysisAddOrUpdateRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            MarketAnalysisID result = new MarketAnalysisID();
            using (var scope = new TransactionScope())
            {
                if (!Entities.Bas_MarketingAnalyze.Any(t => t.MarketingAnalyze_ID == param.MarketingAnalyze_ID))
                    throw new BusinessException(ResultCode.DataNotFound.Name());
                if (ExistNames(param.Merchant_ID, param.MarketingAnalyze_Name, param.AutoExec, param.MarketingAnalyze_ID))
                    throw new BusinessException(ResultCode.NameExisted.Name());

                Bas_MarketingAnalyze model = param.MapTo<Bas_MarketingAnalyze>();
                model.OperationTime = DateTime.Now;
                model.LastExeTime = DateTime.Now;

                Entities.Entry(model).State = EntityState.Modified;
                Entities.Entry(model).Property(b => b.Merchant_ID).IsModified = false;
                Entities.Entry(model).Property(b => b.AddTime).IsModified = false;
                Entities.Entry(model).Property(b => b.State).IsModified = false;//此处不修改状态
                Entities.Entry(model).Property(b => b.Del).IsModified = false;
                Entities.Entry(model).Property(b => b.AutoExec).IsModified = false;
                Entities.Entry(model).Property(b => b.IssueTotal).IsModified = false;//发放次数不修改 

                //先更新到数据库
                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.UpdateFaild.Name());

                //插入可用店铺数据(先删除后添加Bas_UsableShop )
                #region
                int type = (int)UsableClass.MarketingAnalyze;
                Entities.Bas_UsableShop.Where(t => t.UsableClass == type && t.Record_ID == model.MarketingAnalyze_ID).Delete();
                if (!string.IsNullOrEmpty(param.ShopIds))
                {
                    string[] idList = param.ShopIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    var list = new List<Bas_UsableShop>();
                    foreach (var id in idList)
                    {
                        Bas_UsableShop shop = new Bas_UsableShop();
                        shop.UsableShop_ID = Inke.Common.Helpers.GUID.CreateGUID();
                        shop.UsableClass = type;
                        shop.Record_ID = model.MarketingAnalyze_ID;
                        shop.Merchant_ID = model.Merchant_ID;
                        shop.Shop_ID = id;
                        shop.Status = 1;
                        shop.Memo = "";
                        list.Add(shop);
                    }
                    if (list.Count > 0)
                    {
                        Entities.Bas_UsableShop.AddRange(list);
                    }
                }
                #endregion

                //插入优惠券使用数据,先删除后添加
                int counpontype = (int)GivenCouponType.MarketingAnalyze;
                Entities.Bas_GivenCoupon.Where(t => t.GivenCoupon_Type == counpontype && t.Record_ID == model.MarketingAnalyze_ID).Delete();
                if (param.CouponList != null && param.CouponList.Count > 0)
                {
                    var list = param.CouponList.MapTo<Bas_GivenCoupon>();
                    if (list.Count > 0)
                    {
                        foreach (var coupon in list)
                        {
                            coupon.GivenCoupon_ID = Inke.Common.Helpers.GUID.CreateGUID();
                            coupon.Record_ID = model.MarketingAnalyze_ID;
                            coupon.GivenCoupon_Type = (int)GivenCouponType.MarketingAnalyze;
                            coupon.Merchant_ID = model.Merchant_ID;
                            coupon.AddTime = DateTime.Now;
                        }
                        Entities.Bas_GivenCoupon.AddRange(list);
                    }
                }
                //保存
                Entities.SaveChanges();

                result.MarketingAnalyze_ID = model.MarketingAnalyze_ID;
                scope.Complete();
            }

            return result;
        }
        /// <summary>
        /// 获取营销分析详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public MarketAnalysisInfoResult GetInfo(RecordIDRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            var info = (from a in Entities.Bas_MarketingAnalyze
                        where a.MarketingAnalyze_ID.Equals(param.Record_ID)
                        select a).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            MarketAnalysisInfoResult data = new MarketAnalysisInfoResult();
            //基础信息
            data.MarketAnalysis = info.MapTo<MarketAnalysis>();
            //可用店铺
            int type = (int)UsableClass.MarketingAnalyze;
            var UserShops = (from t in Entities.Bas_Shop
                             where (from t1 in Entities.Bas_UsableShop
                                    where t1.Record_ID == info.MarketingAnalyze_ID && t1.Merchant_ID == info.Merchant_ID && t1.UsableClass == type
                                    select t1.Shop_ID).Contains(t.Shop_ID)
                             select new { Shop_ID = t.Shop_ID, Shop_Name = t.Shop_Name });
            data.UserShopList = UserShops.MapTo<ShopIdAndName>();
            //消费产品
            if (!string.IsNullOrEmpty(info.ConsumeProduct_ID))
            {
                var produnctIds = info.ConsumeProduct_ID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var products = (from t in Entities.Bas_MerchantProducts
                                where produnctIds.Contains(t.Product_ID)
                                select new { Product_ID = t.Product_ID, Product_Name = t.Product_Name });
                data.ConsumeProductList = products.MapTo<MerchantProductIDAndName>();
            }
            //消费优惠券
            if (!string.IsNullOrEmpty(info.ConsumeCoupon_ID))
            {
                var consumeCoupons = info.ConsumeCoupon_ID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var consumes = (from t in Entities.Bas_Coupon
                                where consumeCoupons.Contains(t.Coupon_ID)
                                select new { Coupon_ID = t.Coupon_ID, Coupon_Name = t.Coupon_Name });
                data.ConsumeCouponList = consumes.MapTo<CouponIDAndName>();
            }
            //赠送优惠券
            int coupontype = (int)GivenCouponType.MarketingAnalyze;
            var coupons = (from t in Entities.Bas_GivenCoupon
                           join c in Entities.Bas_Coupon on t.Coupon_ID equals c.Coupon_ID
                           where t.Merchant_ID == info.Merchant_ID && t.Record_ID == info.MarketingAnalyze_ID && t.GivenCoupon_Type == coupontype
                           select new { Coupon_ID = t.Coupon_ID, Coupon_Name = c.Coupon_Name, CouponQuantity = t.CouponQuantity });
            data.CouponList = coupons.MapTo<GivenCouponInfo>();
            return data;
        }
        /// <summary>
        /// 更新最新筛选结果 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool UpdateStatisticsTotal(OperationBaseRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //执行存储过程得到结果明细 更新筛选结果 
            var statisticsTotal = Entities.Rpt_MarketingAnalysisByCard(param.Record_ID).Count();
            int row = Entities.Bas_MarketingAnalyze.Where(t => t.MarketingAnalyze_ID == param.Record_ID)
                .Update(t => new Bas_MarketingAnalyze { StatisticsTotal = statisticsTotal });

            return row > 0;
        }
        /// <summary>
        /// 营销分析结果明细
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<MarketingAnalyzeDetialsResult> GetMarketingAnalyzeResult(MarketingAnalyzeDetailsRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var query = Entities.Rpt_MarketingAnalysisByCard(param.MarketingAnalyze_ID).MapTo<MarketingAnalyzeDetialsResult>().AsQueryable();
            var totalCount = query.Count();
            if (totalCount <= 0)
            {
                return new PaginationResult<MarketingAnalyzeDetialsResult> { Items = new List<MarketingAnalyzeDetialsResult>(), TotalCount = 0 };
            }
            //分页处理
            KeySelectors<MarketingAnalyzeDetialsResult, DefaultSortBy> _keySelector =
          new KeySelectors<MarketingAnalyzeDetialsResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.LastConsumeTime);
            var paging = PaginationHelper.GetPaging(param.PageIndex, param.PageSize, DefaultSortBy.Default);
            var list = query.Paginater(_keySelector, paging);
            var final = list.ToList();
            return new PaginationResult<MarketingAnalyzeDetialsResult> { Items = final, TotalCount = totalCount };
        }
        /// <summary>
        /// 获取营销分析名称集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<MarketingAnalyzeIDAndName> GetMarketingAnalyzeNameList(MarketingAnalyzeNameRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var list = (from a in Entities.Bas_MarketingAnalyze
                        where a.Merchant_ID == param.Merchant_ID && a.AutoExec == param.MarketingAnalyzeType
                        && a.Del != 1
                        select new MarketingAnalyzeIDAndName { MarketingAnalyze_ID = a.MarketingAnalyze_ID, MarketingAnalyze_Name = a.MarketingAnalyze_Name });
            return list.ToList();
        }

        /// <summary>
        /// 分页查询营销分析发放记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<MarketingAnalyzeRecord> GetMarketingAnalyzeRecord(MarketingAnalyzeRecordRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from a in Entities.Bus_MarketingAnalyzeRecord
                         join m1 in Entities.Bas_Member on a.Member_ID equals m1.Member_ID into mt
                         from m in mt.DefaultIfEmpty()
                         join c1 in Entities.Bas_Card on a.Card_ID equals c1.Card_ID into ct
                         from c in ct.DefaultIfEmpty()
                         let couppon = (from t in Entities.Bus_CardCoupon
                                        join t1 in Entities.Bas_Coupon on t.Coupon_ID equals t1.Coupon_ID
                                        where t.Merchant_ID == a.Merchant_ID && t.Record_ID == a.MarketingAnalyzeRecord_ID
                                        && t.Del != 1 && t.Adjust != 1
                                        group new
                                        {
                                            Coupon_ID = t.Coupon_ID,
                                            Coupon_Name = t1.Coupon_Name,
                                            CardCoupon_ID = t.CardCoupon_ID == null ? 0 : 1
                                        } by new
                                        {
                                            Coupon_ID = t.Coupon_ID,
                                            Coupon_Name = t1.Coupon_Name
                                        } into table
                                        select new
                                        {
                                            CouponQuantity = table.Sum(t => t.CardCoupon_ID),
                                            Coupon_Name = table.Max(t => t.Coupon_Name)
                                        })
                         where a.Merchant_ID.Equals(param.Merchant_ID) && a.Status == 1 && a.Adjust != 1 && a.MarketingAnalyzeType == param.MarketingAnalyzeType
                        && (string.IsNullOrEmpty(param.MarketingAnalyze_ID) || a.MarketingAnalyze_ID == param.MarketingAnalyze_ID)
                         select new MarketingAnalyzeRecord
                         {
                             Coupon_Name = (from t in couppon
                                            select (t.Coupon_Name + "*" + t.CouponQuantity)).ToList(),
                             Card_Num = c == null ? "" : c.Card_Num,
                             ExecuteTime = a.ExecuteTime,
                             GivenIntegral = a.GivenIntegral,
                             Member_MobilePhone = m == null ? "" : m.Member_MobilePhone,
                             Member_Name = m == null ? "" : m.Member_Name,
                             MarketingAnalyze_Name = a.MarketingAnalyze_Name,
                             MarketingAnalyzeRecord_ID = a.MarketingAnalyzeRecord_ID
                         });

            query = query.WhereIf(t => t.Member_Name.IndexOf(param.Member_Name) > -1, param.Member_Name.NotNullOrEmpty());
            query = query.WhereIf(t => t.Member_MobilePhone.IndexOf(param.MobilePhone) > -1, param.MobilePhone.NotNullOrEmpty());
            query = query.WhereIf(t => t.ExecuteTime >= param.DateForm && t.ExecuteTime <= param.DateTo, param.DateForm.HasValue && param.DateTo.HasValue);


            KeySelectors<MarketingAnalyzeRecord, DefaultSortBy> _keySelectors =
            new KeySelectors<MarketingAnalyzeRecord, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.ExecuteTime);
            return QueryPaginate<MarketingAnalyzeRecord, MarketingAnalyzeRecord>(query, param, _keySelectors);
            #endregion
        }
        /// <summary>
        /// 营销分析结果明细 筛选重复名称 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<MarketingAnalyzeDetialsResult> GetMarketingAnalyzeResultDistinct(MarketingAnalyzeResultDistinctRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //获取结果明细
            var query = Entities.Rpt_MarketingAnalysisByCard(param.MarketingAnalyze_ID).AsQueryable();
            //找出要筛选的营销分析
            var memberIdlist = (from c in Entities.Bus_MarketingAnalyzeRecord where param.DistinctMarketingAnalyze_ID.Contains(c.MarketingAnalyze_ID) select c.Member_ID).Distinct().ToList();

            var souce = query.Where(m => !memberIdlist.Contains(m.Member_ID)).MapTo<MarketingAnalyzeDetialsResult>().AsQueryable();
            var totalCount = souce.Count();
            if (totalCount <= 0)
            {
                return new PaginationResult<MarketingAnalyzeDetialsResult> { Items = new List<MarketingAnalyzeDetialsResult>(), TotalCount = 0 };
            }
            //分页处理
            KeySelectors<MarketingAnalyzeDetialsResult, DefaultSortBy> _keySelector =
        new KeySelectors<MarketingAnalyzeDetialsResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.LastConsumeTime);
            var paging = PaginationHelper.GetPaging(param.PageIndex, param.PageSize, DefaultSortBy.Default);
            var list = souce.Paginater(_keySelector, paging);
            var final = list.ToList();
            return new PaginationResult<MarketingAnalyzeDetialsResult> { Items = final, TotalCount = totalCount };
        }
        /// <summary>
        /// 检查营销方案的可执行性
        /// </summary>
        /// <param name="param"></param>
        /// <returns>返回过期优惠券集合</returns>
        public List<CouponIDAndName> CheckMarketAnalyzeExecutable(RecordIDRequest param)
        {
            //得到营销分析记录 
            var info = (from a in Entities.Bas_MarketingAnalyze where a.MarketingAnalyze_ID == param.Record_ID select a).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            //得到要发放的优惠券记录
            //判断是否存在过期优惠券，若有过期优惠券则不允许发放这个营销方案
            int type = (int)GivenCouponType.MarketingAnalyze;
            var coupons = (from a in Entities.Bas_GivenCoupon
                           join c in Entities.Bas_Coupon on a.Coupon_ID equals c.Coupon_ID
                           where a.Merchant_ID == info.Merchant_ID && a.Record_ID == param.Record_ID && a.GivenCoupon_Type == type
                           &&(c.Coupon_Validity == 1 && System.Data.Entity.DbFunctions.DiffDays(c.Coupon_LDate, DateTime.Now) >0)
                           select new
                           {
                               Coupon_Name = c == null ? "" : c.Coupon_Name,
                               Coupon_ID = a.Coupon_ID
                           });
            return coupons.MapTo<CouponIDAndName>();
        }
        /// <summary>
        /// 营销分析发放
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool MarketingAnalyzeExec(MarketingAnalyzeExecRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                //得到营销分析记录 
                var info = (from a in Entities.Bas_MarketingAnalyze where a.MarketingAnalyze_ID == param.MarketingAnalyze_ID select a).FirstOrDefault();
                if(info==null)
                    throw new BusinessException(ResultCode.DataNotFound.Name());
                //得到要发放的优惠券记录
                int type = (int)GivenCouponType.MarketingAnalyze;
                var coupons = (from a in Entities.Bas_GivenCoupon
                               join c in Entities.Bas_Coupon on a.Coupon_ID equals c.Coupon_ID
                               where a.Merchant_ID == param.Merchant_ID && a.Record_ID == param.MarketingAnalyze_ID && a.GivenCoupon_Type == type
                               select new
                               {
                                   Coupon_Name = c == null ? "" : c.Coupon_Name,
                                   Coupon_ID = a.Coupon_ID,
                                   CouponQuantity = a.CouponQuantity,
                                   Coupon_Validity = c == null ? 0 : c.Coupon_Validity,
                                   Coupon_FDate = c == null ? null : c.Coupon_FDate,
                                   Coupon_LDate = c == null ? null : c.Coupon_LDate
                               });
                //先判断是否有过期优惠券，若有则不允许发放
                //DiffDays(starttime,enttime)
                if (coupons.Any(c => c.Coupon_Validity == 1 && System.Data.Entity.DbFunctions.DiffDays(c.Coupon_LDate, DateTime.Now) >0))
                {
                    throw new BusinessException(ResultCode.GiveCouponOverdue.Name());
                }
                
                var couponlist = new List<Bus_CardCoupon>();
                var changelist = new List<Bus_IntegralChange>();
                var recordlist = new List<Bus_MarketingAnalyzeRecord>();

                //为空则发放所有记录
                var datalist = param.MarketingAnalyzeList;
                if (param.MarketingAnalyzeList == null || param.MarketingAnalyzeList.Count == 0)
                {
                    datalist = Entities.Rpt_MarketingAnalysisByCard(param.MarketingAnalyze_ID).
                        Select(t =>
                        new MarketingAnalyzeCard
                        {
                            Card_BusinessID = t.Card_BusinessID,
                            Card_ID = t.Card_ID,
                            Member_ID = t.Member_ID
                        }).Distinct().ToList();
                }
                foreach (var card in datalist)
                {
                    //方法记录主键ID 对应cardCoupon表recordId
                    var recordId = Inke.Common.Helpers.GUID.CreateGUID();
                    //插入Bus_CardCoupon
                    #region 插入Bus_CardCoupon
                    foreach (var coupon in coupons)
                    {
                        if (coupon != null)
                        {
                            int i = 0;
                            while (i < coupon.CouponQuantity)
                            {
                                Bus_CardCoupon cardcoupon = new Bus_CardCoupon();
                                cardcoupon.CardCoupon_ID = Inke.Common.Helpers.GUID.CreateGUID();
                                cardcoupon.Coupon_ID = coupon.Coupon_ID;
                                cardcoupon.Coupon_Name = coupon.Coupon_Name;
                                cardcoupon.BusinessClass = (int)BusinessClass.MarketingAnalyze;
                                cardcoupon.Record_ID = recordId;
                                cardcoupon.Status = 0;
                                cardcoupon.FDate = coupon.Coupon_FDate;
                                cardcoupon.LDate = coupon.Coupon_LDate;
                                cardcoupon.Card_ID = card.Card_ID;
                                cardcoupon.Card_BusinessID = card.Card_BusinessID;
                                cardcoupon.Merchant_ID = param.Merchant_ID;
                                cardcoupon.AddTime = DateTime.Now;
                                cardcoupon.OperationTime = DateTime.Now;
                                cardcoupon.Operator = param.Operater;
                                cardcoupon.Memo = "";
                                cardcoupon.Adjust = 0;
                                cardcoupon.Del = 0;
                                couponlist.Add(cardcoupon);
                                i++;
                            }
                        }
                    }
                    #endregion

                    //插入Bus_IntegralChange
                    #region 插入Bus_IntegralChange
                    Bus_IntegralChange change = new Bus_IntegralChange();
                    change.IntegralChange_ID = Inke.Common.Helpers.GUID.CreateGUID();
                    change.Card_ID = card.Card_ID;
                    change.Card_BusinessID = card.Card_BusinessID;
                    change.BusinessClass = (int)BusinessClass.MarketingAnalyze;
                    change.Record_ID = recordId;
                    change.IntegralIncome = info.GivenIntegral;
                    change.IntegralConsume = 0;
                    change.Merchant_ID = param.Merchant_ID;
                    change.Shop_ID = "";
                    change.Memo = "";
                    change.AddTime = DateTime.Now;
                    change.OperationTime = DateTime.Now;
                    change.Adjust = 0;
                    changelist.Add(change);
                    #endregion

                    //更新Bas_Card(sum(IntegralIncome)-sum(IntegralConsume))
                    #region 更新Bas_Card
                    Entities.Bas_Card.Where(t => t.Card_Status == 1 && t.Merchant_ID == param.Merchant_ID && t.Card_BusinessID == card.Card_BusinessID)
                        .Update(t => new Bas_Card
                        {
                            Card_Integral = ((from a in Entities.Bus_IntegralChange
                                              where a.Adjust != 1 && a.Merchant_ID == param.Merchant_ID && a.Card_BusinessID == card.Card_BusinessID
                                              select (a.IntegralIncome == null ? 0 : a.IntegralIncome)).Sum() -
                                           (from a in Entities.Bus_IntegralChange
                                            where a.Adjust != 1 && a.Merchant_ID == param.Merchant_ID && a.Card_BusinessID == card.Card_BusinessID
                                            select (a.IntegralConsume == null ? 0 : a.IntegralConsume)).Sum())
                        });
                    #endregion

                    //插入营销分析发放表
                    #region 插入营销分析发放表
                    Bus_MarketingAnalyzeRecord record = new Bus_MarketingAnalyzeRecord();
                    record.MarketingAnalyzeRecord_ID = recordId;
                    record.MarketingAnalyze_ID = info.MarketingAnalyze_ID;
                    record.MarketingAnalyze_Name = info.MarketingAnalyze_Name;
                    record.MarketingAnalyzeType = info.AutoExec == null ? 0 : Convert.ToInt32(info.AutoExec);
                    record.GivenIntegral = info.GivenIntegral;
                    record.Status = 1;
                    record.Card_ID = card.Card_ID;
                    record.Card_BusinessID = card.Card_BusinessID;
                    record.Member_ID = card.Member_ID;
                    record.Merchant_ID = info.Merchant_ID;
                    record.Memo = "";
                    record.ExecuteTime = DateTime.Now;
                    record.Adjust = 0;
                    recordlist.Add(record);
                    #endregion

                }
                if (couponlist.Count > 0)
                {
                    Entities.Bus_CardCoupon.AddRange(couponlist);
                }
                if (changelist.Count > 0)
                {
                    Entities.Bus_IntegralChange.AddRange(changelist);
                }
                if (recordlist.Count > 0)
                {
                    Entities.Bus_MarketingAnalyzeRecord.AddRange(recordlist);
                }
                //更新营销分析主表 发放次数+1
                info.IssueTotal = info.IssueTotal + 1;

                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.OperationFaild.Name());

                scope.Complete();
            }
            return true;
        }
        /// <summary>
        /// 分页查询 营销分析 优惠券 使用记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<MarketingAnalyzeCouponUsedRecord> GetMarketAnalysisCouponUsedRecord(MarketingAnalyzeRecordRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            /*
            * 此处消费优惠券为 当前统计条件下使用过的优惠券 可能会比此条件下发放的优惠券多
            */
            var type = (int)BusinessClass.MarketingAnalyze;
            var query = (from ar in Entities.Bus_MarketingAnalyzeRecord
                         join a in Entities.Bus_CardCoupon on ar.MarketingAnalyzeRecord_ID equals a.Record_ID
                         join p in Entities.Bas_Coupon on a.Coupon_ID equals p.Coupon_ID
                         join o1 in Entities.Bus_Orders on a.Order_ID equals o1.Order_ID into ot
                         from o in ot.DefaultIfEmpty()
                         join m1 in Entities.Bas_Member on o.Member_ID equals m1.Member_ID into mt
                         from m in mt.DefaultIfEmpty()
                         let card = o == null ? null : (from c in Entities.Bas_Card where c.Card_ID == o.Card_ID select c).FirstOrDefault()
                         let shop = o == null ? null : (from s in Entities.Bas_Shop where s.Shop_ID == o.Shop_ID select s).FirstOrDefault()

                         where a.Status == 1 && a.Del != 1 && a.Adjust != 1 && a.BusinessClass == type && ar.Merchant_ID == param.Merchant_ID
                        && ar.MarketingAnalyzeType == param.MarketingAnalyzeType && ar.Adjust != 1
                         && (string.IsNullOrEmpty(param.MarketingAnalyze_ID) || ar.MarketingAnalyze_ID == param.MarketingAnalyze_ID)
                         select new MarketingAnalyzeCouponUsedRecord
                         {
                             Coupon_Name = a.Coupon_Name,
                             Card_Num = card == null ? "" : card.Card_Num,
                             Member_MobilePhone = m == null ? "" : m.Member_MobilePhone,
                             Member_Name = m == null ? "" : m.Member_Name,
                             MarketingAnalyze_Name = ar.MarketingAnalyze_Name,
                             CardCoupon_ID = a.CardCoupon_ID,
                             Coupon_DeductionPrice = p.Coupon_DeductionPrice,
                             Shop_Name = shop == null ? "" : shop.Shop_Name,
                             UsedTime = o == null ? null : o.AddTime
                         });
            query = query.WhereIf(t => t.Member_Name.IndexOf(param.Member_Name) > -1, param.Member_Name.NotNullOrEmpty());
            query = query.WhereIf(t => t.Member_MobilePhone.IndexOf(param.MobilePhone) > -1, param.MobilePhone.NotNullOrEmpty());
            query = query.WhereIf(t => t.UsedTime >= param.DateForm && t.UsedTime <= param.DateTo, param.DateForm.HasValue && param.DateTo.HasValue);

            KeySelectors<MarketingAnalyzeCouponUsedRecord, DefaultSortBy> _keySelectors =
            new KeySelectors<MarketingAnalyzeCouponUsedRecord, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.UsedTime);
            return QueryPaginate<MarketingAnalyzeCouponUsedRecord, MarketingAnalyzeCouponUsedRecord>(query, param, _keySelectors);
            #endregion
        }

        /// <summary>
        /// 营销分析首页统计图表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public MarketAnalysisStstistics GetMarketingAnalyzeStatisticsTable(PromotionStatisticsRequest param)
        {
            var shoplist = param.Shop_ID.NotNullOrEmpty() ? param.Shop_ID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) : null;
            #region query
            #region 方案总数
            //方案总数
            var totalfuture = (from a in Entities.Bas_MarketingAnalyze
                               where a.Merchant_ID == param.Merchant_ID && a.Del != 1 && a.AutoExec == param.AutoExec
                               select new
                               {
                                   MarketingAnalyze_ID = a.MarketingAnalyze_ID,
                                   Shop_Id = (from t in Entities.Bas_Shop
                                              where (from t1 in Entities.Bas_UsableShop
                                                     where t1.Record_ID == a.MarketingAnalyze_ID && t1.Merchant_ID == a.Merchant_ID
                                                     select t1.Shop_ID).Contains(t.Shop_ID)
                                              select t.Shop_ID)
                               });
            //可用店铺 有交集 
            totalfuture = totalfuture.WhereIf(t => t.Shop_Id.Intersect(shoplist).Count() > 0, shoplist != null && shoplist.Count() > 0);

            #endregion

            #region 赠送积分总数
            //赠送积分总数
            var tempTotal = (from ar in Entities.Bus_MarketingAnalyzeRecord
                             join a in Entities.Bas_MarketingAnalyze on ar.MarketingAnalyze_ID equals a.MarketingAnalyze_ID
                             where ar.Adjust != 1 && ar.Status == 1 && a.Merchant_ID == param.Merchant_ID && a.Del != 1
                             && a.AutoExec == param.AutoExec
                             select new
                             {
                                 GivenIntegral = ar.GivenIntegral,
                                 Shop_Id = (from t in Entities.Bas_Shop
                                            where (from t1 in Entities.Bas_UsableShop
                                                   where t1.Record_ID == a.MarketingAnalyze_ID && t1.Merchant_ID == a.Merchant_ID
                                                   select t1.Shop_ID).Contains(t.Shop_ID)
                                            select t.Shop_ID),
                                 ExecuteTime = ar.ExecuteTime
                             });
            tempTotal = tempTotal.WhereIf(t => t.Shop_Id.Intersect(shoplist).Count() > 0, shoplist != null && shoplist.Length > 0);
            tempTotal = tempTotal.WhereIf(t => t.ExecuteTime >= param.StartTime, param.StartTime.HasValue);
            tempTotal = tempTotal.WhereIf(t => t.ExecuteTime <= param.EndTime, param.EndTime.HasValue);

            #endregion

            #region 赠送优惠券总数/消费优惠券总数

            int couponbussinessclass = (int)BusinessClass.MarketingAnalyze;
            var givenCouponsTotal = (from c in Entities.Bus_CardCoupon
                                     join ar in Entities.Bus_MarketingAnalyzeRecord on c.Record_ID equals ar.MarketingAnalyzeRecord_ID
                                     join a in Entities.Bas_MarketingAnalyze on ar.MarketingAnalyze_ID equals a.MarketingAnalyze_ID
                                     where c.BusinessClass == couponbussinessclass && c.Adjust != 1 && c.Del != 1
                                   && c.Merchant_ID == param.Merchant_ID
                                   && a.Del != 1 && ar.Adjust != 1 && ar.Status == 1
                                   && a.Merchant_ID == param.Merchant_ID && ar.Merchant_ID == param.Merchant_ID
                                     select new
                                     {
                                         CardCoupon_ID = c.CardCoupon_ID,
                                         Shop_Id = (from t in Entities.Bas_Shop
                                                    where (from t1 in Entities.Bas_UsableShop
                                                           where t1.Record_ID == a.MarketingAnalyze_ID && t1.Merchant_ID == a.Merchant_ID
                                                           select t1.Shop_ID).Contains(t.Shop_ID)
                                                    select t.Shop_ID),
                                         ExecuteTime = ar.ExecuteTime,
                                         Status = c.Status
                                     });
            givenCouponsTotal = givenCouponsTotal.WhereIf(t => t.Shop_Id.Intersect(shoplist).Count() > 0, shoplist != null && shoplist.Count() > 0);
            givenCouponsTotal = givenCouponsTotal.WhereIf(t => t.ExecuteTime >= param.StartTime && t.ExecuteTime <= param.EndTime, param.StartTime.HasValue && param.EndTime.HasValue);
            #endregion

            #endregion

            MarketAnalysisStstistics info = new MarketAnalysisStstistics();

            #region 方案总数
            //方案总数
            info.PromotionTotal = totalfuture.Count();
            #endregion


            #region 赠送积分总数
            if (tempTotal == null || tempTotal.Count() == 0)
            {
                //赠送积分总数
                info.GivenIntegralTotal = 0;
            }
            else
            {
                //赠送积分总数
                info.GivenIntegralTotal = tempTotal.Sum(t => t.GivenIntegral);
            }
            #endregion


            #region 赠送优惠券总数/消费优惠券总数
            if (givenCouponsTotal == null || givenCouponsTotal.Count() == 0)
            {
                //赠送优惠券总数
                info.GivenCouponsTotal = 0;
                //消费优惠券总数
                info.ComsumeCouponsTotal = 0;
            }
            else
            {
                //赠送优惠券总数
                info.GivenCouponsTotal = givenCouponsTotal.Select(t => t.CardCoupon_ID).Count();
                //消费优惠券总数
                info.ComsumeCouponsTotal = 0;
                var comsumeTotal = givenCouponsTotal.Where(t => t.Status == 1);
                if (comsumeTotal != null && comsumeTotal.Count() > 0)
                {
                    info.ComsumeCouponsTotal = comsumeTotal.Select(t => t.CardCoupon_ID).Count();
                }
            }
            #endregion
            return info;
        }
        /// <summary>
        /// 营销分析发放使用统计
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public MarketAnalysisStstistics GetMarketingAnalyzeRecordStatistics(MarketingAnalyzeRecordRequest param)
        {
            #region query

            #region 发放人数
            //发放人数
            var tempTotal = (from ar in Entities.Bus_MarketingAnalyzeRecord
                             join m1 in Entities.Bas_Member on ar.Member_ID equals m1.Member_ID into mt
                             from m in mt.DefaultIfEmpty()
                             where ar.Adjust != 1 && ar.Status == 1 && ar.Merchant_ID == param.Merchant_ID
                             && ar.MarketingAnalyzeType == param.MarketingAnalyzeType
                             select new
                             {
                                 Member_ID = m.Member_ID,
                                 MarketingAnalyze_ID = ar.MarketingAnalyze_ID,
                                 ExecuteTime = ar.ExecuteTime,
                                 Member_Name = m == null ? "" : m.Member_Name,
                                 Member_MobilePhone = m == null ? "" : m.Member_MobilePhone
                             });
            tempTotal = tempTotal.WhereIf(t => t.MarketingAnalyze_ID==param.MarketingAnalyze_ID, param.MarketingAnalyze_ID.NotNullOrEmpty());
            tempTotal = tempTotal.WhereIf(t => t.Member_Name.IndexOf(param.Member_Name) > -1, param.Member_Name.NotNullOrEmpty());
            tempTotal = tempTotal.WhereIf(t => t.Member_MobilePhone.IndexOf(param.MobilePhone) > -1, param.MobilePhone.NotNullOrEmpty());
            tempTotal = tempTotal.WhereIf(t => t.ExecuteTime >= param.DateForm && t.ExecuteTime <= param.DateTo, param.DateForm.HasValue && param.DateTo.HasValue);

            #endregion



            #region 赠送优惠券总数/消费优惠券总数/带动消费金额
            //赠送优惠券总数
            int couponbussinessclass = (int)BusinessClass.MarketingAnalyze;
            var givenCouponsTotal = (from c in Entities.Bus_CardCoupon
                                     join ar in Entities.Bus_MarketingAnalyzeRecord on c.Record_ID equals ar.MarketingAnalyzeRecord_ID
                                     let men = (from m in Entities.Bas_Member where m.Member_ID == ar.Member_ID select m).FirstOrDefault()
                                     where c.BusinessClass == couponbussinessclass && c.Adjust != 1 && c.Del != 1
                                   && c.Merchant_ID == param.Merchant_ID
                                   && ar.Adjust != 1 && ar.Status == 1 && ar.Merchant_ID == param.Merchant_ID
                                     select new
                                     {
                                         Order_ID = c.Order_ID,
                                         CardCoupon_ID = c.CardCoupon_ID,
                                         MarketingAnalyze_ID = ar.MarketingAnalyze_ID,
                                         Member_Name = men == null ? "" : men.Member_Name,
                                         Member_MobilePhone = men == null ? "" : men.Member_MobilePhone,
                                         ExecuteTime = ar.ExecuteTime,
                                         Status = c.Status
                                     });
            givenCouponsTotal = givenCouponsTotal.WhereIf(t => t.MarketingAnalyze_ID == param.MarketingAnalyze_ID, param.MarketingAnalyze_ID.NotNullOrEmpty());
            givenCouponsTotal = givenCouponsTotal.WhereIf(t => t.Member_Name.IndexOf(param.Member_Name) > -1, param.Member_Name.NotNullOrEmpty());
            givenCouponsTotal = givenCouponsTotal.WhereIf(t => t.Member_MobilePhone.IndexOf(param.MobilePhone) > -1, param.MobilePhone.NotNullOrEmpty());
            givenCouponsTotal = givenCouponsTotal.WhereIf(t => t.ExecuteTime >= param.DateForm && t.ExecuteTime <= param.DateTo, param.DateForm.HasValue && param.DateTo.HasValue);


            #endregion

            #endregion

            MarketAnalysisStstistics info = new MarketAnalysisStstistics();


            #region 发放人数
            if (tempTotal == null || tempTotal.Count() == 0)
            {
                //发放人数
                info.SendedPeopel = 0;
            }
            else
            {
                //发放人数
                info.SendedPeopel = tempTotal.Select(t => t.Member_ID).Distinct().Count();
            }
            #endregion


            #region 赠送优惠券总数/消费优惠券总数/带动消费金额
            if (givenCouponsTotal == null || givenCouponsTotal.Count() == 0)
            {
                //赠送优惠券总数
                info.GivenCouponsTotal = 0;
                //消费优惠券总数
                info.ComsumeCouponsTotal = 0;
                // 带动消费金额
                info.ComsumeMoneyTotal = 0;
            }
            else
            {
                //赠送优惠券总数
                info.GivenCouponsTotal = givenCouponsTotal.Select(t => t.CardCoupon_ID).Count();
                //消费优惠券总数
                info.ComsumeCouponsTotal = 0;
                // 带动消费金额
                info.ComsumeMoneyTotal = 0;
                var comsumeTotal = givenCouponsTotal.Where(t => t.Status == 1);
                if (comsumeTotal != null && comsumeTotal.Count() > 0)
                {
                    //消费优惠券总数
                    info.ComsumeCouponsTotal = comsumeTotal.Select(t => t.CardCoupon_ID).Count();
                    //带动消费金额
                    var orderlist = comsumeTotal.Select(t => t.Order_ID).Distinct();
                    var moneyTotal = (from a in Entities.Bus_Orders
                                      where a.Adjust != 1 && a.Merchant_ID == param.Merchant_ID
                                      && orderlist.Contains(a.Order_ID)
                                      select a.FinalMoney);
                    var money = moneyTotal.Sum();
                    info.ComsumeMoneyTotal = money == null ? 0 : money;
                }
            }
            #endregion
            return info;
        }
    }
}
