using Inke.Common.Paginations;
using InkeServer.DataMapping;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Linq;
using Inke.Common.Extentions;
using InkeServer.Enums;
using EntityFramework.Extensions;
using Inke.Common.Exceptions;
using AutoMapper;
using System.Data.Entity;
using System.Collections.Generic;

namespace InkeServer.Service.Impl
{
    /// <summary>
    /// 商家积分产品服务类 
    /// </summary>
    public class MerchantScoreProductService : ServiceBase, IMerchantScoreProductService
    {
        //标记为注入对象
        [InjectionConstructor]
        public MerchantScoreProductService() { }
        /// <summary>
        /// 分页查询 商家积分产品集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<MerchantScoreProductInfoResult> Query(MerchantScoreProductQueyRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            //构造查询条件
            int classtype = (int)BaseInfo.积分产品种类;
            var query = (from a in Entities.Bas_IntegralProducts
                         join b in Entities.Bas_MerchantBaseInfo on a.Dictionary_ID equals b.MerchantBaseInfo_ID
                         where a.Del != 1 && b.Del != 1
                         && a.Merchant_ID.Equals(param.Merchant_ID)
                         && (string.IsNullOrEmpty(param.MerchantBaseInfo_ID) || a.Dictionary_ID.Equals(param.MerchantBaseInfo_ID))
                         && (string.IsNullOrEmpty(param.Code) || a.IntegralProduct_Code.Equals(param.Code))
                         && (string.IsNullOrEmpty(param.Name) || a.IntegralProduct_Name.IndexOf(param.Name) > -1)
                         && b.BaseInfoClass == classtype
                         select new MerchantScoreProductInfoResult
                         {
                             MerchantBaseInfo_Name = b.MerchantBaseInfo_Name,
                             IntegralProduct_ID = a.IntegralProduct_ID,
                             AddTime = a.AddTime,
                             OperationTime = a.OperationTime,
                             Merchant_ID = a.Merchant_ID,
                             Dictionary_ID = a.Dictionary_ID,
                             IntegralProduct_Name = a.IntegralProduct_Name,
                             IntegralProduct_Code = a.IntegralProduct_Code,
                             IntegralProduct_SpellCode = a.IntegralProduct_SpellCode,
                             IntegralProduct_Unit = a.IntegralProduct_Unit,
                             IntegralProduct_Price = a.IntegralProduct_Price,
                             IntegralProduct_BPic = a.IntegralProduct_BPic,
                             IntegralProduct_SPic = a.IntegralProduct_SPic,
                             IntegralProduct_Memo = a.IntegralProduct_Memo,
                             Operator = a.Operator
                         });
            if (!string.IsNullOrEmpty(param.SPrice.ToString()) && !string.IsNullOrEmpty(param.BPrice.ToString()))
            {
                query = query.Where(a => a.IntegralProduct_Price >= param.SPrice && a.IntegralProduct_Price < param.BPrice);
            }
            query = query.WhereIf(a => a.IntegralProduct_Price >= param.SPrice, !string.IsNullOrEmpty(param.SPrice.ToString()));
            query = query.WhereIf(a => a.IntegralProduct_Price <= param.BPrice, !string.IsNullOrEmpty(param.BPrice.ToString()));


