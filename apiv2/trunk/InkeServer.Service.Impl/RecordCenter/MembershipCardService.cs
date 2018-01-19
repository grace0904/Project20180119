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
    public class MembershipCardService : ServiceBase, IMembershipCardService
    {
        //标记为注入对象
        [InjectionConstructor]
        public MembershipCardService() { }

        private static KeySelectors<MembershipCardPageResult, DefaultSortBy> _keySelectors =
            new KeySelectors<MembershipCardPageResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.AddTime);
        /// <summary>
        /// 分页获取会员卡记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<MembershipCardPageResult> MembershipCardPage(MembershipCardPageRequest param)
        {

            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            var query = (from a in Entities.Log_CardOperationLogs
                         join b in Entities.Bas_Card on a.Card_Id equals b.Card_ID
                         join c in Entities.Bas_Member on a.Member_Id equals c.Member_ID
                         join d in Entities.Bas_Shop on a.Shop_Id equals d.Shop_ID
                         where a.Merchant_Id == param.Merchant_ID
                         select new MembershipCardPageResult
                         {
                             Member_Sex = c.Member_Sex,
                             Member_Name = c.Member_Name,
                             Member_MobilePhone = c.Member_MobilePhone,
                             Shop_Name = d.Shop_Name,
                             Log_Id = a.Log_Id,
                             Merchant_Id = a.Merchant_Id,
                             Shop_Id = a.Shop_Id,
                             Log_Type = a.Log_Type,
                             Log_Content = a.Log_Content,
                             AddTime = a.AddTime,
                             Operator = a.Operator,
                             Member_Id = a.Member_Id,
                             Card_Id = a.Card_Id,
                             Card_BusinessID = a.Card_BusinessID
                         });

            if (!param.ShopGroup.IsNullOrEmpty())
            {
                string[] shoplist = param.ShopGroup.Split(',');
                //店铺
                query = query.Where(l => shoplist.Contains(l.Shop_Id));
            }
            //操作类型
            query = query.WhereIf(
                 l => l.Log_Type == param.Log_Type, param.Log_Type.HasValue);

            //会员姓名
            query = query.WhereIf(
              l => l.Member_Name.Contains(param.Member_Name), !param.Member_Name.IsNullOrEmpty());
            //手机号
            query = query.WhereIf(
             l => l.Member_MobilePhone == param.Member_MobilePhone, !param.Member_MobilePhone.IsNullOrEmpty());

            //充值日期起始
            query = query.WhereIf(
           l => l.AddTime >= param.DateFrom && l.AddTime <= param.DateTo, param.DateFrom.HasValue && param.DateTo.HasValue);

            //会员卡号
            query = query.WhereIf(
           l => (from m in Entities.Bas_Card where m.Merchant_ID == param.Merchant_ID && m.Card_Num == param.Card_Num select m.Card_BusinessID).Contains(l.Card_BusinessID), !param.Card_Num.IsNullOrEmpty());

            return QueryPaginate<MembershipCardPageResult, MembershipCardPageResult>(query, param, _keySelectors);
        }

        /// <summary>
        /// 根据ID获取会员卡记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public MembershipCardPageResult MembershipCardbyID(RecordIDRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            MembershipCardPageResult result=new MembershipCardPageResult();
            var query = (from a in Entities.Log_CardOperationLogs
                         join b in Entities.Bas_Card on a.Card_Id equals b.Card_ID
                         join c in Entities.Bas_Member on a.Member_Id equals c.Member_ID
                         join d in Entities.Bas_Shop on a.Shop_Id equals d.Shop_ID
                         where a.Log_Id == param.Record_ID
                         select new MembershipCardPageResult
                         {
                             Member_Sex = c.Member_Sex,
                             Member_Name = c.Member_Name,
                             Member_MobilePhone = c.Member_MobilePhone,
                             Shop_Name = d.Shop_Name,
                             Log_Id = a.Log_Id,
                             Merchant_Id = a.Merchant_Id,
                             Shop_Id = a.Shop_Id,
                             Log_Type = a.Log_Type,
                             Log_Content = a.Log_Content,
                             AddTime = a.AddTime,
                             Operator = a.Operator,
                             Member_Id = a.Member_Id,
                             Card_Id = a.Card_Id,
                             Card_BusinessID = a.Card_BusinessID
                         });

            result=query.FirstOrDefault().MapTo<MembershipCardPageResult>();
            return result;
        }

    }
}
