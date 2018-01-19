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
    /// <summary>
    /// 挂账记录
    /// </summary>
    public class ArrearsRecordService : ServiceBase, IArrearsRecordService
    {
        //标记为注入对象
        [InjectionConstructor]
        public ArrearsRecordService() { }


        private static KeySelectors<ArrearsRecordResult, DefaultSortBy> _keySelectors =
            new KeySelectors<ArrearsRecordResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.AddTime);
        /// <summary>
        /// 获取挂账记录分页信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<ArrearsRecordResult> GetArrearsListPage(ArrearsRecordRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            var query = (from a in Entities.Bus_Arrears
                         join b in Entities.Bus_Orders on a.Order_ID equals b.Order_ID
                         join c in Entities.Bas_Member on a.Member_ID equals c.Member_ID
                         join d in Entities.Bas_Shop on a.Shop_ID equals d.Shop_ID
                         join e in Entities.Bas_Card on b.Card_ID equals e.Card_ID
                         where a.Adjust != 1
                         select new ArrearsRecordResult
                         {
                             Business_Num = b.Business_Num,
                             Card_ID = b.Card_ID,
                             ConsumeMoney = b.ConsumeMoney,
                             Member_Name = c.Member_Name,
                             Member_MobilePhone = c.Member_MobilePhone,
                             Shop_Name = d.Shop_Name,
                             Card_Num = e.Card_Num,
                             Order_ID = a.Order_ID,
                             Arrears_ID = a.Arrears_ID,
                             Member_ID = a.Member_ID,
                             Arrears_Money = a.Arrears_Money,
                             Arrears_Status = a.Arrears_Status,
                             Merchant_ID = a.Merchant_ID,
                             Shop_ID = a.Shop_ID,
                             Memo = a.Memo,
                             AddTime = a.AddTime,
                             PayType = a.PayType,
                             PayMoney = a.PayMoney,
                             Pay_Card_ID = a.Pay_Card_ID,
                             PayTime = a.PayTime,
                             Operator = a.Operator,
                             Adjust = a.Adjust,
                             PayMemo = a.PayMemo
                         });

            //商家ID
            query = query.WhereIf(
                l => l.Merchant_ID == param.Merchant_ID, !string.IsNullOrEmpty(param.Merchant_ID));

            if (!param.ShopGroup.IsNullOrEmpty())
            {
                string[] shoplist = param.ShopGroup.Split(',');
                //店铺
                query = query.Where(l => shoplist.Contains(l.Shop_ID));
            }

            //挂账状态
            query = query.WhereIf(
                l => l.Arrears_Status == param.Arrears_Status, param.Arrears_Status > 0);
            //会员姓名
            query = query.WhereIf(
              l => l.Member_Name.Contains(param.Member_Name), !param.Member_Name.IsNullOrEmpty());
            //手机号
            query = query.WhereIf(
             l => l.Member_MobilePhone.Contains(param.Member_MobilePhone), !param.Member_MobilePhone.IsNullOrEmpty());


            //充值金额起始
            query = query.WhereIf(
           l => l.Arrears_Money >= param.ArrearsMoneyFrom, param.ArrearsMoneyFrom > 0);
            //充值金额结束
            query = query.WhereIf(
        l => l.Arrears_Money <= param.ArrearsMoneyTo, param.ArrearsMoneyTo > 0);
            //充值日期起始
            query = query.WhereIf(
           l => l.AddTime >= param.ArrearsDateFrom && l.AddTime <= param.ArrearsDateTo, param.ArrearsDateFrom.HasValue && param.ArrearsDateTo.HasValue);

            return QueryPaginate<ArrearsRecordResult, ArrearsRecordResult>(query, param, _keySelectors);
        }

        /// <summary>
        /// 根据ID获取挂详细记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ArrearsRecordResult GetArrearsListbyID(RecordIDRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            ArrearsRecordResult ArrearsRecordResult = new ArrearsRecordResult();
            var query = (from a in Entities.Bus_Arrears
                         join b in Entities.Bus_Orders on a.Order_ID equals b.Order_ID
                         join c in Entities.Bas_Member on a.Member_ID equals c.Member_ID
                         join d in Entities.Bas_Shop on a.Shop_ID equals d.Shop_ID
                         join e in Entities.Bas_Card on b.Card_ID equals e.Card_ID
                         where a.Adjust != 1 && a.Arrears_ID == param.Record_ID
                         select new ArrearsRecordResult
                         {
                             Business_Num = b.Business_Num,
                             Card_ID = b.Card_ID,
                             ConsumeMoney = b.ConsumeMoney,
                             Member_Name = c.Member_Name,
                             Member_MobilePhone = c.Member_MobilePhone,
                             Shop_Name = d.Shop_Name,
                             Card_Num = e.Card_Num,
                             Order_ID = a.Order_ID,
                             Arrears_ID = a.Arrears_ID,
                             Member_ID = a.Member_ID,
                             Arrears_Money = a.Arrears_Money,
                             Arrears_Status = a.Arrears_Status,
                             Merchant_ID = a.Merchant_ID,
                             Shop_ID = a.Shop_ID,
                             Memo = a.Memo,
                             AddTime = a.AddTime,
                             PayType = a.PayType,
                             PayMoney = a.PayMoney,
                             Pay_Card_ID = a.Pay_Card_ID,
                             PayTime = a.PayTime,
                             Operator = a.Operator,
                             Adjust = a.Adjust,
                             PayMemo = a.PayMemo
                         });
            ArrearsRecordResult = query.FirstOrDefault().MapTo<ArrearsRecordResult>();
            return ArrearsRecordResult;
        }
    }
}
