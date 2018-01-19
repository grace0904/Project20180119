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
    public class SeatClassService : ServiceBase, ISeatClassService
    {
        //标记为注入对象
        [InjectionConstructor]
        public SeatClassService() { }

        private static KeySelectors<SeatClassQueryResult, DefaultSortBy> _keySelectors =
            new KeySelectors<SeatClassQueryResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.ShopSeatClass_ID);


        public void Insert(SeatClassInsert param)
        {
            #region Insert
            if (param.Shop_ID.IsNullOrEmpty())
                throw new BusinessException(ResultCode.ArgumentsMiss.Name()); 

            string[] baseinfolist = param.ShopSeatClass_Name.Split(',');
            baseinfolist.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //检查当前座位类型的名称是否在该商家的店铺中存在
            var temp = (from m in Entities.Bas_ShopSeatClass
                        where m.Merchant_ID == param.Merchant_ID && m.Del != 1 && m.ShopSeatClass_Name == param.ShopSeatClass_Name && baseinfolist.Contains(m.ShopSeatClass_Name)
                        select m).FirstOrDefault();

            //  shopList.Select(s => s.Shop_ID).Distinct().ToArray(); 
            temp.MustIsNull(ResultCode.DataRepeated.Name());
            foreach (string item in baseinfolist)
            { 
                var shopseatclassinfo = param.MapTo<Bas_ShopSeatClass>();
                shopseatclassinfo.ShopSeatClass_ID = Inke.Common.Helpers.GUID.CreateGUID();
                shopseatclassinfo.ShopSeatClass_Name = item;
                shopseatclassinfo.Del = 0;
                Entities.Set<Bas_ShopSeatClass>().Add(shopseatclassinfo);
            }

            int rownum = Entities.SaveChanges();

            if (rownum == 0)//!Insert(merchantbaseinfo))
                throw new BusinessException(ResultCode.AddFaild.Name());

            #endregion

        }

        public void Delete(OperationBaseRequest param)
        {
            #region Delete
            var temp = (from m in Entities.Bas_ShopSeatClass  where m.Del != 1 select m);
             
            string[] idlist = param.Record_ID.Split(',');            

            temp = temp.WhereIf(
               l => idlist.Contains(l.ShopSeatClass_ID), idlist.Length > 0);

            temp.MustNotNull(ResultCode.DataNotFound.Name());
            int count = Entities.Bas_ShopSeatClass.Update(temp, m => new Bas_ShopSeatClass { Del = 1 });
            //若存在座位用了该座位类型则删除该座位
            var temp2 = (from m in Entities.Bas_ShopSeat
                        where m.Del != 1
                        select m);

            temp2 = temp2.WhereIf(
               l => idlist.Contains(l.ShopSeatClass_ID), idlist.Length > 0);
            int count2 = Entities.Bas_ShopSeat.Update(temp2, m => new Bas_ShopSeat { Del = 1, OptionTime = DateTime.Now, Operator = param.Operator });

            if (count == 0)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }

        public void Update(SeatClassUpdate param)
        {
            #region Update
            var temp = (from m in Entities.Bas_ShopSeatClass
                        where m.ShopSeatClass_ID == param.ShopSeatClass_ID && m.Del != 1
                        select m).FirstOrDefault();

            temp.MustNotNull(ResultCode.DataNotFound.Name());
            temp.ShopSeatClass_Name = param.ShopSeatClass_Name;
            temp.Shop_ID = param.Shop_ID;

            bool state = Entities.SaveChanges() > 0;

            if (!state)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }

        public IPaginationResult<SeatClassQueryResult> Query(SeatClassQueryRequest param)
        {
            #region Query

            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from c in Entities.Bas_ShopSeatClass
                         join s in Entities.Bas_Shop on c.Shop_ID equals s.Shop_ID
                         where c.Del != 1 && c.Merchant_ID == param.Merchant_ID
                         select new SeatClassQueryResult
                         {
                             Shop_ID = c.Shop_ID,
                             ShopSeatClass_Name = c.ShopSeatClass_Name,
                             ShopSeatClass_ID = c.ShopSeatClass_ID,
                             Shop_Name = s.Shop_Name
                         });
            string[] idlist = param.Shop_ID.Split(',');
            query = query.WhereIf(
             l => idlist.Contains(l.Shop_ID), idlist.Length > 0);

            //query = query.WhereIf(
            //        l => l.Shop_ID == param.Shop_ID, !param.Shop_ID.IsNullOrEmpty());


            #region 构造查询

            #endregion 构造查询
            return QueryPaginate<SeatClassQueryResult, SeatClassQueryResult>(query, param, _keySelectors);
            #endregion
        }

        public SeatClassQueryResult GetSeatClassIdAndName(RecordIDRequest param)
        {
            SeatClassQueryResult seatlist = new SeatClassQueryResult();
            seatlist = (from l in Entities.Bas_ShopSeatClass
                        where l.ShopSeatClass_ID == param.Record_ID
                        select l).FirstOrDefault().MapTo<SeatClassQueryResult>();
            return seatlist;
        }
    }
}
