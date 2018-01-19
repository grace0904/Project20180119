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
using System.Linq;
using EntityFramework.Extensions;

namespace InkeServer.Service.Impl
{
    public class ShopSeatService : ServiceBase, IShopSeatService
    {
        //标记为注入对象
        [InjectionConstructor]
        public ShopSeatService() { }

        private static KeySelectors<ShopSeatInfoResult, DefaultSortBy> _keySelectors =
            new KeySelectors<ShopSeatInfoResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.AddTime);

        public List<SeatClassIdAndName> QueryShopSeatClass(MerchantAndShopIdRequest param)
        {
            #region 旧逻辑 新逻辑中不同店铺的座位类型一致
            List<SeatClassIdAndName> result = new List<SeatClassIdAndName>();

            var query = (from l in Entities.Bas_ShopSeatClass
                         where l.Del != 1 && l.Merchant_ID == param.Merchant_ID
                         select l);

            string[] idlist = param.Shop_ID.Split(',');
            query = query.WhereIf(
             l => idlist.Contains(l.Shop_ID), idlist.Length > 0);
            if (query != null)
                result = query.ToList().MapTo<SeatClassIdAndName>();

            return result;
            #endregion

            //List<MerchantBaseQueryResult> result = new List<MerchantBaseQueryResult>();
            //int baseinfoclass = (int)InkeServer.Enums.BaseInfo.座位类型;
            //result = (from l in Entities.Bas_MerchantBaseInfo
            //          where l.Del != 1 && l.BaseInfoClass == baseinfoclass && l.Merchant_ID == Merchant_ID
            //          select l).ToList().MapTo<MerchantBaseQueryResult>();
            //return result;
        }

        public void Insert(ShopSeatInsert param)
        {
            #region Insert
            if (param.Shop_ID.IsNullOrEmpty())
                throw new BusinessException(ResultCode.ArgumentsMiss.Name());

            //检查当前座位类型的名称是否在该商家的店铺中存在
            var temp = (from m in Entities.Bas_ShopSeat
                        where m.Merchant_ID == param.Merchant_ID && m.Del != 1 && m.ShopSeatClass_ID == param.ShopSeatClass_ID
                        && m.Shop_ID == param.Shop_ID && m.Seat_Name == param.Seat_Name
                        select m).FirstOrDefault();

            temp.MustIsNull(ResultCode.DataRepeated.Name());

            var shopseatclassinfo = param.MapTo<Bas_ShopSeat>();
            shopseatclassinfo.Seat_ID = Inke.Common.Helpers.GUID.CreateGUID();
            shopseatclassinfo.Seat_Order = 0;
            shopseatclassinfo.Del = 0;
            shopseatclassinfo.AddTime = DateTime.Now;
            shopseatclassinfo.OptionTime = DateTime.Now;

            if (!Insert(shopseatclassinfo))
                throw new BusinessException(ResultCode.AddFaild.Name());

            #endregion

        }

        public void Delete(OperationBaseRequest param)
        {

            if (param.Record_ID.IsNullOrEmpty())
                throw new BusinessException(ResultCode.ArgumentsMiss.Name());
            #region Delete

            string[] idlist = param.Record_ID.Split(',');

            var temp = (from m in Entities.Bas_ShopSeat
                        where m.Del != 1
                        select m);

            temp = temp.WhereIf(
               l => idlist.Contains(l.Seat_ID), idlist.Length > 0);

            temp.MustNotNull(ResultCode.DataNotFound.Name());

            int count = Entities.Bas_ShopSeat.Update(temp, m => new Bas_ShopSeat { Del = 1, OptionTime = DateTime.Now, Operator = param.Operator });

            if (count == 0)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }

        public void Update(ShopSeatUpdate param)
        {
            #region Update
            var temp = (from m in Entities.Bas_ShopSeat
                        where m.Seat_ID == param.Seat_ID && m.Del != 1
                        select m).FirstOrDefault();

            temp.MustNotNull(ResultCode.DataNotFound.Name());
            //temp = temp.MapTo<Bas_ShopSeat>();
            temp.Seat_Name = param.Seat_Name;
            temp.Seat_Num = param.Seat_Num;
            temp.Shop_ID = param.Shop_ID;
            temp.ShopSeatClass_ID = param.ShopSeatClass_ID;
            temp.Seat_Order = param.Seat_Order.HasValue ? param.Seat_Order : 0;
            temp.AddTime = DateTime.Now;
            temp.OptionTime = DateTime.Now;
            temp.Operator = param.Operator;

            
            bool state = Entities.SaveChanges() > 0;

            if (!state)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }

        public IPaginationResult<ShopSeatInfoResult> Query(ShopSeatInfoRequest param)
        {
            #region Query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //构造查询
            var query = (from c in Entities.Bas_ShopSeatClass
                         join s in Entities.Bas_ShopSeat on c.ShopSeatClass_ID equals s.ShopSeatClass_ID
                         join m in Entities.Bas_Shop on s.Shop_ID equals m.Shop_ID
                         where s.Del != 1 && c.Del!=1
                         select new ShopSeatInfoResult
                         {
                             Seat_ID = s.Seat_ID,
                             Seat_Name = s.Seat_Name,
                             Merchant_ID = s.Merchant_ID,
                             Shop_ID = s.Shop_ID,
                             Shop_Name = m.Shop_Name,
                             Seat_Num = s.Seat_Num,
                             ShopSeatClass_Name = c.ShopSeatClass_Name,
                             ShopSeatClass_ID = s.ShopSeatClass_ID,
                             AddTime = s.AddTime,
                             OptionTime = s.OptionTime,
                             Operator = s.Operator
                         });

            if (!param.ShopIDList.IsNullOrEmpty())
            {
                string[] shoplist = param.ShopIDList.Split(',');
                //店铺
                query = query.Where(l => shoplist.Contains(l.Shop_ID));
            }
            //座位类型
            query = query.WhereIf(
                  l => l.ShopSeatClass_ID == param.ShopSeatClassID, !param.ShopSeatClassID.IsNullOrEmpty());

            return QueryPaginate<ShopSeatInfoResult, ShopSeatInfoResult>(query, param, _keySelectors);
            #endregion
        }

        public ShopSeatInfobyIDResult GetMerchantBaseInfo(string id)
        {
            #region Query
            ShopSeatInfobyIDResult result = new ShopSeatInfobyIDResult();

            id.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询
            result = (from s in Entities.Bas_ShopSeat
                      where s.Del != 1 && s.Seat_ID == id
                      select s).FirstOrDefault().MapTo<ShopSeatInfobyIDResult>();
            return result;

            #endregion
        }
    }
}
