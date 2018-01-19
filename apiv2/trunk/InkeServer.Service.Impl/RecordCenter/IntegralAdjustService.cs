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
    public class IntegralAdjustService : ServiceBase, IIntegralAdjustService
    {
        
        //标记为注入对象
        [InjectionConstructor]
        public IntegralAdjustService() { }

        private static KeySelectors<IntegralAdjustPageResult, DefaultSortBy> _keySelectors =
            new KeySelectors<IntegralAdjustPageResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.AddTime);
        /// <summary>
        /// 分页获取积分调整
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<IntegralAdjustPageResult> GetIntegralAdjustPage(IntegralAdjustPageRequest param)
        {
            #region Query
            IntegralAdjustPageResult result = new IntegralAdjustPageResult();

            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //获取商家产品种类集合
            var query = (from a in Entities.Bus_IntegralAdjust
                         join b in Entities.Bas_Card on a.Card_ID equals b.Card_ID
                         join c in Entities.Bas_Member on a.Member_ID equals c.Member_ID
                         join d in Entities.Bas_Shop on a.Shop_ID equals d.Shop_ID
                         join e in Entities.Bas_CardDiscountType on b.Discount_ID equals e.Discount_ID
                         where  a.Merchant_ID == param.Merchant_ID
                         select new IntegralAdjustPageResult
                         {
                             Member_Name = c.Member_Name,
                             Member_Sex = c.Member_Sex,
                             Member_MobilePhone = c.Member_MobilePhone,
                             Card_Num = b.Card_Num,
                             Shop_Name = d.Shop_Name,
                             Discount_Name = e.Discount_Name,
                             IntegralAdjust_ID = a.IntegralAdjust_ID,
                             Business_Num = a.Business_Num,
                             AdjustType = a.AdjustType,
                             AdjustIntegral = a.AdjustIntegral,
                             Memo = a.Memo,
                             Card_ID = a.Card_ID,
                             Card_BussinessID = a.Card_BussinessID,
                             Member_ID = a.Member_ID,
                             Merchant_ID = a.Merchant_ID,
                             Shop_ID = a.Shop_ID,
                             AddTime = a.AddTime,
                             Operator = a.Operator
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
            //调整类型
            query = query.WhereIf(
                l => l.AdjustType == param.AdjustType, param.AdjustType.HasValue);
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
            l => (from m in Entities.Bas_Card where m.Merchant_ID == param.Merchant_ID && m.Card_Num == param.Card_Num select m.Card_BusinessID).Contains(l.Card_BussinessID), !param.Card_Num.IsNullOrEmpty());
           
            return QueryPaginate<IntegralAdjustPageResult, IntegralAdjustPageResult>(query, param, _keySelectors);
            #endregion
        }
    }
}
