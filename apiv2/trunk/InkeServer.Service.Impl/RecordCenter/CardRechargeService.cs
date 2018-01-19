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
    public class CardRechargeService : ServiceBase, ICardRechargeService
    {
        //标记为注入对象
        [InjectionConstructor]
        public CardRechargeService() { }

        private static KeySelectors<CardRechargeRecordInfo, DefaultSortBy> _keySelectors =
            new KeySelectors<CardRechargeRecordInfo, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.OperationTime);
        /// <summary>
        /// 获取充值记录分页查询结果
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<CardRechargeRecordInfo> GetRechargeRecordPage(CardRechargeRecordPageRequest param)
        {
            #region Query
            CardRechargeRecordInfo result = new CardRechargeRecordInfo();

            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //获取商家产品种类集合
            var query = (from a in Entities.Bus_CardRechargeRecord
                         join b in Entities.Bas_Member on a.Member_ID equals b.Member_ID
                         join c in Entities.Bas_Card on a.Card_ID equals c.Card_ID
                         join d in Entities.Bas_Shop on a.Shop_ID equals d.Shop_ID
                         join e in Entities.Bas_CardDiscountType on c.Discount_ID equals e.Discount_ID
                         where a.Del != 1 && a.Merchant_ID == param.Merchant_ID && a.Adjust == param.IsAdjust
                         select new CardRechargeRecordInfo
                         {
                             Member_Name = b.Member_Name,
                             Member_MobilePhone = b.Member_MobilePhone,
                             Card_Num = c.Card_Num,
                             Shop_Name = d.Shop_Name,
                             Discount_Name = e.Discount_Name,
                             RechargeRecord_ID = a.RechargeRecord_ID,
                             Business_Num = a.Business_Num,
                             RechargeMoney = a.RechargeMoney,
                             PayMoney = a.PayMoney,
                             GivenMoney = a.GivenMoney,
                             PayType = a.PayType,
                             Card_ID = a.Card_ID,
                             Merchant_ID = a.Merchant_ID,
                             Card_BusinessID = a.Card_BusinessID,
                             Shop_ID = a.Shop_ID,
                             Member_ID = a.Member_ID,
                             Operator = a.Operator,
                             GivenIntegral = a.GivenIntegral,
                             Employee_ID = a.Employee_ID,
                             Memo = a.Memo,
                             OperationTime=a.OperationTime,
                             AddTime = a.AddTime
                         });
            if (!param.Shop_IDList.IsNullOrEmpty())
            {
                string[] shoplist = param.Shop_IDList.Split(',');
                //店铺
                query = query.Where(l => shoplist.Contains(l.Shop_ID));
            }

            //流水号 业务号
            query = query.WhereIf(
                 l => l.Business_Num == param.Business_Num, !param.Business_Num.IsNullOrEmpty());
            //会员ID
            query = query.WhereIf(
                l => l.Member_ID == param.Member_ID, !param.Member_ID.IsNullOrEmpty());
            //会员姓名
            query = query.WhereIf(
              l => l.Member_Name.Contains(param.Member_Name), !param.Member_Name.IsNullOrEmpty());
            //手机号
            query = query.WhereIf(
             l => l.Member_MobilePhone == param.MobilePhone, !param.MobilePhone.IsNullOrEmpty());
            //充值金额起始
            if (param.MoneyForm.HasValue && param.MoneyTo.HasValue)
            {
                decimal MoneyForm = Convert.ToDecimal(param.MoneyForm);
                decimal MoneyTo = Convert.ToDecimal(param.MoneyTo);
                query = query.Where(
               l => l.RechargeMoney >= MoneyForm && l.RechargeMoney <= MoneyTo);
            }

            //充值日期起始
            query = query.WhereIf(
           l => l.AddTime >=param.DateForm && l.AddTime <= param.DateTo, param.DateForm.HasValue && param.DateTo.HasValue);

            //会员卡号
            query = query.WhereIf(
           l => (from m in Entities.Bas_Card where m.Merchant_ID == param.Merchant_ID && m.Card_Num == param.Card_Num select m.Card_BusinessID).Contains(l.Card_BusinessID), !param.Card_Num.IsNullOrEmpty());

            return QueryPaginate<CardRechargeRecordInfo, CardRechargeRecordInfo>(query, param, _keySelectors);
            #endregion
        }
        /// <summary>
        /// 获取充值记录相关信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public CardRechargeRecordInfoResult GetRechargeRecordInfo(CardRechargeRecordInfoRequest param)
        {
            CardRechargeRecordInfoResult result = new CardRechargeRecordInfoResult();
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //详细信息
            result.CardRechargeInfo = (from a in Entities.Bus_CardRechargeRecord
                                       join b in Entities.Bas_Member on a.Member_ID equals b.Member_ID
                                       join c in Entities.Bas_Card on a.Card_ID equals c.Card_ID
                                       join d in Entities.Bas_Shop on a.Shop_ID equals d.Shop_ID
                                       join e in Entities.Bas_CardDiscountType on c.Discount_ID equals e.Discount_ID
                                       where a.Del != 1 && a.RechargeRecord_ID == param.RechargeRecord_ID
                                       select new CardRechargeRecordInfo
                                       {
                                           #region
                                           Member_Name = b.Member_Name,
                                           Member_MobilePhone = b.Member_MobilePhone,
                                           Card_Num = c.Card_Num,
                                           Shop_Name = d.Shop_Name,
                                           Discount_Name = e.Discount_Name,
                                           RechargeRecord_ID = a.RechargeRecord_ID,
                                           Business_Num = a.Business_Num,
                                           RechargeMoney = a.RechargeMoney,
                                           PayMoney = a.PayMoney,
                                           GivenMoney = a.GivenMoney,
                                           PayType = a.PayType,
                                           Card_ID = a.Card_ID,
                                           Merchant_ID = a.Merchant_ID,
                                           Card_BusinessID = a.Card_BusinessID,
                                           Shop_ID = a.Shop_ID,
                                           Member_ID = a.Member_ID,
                                           Operator = a.Operator,
                                           GivenIntegral = a.GivenIntegral,
                                           Employee_ID = a.Employee_ID,
                                           Memo = a.Memo,
                                           AddTime = a.AddTime,
                                           OperationTime=a.OperationTime,
                                           #endregion
                                       }).FirstOrDefault().MapTo<CardRechargeRecordInfo>();

            //历史
            result.HistoryCardRechargeRecord = (from l in Entities.Bus_CardRechargeRecord
                                                where l.Adjust == 1 && l.Merchant_ID == param.Merchant_ID && l.Shop_ID == param.Shop_ID &&
                                                 (from k in Entities.Bus_CardRechargeRecord where k.RechargeRecord_ID == param.RechargeRecord_ID select k.Business_Num).FirstOrDefault().Contains(l.Business_Num)
                                                select l).ToList().MapTo<CardRechargeRecordInfo>();
            return result;
        }
    }
}
