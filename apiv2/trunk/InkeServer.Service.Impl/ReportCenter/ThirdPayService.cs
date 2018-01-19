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
using Inke.Common.Extentions;

namespace InkeServer.Service.Impl
{
    public class ThirdPayService : ServiceBase, IThirdPayService
    {
        
         //标记为注入对象
        [InjectionConstructor]
        public ThirdPayService() { }

        private static KeySelectors<ThirdPayResult, DefaultSortBy> _keySelectors =
            new KeySelectors<ThirdPayResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.AddTime);
        /// <summary>
        /// 获取充值记录分页查询结果
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<ThirdPayResult> GetThirdPayPage(ThirdPayRequest param)
        {
            #region Query
            ThirdPayResult result = new ThirdPayResult();

            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //获取商家产品种类集合
            var query = (from a in Entities.Bus_ThirdPay
                         join b in Entities.Bas_Shop on a.Shop_ID equals b.Shop_ID
                         where a.Merchant_ID == param.Merchant_ID
                         select new ThirdPayResult
                         {
                             BusinessClass = a.BusinessClass,
                             PayType = a.PayType,
                             PayMoney = a.PayMoney,
                             PayStatus = a.PayStatus,
                             Shop_Name = b.Shop_Name,
                             Shop_ID = a.Shop_ID,
                             AddTime = a.AddTime,
                             ThirdPay_ID = a.ThirdPay_ID,
                             PayBussinessNum = a.PayBussinessNum
                         });
           if (!param.Shop_IDList.IsNullOrEmpty())
            {
                string[] shoplist = param.Shop_IDList.Split(',');
                //店铺
                query = query.Where(l => shoplist.Contains(l.Shop_ID));
            }

           //流水号 业务号
            query = query.WhereIf(
                 l => l.PayBussinessNum == param.PayBussinessNum, !param.PayBussinessNum.IsNullOrEmpty());
             //支付类型
            query = query.WhereIf(
                l => l.PayType == param.PayType, param.PayType.HasValue);
            //
            query = query.WhereIf(
                l => l.PayStatus == param.PayStatus, param.PayStatus.HasValue);
            //
            query = query.WhereIf(
                l => l.BusinessClass == param.BusinessClass, param.BusinessClass.HasValue);
            //ID
            query = query.WhereIf(
              l => l.ThirdPay_ID.Contains(param.ThirdPay_ID), !param.ThirdPay_ID.IsNullOrEmpty());
           /*  //手机号
            query = query.WhereIf(
             l => l.Member_MobilePhone == param.MobilePhone, !param.MobilePhone.IsNullOrEmpty());*/
            //金额起始
            if (param.MoneyForm.HasValue)
            {
                decimal MoneyForm = Convert.ToDecimal(param.MoneyForm);
                query = query.Where(
               l => l.PayMoney >= MoneyForm);
            }
            if (param.MoneyTo.HasValue)
            {
                decimal MoneyTo = Convert.ToDecimal(param.MoneyTo);
                query = query.Where(
               l =>l.PayMoney <= MoneyTo);
            }
            //日期起始
            query = query.WhereIf(
           l => l.AddTime >=param.DateForm && l.AddTime <= param.DateTo, param.DateForm.HasValue && param.DateTo.HasValue);
            return QueryPaginate<ThirdPayResult, ThirdPayResult>(query, param, _keySelectors);
            #endregion
        }
    }
}
