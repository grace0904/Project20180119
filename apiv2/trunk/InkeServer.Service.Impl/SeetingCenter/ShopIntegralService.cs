using AutoMapper;
using Inke.Common.Exceptions;
using Inke.Common.Extentions;
using Inke.Common.Helpers;
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
using EntityFramework.Extensions;

namespace InkeServer.Service.Impl
{
    public class ShopIntegralService : ServiceBase, IShopIntegralService
    {
        [Dependency]
        public IMerchantBaseService MerchantBaseService { get; set; }

        //标记为注入对象
        [InjectionConstructor]
        public ShopIntegralService() { }

        private static KeySelectors<ShopIntegralProductsResult, DefaultSortBy> _keySelectors =
            new KeySelectors<ShopIntegralProductsResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.AddTime);

        public IPaginationResult<ShopIntegralProductsResult> QueryShopAndProductList(ShopProductsRequest param)
        {
            #region Query
            ShopIntegralProductsResult result = new ShopIntegralProductsResult();

            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            #region 店铺列表
            //获取商家产品种类集合
            int classtype = (int)BaseInfo.积分产品种类;
            var query = (from t in Entities.Bas_ShopIntegralProducts
                         join s in Entities.Bas_MerchantBaseInfo on t.Dictionary_ID equals s.MerchantBaseInfo_ID
                         join sh in Entities.Bas_Shop on t.Shop_ID equals sh.Shop_ID
                         where t.Del != 1 && s.BaseInfoClass == classtype && t.Merchant_ID == param.Merchant_ID && s.Del != 1
                         select new ShopIntegralProductsResult
                         {
                             MerchantBaseInfo_Name = s.MerchantBaseInfo_Name,
                             Shop_ID = sh.Shop_ID,
                             Merchant_ID = t.Merchant_ID,
                             ShopIntegralProduct_ID = t.ShopIntegralProduct_ID,
                             Name = t.Name,
                             Shop_Name = sh.Shop_Name,
                             Code = t.Code,
                             ProductNum = t.ProductNum,
                             Unit = t.Unit,
                             Price = t.Price,
                             AddTime = t.AddTime,
                             Dictionary_ID = t.Dictionary_ID,
                             SpellCode = t.SpellCode,
                             Memo = t.Memo
                         });

            if (!param.Shop_ID.IsNullOrEmpty())
            {
                string[] shoplist = param.Shop_ID.Split(',');
                //店铺
                query = query.Where(l => shoplist.Contains(l.Shop_ID));
            }
            //类别信息 
            query = query.WhereIf(
               l => l.Dictionary_ID == param.MerchantBaseInfo_ID, !param.MerchantBaseInfo_ID.IsNullOrEmpty());
            //编码
            query = query.WhereIf(
         l => l.Code.StartsWith(param.Code), !param.Code.IsNullOrEmpty());
            //名称
            query = query.WhereIf(
         l => l.Name.Contains(param.Name), !param.Name.IsNullOrEmpty());
            //积分开始
            query = query.WhereIf(
                l => l.Price >= param.SPrice.Value, param.SPrice.HasValue);
            //积分结束
            query = query.WhereIf(
                l => l.Price <= param.BPrice.Value, param.BPrice.HasValue);

            #endregion

            return QueryPaginate<ShopIntegralProductsResult, ShopIntegralProductsResult>(query, param, _keySelectors);
            #endregion
        }

