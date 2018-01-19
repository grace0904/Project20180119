using Inke.Common.Paginations;
using InkeServer.DataMapping;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inke.Common.Extentions;
using InkeServer.Model;
using InkeServer.Enums;
using AutoMapper;
using EntityFramework.Extensions;
using Inke.Common.Exceptions;
using System.Transactions;
using System.Data.Entity;
using Inke.Common.Helpers;

namespace InkeServer.Service.Impl
{
    public class AutoPromotionService : ServiceBase, IAutoPromotionService
    {
        //标记为注入对象
        [InjectionConstructor]
        public AutoPromotionService() { }

        /// <summary>
        /// 分页查询 自动促销集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<AutoPromotionQueryResult> Query(AutoPromotionQueryRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from a in Entities.Bas_AutoPromotion
                         where a.Merchant_Id.Equals(param.Merchant_ID)
                         && (param.PromotionType <= 0 || a.PromotionType == param.PromotionType)
                         select new AutoPromotionQueryResult
                         {
                             Coupon_Name = (from t in Entities.Bas_Coupon
                                            join t1 in Entities.Bas_GivenCoupon on t.Coupon_ID equals t1.Coupon_ID
                                            where t1.Record_ID == a.Promotion_ID && t1.Merchant_ID == a.Merchant_Id
                                            select (t.Coupon_Name + "*" + t1.CouponQuantity)).Distinct().ToList(),
                             ShopNames = (from t in Entities.Bas_Shop
                                          where (from t1 in Entities.Bas_UsableShop
                                                 where t1.Record_ID == a.Promotion_ID && t1.Merchant_ID == a.Merchant_Id
                                                 select t1.Shop_ID).Contains(t.Shop_ID)
                                          select t.Shop_Name).Distinct().ToList(),
                             Promotion_ID = a.Promotion_ID,
                             Merchant_Id = a.Merchant_Id,
                             PromotionName = a.PromotionName,
                             PromotionType = a.PromotionType,
                             ValidityType = a.ValidityType,
                             DateFrom = a.DateFrom,
                             DateTo = a.DateTo,
                             GivenIntegral = a.GivenIntegral,
                             GivenIntegralMultiple = a.GivenIntegralMultiple,
                             State = a.State,
                             AddTime = a.AddTime,
                             OperationTime = a.OperationTime,
                             Operator = a.Operator
                         });


