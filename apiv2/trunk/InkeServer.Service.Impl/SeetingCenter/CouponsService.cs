using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Inke.Common.Extentions;
using InkeServer.Enums;
using InkeServer.DataMapping;
using Microsoft.Practices.Unity;
using EntityFramework.Extensions;
using Inke.Common.Exceptions;
using System.Transactions;
using AutoMapper;
using System.Data.Entity;

namespace InkeServer.Service.Impl
{
    public class CouponsService : ServiceBase, ICouponsService
    {
        //标记为注入对象
        [InjectionConstructor]
        public CouponsService() { }
        /// <summary>
        /// 分页查询 优惠券集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<CouponInfoResult> Query(CouponsQueryRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from a in Entities.Bas_Coupon
                         join b in Entities.Bas_MerchantBaseInfo on a.MerchantBaseInfo_ID equals b.MerchantBaseInfo_ID
                         where a.Del != 1 && b.Del != 1
                         && a.Merchant_ID.Equals(param.Merchant_ID)
                         && (string.IsNullOrEmpty(param.MerchantBaseInfo_ID) || a.MerchantBaseInfo_ID.Equals(param.MerchantBaseInfo_ID))
                         && (string.IsNullOrEmpty(param.Coupon_Code) || a.Coupon_Code.Equals(param.Coupon_Code))
                         && (string.IsNullOrEmpty(param.Coupon_Name) || a.Coupon_Name.IndexOf(param.Coupon_Name) > -1)
                         select new CouponInfoResult
                         {
                             MerchantBaseInfo_Name = b.MerchantBaseInfo_Name,
                             Coupon_ID = a.Coupon_ID,
                             MerchantBaseInfo_ID = a.MerchantBaseInfo_ID,
                             Coupon_Name = a.Coupon_Name,
                             Coupon_BuyPrice = a.Coupon_BuyPrice,
                             Coupon_Code = a.Coupon_Code,
                             Coupon_BriefCode = a.Coupon_BriefCode,
                             Coupon_Class = a.Coupon_Class,
                             Product_ID = a.Product_ID,
                             Coupon_ConsumeClass = a.Coupon_ConsumeClass,
                             Coupon_Cash = a.Coupon_Cash,
                             Coupon_UserNum = a.Coupon_UserNum,
                             Coupon_Unit = a.Coupon_Unit,
                             Coupon_DeductionPrice = a.Coupon_DeductionPrice,
                             Coupon_Validity = a.Coupon_Validity,
                             Coupon_FDate = a.Coupon_FDate,
                             Coupon_LDate = a.Coupon_LDate,
                             Coupon_DateNum = a.Coupon_DateNum,
                             Coupon_IntegralExchange = a.Coupon_IntegralExchange,
                             Coupon_Integral = a.Coupon_Integral,
                             Coupon_BPic = a.Coupon_BPic,
                             Coupon_SPic = a.Coupon_SPic,
                             Coupon_Status = a.Coupon_Status,
                             Merchant_ID = a.Merchant_ID,
                             AddTime = a.AddTime,
                             OperationTime = a.OperationTime,
                             Operator = a.Operator,
                             Del = a.Del,
                             Memo = a.Memo
                         });
            if (!string.IsNullOrEmpty(param.Coupon_BeginBuyPrice.ToString()) && !string.IsNullOrEmpty(param.Coupon_EndBuyPrice.ToString()))
            {
                query = query.Where(a => a.Coupon_DeductionPrice >= param.Coupon_BeginBuyPrice && a.Coupon_DeductionPrice < param.Coupon_EndBuyPrice);
            }
            query = query.WhereIf(a => a.Coupon_DeductionPrice >= param.Coupon_BeginBuyPrice, !string.IsNullOrEmpty(param.Coupon_BeginBuyPrice.ToString()));
            query = query.WhereIf(a => a.Coupon_DeductionPrice <= param.Coupon_EndBuyPrice, !string.IsNullOrEmpty(param.Coupon_EndBuyPrice.ToString()));

