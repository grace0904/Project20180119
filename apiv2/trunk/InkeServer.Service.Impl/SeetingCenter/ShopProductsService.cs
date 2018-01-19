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
    public class ShopProductsService : ServiceBase, IShopProductsService
    {
        //标记为注入对象
        [InjectionConstructor]
        public ShopProductsService() { }

        private static KeySelectors<ShopProductPageResult, DefaultSortBy> _keySelectors =
            new KeySelectors<ShopProductPageResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.Code);

        public IPaginationResult<ShopProductPageResult> QueryShopAndProductList(ShopProductsRequest param)
        {
            #region Query
            ShopProductPageResult result = new ShopProductPageResult();

            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            #region 店铺列表
            //获取商家产品种类集合
            int classtype = (int)BaseInfo.产品种类;
            var query = (from t in Entities.Bas_ShopProducts
                         join s in Entities.Bas_MerchantBaseInfo on t.MerchantBaseInfo_ID equals s.MerchantBaseInfo_ID
                         join sh in Entities.Bas_Shop on t.Shop_ID equals sh.Shop_ID
                         where t.Del != 1 && s.Del != 1 && t.Merchant_ID == param.Merchant_ID && s.BaseInfoClass == classtype
                         select new ShopProductPageResult
                         {
                             Product_ID = t.Product_ID,
                             MerchantBaseInfo_ID = t.MerchantBaseInfo_ID,
                             SpellCode = t.SpellCode,
                             BPic = t.BPic,
                             SPic = t.SPic,
                             Discount = t.Discount,
                             Combo = t.Combo,
                             Name = t.Name,
                             Shop_Name = sh.Shop_Name,
                             MerchantBaseInfo_Name = s.MerchantBaseInfo_Name,
                             Shop_ID = sh.Shop_ID,
                             Code = t.Code,
                             Unit = t.Unit,
                             Price = t.Price,
                             AddTime = t.AddTime,
                             Merchant_ID = t.Merchant_ID,
                             ShopProduct_ID = t.ShopProduct_ID,
                             ProductNum = t.ProductNum,
                             Memo = t.Memo,
                             GuQing = t.GuQing,
                             UseRepertory = t.UseRepertory
                         });

            if (!param.Shop_ID.IsNullOrEmpty())
            {
                string[] shoplist = param.Shop_ID.Split(',');
                //店铺
                query = query.Where(l => shoplist.Contains(l.Shop_ID));
            }
            //类别信息 
            query = query.WhereIf(
               l => l.MerchantBaseInfo_ID == param.MerchantBaseInfo_ID, !param.MerchantBaseInfo_ID.IsNullOrEmpty());
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

            return QueryPaginate<ShopProductPageResult, ShopProductPageResult>(query, param, _keySelectors);
            #endregion
        }
        /// <summary>
        /// 查询店铺没有的产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<ShopProductPageResult> QueryShopAndProductNotExists(ShopProductsRequest param)
        {
            #region Query
            ShopProductPageResult result = new ShopProductPageResult();

            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            #region 店铺列表
            //获取商家产品种类集合
            int classtype = (int)BaseInfo.产品种类;
            var query = (from t in Entities.Bas_MerchantProducts
                         join s in Entities.Bas_MerchantBaseInfo on t.MerchantBaseInfo_ID equals s.MerchantBaseInfo_ID
                         //join sh in Entities.Bas_Shop on t.Shop_ID equals sh.Shop_ID
                         where t.Del != 1 && s.Del != 1 && t.Merchant_ID == param.Merchant_ID && s.BaseInfoClass == classtype
                         select new ShopProductPageResult
                         {
                             Product_ID = t.Product_ID,
                             MerchantBaseInfo_ID = t.MerchantBaseInfo_ID,
                             SpellCode = t.Product_SpellCode,
                             BPic = t.Product_BPic,
                             SPic = t.Product_SPic,
                             Discount = t.Product_Discount,
                             Combo = t.Combo,
                             Name = t.Product_Name,
                             MerchantBaseInfo_Name = s.MerchantBaseInfo_Name, 
                             Code = t.Product_Code,
                             AddTime = t.AddTime,
                             Merchant_ID = t.Merchant_ID,
                             Price=t.Product_Price,
                         });
            //类别信息 
            query = query.WhereIf(
               l => l.MerchantBaseInfo_ID == param.MerchantBaseInfo_ID, !param.MerchantBaseInfo_ID.IsNullOrEmpty());
            if (!param.Shop_ID.IsNullOrEmpty())
            {
                string[] shoplist = param.Shop_ID.Split(',');
                //店铺
                query = query.Where(l =>  !(from k in Entities.Bas_ShopProducts 
                                                               where k.Shop_ID==param.Shop_ID  && k.Del!=1
                                                               select k.Product_ID).Contains(l.Product_ID));
            }
        
            #endregion

            return QueryPaginate<ShopProductPageResult, ShopProductPageResult>(query, param, _keySelectors);
            #endregion
        }

        public ShopProductPageResult GetShopProductInfobyID(string id)
        {
            ShopProductPageResult result = new ShopProductPageResult();
            result = (from t in Entities.Bas_ShopProducts
                      join s in Entities.Bas_MerchantBaseInfo on t.MerchantBaseInfo_ID equals s.MerchantBaseInfo_ID
                      join sh in Entities.Bas_Shop on t.Shop_ID equals sh.Shop_ID
                      where t.Del != 1 && s.Del != 1 && t.ShopProduct_ID == id
                      select new ShopProductPageResult
                      {
                          MerchantBaseInfo_Name = s.MerchantBaseInfo_Name,
                          Shop_Name = sh.Shop_Name,
                          ShopProduct_ID = t.ShopProduct_ID,
                          Product_ID = t.Product_ID,
                          MerchantBaseInfo_ID = t.MerchantBaseInfo_ID,
                          Name = t.Name,
                          Code = t.Code,
                          SpellCode = t.SpellCode,
                          BPic = t.BPic,
                          SPic = t.SPic,
                          Discount = t.Discount,
                          Combo = t.Combo,
                          Shop_ID = sh.Shop_ID,
                          Unit = t.Unit,
                          Price = t.Price,
                          AddTime = t.AddTime,
                          Merchant_ID = t.Merchant_ID,
                          ProductNum = t.ProductNum,
                          Memo = t.Memo,
                          GuQing = t.GuQing,
                          UseRepertory = t.UseRepertory
                      }).FirstOrDefault().MapTo<ShopProductPageResult>();

            return result;
        }
        #region insert
        public void Insert(ShopProductInsert param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //获取商家产品信息 --产品本身有可能是套餐产品，因此需要添加套餐产品下的全部产品
            //获取套餐产品下的产品列表         
            string[] ProductIDList = param.ProductIDList.Split(',');
            var idlist = (from p in Entities.Bas_ProductCombo
                          join cp in Entities.Bas_ComboProduct on p.ComboGroup_ID equals cp.ComboGroup_ID
                          where ProductIDList.Contains(p.Product_ID) && p.Del != 1
                          select cp.Product_ID).ToList();

            List<ShopProductInfo> shopProList =
                (from l in Entities.Bas_MerchantProducts
                 where l.Del != 1
                 && (ProductIDList.Contains(l.Product_ID) || idlist.Contains(l.Product_ID))
                 select new ShopProductInfo
                 {
                     BPic = l.Product_BPic == null ? "" : l.Product_BPic,
                     Code = l.Product_Code,
                     Combo = l.Combo,
                     Discount = l.Product_Discount,
                     Memo = l.Product_Memo == null ? "" : l.Product_Memo,
                     Merchant_ID = l.Merchant_ID,
                     MerchantBaseInfo_ID = l.MerchantBaseInfo_ID,
                     Name = l.Product_Name,
                     Price = l.Product_Price,
                     Product_ID = l.Product_ID,
                     SpellCode = l.Product_SpellCode,
                     SPic = l.Product_SPic == null ? "" : l.Product_SPic,
                     Unit = l.Product_Unit,
                     GuQing = 0,
                     ProductNum = 0,
                     UseRepertory = 0
                 }).MapTo<ShopProductInfo>();

            string[] shopIDList = param.ShopIDList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in shopIDList)
            {
                for (int j = 0; j < shopProList.Count; j++)
                {
                    var info = shopProList[j].MapTo<Bas_ShopProducts>();
                    info.Shop_ID = item;
                    info.Merchant_ID = param.Merchant_ID;
                    info.AddTime = DateTime.Now;
                    info.Operator = param.Operator;
                    info.OperationTime = DateTime.Now;
                    info.Del = 0;
                    info.ShopProduct_ID = GUID.CreateGUID();
                    if (!Exists(info))
                    {
                        Entities.Set<Bas_ShopProducts>().Add(info);
                    }
                }
            }

            bool state = Entities.SaveChanges() > 0;

            if (!state)
                throw new BusinessException(ResultCode.DataRepeated.Name());

        }



        #endregion
        public void Update(ShopProductUpdate param)
        {
            #region Update
            var temp = (from m in Entities.Bas_ShopProducts
                        where m.ShopProduct_ID == param.ShopProduct_ID && m.Del != 1
                        select m).FirstOrDefault();

            temp.MustNotNull(ResultCode.DataNotFound.Name());

            temp.Product_ID = param.Product_ID;
            temp.MerchantBaseInfo_ID = param.MerchantBaseInfo_ID;
            temp.Name = param.Name;
            temp.Code = param.Code;
            //temp.AddTime = DateTime.Now;
            temp.OperationTime = DateTime.Now;
            temp.SpellCode = param.SpellCode;
            temp.Unit = param.Unit;
            temp.Price = param.Price;
            temp.BPic = param.BPic.IsNullOrEmpty() ? "" : param.BPic;
            temp.SPic = param.SPic.IsNullOrEmpty() ? "" : param.SPic;
            temp.Discount = param.Discount;
            temp.Combo = param.Combo;
            temp.Memo = param.Memo.IsNullOrEmpty() ? "" : param.Memo;
            temp.GuQing = param.GuQing.HasValue ? param.GuQing : 0;
            temp.ProductNum = param.ProductNum.HasValue ? param.ProductNum : 0;
            temp.UseRepertory = param.UseRepertory;
            temp.Merchant_ID = param.Merchant_ID;
            temp.Shop_ID = param.Shop_ID;
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

            var temp = (from m in Entities.Bas_ShopProducts
                        where m.Del != 1
                        select m);

            temp = temp.WhereIf(
               l => idlist.Contains(l.ShopProduct_ID), idlist.Length > 0);

            temp.MustNotNull(ResultCode.DataNotFound.Name());

            int count = Entities.Bas_ShopProducts.Update(temp, m => new Bas_ShopProducts { Del = 1, OperationTime = DateTime.Now, Operator = param.Operator });

            if (count == 0)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }

        /// <summary>
        /// 批量增加店铺产品记录 只需要商家ID及店铺列表
        /// </summary>
        public void InsertList(ShopProductInsertList param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //获取到该商家下所有的产品列表
            var productlist = (from T in Entities.Bas_MerchantProducts
                               join s in Entities.Bas_MerchantBaseInfo on T.MerchantBaseInfo_ID equals s.MerchantBaseInfo_ID
                               where T.Del != 1 && s.Del != 1 && T.Merchant_ID == param.Merchant_ID
                               select T.Product_ID);

            //获取商家产品信息 --产品本身有可能是套餐产品，因此需要添加套餐产品下的全部产品
            //获取套餐产品下的产品列表         
            string[] ProductIDList = productlist.ToArray(); //param.ProductIDList.Split(',');
            var idlist = (from p in Entities.Bas_ProductCombo
                          join cp in Entities.Bas_ComboProduct on p.ComboGroup_ID equals cp.ComboGroup_ID
                          where ProductIDList.Contains(p.Product_ID) && p.Del != 1
                          select cp.Product_ID).ToList();

            List<ShopProductInfo> shopProList =
                (from l in Entities.Bas_MerchantProducts
                 where l.Del != 1
                 && (ProductIDList.Contains(l.Product_ID) || idlist.Contains(l.Product_ID))
                 select new ShopProductInfo
                 {
                     BPic = l.Product_BPic == null ? "" : l.Product_BPic,
                     Code = l.Product_Code,
                     Combo = l.Combo,
                     Discount = l.Product_Discount,
                     Memo = l.Product_Memo == null ? "" : l.Product_Memo,
                     Merchant_ID = l.Merchant_ID,
                     MerchantBaseInfo_ID = l.MerchantBaseInfo_ID,
                     Name = l.Product_Name,
                     Price = l.Product_Price,
                     Product_ID = l.Product_ID,
                     SpellCode = l.Product_SpellCode,
                     SPic = l.Product_SPic == null ? "" : l.Product_SPic,
                     Unit = l.Product_Unit,
                     GuQing = 0,
                     ProductNum = 0,
                     UseRepertory = 0
                 }).MapTo<ShopProductInfo>();

            string[] shopIDList = param.ShopIDList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in shopIDList)
            {
                for (int j = 0; j < shopProList.Count; j++)
                {
                    var info = shopProList[j].MapTo<Bas_ShopProducts>();
                    info.Shop_ID = item;
                    info.Merchant_ID = param.Merchant_ID;
                    info.AddTime = DateTime.Now;
                    info.Operator = param.Operator;
                    info.OperationTime = DateTime.Now;
                    info.Del = 0;
                    info.ShopProduct_ID = GUID.CreateGUID();
                    if (!Exists(info))
                    {
                        Entities.Set<Bas_ShopProducts>().Add(info);
                    }
                }
            }

            bool state = Entities.SaveChanges() > 0;

            if (!state)
                throw new BusinessException(ResultCode.DataRepeated.Name());

        }
        #region private Method


        /// <summary>
        /// 判断是否名称重复 与 判断是否存在同一记录-产品ID是否重复
        /// </summary>
        public bool Exists(Bas_ShopProducts info)
        {
            var query = (from l in Entities.Bas_ShopProducts
                         where l.Merchant_ID == info.Merchant_ID && l.Shop_ID == info.Shop_ID && l.Del != 1
                         && ((l.Name == info.Name && l.ShopProduct_ID == l.ShopProduct_ID) || (l.Product_ID == info.Product_ID))
                         select l);
            return query.Count() > 0;
        }
        #endregion
    }
}