        public ShopIntegralProductsResult GetShopIntegralInfobyID(string id)
        {
            ShopIntegralProductsResult result = new ShopIntegralProductsResult();
            result = (from t in Entities.Bas_ShopIntegralProducts
                      join s in Entities.Bas_MerchantBaseInfo on t.Dictionary_ID equals s.MerchantBaseInfo_ID
                      join sh in Entities.Bas_Shop on t.Shop_ID equals sh.Shop_ID
                      where t.Del != 1 && s.Del != 1 && t.ShopIntegralProduct_ID == id
                      select new ShopIntegralProductsResult
                      {
                          MerchantBaseInfo_Name = s.MerchantBaseInfo_Name,
                          Shop_ID = sh.Shop_ID,
                          Merchant_ID = t.Merchant_ID,
                          ShopIntegralProduct_ID = t.ShopIntegralProduct_ID,
                          Name = t.Name,
                          Shop_Name = sh.Shop_Name,
                          Code = t.Code,
                          ProductNum = t.ProductNum,
                          Unit = t.Unit,
                          Price = t.Price,
                          AddTime = t.AddTime,
                          Dictionary_ID = t.Dictionary_ID,
                          SpellCode = t.SpellCode,
                          Memo = t.Memo
                      }).FirstOrDefault().MapTo<ShopIntegralProductsResult>();

            return result;
        }
        public void Insert(ShopProductInsert param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            string[] ProductIDList = param.ProductIDList.Split(',');
            List<ShopIntegralProductInfo> shopProList =
                (from l in Entities.Bas_IntegralProducts
                 where l.Del != 1 && ProductIDList.Contains(l.IntegralProduct_ID)
                 select new ShopIntegralProductInfo
                 {
                     BPic = l.IntegralProduct_BPic,
                     Code = l.IntegralProduct_Code,
                     Dictionary_ID = l.Dictionary_ID,
                     IntegralProduct_ID = l.IntegralProduct_ID,
                     Memo = l.IntegralProduct_Memo,
                     Merchant_ID = l.Merchant_ID,
                     Name = l.IntegralProduct_Name,
                     Price = l.IntegralProduct_Price,
                     SpellCode = l.IntegralProduct_SpellCode,
                     SPic = l.IntegralProduct_SPic,
                     ProductNum = 0,
                     Unit = l.IntegralProduct_Unit
                 }).MapTo<ShopIntegralProductInfo>();

            string[] shopIDList = param.ShopIDList.Split(',');
            foreach (string item in shopIDList)
            {
                for (int j = 0; j < shopProList.Count; j++)
                {
                    var info = shopProList[j].MapTo<Bas_ShopIntegralProducts>();
                    info.Shop_ID = item;
                    info.Merchant_ID = param.Merchant_ID;
                    info.AddTime = DateTime.Now;
                    info.Operator = param.Operator;
                    info.OperationTime = DateTime.Now;
                    info.Del = 0;
                    info.ShopIntegralProduct_ID = GUID.CreateGUID();
                    if (!Exists(info))
                    {
                        Entities.Set<Bas_ShopIntegralProducts>().Add(info);
                    }
                }
            }

            bool state = Entities.SaveChanges() > 0;

            if (!state)
                throw new BusinessException(ResultCode.DataRepeated.Name());

        }

        public void Update(ShopIntegralProductsUpdate param)
        {
            #region Update
            var temp = (from m in Entities.Bas_ShopIntegralProducts
                        where m.ShopIntegralProduct_ID == param.ShopIntegralProduct_ID && m.Del != 1
                        select m).FirstOrDefault();

            temp.MustNotNull(ResultCode.DataNotFound.Name());

           /* temp.Shop_ID = param.Shop_ID;
            temp.Dictionary_ID = param.Dictionary_ID;
            temp.IntegralProduct_ID = param.IntegralProduct_ID;
            temp.ProductNum = param.ProductNum;
            temp.Name = param.Name;
            temp.Merchant_ID = param.Merchant_ID;
            temp.Code = param.Code;
            temp.OperationTime = DateTime.Now;
            temp.SpellCode = param.SpellCode;
            temp.Unit = param.Unit;*/
            temp.Price = param.Price;
            //temp.BPic = param.BPic;
           // temp.SPic = param.SPic;
            //temp.Memo = param.Memo;
            temp.ProductNum = param.ProductNum;
            //temp.Merchant_ID = param.Merchant_ID;
            temp.Operator = param.Operator;
            temp.Del = 0;

            bool state = Entities.SaveChanges() > 0;

            if (!state)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }
        public void Delete(OperationBaseRequest param)
        {
            if (param.Record_ID.IsNullOrEmpty())
                throw new BusinessException(ResultCode.ArgumentsMiss.Name());
            #region Delete

            string[] idlist = param.Record_ID.Split(',');

            var temp = (from m in Entities.Bas_ShopIntegralProducts
                        where m.Del != 1
                        select m);

            temp = temp.WhereIf(
               l => idlist.Contains(l.ShopIntegralProduct_ID), idlist.Length > 0);

            temp.MustNotNull(ResultCode.DataNotFound.Name());

            int count = Entities.Bas_ShopIntegralProducts.Update(temp, m => new Bas_ShopIntegralProducts { Del = 1, OperationTime = DateTime.Now, Operator = param.Operator });

            if (count == 0)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }
        #region private Method


        /// <summary>
        /// 判断是否名称重复 与 判断是否存在同一记录-产品ID是否重复
        /// </summary>
        public bool Exists(Bas_ShopIntegralProducts info)
        {
            var query = (from l in Entities.Bas_ShopIntegralProducts
                         where l.Merchant_ID == info.Merchant_ID && l.Shop_ID == info.Shop_ID && l.Del != 1
                         && ((l.Name == info.Name && l.ShopIntegralProduct_ID == l.ShopIntegralProduct_ID) || (l.IntegralProduct_ID == info.IntegralProduct_ID))
                         select l);
            return query.Count() > 0;
        }
        #endregion
    }
}