            KeySelectors<AutoPromotionQueryResult, DefaultSortBy> _keySelectors =
            new KeySelectors<AutoPromotionQueryResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.AddTime);
            return QueryPaginate<AutoPromotionQueryResult, AutoPromotionQueryResult>(query, param, _keySelectors);
            #endregion
        }
        /// <summary>
        /// 直接删除自动促销记录
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
                //删除优惠券使用记录
                int counpontype = (int)GivenCouponType.AutoPromotion;
                Entities.Bas_GivenCoupon.Where(t => t.GivenCoupon_Type == counpontype && param.Record_ID.Contains(t.Record_ID)).Delete();
                //删除可用店铺记录
                int type = (int)UsableClass.AutoPromotion;
                Entities.Bas_UsableShop.Where(t => t.UsableClass == type && param.Record_ID.Contains(t.Record_ID)).Delete();
                //删除时间段数据
                Entities.Bas_AutoPromotionTime.Where(t => param.Record_ID.Contains(t.AutoPromotion_Id)).Delete();
                int row = Entities.Bas_AutoPromotion
                       .Where(t => param.Record_ID.Contains(t.Promotion_ID))
                       .Delete();
                if (row == 0)
                    throw new BusinessException(ResultCode.DeleteFaild.Name());
                scope.Complete();
            }
            return true;
        }

        /// <summary>
        /// 启用/停用自动促销记录
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
            int row = Entities.Bas_AutoPromotion
                   .Where(t => param.Record_ID.Contains(t.Promotion_ID))
                   .Update(t => new Bas_AutoPromotion { State = param.Status, StartUseDate = DateTime.Now, LastExecDate = DateTime.Now, Operator = param.Operator });

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
        public bool ExistNames(string merchantId, string name, string id = "")
        {
            var info = (from a in Entities.Bas_AutoPromotion where a.Merchant_Id == merchantId && a.Promotion_ID != id && a.PromotionName == name select a).FirstOrDefault();
            return info != null;
        }
        /// <summary>
        /// 新增自动促销记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Insert(AddAndUpdatePromotionRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                if (ExistNames(param.Merchant_Id, param.PromotionName, ""))
                    throw new BusinessException(ResultCode.NameExisted.Name());
                //处理model
                Bas_AutoPromotion model = param.MapTo<Bas_AutoPromotion>();
                model.Promotion_ID = Inke.Common.Helpers.GUID.CreateGUID();
                model.AddTime = DateTime.Now;
                model.OperationTime = DateTime.Now;
                model.PromotionShopIds = "";
                model.Shop_Id = "";
                model.State = 1;
                model.LastExecDate = DateTime.Now;
                model.StartUseDate = DateTime.Now;
                Entities.Bas_AutoPromotion.Add(model);

                //插入可用店铺数据
                if (!string.IsNullOrEmpty(param.PromotionShopIds))
                {
                    string[] idList = param.PromotionShopIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    var list = new List<Bas_UsableShop>();
                    foreach (var id in idList)
                    {
                        Bas_UsableShop shop = new Bas_UsableShop();
                        shop.UsableShop_ID = Inke.Common.Helpers.GUID.CreateGUID();
                        shop.UsableClass = (int)UsableClass.AutoPromotion; ;
                        shop.Record_ID = model.Promotion_ID;
                        shop.Merchant_ID = model.Merchant_Id;
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
                //插入时间段数据
                if (param.AutoPromotionTimeList != null && param.AutoPromotionTimeList.Count > 0)
                {
                    var list = param.AutoPromotionTimeList.MapTo<Bas_AutoPromotionTime>();
                    if (list.Count > 0)
                    {
                        foreach (var time in list)
                        {
                            time.AutoPromotionTime_Id = Inke.Common.Helpers.GUID.CreateGUID();
                            time.Status = 1;
                            time.AutoPromotion_Id = model.Promotion_ID;
                            time.AddTime = DateTime.Now;
                        }
                        Entities.Bas_AutoPromotionTime.AddRange(list);
                    }
                }
                //插入优惠券使用数据
                if (param.CouponList != null && param.CouponList.Count > 0)
                {
                    var list = param.CouponList.MapTo<Bas_GivenCoupon>();
                    if (list.Count > 0)
                    {
                        foreach (var coupon in list)
                        {
                            coupon.GivenCoupon_ID = Inke.Common.Helpers.GUID.CreateGUID();
                            coupon.Record_ID = model.Promotion_ID;
                            coupon.Merchant_ID = model.Merchant_Id;
                            coupon.GivenCoupon_Type = (int)GivenCouponType.AutoPromotion;
                            coupon.AddTime = DateTime.Now;
                        }
                        Entities.Bas_GivenCoupon.AddRange(list);
                    }
                }
                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.AddFaild.Name());
                scope.Complete();
            }
            return true;
        }

        /// <summary>
        /// 修改自动促销记录信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Update(AddAndUpdatePromotionRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                if (!Entities.Bas_AutoPromotion.Any(e => e.Promotion_ID == param.Promotion_ID))
                    throw new BusinessException(ResultCode.DataNotFound.Name());
                if (ExistNames(param.Merchant_Id, param.PromotionName, param.Promotion_ID))
                    throw new BusinessException(ResultCode.NameExisted.Name());
                Bas_AutoPromotion model = param.MapTo<Bas_AutoPromotion>();
                model.OperationTime = DateTime.Now;
                model.PromotionShopIds = "";
                model.Shop_Id = "";
                model.LastExecDate = DateTime.Now;
                model.StartUseDate = DateTime.Now;
                Entities.Entry(model).State = EntityState.Modified;
                Entities.Entry(model).Property(b => b.Merchant_Id).IsModified = false;
                Entities.Entry(model).Property(b => b.AddTime).IsModified = false;
                Entities.Entry(model).Property(b => b.State).IsModified = false;//此处不修改状态


                //插入可用店铺数据(先删除后添加Bas_UsableShop )
                #region
                int type = (int)UsableClass.AutoPromotion;
                Entities.Bas_UsableShop.Where(t => t.UsableClass == type && t.Record_ID == model.Promotion_ID).Delete();
                if (!string.IsNullOrEmpty(param.PromotionShopIds))
                {
                    string[] idList = param.PromotionShopIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    var list = new List<Bas_UsableShop>();
                    foreach (var id in idList)
                    {
                        Bas_UsableShop shop = new Bas_UsableShop();
                        shop.UsableShop_ID = Inke.Common.Helpers.GUID.CreateGUID();
                        shop.UsableClass = type;
                        shop.Record_ID = model.Promotion_ID;
                        shop.Merchant_ID = model.Merchant_Id;
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


                //插入时间段数据,先删除后添加
                Entities.Bas_AutoPromotionTime.Where(t => t.AutoPromotion_Id == model.Promotion_ID).Delete();
                if (param.AutoPromotionTimeList != null && param.AutoPromotionTimeList.Count > 0)
                {
                    var list = param.AutoPromotionTimeList.MapTo<Bas_AutoPromotionTime>();
                    if (list.Count > 0)
                    {
                        foreach (var time in list)
                        {
                            time.AutoPromotionTime_Id = Inke.Common.Helpers.GUID.CreateGUID();
                            time.AutoPromotion_Id = model.Promotion_ID;
                            time.Status = 1;
                            time.AddTime = DateTime.Now;
                        }
                        Entities.Bas_AutoPromotionTime.AddRange(list);
                    }
                }
                //插入优惠券使用数据,先删除后添加
                int counpontype = (int)GivenCouponType.AutoPromotion;
                Entities.Bas_GivenCoupon.Where(t => t.GivenCoupon_Type == counpontype && t.Record_ID == model.Promotion_ID).Delete();
                if (param.CouponList != null && param.CouponList.Count > 0)
                {
                    var list = param.CouponList.MapTo<Bas_GivenCoupon>();
                    if (list.Count > 0)
                    {
                        foreach (var coupon in list)
                        {
                            coupon.GivenCoupon_ID = Inke.Common.Helpers.GUID.CreateGUID();
                            coupon.Record_ID = model.Promotion_ID;
                            coupon.GivenCoupon_Type = (int)GivenCouponType.AutoPromotion;
                            coupon.AddTime = DateTime.Now;
                            coupon.Merchant_ID = model.Merchant_Id;
                        }
                        Entities.Bas_GivenCoupon.AddRange(list);
                    }
                }
                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.UpdateFaild.Name());

                scope.Complete();
            }

            return true;
        }
        /// <summary>
        /// 获取自动促销详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public AutoPromotionInfoResult GetAutoPromotionInfo(RecordIDRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var info = (from a in Entities.Bas_AutoPromotion
                        where a.Promotion_ID.Equals(param.Record_ID)
                        select new AutoPromotionInfo
                        {
                            CouponList = (from t in Entities.Bas_Coupon
                                          join t1 in Entities.Bas_GivenCoupon on t.Coupon_ID equals t1.Coupon_ID
                                          where t1.Record_ID == a.Promotion_ID && t1.Merchant_ID == a.Merchant_Id
                                          select new GivenCouponInfo { Coupon_Name = t.Coupon_Name, Coupon_ID = t.Coupon_ID, CouponQuantity = t1.CouponQuantity }).Distinct().ToList(),
                            ShopNames = (from t in Entities.Bas_Shop
                                         where (from t1 in Entities.Bas_UsableShop
                                                where t1.Record_ID == a.Promotion_ID && t1.Merchant_ID == a.Merchant_Id
                                                select t1.Shop_ID).Contains(t.Shop_ID)
                                         select t.Shop_Name).Distinct().ToList(),
                            Promotion_ID = a.Promotion_ID,
                            Merchant_Id = a.Merchant_Id,
                            PromotionName = a.PromotionName,
                            PromotionType = a.PromotionType,
                            ValidityType = a.ValidityType,
                            DateFrom = a.DateFrom,
                            DateTo = a.DateTo,
                            GivenIntegral = a.GivenIntegral,
                            GivenIntegralMultiple = a.GivenIntegralMultiple,
                            State = a.State,
                            Operator = a.Operator,
                            PromotionGender = a.PromotionGender,
                            MemberType = a.MemberType,
                            MultiplePromotion = a.MultiplePromotion,
                            ValidityBirthDay = a.ValidityBirthDay,
                            BirthDayStartDate = a.BirthDayStartDate,
                            BirthDayEndDate = a.BirthDayEndDate,
                            ChargeAmountFrom = a.ChargeAmountFrom,
                            ChargeAmountTo = a.ChargeAmountTo,
                            ConsumeFrom = a.ConsumeFrom,
                            ConsumeTo = a.ConsumeTo,
                            IntegralTotalFrom = a.IntegralTotalFrom,
                            IntegralTotalTo = a.IntegralTotalTo,
                            FestivalName = a.FestivalName,
                            FestivalDate = a.FestivalDate,
                            BeforeDays = a.BeforeDays,
                            PromotionCardTypeIds = a.PromotionCardTypeIds,
                            TotalDateStart = a.TotalDateStart,
                            TotalDateEnd = a.TotalDateEnd
                        }).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            AutoPromotionInfoResult data = new AutoPromotionInfoResult();
            data.AutoPromotionInfo = info;
            //得到时间段数据
            var timelist = (from t in Entities.Bas_AutoPromotionTime where t.AutoPromotion_Id == param.Record_ID select t).MapTo<AutoPromotionTime>();
            if (timelist == null) timelist = new List<AutoPromotionTime>();
            data.AutoPromotionTimeList = timelist;
            return data;
        }
        /// <summary>
        /// 获取自动促销名称集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<AutoPromotionName> GetAutoPromotionNameList(MerchantIdRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var list = (from a in Entities.Bas_AutoPromotion where a.Merchant_Id == param.Merchant_ID select new AutoPromotionName { Promotion_ID = a.Promotion_ID, PromotionName = a.PromotionName });
            return list.ToList();
        }

        /// <summary>
        /// 分页查询 自动促销发放记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<PromotionRecord> GetAutoPromotionRecord(PromotionRecordSearch param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from a in Entities.Bus_AutoPromotionRecord
                         join m1 in Entities.Bas_Member on a.Member_ID equals m1.Member_ID into mt
                         from m in mt.DefaultIfEmpty()
                         join c1 in Entities.Bas_Card on a.Card_ID equals c1.Card_ID into ct
                         from c in ct.DefaultIfEmpty()
                         where a.Merchant_ID.Equals(param.Merchant_ID) && a.Adjust != 1 && a.Status == 1
                         && (string.IsNullOrEmpty(param.Promotion_ID) || a.Promotion_ID==param.Promotion_ID)
                         select new PromotionRecord
                         {
                             Coupon_Name = a.Coupon_ID,
                             Card_Num = c == null ? "" : c.Card_Num,
                             ExecuteTime = a.ExecuteTime,
                             GivenIntegral = a.GivenIntegral,
                             Member_MobilePhone = m == null ? "" : m.Member_MobilePhone,
                             Member_Name = m == null ? "" : m.Member_Name,
                             PromotionName = a.PromotionName,
                             PromotionRecord_ID = a.PromotionRecord_ID,
                             PromotionType = a.PromotionType
                         });
            query = query.WhereIf(t => t.PromotionType == param.PromotionType, param.PromotionType.NotNullOrEmpty());
            query = query.WhereIf(t => t.Member_Name.IndexOf(param.Member_Name) > -1, param.Member_Name.NotNullOrEmpty());
            query = query.WhereIf(t => t.Member_MobilePhone.IndexOf(param.MobilePhone) > -1, param.MobilePhone.NotNullOrEmpty());
            query = query.WhereIf(t => t.ExecuteTime >= param.DateForm && t.ExecuteTime <= param.DateTo, param.DateForm.HasValue && param.DateTo.HasValue);


            KeySelectors<PromotionRecord, DefaultSortBy> _keySelectors =
            new KeySelectors<PromotionRecord, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.ExecuteTime);
            return QueryPaginate<PromotionRecord, PromotionRecord>(query, param, _keySelectors);
            #endregion
        }

        /// <summary>
        /// 分页查询 自动促销优惠券 使用记录集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<PromotionCouponUsedRecord> GetAutoPromotionCouponUsedRecord(PromotionRecordSearch param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //构造查询条件
            var type = (int)BusinessClass.AutoPromotion;
            var query = (from a in Entities.Bus_CardCoupon
                         join p in Entities.Bas_Coupon on a.Coupon_ID equals p.Coupon_ID
                         join ar in Entities.Bus_AutoPromotionRecord on a.Record_ID equals ar.PromotionRecord_ID
                         join o1 in Entities.Bus_Orders on a.Order_ID equals o1.Order_ID into ot
                         from o in ot.DefaultIfEmpty()
                         join m1 in Entities.Bas_Member on o.Member_ID equals m1.Member_ID into mt
                         from m in mt.DefaultIfEmpty()
                         let card = o == null ? null : (from c in Entities.Bas_Card where c.Card_ID == o.Card_ID select c).FirstOrDefault()
                         let shop = o == null ? null : (from s in Entities.Bas_Shop where s.Shop_ID == o.Shop_ID select s).FirstOrDefault()
                         where a.Status == 1 && a.Del != 1 && a.Adjust != 1 && a.BusinessClass == type && ar.Merchant_ID == param.Merchant_ID
                           && (string.IsNullOrEmpty(param.Promotion_ID) || ar.Promotion_ID == param.Promotion_ID)
                         select new PromotionCouponUsedRecord
                         {
                             CardCoupon_ID = a.CardCoupon_ID,
                             Coupon_Name = a.Coupon_Name,
                             Card_Num = card == null ? "" : card.Card_Num,
                             Member_MobilePhone = m == null ? "" : m.Member_MobilePhone,
                             Member_Name = m == null ? "" : m.Member_Name,
                             PromotionName = ar.PromotionName,
                             PromotionType = ar.PromotionType.ToString(),
                             Coupon_DeductionPrice = p.Coupon_DeductionPrice,
                             Shop_Name = shop == null ? "" : shop.Shop_Name,
                             UsedTime = o == null ? null : o.AddTime
                         });
            query = query.WhereIf(t => t.PromotionType == param.PromotionType, param.PromotionType.NotNullOrEmpty());
            query = query.WhereIf(t => t.Member_Name.IndexOf(param.Member_Name) > -1, param.Member_Name.NotNullOrEmpty());
            query = query.WhereIf(t => t.Member_MobilePhone.IndexOf(param.MobilePhone) > -1, param.MobilePhone.NotNullOrEmpty());
            query = query.WhereIf(t => t.UsedTime >= param.DateForm && t.UsedTime <= param.DateTo, param.DateForm.HasValue && param.DateTo.HasValue);



            KeySelectors<PromotionCouponUsedRecord, DefaultSortBy> _keySelectors =
            new KeySelectors<PromotionCouponUsedRecord, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.UsedTime);
            return QueryPaginate<PromotionCouponUsedRecord, PromotionCouponUsedRecord>(query, param, _keySelectors);
            #endregion
        }
        /// <summary>
        /// 自动促销首页统计表数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<PromotionStatistics> GetPromotionStatisticsTable(PromotionStatisticsRequest param)
        {
            var shoplist = param.Shop_ID.NotNullOrEmpty() ? param.Shop_ID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries) : null;
            #region query
            #region 方案总数
            //方案总数
            var totalfuture = (from a in Entities.Bas_AutoPromotion
                               where a.Merchant_Id == param.Merchant_ID
                               select new
                               {
                                   Promotion_ID = a.Promotion_ID,
                                   PromotionType = a.PromotionType,
                                   Shop_Id = (from t in Entities.Bas_Shop
                                              where (from t1 in Entities.Bas_UsableShop
                                                     where t1.Record_ID == a.Promotion_ID && t1.Merchant_ID == a.Merchant_Id
                                                     select t1.Shop_ID).Contains(t.Shop_ID)
                                              select t.Shop_ID)
                               }); ;
            totalfuture = totalfuture.WhereIf(t => t.Shop_Id.Intersect(shoplist).Count() > 0, shoplist != null && shoplist.Count() > 0);
            #endregion

            #region 赠送积分总数
            //赠送积分总数
            var tempTotal = (from ar in Entities.Bus_AutoPromotionRecord
                             join a in Entities.Bas_AutoPromotion on ar.Promotion_ID equals a.Promotion_ID
                             where ar.Adjust != 1 && ar.Status == 1 && a.Merchant_Id == param.Merchant_ID
                             select new
                             {
                                 GivenIntegral = ar.GivenIntegral,
                                 Shop_Id = (from t in Entities.Bas_Shop
                                            where (from t1 in Entities.Bas_UsableShop
                                                   where t1.Record_ID == a.Promotion_ID && t1.Merchant_ID == a.Merchant_Id
                                                   select t1.Shop_ID).Contains(t.Shop_ID)
                                            select t.Shop_ID),
                                 ExecuteTime = ar.ExecuteTime,
                                 PromotionType = a.PromotionType
                             });
            tempTotal = tempTotal.WhereIf(t => t.Shop_Id.Intersect(shoplist).Count() > 0, shoplist != null && shoplist.Count() > 0);
            tempTotal = tempTotal.WhereIf(t => t.ExecuteTime >= param.StartTime, param.StartTime.HasValue);
            tempTotal = tempTotal.WhereIf(t => t.ExecuteTime <= param.EndTime, param.EndTime.HasValue);
            #endregion


            #region 赠送优惠券总数/消费优惠券总数
            //赠送优惠券总数
            int couponbussinessclass = (int)BusinessClass.AutoPromotion;
            var givenCouponsTotal = (from c in Entities.Bus_CardCoupon
                                     join ar in Entities.Bus_AutoPromotionRecord on c.Record_ID equals ar.PromotionRecord_ID
                                     join a in Entities.Bas_AutoPromotion on ar.Promotion_ID equals a.Promotion_ID
                                     where c.BusinessClass == couponbussinessclass && c.Adjust != 1 && c.Del != 1
                                   && c.Merchant_ID == param.Merchant_ID
                                   && ar.Merchant_ID == param.Merchant_ID && ar.Adjust != 1 && ar.Status == 1
                                     select new
                                     {
                                         CardCoupon_ID = c.CardCoupon_ID,
                                         Shop_Id = (from t in Entities.Bas_Shop
                                                    where (from t1 in Entities.Bas_UsableShop
                                                           where t1.Record_ID == a.Promotion_ID && t1.Merchant_ID == a.Merchant_Id
                                                           select t1.Shop_ID).Contains(t.Shop_ID)
                                                    select t.Shop_ID),
                                         ExecuteTime = ar.ExecuteTime,
                                         PromotionType = a.PromotionType,
                                         Status = c.Status
                                     });
            givenCouponsTotal = givenCouponsTotal.WhereIf(t => t.Shop_Id.Intersect(shoplist).Count() > 0, shoplist != null && shoplist.Count() > 0);
            givenCouponsTotal = givenCouponsTotal.WhereIf(t => t.ExecuteTime >= param.StartTime && t.ExecuteTime <= param.EndTime, param.StartTime.HasValue && param.EndTime.HasValue);

            #endregion

            #endregion

            var typelist = EnumHelper.ConvertEnumToEntity(typeof(InkeServer.Enums.AutoPromotion));
            List<PromotionStatistics> data = new List<PromotionStatistics>();
            foreach (var type in typelist)
            {
                int typevalue = type.EnumValue;
                PromotionStatistics info = new PromotionStatistics();
                info.PromotionType = typevalue;
                //方案总数
                info.PromotionTotal = totalfuture.Where(t => t.PromotionType == typevalue).Count();

                #region 赠送积分总数
                var temp0 = tempTotal.Where(t => t.PromotionType == typevalue);
                if (temp0 == null || temp0.Count() == 0)
                {
                    //赠送积分总数
                    info.GivenIntegralTotal = 0;
                }
                else
                {
                    //赠送积分总数
                    info.GivenIntegralTotal = temp0.Sum(t => t.GivenIntegral);
                }
                #endregion


                #region 赠送优惠券总数/消费优惠券总数
                var temp1 = givenCouponsTotal.Where(t => t.PromotionType == typevalue);
                if (temp1 == null || temp1.Count() == 0)
                {
                    //赠送优惠券总数
                    info.GivenCouponsTotal = 0;
                    //消费优惠券总数
                    info.ComsumeCouponsTotal = 0;
                }
                else
                {
                    //赠送优惠券总数
                    info.GivenCouponsTotal = temp1.Select(t => t.CardCoupon_ID).Count();
                    //消费优惠券总数
                    info.ComsumeCouponsTotal = 0;
                    var comsumeTotal = temp1.Where(t => t.Status == 1);
                    if (comsumeTotal != null && comsumeTotal.Count() > 0)
                    {
                        info.ComsumeCouponsTotal = comsumeTotal.Select(t => t.CardCoupon_ID).Count();
                    }
                }
                #endregion


                data.Add(info);
            }
            return data;
        }

        /// <summary>
        /// 自动促销 发放使用统计 表数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public PromotionStatistics GetPromotionRecordStatisticsTable(PromotionRecordSearch param)
        {
            #region query

            #region 发放人数
            //发放人数
            var tempTotal = (from ar in Entities.Bus_AutoPromotionRecord
                             join m1 in Entities.Bas_Member on ar.Member_ID equals m1.Member_ID into mt
                             from m in mt.DefaultIfEmpty()
                             where ar.Adjust != 1 && ar.Status == 1 && ar.Merchant_ID == param.Merchant_ID
                             select new
                             {
                                 Member_ID = ar.Member_ID,
                                 Promotion_ID = ar.Promotion_ID,
                                 ExecuteTime = ar.ExecuteTime,
                                 PromotionType = ar.PromotionType,
                                 Member_Name = m == null ? "" : m.Member_Name,
                                 Member_MobilePhone = m == null ? "" : m.Member_MobilePhone
                             });
            tempTotal = tempTotal.WhereIf(t => t.PromotionType == param.PromotionType, param.PromotionType.NotNullOrEmpty());
            tempTotal = tempTotal.WhereIf(t => t.Promotion_ID==param.Promotion_ID, param.Promotion_ID.NotNullOrEmpty());
            tempTotal = tempTotal.WhereIf(t => t.Member_Name.IndexOf(param.Member_Name) > -1, param.Member_Name.NotNullOrEmpty());
            tempTotal = tempTotal.WhereIf(t => t.Member_MobilePhone.IndexOf(param.MobilePhone) > -1, param.MobilePhone.NotNullOrEmpty());
            tempTotal = tempTotal.WhereIf(t => t.ExecuteTime >= param.DateForm && t.ExecuteTime <= param.DateTo, param.DateForm.HasValue && param.DateTo.HasValue);
            #endregion


            #region 赠送优惠券总数/消费优惠券总数/带动消费金额
            //赠送优惠券总数
            int couponbussinessclass = (int)BusinessClass.AutoPromotion;
            var givenCouponsTotal = (from c in Entities.Bus_CardCoupon
                                     join ar in Entities.Bus_AutoPromotionRecord on c.Record_ID equals ar.PromotionRecord_ID
                                     let m = (from m1 in Entities.Bas_Member
                                              where m1.Member_ID == ar.Member_ID
                                              select m1).FirstOrDefault()
                                     where c.BusinessClass == couponbussinessclass && c.Adjust != 1 && c.Del != 1
                                   && c.Merchant_ID == param.Merchant_ID
                                   && ar.Merchant_ID == param.Merchant_ID && ar.Adjust != 1 && ar.Status == 1
                                     select new
                                     {
                                         CardCoupon_ID = c.CardCoupon_ID,
                                         Promotion_ID = ar.Promotion_ID,
                                         ExecuteTime = ar.ExecuteTime,
                                         PromotionType = ar.PromotionType,
                                         Member_Name = m == null ? "" : m.Member_Name,
                                         Member_MobilePhone = m == null ? "" : m.Member_MobilePhone,
                                         Order_ID = c.Order_ID,
                                         Status = c.Status
                                     });
            givenCouponsTotal = givenCouponsTotal.WhereIf(t => t.PromotionType == param.PromotionType, param.PromotionType.NotNullOrEmpty());
            givenCouponsTotal = givenCouponsTotal.WhereIf(t => t.Promotion_ID == param.Promotion_ID, param.Promotion_ID.NotNullOrEmpty());
            givenCouponsTotal = givenCouponsTotal.WhereIf(t => t.Member_Name.IndexOf(param.Member_Name) > -1, param.Member_Name.NotNullOrEmpty());
            givenCouponsTotal = givenCouponsTotal.WhereIf(t => t.Member_MobilePhone.IndexOf(param.MobilePhone) > -1, param.MobilePhone.NotNullOrEmpty());
            givenCouponsTotal = givenCouponsTotal.WhereIf(t => t.ExecuteTime >= param.DateForm && t.ExecuteTime <= param.DateTo, param.DateForm.HasValue && param.DateTo.HasValue);

            #endregion

            #endregion

            PromotionStatistics info = new PromotionStatistics();

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

                    // 带动消费金额
                    var orderlist = comsumeTotal.Select(t => t.Order_ID).Distinct();
                    var moneyTotal = (from a in Entities.Bus_Orders
                                      where a.Adjust != 1 && a.Merchant_ID == param.Merchant_ID
                                      where orderlist.Contains(a.Order_ID)
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
