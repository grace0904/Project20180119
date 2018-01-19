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
    public class IntegralExchangeService : ServiceBase, IIntegralExchangeService
    {
        //标记为注入对象
        [InjectionConstructor]
        public IntegralExchangeService() { }

        private static KeySelectors<IntegralExchangePageResult, DefaultSortBy> _keySelectors =
            new KeySelectors<IntegralExchangePageResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.AddTime);
        /// <summary>
        /// 分页获取积分兑换
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<IntegralExchangePageResult> GetIntegralExchangePage(IntegralExchangePageRequest param)
        {
            #region Query
            IntegralExchangePageResult result = new IntegralExchangePageResult();

            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //获取商家产品种类集合
            var query = (from a in Entities.Bus_IntegralExchange
                         join b in Entities.Bas_Card on a.Card_ID equals b.Card_ID
                         join c in Entities.Bas_Member on a.Member_ID equals c.Member_ID
                         join d in Entities.Bas_Shop on a.Shop_ID equals d.Shop_ID
                         join e in Entities.Bas_CardDiscountType on b.Discount_ID equals e.Discount_ID
                         where a.Del != 1 && a.Merchant_ID == param.Merchant_ID
                         select new IntegralExchangePageResult
                         {
                             Member_Name = c.Member_Name,
                             Member_Sex = c.Member_Sex,
                             Member_MobilePhone = c.Member_MobilePhone,
                             Card_Num = b.Card_Num,
                             Shop_Name = d.Shop_Name,
                             Discount_Name = e.Discount_Name,
                             Exchange_ID = a.Exchange_ID,
                             Business_Num = a.Business_Num,
                             IntegralProduct_ID = a.IntegralProduct_ID,
                             ShopIntegralProduct_ID = a.ShopIntegralProduct_ID,
                             Product_Name = a.Product_Name,
                             Product_Price = a.Product_Price,
                             ProductQuantity = a.ProductQuantity,
                             Coupon_ID = a.Coupon_ID,
                             Coupon_Name = a.Coupon_Name,
                             Coupon_Price = a.Coupon_Price,
                             CouponQuantity = a.CouponQuantity,
                             Exchange_Cash = a.Exchange_Cash,
                             DeductIntegral = a.DeductIntegral,
                             Card_ID = a.Card_ID,
                             Card_BusinessID = a.Card_BusinessID,
                             Member_ID = a.Member_ID,
                             User_ID = a.User_ID,
                             Merchant_ID = a.Merchant_ID,
                             Shop_ID = a.Shop_ID,
                             Memo = a.Memo,
                             AddTime = a.AddTime,
                             OperationTime = a.OperationTime,
                             Operator = a.Operator,
                             Terminal = a.Terminal
                         });
           
            if (!param.ShopGroup.IsNullOrEmpty())
            {
                string[] shoplist = param.ShopGroup.Split(',');
                //店铺
                query = query.Where(l => shoplist.Contains(l.Shop_ID));
            }

            //流水号 业务号
            query = query.WhereIf(
                 l => l.Business_Num == param.Business_Num, !param.Business_Num.IsNullOrEmpty());
            //会员ID
            // query = query.WhereIf(
            //     l => l.Member_ID == param.Member_ID, !param.Member_ID.IsNullOrEmpty());
            //会员姓名
            query = query.WhereIf(
              l => l.Member_Name.Contains(param.Member_Name), !param.Member_Name.IsNullOrEmpty());
            //手机号
            query = query.WhereIf(
             l => l.Member_MobilePhone == param.Member_MobilePhone, !param.Member_MobilePhone.IsNullOrEmpty());
            // //充值金额起始
            // query = query.WhereIf(
            //l => l.RechargeMoney >= Convert.ToDecimal(param.MoneyForm) && l.RechargeMoney <= Convert.ToDecimal(param.MoneyTo), !param.MoneyForm.IsNullOrEmpty() && !param.MoneyTo.IsNullOrEmpty());
            //充值日期起始
            query = query.WhereIf(
           l => l.AddTime >= param.DateFrom && l.AddTime <= param.DateTo, param.DateFrom.HasValue && param.DateTo.HasValue);

            //会员卡号
            query = query.WhereIf(
           l => (from m in Entities.Bas_Card where m.Merchant_ID == param.Merchant_ID && m.Card_Num == param.Card_Num select m.Card_BusinessID).Contains(l.Card_BusinessID), !param.Card_Num.IsNullOrEmpty());

            return QueryPaginate<IntegralExchangePageResult, IntegralExchangePageResult>(query, param, _keySelectors);
            #endregion
        }
    }
}
