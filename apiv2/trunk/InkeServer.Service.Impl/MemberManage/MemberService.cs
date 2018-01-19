using Inke.Common.Paginations;
using InkeServer.DataMapping;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inke.Common.Extentions;
using InkeServer.Enums;

namespace InkeServer.Service.Impl
{
    public class MemberService : ServiceBase, IMemberService
    {
        //标记为注入对象
        [InjectionConstructor]
        public MemberService() { }
        /// <summary>
        /// 分页查询 会员集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<MemberQueryResult> Query(MemberQueryRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from a in Entities.Bas_Member
                         where a.Del != 1
                         select new MemberQueryResult
                         {
                             Member_ID = a.Member_ID,
                             Member_Name = a.Member_Name,
                             Member_Sex = a.Member_Sex,
                             Member_MobilePhone = a.Member_MobilePhone,
                             Member_HomePhone = a.Member_HomePhone,
                             Member_Birthday = a.Member_Birthday != null ? a.Member_Birthday.ToString().Substring(6, 4) 
                             + "-" + a.Member_Birthday.ToString().Substring(0, 2)
                             + "-" + a.Member_Birthday.ToString().Substring(3, 2).Replace(" ","0"): "",
                             Member_Email = a.Member_Email,
                             Member_RegisterTime = a.Member_RegisterTime,
                             Operation = a.Operation,
                             Operator = a.Operator
                         });
            query = query.WhereIf(t => t.Member_Name.IndexOf(param.Member_Name) > -1, param.Member_Name.NotNullOrEmpty());
            query = query.WhereIf(t => t.Member_MobilePhone.IndexOf(param.Member_MobilePhone) > -1, param.Member_MobilePhone.NotNullOrEmpty());
            query = query.WhereIf(t => t.Member_RegisterTime >= param.RegisterTimeFrom, param.RegisterTimeFrom.HasValue);
            query = query.WhereIf(t => t.Member_RegisterTime <= param.RegisterTimeTo, param.RegisterTimeTo.HasValue);
            //增加逻辑只查询在商家开了卡的会员记录
            query = query.Where(l => (from k in Entities.Bas_Card
                                      where k.Merchant_ID == param.Merchant_ID && k.Del != 1
                                      select k.Member_ID).Distinct().Contains(l.Member_ID));



            KeySelectors<MemberQueryResult, DefaultSortBy> _keySelectors =
            new KeySelectors<MemberQueryResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.Member_RegisterTime);
            return QueryPaginate<MemberQueryResult, MemberQueryResult>(query, param, _keySelectors);
            #endregion
        }
    }
}
