using Inke.Common.Paginations;
using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inke.Common.Extentions;
using Microsoft.Practices.Unity;
using AutoMapper;
using EntityFramework.Extensions;
using Inke.Common.Exceptions;
using System.Transactions;
using System.Data.Entity;
using Newtonsoft.Json;
using Inke.Common.Helpers;

namespace InkeServer.Service.Impl
{
    public class MerchantProductService : ServiceBase, IMerchantProductService
    {
        //标记为注入对象
        [InjectionConstructor]
        public MerchantProductService() { }
        /// <summary>
        /// 分页查询 商家产品集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<MerchantProductInfoResult> Query(MerchantProductQueryRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            int classtype = (int)BaseInfo.产品种类;
            var query = (from a in Entities.Bas_MerchantProducts
                         join b in Entities.Bas_MerchantBaseInfo on a.MerchantBaseInfo_ID equals b.MerchantBaseInfo_ID
                         where a.Del != 1 && b.Del != 1 && b.BaseInfoClass == classtype
                         && a.Merchant_ID.Equals(param.Merchant_ID)
                         && (string.IsNullOrEmpty(param.MerchantBaseInfo_ID) || a.MerchantBaseInfo_ID.Equals(param.MerchantBaseInfo_ID))
                         && (string.IsNullOrEmpty(param.Code) || a.Product_Code.IndexOf(param.Code) > -1)
                         && (string.IsNullOrEmpty(param.Name) || a.Product_Name.IndexOf(param.Name) > -1)
                         select new MerchantProductInfoResult
                         {
                             MerchantBaseInfo_Name = b.MerchantBaseInfo_Name,
                             Product_ID = a.Product_ID,
                             MerchantBaseInfo_ID = a.MerchantBaseInfo_ID,
                             Product_Name = a.Product_Name,
                             Product_Code = a.Product_Code,
                             Product_SpellCode = a.Product_SpellCode,
                             Product_Unit = a.Product_Unit,
                             Product_Price = a.Product_Price,
                             Product_BPic = a.Product_BPic,
                             Product_SPic = a.Product_SPic,
                             Product_Discount = a.Product_Discount,
                             Combo = a.Combo,
                             Product_Memo = a.Product_Memo,
                             Merchant_ID = a.Merchant_ID,
                             AddTime = a.AddTime,
                             OperationTime = a.OperationTime,
                             Operator = a.Operator
                         });
            if (!string.IsNullOrEmpty(param.SPrice.ToString()) && !string.IsNullOrEmpty(param.BPrice.ToString()))
            {
                query = query.Where(a => a.Product_Price >= param.SPrice && a.Product_Price < param.BPrice);
            }
            else
            {
                query = query.WhereIf(a => a.Product_Price >= param.SPrice, !string.IsNullOrEmpty(param.SPrice.ToString()));
                query = query.WhereIf(a => a.Product_Price <= param.BPrice, !string.IsNullOrEmpty(param.BPrice.ToString()));
            }
            KeySelectors<MerchantProductInfoResult, DefaultSortBy> _keySelectors =
            new KeySelectors<MerchantProductInfoResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.Product_Code);
            return QueryPaginate<MerchantProductInfoResult, MerchantProductInfoResult>(query, param, _keySelectors);
            #endregion
        }
        /// <summary>
        /// 根据商家ID和类型获取商家产品集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<MerchantProductInfoResult> GetList(MerchantAndBaseInfoRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var list = (from a in Entities.Bas_MerchantProducts
                        join b in Entities.Bas_MerchantBaseInfo on a.MerchantBaseInfo_ID equals b.MerchantBaseInfo_ID
                        where a.Del != 1 && b.Del != 1 && a.Merchant_ID == param.Merchant_ID
                        && (string.IsNullOrEmpty(param.MerchantBaseInfo_ID) || a.MerchantBaseInfo_ID == param.MerchantBaseInfo_ID)
                        select new MerchantProductInfoResult
                        {
                            MerchantBaseInfo_Name = b.MerchantBaseInfo_Name,
                            Product_ID = a.Product_ID,
                            MerchantBaseInfo_ID = a.MerchantBaseInfo_ID,
                            Product_Name = a.Product_Name,
                            Product_Code = a.Product_Code,
                            Product_SpellCode = a.Product_SpellCode,
                            Product_Unit = a.Product_Unit,
                            Product_Price = a.Product_Price,
                            Product_BPic = a.Product_BPic,
                            Product_SPic = a.Product_SPic,
                            Product_Discount = a.Product_Discount,
                            Combo = a.Combo,
                            Product_Memo = a.Product_Memo,
                            Merchant_ID = a.Merchant_ID,
                            AddTime = a.AddTime,
                            OperationTime = a.OperationTime,
                            Operator = a.Operator
                        });
            return list.MapTo<MerchantProductInfoResult>();
        }
        /// <summary>
        /// 判断该产品是否被店铺使用
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool IfExistsUser(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }
            var result = (from a in Entities.Bas_ShopProducts where productId.IndexOf(a.Product_ID) > -1 && a.Del != 1 && a.Shop_ID != "" select a);
            return result.Count() > 0;
        }
        /// <summary>
        /// 判断产品中是否有套餐产品存在子产品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool IfExistsChild(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }
            var result = (from a in Entities.Bas_ProductCombo
                          join sp in Entities.Bas_ComboProduct on a.ComboGroup_ID equals sp.ComboGroup_ID
                          where productId.IndexOf(sp.Product_ID) > -1 && a.Del != 1
                          select a);
            return result.Count() > 0;
        }
        /// <summary>
        /// 把商家产品标记为删除
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Delete(OperationBaseRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                if (!string.IsNullOrEmpty(param.Record_ID))
                {
                    param.Record_ID = string.Join(",", param.Record_ID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                }
                //判断产品是否有被店铺使用
                if (IfExistsUser(param.Record_ID))
                {
                    throw new BusinessException(ResultCode.ProductComboUsed.Name());
                }
                //判断产品中是否有套餐产品存在子产品
                if (IfExistsChild(param.Record_ID))
                {
                    throw new BusinessException(ResultCode.ProductComboHasProduct.Name());
                }
                int row = Entities.Bas_MerchantProducts
                         .Where(t => param.Record_ID.Contains(t.Product_ID))
                         .Update(t => new Bas_MerchantProducts { Del = 1 });
                if (row == 0)
                    throw new BusinessException(ResultCode.OperationFaild.Name());
                scope.Complete();
            }

            return true;
        }

        /// <summary>
        /// 获取商家产品详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public MerchantProductInfoResult GetInfo(GetProductInfoRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var info = (from a in Entities.Bas_MerchantProducts
                        join b in Entities.Bas_MerchantBaseInfo on a.MerchantBaseInfo_ID equals b.MerchantBaseInfo_ID
                        where a.Del != 1 && b.Del != 1
                        && a.Merchant_ID.Equals(param.Merchant_ID) && a.Product_ID == param.Product_ID
                        select new MerchantProductInfoResult
                        {
                            MerchantBaseInfo_Name = b.MerchantBaseInfo_Name,
                            Product_ID = a.Product_ID,
                            MerchantBaseInfo_ID = a.MerchantBaseInfo_ID,
                            Product_Name = a.Product_Name,
                            Product_Code = a.Product_Code,
                            Product_SpellCode = a.Product_SpellCode,
                            Product_Unit = a.Product_Unit,
                            Product_Price = a.Product_Price,
                            Product_BPic = a.Product_BPic,
                            Product_SPic = a.Product_SPic,
                            Product_Discount = a.Product_Discount,
                            Combo = a.Combo,
                            Product_Memo = a.Product_Memo,
                            Merchant_ID = a.Merchant_ID,
                            AddTime = a.AddTime,
                            OperationTime = a.OperationTime,
                            Operator = a.Operator
                        }).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            //可用店铺
            var shops = (from s in Entities.Bas_ShopProducts
                         where s.Product_ID == info.Product_ID && s.Del != 1 && s.Merchant_ID == info.Merchant_ID
                         join p in Entities.Bas_Shop on s.Shop_ID equals p.Shop_ID
                         select s.Shop_ID).Distinct().ToList();
            info.UseableShopList = string.Join(",", shops);
            //套餐组
            var gruops = (from g in Entities.Bas_ComboGroup
                          join p in Entities.Bas_ProductCombo on g.ComboGroup_ID equals p.ComboGroup_ID
                          where p.Product_ID == info.Product_ID && p.Merchant_ID == info.Merchant_ID && g.Del != 1
                          && p.Del != 1 && g.Merchant_ID == info.Merchant_ID
                          select g.ComboGroup_ID).Distinct().ToList();
            info.ComboGroupList = string.Join(",", gruops);
            return info;
        }
        public bool ExistsName(string merchantId, string name, string id)
        {
            var count = (from a in Entities.Bas_MerchantProducts where a.Del != 1 && a.Merchant_ID == merchantId && a.Product_Name == name && a.Product_ID != id && (from b in Entities.Bas_MerchantBaseInfo where b.Del != 1 select b.MerchantBaseInfo_ID).Contains(a.MerchantBaseInfo_ID) select a).Count();
            return count > 0;
        }
        public bool ExistsCode(string merchantId, string code, string id)
        {
            var count = (from a in Entities.Bas_MerchantProducts where a.Del != 1 && a.Merchant_ID == merchantId && a.Product_Code == code && a.Product_ID != id && (from b in Entities.Bas_MerchantBaseInfo where b.Del != 1 select b.MerchantBaseInfo_ID).Contains(a.MerchantBaseInfo_ID) select a).Count();
            return count > 0;
        }
        /// <summary>
        /// 添加商家产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Insert(AddOrUpdateMerchantProduct param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                if (ExistsName(param.Merchant_ID, param.Product_Name, ""))
                    throw new BusinessException(ResultCode.NameExisted.Name());
                if (ExistsCode(param.Merchant_ID, param.Product_Code, ""))
                    throw new BusinessException(ResultCode.CodeExisted.Name());
                Bas_MerchantProducts model = param.MapTo<Bas_MerchantProducts>();
                model.Product_ID = Inke.Common.Helpers.GUID.CreateGUID();
                model.AddTime = DateTime.Now;
                model.OperationTime = DateTime.Now;
                model.Del = 0;
                model.Product_Memo = param.Product_Memo.IsNullOrEmpty() ? "" : param.Product_Memo;
                model.Product_BPic = param.Product_BPic.IsNullOrEmpty() ? "" : param.Product_BPic;
                model.Product_SPic = param.Product_SPic.IsNullOrEmpty() ? "" : param.Product_SPic;
                Entities.Bas_MerchantProducts.Add(model);

                #region 获取套餐产品的套餐列表ID 并插入套餐产品表

                if (!string.IsNullOrEmpty(param.UsableShopList))
                {
                    string[] ComboIDList={};
                    if (model.Combo == 1 && !string.IsNullOrEmpty(param.ComboGroupList)) { 
                    ComboIDList = param.ComboGroupList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    IList<Bas_ProductCombo> addProductCombo = new List<Bas_ProductCombo>();
                    foreach (var comboid in ComboIDList)
                    {
                        Bas_ProductCombo combo = new Bas_ProductCombo();
                        combo.ProductCombo_ID = Inke.Common.Helpers.GUID.CreateGUID();
                        combo.Product_ID = model.Product_ID;
                        combo.Merchant_ID = model.Merchant_ID;
                        combo.ComboGroup_ID = comboid;
                        combo.Del = 0;
                        addProductCombo.Add(combo);
                    }
                    if (addProductCombo.Count > 0)
                    {
                        Entities.Bas_ProductCombo.AddRange(addProductCombo);
                    }
                    }
                #endregion

                    #region  添加数据到店铺产品表

                    if (!string.IsNullOrEmpty(param.UsableShopList))
                    {
                        List<Bas_ShopProducts> shopProuctList = new List<Bas_ShopProducts>();
                        string[] shopList = param.UsableShopList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                        //添加套餐中的产品到店铺产品表中
                        //获取套餐中的套餐产品列表
                        List<ShopProductInfo> shopProList = (from l in Entities.Bas_MerchantProducts
                                                             where (from k in Entities.Bas_ComboProduct
                                                                    where ComboIDList.Contains(k.ComboGroup_ID)
                                                                    select k.Product_ID).Contains(l.Product_ID)
                                                             && l.Merchant_ID == param.Merchant_ID && l.Del != 1
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
                        //获取店铺产品中已包含套餐产品列表的店铺列表
                        List<ShopProductInfo> combshoplist = (from l in Entities.Bas_ShopProducts
                                                              where (from k in Entities.Bas_ComboProduct
                                                                     where ComboIDList.Contains(k.ComboGroup_ID)
                                                                     select k.Product_ID).Contains(l.Product_ID)
                                                              && l.Merchant_ID == param.Merchant_ID && shopList.Contains(l.Shop_ID) && l.Del != 1
                                                              select l).MapTo<ShopProductInfo>();

                        foreach (var shopid in shopList)
                        {                            
                            //将套餐产品中在店铺中没有的新增到店铺产品中
                            Bas_ShopProducts product = new Bas_ShopProducts();
                            product.ShopProduct_ID = Inke.Common.Helpers.GUID.CreateGUID();
                            product.Product_ID = model.Product_ID;
                            product.MerchantBaseInfo_ID = model.MerchantBaseInfo_ID;
                            product.Name = model.Product_Name;
                            product.Code = model.Product_Code;
                            product.SpellCode = model.Product_SpellCode;
                            product.Unit = model.Product_Unit;
                            product.Price = model.Product_Price;
                            product.BPic = model.Product_BPic.IsNullOrEmpty() ? "" : model.Product_BPic;
                            product.SPic = model.Product_SPic.IsNullOrEmpty() ? "" : model.Product_SPic;
                            product.Discount = model.Product_Discount;
                            product.Combo = model.Combo;
                            product.Memo = model.Product_Memo.IsNullOrEmpty() ? "" : model.Product_Memo;
                            product.Merchant_ID = model.Merchant_ID;
                            product.Shop_ID = shopid;
                            product.AddTime = DateTime.Now;
                            product.OperationTime = DateTime.Now;
                            product.Operator = model.Operator;
                            product.Del = 0;
                            product.GuQing = 0;
                            product.ProductNum = 0;
                            shopProuctList.Add(product);
                            //将套餐中店铺产品中没有的商家产品新增到店铺产品中
                            for (int j = 0; j < shopProList.Count; j++)
                            {
                                var info = shopProList[j].MapTo<Bas_ShopProducts>();
                                info.Shop_ID = shopid;
                                info.Merchant_ID = param.Merchant_ID;
                                info.AddTime = DateTime.Now;
                                info.Operator = param.Operator;
                                info.OperationTime = DateTime.Now;
                                info.Del = 0;
                                info.ShopProduct_ID = GUID.CreateGUID();
                                var test = combshoplist.Select(c => c.Shop_ID == shopid && c.Product_ID == shopProList[j].Product_ID);
                                if (test.ToList().Count() == 0)
                                {
                                    Entities.Set<Bas_ShopProducts>().Add(info);
                                }
                            }
                        }
                        if (shopProuctList.Count > 0)
                        {
                            Entities.Bas_ShopProducts.AddRange(shopProuctList);
                        }
                    }
                    #endregion
                }
                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.AddFaild.Name());
                scope.Complete();

            }
            return true;
        }

        /// <summary>
        /// 修改会员卡折扣类型信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Update(AddOrUpdateMerchantProduct param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                if (!Entities.Bas_MerchantProducts.Any(e => e.Product_ID == param.Product_ID))
                    throw new BusinessException(ResultCode.DataNotFound.Name());
                if (ExistsName(param.Merchant_ID, param.Product_Name, param.Product_ID))
                    throw new BusinessException(ResultCode.NameExisted.Name());
                if (ExistsCode(param.Merchant_ID, param.Product_Code, param.Product_ID))
                    throw new BusinessException(ResultCode.CodeExisted.Name());
                Bas_MerchantProducts model = param.MapTo<Bas_MerchantProducts>();
                model.OperationTime = DateTime.Now;
                model.Product_Memo = param.Product_Memo.IsNullOrEmpty() ? "" : param.Product_Memo;
                model.Product_BPic = param.Product_BPic.IsNullOrEmpty() ? "" : param.Product_BPic;
                model.Product_SPic = param.Product_SPic.IsNullOrEmpty() ? "" : param.Product_SPic;
                Entities.Entry(model).State = EntityState.Modified;
                Entities.Entry(model).Property(b => b.AddTime).IsModified = false;
                Entities.Entry(model).Property(b => b.Del).IsModified = false;

                #region 若非套餐则删除套餐产品相关的套餐分组，若套餐产品不为空则再插入套餐产品
                if (model.Combo == 0 || !string.IsNullOrEmpty(param.ComboGroupList))
                {
                    //删除套餐产品相关的套餐分组
                    Entities.Bas_ProductCombo.Where(p => p.Product_ID == model.Product_ID && p.Merchant_ID == model.Merchant_ID).Update(p => new Bas_ProductCombo { Del = 1 });
                    if (!string.IsNullOrEmpty(param.ComboGroupList))
                    {
                        string[] ComboIDList = param.ComboGroupList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        IList<Bas_ProductCombo> addProductCombo = new List<Bas_ProductCombo>();
                        foreach (var comboid in ComboIDList)
                        {
                            Bas_ProductCombo combo = new Bas_ProductCombo(); ;
                            combo.ProductCombo_ID = Inke.Common.Helpers.GUID.CreateGUID();
                            combo.Product_ID = model.Product_ID;
                            combo.Merchant_ID = model.Merchant_ID;
                            combo.ComboGroup_ID = comboid;
                            combo.Del = 0;
                            addProductCombo.Add(combo);
                        }
                        if (addProductCombo.Count > 0)
                        {
                            Entities.Bas_ProductCombo.AddRange(addProductCombo);
                        }
                    }
                }
                #endregion

                #region  判断此产品是否已存在于店铺产品中，存在则更新 若否则加入(未完成)
                //批量更新已存在于店铺的数据(已删除的不修改)
                var nowdate = DateTime.Now;
                Entities.Bas_ShopProducts.Where(t => t.Merchant_ID == model.Merchant_ID && t.Product_ID == model.Product_ID && t.Del != 1).Update(t =>
                 new Bas_ShopProducts
                 {
                     MerchantBaseInfo_ID = model.MerchantBaseInfo_ID,
                     Name = model.Product_Name,
                     Code = model.Product_Code,
                     SpellCode = model.Product_SpellCode,
                     Unit = model.Product_Unit,
                     Price = model.Product_Price,
                     BPic = model.Product_BPic == null ? "" : model.Product_BPic,
                     SPic = model.Product_SPic == null ? "" : model.Product_SPic,
                     Discount = model.Product_Discount,
                     Combo = model.Combo,
                     Memo = model.Product_Memo == null ? "" : model.Product_Memo,
                     Merchant_ID = model.Merchant_ID,
                     OperationTime = nowdate,
                     Operator = model.Operator
                 });
                if (!string.IsNullOrEmpty(param.UsableShopList))
                {
                    //判断此产品是否已存在于店铺产品中， 若否则加入
                    List<Bas_ShopProducts> shopProuctList = new List<Bas_ShopProducts>();
                    string[] shopList = param.UsableShopList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var shopid in shopList)
                    {
                        //不存在才加入 
                        if (!Entities.Bas_ShopProducts.Any(t => t.Product_ID == model.Product_ID && t.Shop_ID == shopid && t.Merchant_ID == model.Merchant_ID))
                        {
                            Bas_ShopProducts product = new Bas_ShopProducts();
                            product.ShopProduct_ID = Inke.Common.Helpers.GUID.CreateGUID();
                            product.Product_ID = model.Product_ID;
                            product.MerchantBaseInfo_ID = model.MerchantBaseInfo_ID;
                            product.Name = model.Product_Name;
                            product.Code = model.Product_Code;
                            product.SpellCode = model.Product_SpellCode;
                            product.Unit = model.Product_Unit;
                            product.Price = model.Product_Price;
                            product.BPic = model.Product_BPic.IsNullOrEmpty() ? "" : model.Product_BPic;
                            product.SPic = model.Product_SPic.IsNullOrEmpty() ? "" : model.Product_SPic;
                            product.Discount = model.Product_Discount;
                            product.Combo = model.Combo;
                            product.Memo = model.Product_Memo.IsNullOrEmpty() ? "" : model.Product_Memo;
                            product.Merchant_ID = model.Merchant_ID;
                            product.Shop_ID = shopid;
                            product.AddTime = DateTime.Now;
                            product.OperationTime = DateTime.Now;
                            product.Operator = model.Operator;
                            product.Del = 0;
                            product.GuQing = 0;
                            product.ProductNum = 0;
                            shopProuctList.Add(product);
                        }
                    }
                    if (shopProuctList.Count > 0)
                    {
                        Entities.Bas_ShopProducts.AddRange(shopProuctList);
                    }
                }
                #endregion

                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.UpdateFaild.Name());
                scope.Complete();
            }
            return true;
        }

        /// <summary>
        /// 获取店铺尚未拥有的商家产品列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<MerchantProductInfo> GetMerchantProductByShopID(MerchantShopAndBaseInfo param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var list = (from a in Entities.Bas_MerchantProducts where a.Del != 1 && a.Merchant_ID == param.Merchant_ID select a);
            list = list.WhereIf(a => a.MerchantBaseInfo_ID == param.MerchantBaseInfo_ID, param.MerchantBaseInfo_ID.NotNullOrEmpty());
            list = list.WhereIf(a => (from c in Entities.Bas_ShopProducts where c.Del != 1 && c.Product_ID == a.Product_ID && c.Shop_ID == param.Shop_ID select c).Count() == 0, param.Shop_ID.NotNullOrEmpty());
            return list.MapTo<MerchantProductInfo>();
        }
    }
}
