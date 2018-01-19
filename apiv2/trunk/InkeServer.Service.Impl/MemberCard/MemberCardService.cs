using Inke.Common.Extentions;
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
using Inke.Common.Helpers;
using EntityFramework.Extensions;

namespace InkeServer.Service.Impl
{
    /// <summary>
    /// 会员卡记录
    /// </summary>
    public class MemberCardService : ServiceBase, IMemberCardService
    {
        //标记为注入对象
        [InjectionConstructor]
        public MemberCardService() { }

        private static KeySelectors<MemberCardResult, DefaultSortBy> _keySelectors =
            new KeySelectors<MemberCardResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.AddTime);
        /// <summary>
        /// 分页查询会员卡记录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<MemberCardResult> GetMemberCardPage(MemberCardRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var query = (from a in Entities.Bas_Card
                         join b in Entities.Bas_Shop on a.Shop_ID equals b.Shop_ID into t3
                         from mmm in t3.DefaultIfEmpty()
                         join c in Entities.Bas_CardDiscountType on a.Discount_ID equals c.Discount_ID into t1
                         from m in t1.DefaultIfEmpty()
                         join d in Entities.Bas_Member on a.Member_ID equals d.Member_ID into t2
                         from mm in t2.DefaultIfEmpty()
                         where a.Merchant_ID == param.Merchant_ID && a.Card_Status != 9
                         select new MemberCardResult
                         {
                             Shop_ID = a.Shop_ID,
                             Card_BusinessID = a.Card_BusinessID,
                             Card_ID = a.Card_ID,
                             Card_Validity = a.Card_Validity,
                             Card_FDate = a.Card_FDate,
                             Card_LDate = a.Card_LDate,
                             AddTime = a.OperationTime,
                             Card_Integral = a.Card_Integral,
                             Card_Cash = a.Card_Cash,
                             Shop_Name = mmm.Shop_Name == null ? "" : mmm.Shop_Name,
                             Member_MobilePhone = mm.Member_MobilePhone == null ? "" : mm.Member_MobilePhone,
                             Member_Name = mm.Member_Name == null ? "" : mm.Member_Name,
                             Member_ID = mm.Member_ID,
                             Discount_Name = m.Discount_Name == null ? "" : m.Discount_Name,
                             Card_Num = a.Card_Num,
                             Card_Status = a.Card_Status
                         });
            //卡状态，卡号，卡业务id,会员id，会员名称，会员电话 card_id
            if (!param.Shop_ID.IsNullOrEmpty())
            {
                string[] shoplist = param.Shop_ID.Split(',');
                //店铺
                query = query.Where(l => shoplist.Contains(l.Shop_ID));
            }
            //卡状态
            query = query.WhereIf(
                l => l.Card_Status == param.Card_Status, param.Card_Status.HasValue);
            //卡业务id
            query = query.WhereIf(
                l => l.Card_BusinessID == param.Card_BusinessID, !param.Card_BusinessID.IsNullOrEmpty());
            //会员id
            query = query.WhereIf(
              l => l.Member_ID.Contains(param.Member_ID), !param.Member_ID.IsNullOrEmpty());
            //手机号
            query = query.WhereIf(
             l => l.Member_MobilePhone.Contains(param.Member_MobilePhone), !param.Member_MobilePhone.IsNullOrEmpty());
            //会员名称
            query = query.WhereIf(
             l => l.Member_Name.Contains(param.Member_Name), !param.Member_Name.IsNullOrEmpty());

            //会员卡号
            query = query.WhereIf(
           l => (from m in Entities.Bas_Card where m.Merchant_ID == param.Merchant_ID && m.Card_Num == param.Card_Num select m.Card_BusinessID).Contains(l.Card_BusinessID), !param.Card_Num.IsNullOrEmpty());

            return QueryPaginate<MemberCardResult, MemberCardResult>(query, param, _keySelectors);
        }
    }
}
