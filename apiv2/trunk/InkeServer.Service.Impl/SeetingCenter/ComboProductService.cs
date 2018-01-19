using Inke.Common.Exceptions;
using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inke.Common.Extentions;
using AutoMapper;
using System.Data.Entity;
using EntityFramework.Extensions;
using Inke.Common.Paginations;

namespace InkeServer.Service.Impl
{
    public class ComboProductService : ServiceBase, IComboProductService
    {
        //标记为注入对象
        [InjectionConstructor]
        public ComboProductService() { }
        /// <summary>
        /// 获取指定套餐组下的套餐产品列表
        /// </summary>
        /// <param name="merchantId">商家ID</param>
        /// <param name="comboGroupId">套餐组ID</param>
        /// <returns></returns>
        public List<GetComboProductQueryResult> GetListByComboGroupID(GetComboProductListRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var list = (from a in Entities.Bas_ComboProduct
                        join p in Entities.Bas_MerchantProducts on a.Product_ID equals p.Product_ID
                        where a.ComboGroup_ID == param.ComboGroup_ID && a.Merchant_ID == param.Merchant_ID
                        select new GetComboProductQueryResult
                        {
                            Product_Name = p.Product_Name,
                            Product_Unit = p.Product_Unit,
                            MerchantBaseInfo_ID = p.MerchantBaseInfo_ID,
                            ComboProduct_ID = a.ComboProduct_ID,
                            ComboGroup_ID = a.ComboGroup_ID,
                            Product_ID = a.Product_ID,
                            OptionalNum = a.OptionalNum,
                            InfluencePrice = a.InfluencePrice,
                            IsRequired = a.IsRequired,
                            IsSelected = a.IsSelected,
                            Merchant_ID = a.Merchant_ID
                        });
            return list.ToList();
        }

        public IPaginationResult<GetComboProductQueryResult> GetListByComboGroupIDPage(GetComboProductPageRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var list = (from a in Entities.Bas_ComboProduct
                        join p in Entities.Bas_MerchantProducts on a.Product_ID equals p.Product_ID
                        where  a.Merchant_ID == param.Merchant_ID
                        select new GetComboProductQueryResult
                        {
                            Product_Name = p.Product_Name,
                            Product_Unit = p.Product_Unit,
                            MerchantBaseInfo_ID = p.MerchantBaseInfo_ID,
                            ComboProduct_ID = a.ComboProduct_ID,
                            ComboGroup_ID = a.ComboGroup_ID,
                            Product_ID = a.Product_ID,
                            OptionalNum = a.OptionalNum,
                            InfluencePrice = a.InfluencePrice,
                            IsRequired = a.IsRequired,
                            IsSelected = a.IsSelected,
                            Merchant_ID = a.Merchant_ID
                        });
            
            if (param.ComboGroup_ID.NotNullOrEmpty())
            {
                list = list.Where(t => t.ComboGroup_ID == param.ComboGroup_ID);
            }
            else
            {
                //若无组别 查询全部
                list = list.Where(t => (from g in Entities.Bas_ComboGroup where g.Merchant_ID == param.Merchant_ID && g.Del != 1 select g.ComboGroup_ID).Contains(t.ComboGroup_ID));
            }
         
            KeySelectors<GetComboProductQueryResult, DefaultSortBy> _keySelectors =
             new KeySelectors<GetComboProductQueryResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.Product_Name);
            return QueryPaginate<GetComboProductQueryResult, GetComboProductQueryResult>(list, param, _keySelectors);
        }

        /// <summary>
        /// 获取套餐组产品详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ComboGroupProductInfoResult GetInfo(ComboGroupProductInfoRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var info = (from a in Entities.Bas_ComboProduct
                        join p in Entities.Bas_MerchantProducts on a.Product_ID equals p.Product_ID
                        join g1 in Entities.Bas_ComboGroup on a.ComboGroup_ID equals g1.ComboGroup_ID into g2
                        from g in g2.DefaultIfEmpty()
                        where a.ComboProduct_ID == param.ComboProduct_ID && a.Merchant_ID == param.Merchant_ID
                        select new ComboGroupProductInfoResult
                        {
                            Product_Name = p.Product_Name,
                            Product_Unit = p.Product_Unit,
                            MerchantBaseInfo_ID = p.MerchantBaseInfo_ID,
                            ComboProduct_ID = a.ComboProduct_ID,
                            ComboGroup_ID = a.ComboGroup_ID,
                            Product_ID = a.Product_ID,
                            OptionalNum = a.OptionalNum,
                            InfluencePrice = a.InfluencePrice,
                            IsRequired = a.IsRequired,
                            IsSelected = a.IsSelected,
                            Merchant_ID = a.Merchant_ID,
                            ComboGroup_Name = g == null ? "" : g.Group_Name,
                            ComboGroup_MaxNum = g == null ? 0 : g.MaxNum,
                            ComboGroup_MinNum = g == null ? 0 : g.MinNum
                        }).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            return info;
        }
        public bool Exists(Bas_ComboProduct model)
        {
            //判断套餐中是否已存在此产品
            var info = (from a in Entities.Bas_ComboProduct where a.Merchant_ID == model.Merchant_ID && a.ComboGroup_ID == model.ComboGroup_ID && a.ComboProduct_ID != model.ComboProduct_ID && a.Product_ID == model.Product_ID select a).FirstOrDefault();
            //判断是否大于套餐最大数量
            return info != null;
        }
        /// <summary>
        /// 新增套餐产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Insert(AddOrUpdateComboProduct param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            Bas_ComboProduct model = param.MapTo<Bas_ComboProduct>();
            if (Exists(model))
                throw new BusinessException(ResultCode.ProductExistedOrNumExceeded.Name());
            model.ComboProduct_ID = Inke.Common.Helpers.GUID.CreateGUID();
            Entities.Bas_ComboProduct.Add(model);
            if (Entities.SaveChanges() <= 0)
                throw new BusinessException(ResultCode.AddFaild.Name());
            return true;
        }

        /// <summary>
        /// 修改套餐产品信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Update(AddOrUpdateComboProduct param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            if (!Entities.Bas_ComboProduct.Any(e => e.ComboProduct_ID == param.ComboProduct_ID))
                throw new BusinessException(ResultCode.DataNotFound.Name());
            Bas_ComboProduct model = param.MapTo<Bas_ComboProduct>();
            if (Exists(model))
                throw new BusinessException(ResultCode.ProductExistedOrNumExceeded.Name());
            Entities.Entry(model).State = EntityState.Modified;
            Entities.Entry(model).Property(b => b.ComboGroup_ID).IsModified = false;
            if (Entities.SaveChanges() <= 0)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            return true;
        }
        /// <summary>
        /// 彻底删除套餐产品
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
            int row = Entities.Bas_ComboProduct
                     .Where(t => param.Record_ID.Contains(t.ComboProduct_ID))
                     .Delete();
            if (row == 0)
                throw new BusinessException(ResultCode.OperationFaild.Name());
            return true;
        }
    }
}
