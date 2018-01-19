using AutoMapper;
using Inke.Common.Exceptions;
using Inke.Common.Extentions;
using Inke.Common.Paginations;
using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using InkeServer.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Inke.Common.Helpers;
using EntityFramework.Extensions;


namespace InkeServer.Service.Impl
{
    public class CouponRechargeSercice : ServiceBase, ICouponRechargeSercice
    {
        //标记为注入对象
        [InjectionConstructor]
        public CouponRechargeSercice() { }

        private static KeySelectors<CouponRechargePageResult, DefaultSortBy> _keySelectors =
            new KeySelectors<CouponRechargePageResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.AddTime);
        /// <summary>
        /// 分页查询优惠券记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<CouponRechargePageResult> GetCouponRechargeListPage(CouponRechargePageRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            var query = (from a in Entities.Bus_CouponRechargeRecord
                         join b in Entities.Bas_Card on a.Card_ID equals b.Card_ID
                         join c in Entities.Bas_Member on a.Member_ID equals c.Member_ID
                         join d in Entities.Bas_CardDiscountType on b.Discount_ID equals d.Discount_ID
                         join e in Entities.Bas_Shop on a.Shop_ID equals e.Shop_ID
                         where a.Merchant_ID == param.Merchant_ID
                         select new CouponRechargePageResult
                         {
                             CouponRecord_ID = a.CouponRecord_ID,
                             Business_Num = a.Business_Num,
                             Coupon_Record = a.Coupon_Record,
                             Coupon_Total = a.Coupon_Total,
                             PayType = a.PayType,
                             PayCash = a.PayCash,
                             CardPayCash = a.CardPayCash,
                             Card_ID = a.Card_ID,
                             Card_Num = b.Card_Num,
                             Card_BusinessID = a.Card_BusinessID,
                             Discount_Name = d.Discount_Name,
                             Member_ID = a.Member_ID,
                             Merchant_ID = a.Merchant_ID,
                             Member_Name = c.Member_Name,
                             Member_MobilePhone = c.Member_MobilePhone,
                             Employee_ID = a.Employee_ID,
                             Shop_ID = a.Shop_ID,
                             Shop_Name = e.Shop_Name,
                             Memo = a.Memo,
                             AddTime = a.AddTime,
                             OperationTime = a.OperationTime,
                             Operator = a.Operator
                         });

            if (!param.ShopGroup.IsNullOrEmpty())
            {
                string[] shoplist = param.ShopGroup.Split(',');
                //店铺
                query = query.Where(l => shoplist.Contains(l.Shop_ID));
            }

            //
            query = query.WhereIf(
                l => l.Business_Num == param.Business_Num, !param.Business_Num.IsNullOrEmpty());
            //
            query = query.WhereIf(
              l => l.Card_Num.Contains(param.Card_Num), !param.Card_Num.IsNullOrEmpty());
            //手机号
            query = query.WhereIf(
             l => l.Member_MobilePhone.Contains(param.MobilePhone), !param.MobilePhone.IsNullOrEmpty());
            //
            query = query.WhereIf(
             l => l.Coupon_Record.Contains(param.Coupon_Name), !param.Coupon_Name.IsNullOrEmpty());

            //日期起始
            query = query.WhereIf(
           l => l.AddTime >= param.DateFrom && l.AddTime <= param.DateTo, param.DateFrom.HasValue && param.DateTo.HasValue);

            return QueryPaginate<CouponRechargePageResult, CouponRechargePageResult>(query, param, _keySelectors);
        }
        /// <summary>
        /// 根据ID及商家ID获取优惠券信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<CouponRechargeRecordInfoResult> GetCouponRechargeRecordbyID(CouponRechargeRecordInfoRequest param)
        {
            List<CouponRechargeRecordInfoResult> result = new List<CouponRechargeRecordInfoResult>();
            result = (from a in Entities.Bus_CardCoupon
                      join m in Entities.Bas_Coupon on a.Coupon_ID equals m.Coupon_ID
                      where a.Adjust == 0 && a.Merchant_ID == param.Merchant_ID && a.Record_ID == param.CouponRecord_ID
                      select new CouponRechargeRecordInfoResult
                      {
                          CardCoupon_ID = a.CardCoupon_ID,
                          Coupon_ID = a.Coupon_ID,
                          Coupon_Name = a.Coupon_Name,
                          Status = a.Status,
                          FDate = a.FDate,
                          LDate = a.LDate,
                          Coupon_Code = m.Coupon_Code,
                          Coupon_Class = m.Coupon_Class,
                          Coupon_ClassName = (m.Coupon_Class == 1) ? "产品券" : "代金券",//  m.Coupon_ClassName,
                          Product_ID = m.Product_ID,
                          Coupon_ConsumeClass = m.Coupon_ConsumeClass,
                          Coupon_Cash = m.Coupon_Cash,
                          Coupon_UserNum = m.Coupon_UserNum,
                          Coupon_Unit = m.Coupon_Unit,
                          Coupon_DeductionPrice = m.Coupon_DeductionPrice
                      }).ToList();

            return result;
        }
    }
}