            KeySelectors<MerchantScoreProductInfoResult, DefaultSortBy> _keySelectors =
            new KeySelectors<MerchantScoreProductInfoResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.IntegralProduct_ID);
            return QueryPaginate<MerchantScoreProductInfoResult, MerchantScoreProductInfoResult>(query, param, _keySelectors);
            #endregion

        }
        /// <summary>
        /// 将商家积分产品标记为删除
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Delete(OperationBaseRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            if (!string.IsNullOrEmpty(param.Record_ID))
            {
                param.Record_ID = string.Join(",", param.Record_ID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }
            var check = (from l in Entities.Bas_ShopIntegralProducts
                         where l.IntegralProduct_ID == param.Record_ID && l.Del != 1 && l.Shop_ID !=""
                         select l);
            if (check.FirstOrDefault() != null)
                throw new BusinessException(ResultCode.ProductComboUsed.Name());


            int row = Entities.Bas_IntegralProducts
                     .Where(t => param.Record_ID.Contains(t.IntegralProduct_ID))
                     .Update(t => new Bas_IntegralProducts { Del = 1 });
            if (row == 0)
                throw new BusinessException(ResultCode.OperationFaild.Name());
            return true;
        }
        /// <summary>
        /// 获得商家积分产品详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public MerchantScoreProductInfoResult GetInfo(RecordIDRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var info = (from a in Entities.Bas_IntegralProducts
                        join b in Entities.Bas_MerchantBaseInfo on a.Dictionary_ID equals b.MerchantBaseInfo_ID
                        where a.IntegralProduct_ID == param.Record_ID

                        select new MerchantScoreProductInfoResult
                        {
                            MerchantBaseInfo_Name = b.MerchantBaseInfo_Name,
                            IntegralProduct_ID = a.IntegralProduct_ID,
                            AddTime = a.AddTime,
                            OperationTime = a.OperationTime,
                            Merchant_ID = a.Merchant_ID,
                            Dictionary_ID = a.Dictionary_ID,
                            IntegralProduct_Name = a.IntegralProduct_Name,
                            IntegralProduct_Code = a.IntegralProduct_Code,
                            IntegralProduct_SpellCode = a.IntegralProduct_SpellCode,
                            IntegralProduct_Unit = a.IntegralProduct_Unit,
                            IntegralProduct_Price = a.IntegralProduct_Price,
                            IntegralProduct_BPic = a.IntegralProduct_BPic,
                            IntegralProduct_SPic = a.IntegralProduct_SPic,
                            IntegralProduct_Memo = a.IntegralProduct_Memo,
                            Operator = a.Operator
                        }).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());

            return info.MapTo<MerchantScoreProductInfoResult>();
        }
        public bool ExistsName(string merchantId, string id, string name)
        {
            var info = (from a in Entities.Bas_IntegralProducts where a.Merchant_ID == merchantId && a.IntegralProduct_ID != id && a.IntegralProduct_Name.Equals(name) select a).FirstOrDefault();
            return info != null;
        }
        public bool ExistsCode(string merchantId, string id, string code)
        {
            var info = (from a in Entities.Bas_IntegralProducts where a.Merchant_ID == merchantId && a.IntegralProduct_ID != id && a.IntegralProduct_Code.Equals(code) select a).FirstOrDefault();
            return info != null;
        }
        /// <summary>
        /// 新增商家积分产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Insert(AddOrUpdateMerchantScoreProduct param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            if (ExistsName(param.Merchant_ID, "", param.IntegralProduct_Name))
                throw new BusinessException(ResultCode.NameExisted.Name());
            if (ExistsCode(param.Merchant_ID, "", param.IntegralProduct_Code))
                throw new BusinessException(ResultCode.CodeExisted.Name());

            Bas_IntegralProducts model = param.MapTo<Bas_IntegralProducts>();
            model.IntegralProduct_ID = Inke.Common.Helpers.GUID.CreateGUID();
            model.AddTime = DateTime.Now;
            model.OperationTime = DateTime.Now;
            model.Del = 0;
            Entities.Bas_IntegralProducts.Add(model);
            if (Entities.SaveChanges() <= 0)
                throw new BusinessException(ResultCode.AddFaild.Name());
            return true;
        }

        /// <summary>
        /// 修改商家积分产品信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Update(AddOrUpdateMerchantScoreProduct param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            if (!Entities.Bas_IntegralProducts.Any(e => e.IntegralProduct_ID == param.IntegralProduct_ID))
                throw new BusinessException(ResultCode.DataNotFound.Name());
            if (ExistsName(param.Merchant_ID, param.IntegralProduct_ID, param.IntegralProduct_Name))
                throw new BusinessException(ResultCode.NameExisted.Name());
            if (ExistsCode(param.Merchant_ID, param.IntegralProduct_ID, param.IntegralProduct_Code))
                throw new BusinessException(ResultCode.CodeExisted.Name());

            Bas_IntegralProducts model = param.MapTo<Bas_IntegralProducts>();
            model.OperationTime = DateTime.Now;
            Entities.Entry(model).State = EntityState.Modified;
            Entities.Entry(model).Property(b => b.AddTime).IsModified = false;
            Entities.Entry(model).Property(b => b.Del).IsModified = false;
            if (Entities.SaveChanges() <= 0)
                throw new BusinessException(ResultCode.AddFaild.Name());

            return true;
        }
        /// <summary>
        /// 获取店铺尚未拥有的商家积分产品列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<MerchantScoreProductInfo> GetMerchantScoreProductByShopID(MerchantShopAndBaseInfo param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var list = (from a in Entities.Bas_IntegralProducts where a.Del != 1 && a.Merchant_ID == param.Merchant_ID select a);
            list = list.WhereIf(a => a.Dictionary_ID == param.MerchantBaseInfo_ID, param.MerchantBaseInfo_ID.NotNullOrEmpty());
            list = list.WhereIf(a => (from c in Entities.Bas_ShopIntegralProducts where c.Del != 1 && c.IntegralProduct_ID == a.IntegralProduct_ID && c.Shop_ID == param.Shop_ID select c).Count() == 0, param.Shop_ID.NotNullOrEmpty());
            return list.MapTo<MerchantScoreProductInfo>();
        }
    }
}