            KeySelectors<CouponInfoResult, DefaultSortBy> _keySelectors =
            new KeySelectors<CouponInfoResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.Coupon_Name);
            return QueryPaginate<CouponInfoResult, CouponInfoResult>(query, param, _keySelectors);
            #endregion
        }
        /// <summary>
        /// 将优惠券标记为删除
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
                int row = Entities.Bas_Coupon
                         .Where(t => param.Record_ID.Contains(t.Coupon_ID))
                         .Update(t => new Bas_Coupon { Del = 1 });
                //删除记录表数据
                int type = (int)UsableClass.Coupon;
                Entities.Bas_UsableShop
                        .Where(t => t.Record_ID == param.Record_ID && t.UsableClass == type).Delete();

                if (row == 0)
                    throw new BusinessException(ResultCode.OperationFaild.Name());
                scope.Complete();
            }

            return true;
        }
        public bool Exists(string merchantId, string code, string id)
        {
            var info = (from a in Entities.Bas_Coupon where a.Del != 1 && a.Merchant_ID == merchantId && a.Coupon_Code.Equals(code) && !a.Coupon_ID.Equals(id) select a).FirstOrDefault();
            return info != null;
        }
        /// <summary>
        /// 新增优惠券
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Insert(AddOrUpdateCouponsRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                if (Exists(param.Merchant_ID, param.Coupon_Code, ""))
                    throw new BusinessException(ResultCode.DataRepeated.Name());

                Bas_Coupon model = param.MapTo<Bas_Coupon>();
                model.Coupon_ID = Inke.Common.Helpers.GUID.CreateGUID();
                model.AddTime = DateTime.Now;
                model.OperationTime = DateTime.Now;
                model.Del = 0;
                Entities.Bas_Coupon.Add(model);


                //插入UsableShop
                if (!string.IsNullOrEmpty(param.UsableShopList))
                {
                    string[] items = param.UsableShopList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    IList<Bas_UsableShop> shoplist = new List<Bas_UsableShop>();
                    foreach (string shopId in items)
                    {
                        Bas_UsableShop temp = new Bas_UsableShop();
                        temp.UsableShop_ID = Inke.Common.Helpers.GUID.CreateGUID();
                        temp.UsableClass = (int)InkeServer.Enums.UsableClass.Coupon;
                        temp.Record_ID = model.Coupon_ID;
                        temp.Merchant_ID = model.Merchant_ID;
                        temp.Shop_ID = shopId;
                        temp.Status = 1;
                        temp.Memo = "优惠券可用店铺";
                        shoplist.Add(temp);
                    }
                    if (shoplist.Count > 0)
                    {
                        Entities.Bas_UsableShop.AddRange(shoplist);
                    }
                }
                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.AddFaild.Name());
                scope.Complete();
            }

            return true;
        }

        /// <summary>
        /// 修改优惠券信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Update(AddOrUpdateCouponsRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                if (!Entities.Bas_Coupon.Any(e => e.Coupon_ID == param.Coupon_ID))
                    throw new BusinessException(ResultCode.DataNotFound.Name());
                if (Exists(param.Merchant_ID, param.Coupon_Code, param.Coupon_ID))
                    throw new BusinessException(ResultCode.DataRepeated.Name());
                Bas_Coupon model = param.MapTo<Bas_Coupon>();
                model.OperationTime = DateTime.Now;
                Entities.Entry(model).State = EntityState.Modified;
                Entities.Entry(model).Property(b => b.AddTime).IsModified = false;
                Entities.Entry(model).Property(b => b.Del).IsModified = false;


                //更新usabtable表记录
                //先删除相关记录表   model.Account_ID,model.Merchant_ID,usableClass
                int type = (int)UsableClass.Coupon;
                Entities.Bas_UsableShop
                    .Where(t => t.Merchant_ID == param.Merchant_ID && t.Record_ID == model.Coupon_ID && t.UsableClass == type)
                    .Delete();

                //再添加相关记录表  model.UsableShopList
                if (!string.IsNullOrEmpty(param.UsableShopList))
                {
                    string[] items = param.UsableShopList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    IList<Bas_UsableShop> shoplist = new List<Bas_UsableShop>();
                    foreach (string shopId in items)
                    {
                        Bas_UsableShop temp = new Bas_UsableShop();
                        temp.UsableShop_ID = Inke.Common.Helpers.GUID.CreateGUID();
                        temp.UsableClass = (int)InkeServer.Enums.UsableClass.Coupon;
                        temp.Record_ID = model.Coupon_ID;
                        temp.Merchant_ID = model.Merchant_ID;
                        temp.Shop_ID = shopId;
                        temp.Status = 1;
                        temp.Memo = "优惠券可用的店铺";
                        shoplist.Add(temp);
                    }
                    if (shoplist.Count > 0)
                    {
                        Entities.Bas_UsableShop.AddRange(shoplist);
                    }
                }
                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.UpdateFaild.Name());
                scope.Complete();
            }
            return true;
        }

        /// <summary>
        /// 获取优惠券详细 信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>  
        public CouponInfoResult GetInfo(RecordIDRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //构造查询条件
            var info = (from a in Entities.Bas_Coupon
                        join b in Entities.Bas_MerchantBaseInfo on a.MerchantBaseInfo_ID equals b.MerchantBaseInfo_ID
                        where a.Del != 1
                        && a.Coupon_ID == param.Record_ID
                        select new CouponInfoResult
                        {
                            MerchantBaseInfo_Name = b.MerchantBaseInfo_Name,
                            Coupon_ID = a.Coupon_ID,
                            MerchantBaseInfo_ID = a.MerchantBaseInfo_ID,
                            Coupon_Name = a.Coupon_Name,
                            Coupon_Code = a.Coupon_Code,
                            Coupon_BuyPrice = a.Coupon_BuyPrice,
                            Coupon_BriefCode = a.Coupon_BriefCode,
                            Coupon_Class = a.Coupon_Class,
                            Product_ID = a.Product_ID,
                            Coupon_ConsumeClass = a.Coupon_ConsumeClass,
                            Coupon_Cash = a.Coupon_Cash,
                            Coupon_UserNum = a.Coupon_UserNum,
                            Coupon_Unit = a.Coupon_Unit,
                            Coupon_DeductionPrice = a.Coupon_DeductionPrice,
                            Coupon_Validity = a.Coupon_Validity,
                            Coupon_FDate = a.Coupon_FDate,
                            Coupon_LDate = a.Coupon_LDate,
                            Coupon_DateNum = a.Coupon_DateNum,
                            Coupon_IntegralExchange = a.Coupon_IntegralExchange,
                            Coupon_Integral = a.Coupon_Integral,
                            Coupon_BPic = a.Coupon_BPic,
                            Coupon_SPic = a.Coupon_SPic,
                            Coupon_Status = a.Coupon_Status,
                            Merchant_ID = a.Merchant_ID,
                            AddTime = a.AddTime,
                            OperationTime = a.OperationTime,
                            Operator = a.Operator,
                            Del = a.Del,
                            Memo = a.Memo
                        }).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            //优惠券记录可用店铺列表
            int usableClass = (int)UsableClass.Coupon;
            var list = (from u in Entities.Bas_UsableShop
                        join s in Entities.Bas_Shop on u.Shop_ID equals s.Shop_ID
                        where u.Status == 1 && u.Record_ID == param.Record_ID && u.UsableClass == usableClass
                        select s.Shop_ID).ToList();
            info.Shopidlist = string.Join(",", list);
            return info;
        }
        /// <summary>
        /// 获取商家所有优惠券列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<CouponInfo> GetCouponList(MerchantIdRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var list = (from a in Entities.Bas_Coupon where a.Del != 1 && a.Merchant_ID == param.Merchant_ID select a);
            return list.MapTo<CouponInfo>();
        }
        /// <summary>
        /// 分页获取可用优惠券列表（排除已停用和已过期的）
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<CouponInfoResult> GetAvailableCouponList(AvailableCouponQueryRequest param)
        {

            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from a in Entities.Bas_Coupon
                         join b in Entities.Bas_MerchantBaseInfo on a.MerchantBaseInfo_ID equals b.MerchantBaseInfo_ID
                         where a.Del != 1 && b.Del != 1 && a.Coupon_Status > 0
                         && a.Merchant_ID.Equals(param.Merchant_ID)
                         && (string.IsNullOrEmpty(param.MerchantBaseInfo_ID) || a.MerchantBaseInfo_ID.Equals(param.MerchantBaseInfo_ID))
                         && (string.IsNullOrEmpty(param.Coupon_Name) || a.Coupon_Name.IndexOf(param.Coupon_Name) > -1)
                         select new CouponInfoResult
                         {
                             MerchantBaseInfo_Name = b.MerchantBaseInfo_Name,
                             Coupon_ID = a.Coupon_ID,
                             MerchantBaseInfo_ID = a.MerchantBaseInfo_ID,
                             Coupon_Name = a.Coupon_Name,
                             Coupon_BuyPrice = a.Coupon_BuyPrice,
                             Coupon_Code = a.Coupon_Code,
                             Coupon_BriefCode = a.Coupon_BriefCode,
                             Coupon_Class = a.Coupon_Class,
                             Product_ID = a.Product_ID,
                             Coupon_ConsumeClass = a.Coupon_ConsumeClass,
                             Coupon_Cash = a.Coupon_Cash,
                             Coupon_UserNum = a.Coupon_UserNum,
                             Coupon_Unit = a.Coupon_Unit,
                             Coupon_DeductionPrice = a.Coupon_DeductionPrice,
                             Coupon_Validity = a.Coupon_Validity,
                             Coupon_FDate = a.Coupon_FDate,
                             Coupon_LDate = a.Coupon_LDate,
                             Coupon_DateNum = a.Coupon_DateNum,
                             Coupon_IntegralExchange = a.Coupon_IntegralExchange,
                             Coupon_Integral = a.Coupon_Integral,
                             Coupon_BPic = a.Coupon_BPic,
                             Coupon_SPic = a.Coupon_SPic,
                             Merchant_ID = a.Merchant_ID,
                             AddTime = a.AddTime,
                             OperationTime = a.OperationTime,
                             Operator = a.Operator,
                             Memo = a.Memo
                         });
            //排除已过期优惠券
            query = query.Where(t => t.Coupon_Validity != 1 ||
                (t.Coupon_Validity == 1 && System.Data.Entity.DbFunctions.DiffDays(t.Coupon_LDate, DateTime.Now) <= 0));
            //可用店铺
            if (!string.IsNullOrEmpty(param.Shop_ID))
            {
                var shoplist = param.Shop_ID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int usableClass = (int)UsableClass.Coupon;
                query = query.Where(t => (from u in Entities.Bas_UsableShop
                                          join s in Entities.Bas_Shop on u.Shop_ID equals s.Shop_ID
                                          where u.Status == 1 && u.Record_ID == t.Coupon_ID && u.UsableClass == usableClass
                                          select s.Shop_ID).Intersect(shoplist).Count() > 0);
            }
            KeySelectors<CouponInfoResult, DefaultSortBy> _keySelectors =
            new KeySelectors<CouponInfoResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.Coupon_Name);
            return QueryPaginate<CouponInfoResult, CouponInfoResult>(query, param, _keySelectors);
            #endregion
        }
    }
}
