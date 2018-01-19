using Inke.Common.Paginations;
using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Linq;
using Inke.Common.Extentions;
using Inke.Common.Exceptions;
using AutoMapper;
using System.Data.Entity;
using System.Collections.Generic;
using EntityFramework.Extensions;

namespace InkeServer.Service.Impl
{
    public class CardDiscountTypeService : ServiceBase, ICardDiscountTypeService
    {
        //标记为注入对象
        [InjectionConstructor]
        public CardDiscountTypeService() { }
        /// <summary>
        /// 分页查询 会员卡折扣类型集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<CardDiscountTypeInfo> Query(MerchantIdPageRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from a in Entities.Bas_CardDiscountType
                         where a.Del != 1
                         && a.Merchant_ID.Equals(param.Merchant_ID)
                         select a);

            KeySelectors<Bas_CardDiscountType, DefaultSortBy> _keySelectors =
            new KeySelectors<Bas_CardDiscountType, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.Discount_Name);

            return QueryPaginate<Bas_CardDiscountType, CardDiscountTypeInfo>(query, param, _keySelectors);
            #endregion
        }
        public bool Exists(string merchantId, string name, string id)
        {
            var info = (from a in Entities.Bas_CardDiscountType where a.Del != 1 && a.Merchant_ID == merchantId && a.Discount_Name.Equals(name) && !a.Discount_ID.Equals(id) select a).FirstOrDefault();
            return info != null;
        }
        /// <summary>
        /// 新增会员卡折扣类型
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Insert(CardDiscountTypeAddOrUpdate param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            if (Exists(param.Merchant_ID, param.Discount_Name, ""))
                throw new BusinessException(ResultCode.DataRepeated.Name());

            Bas_CardDiscountType model = param.MapTo<Bas_CardDiscountType>();
            model.Discount_ID = Inke.Common.Helpers.GUID.CreateGUID();
            model.AddTime = DateTime.Now;
            model.OperationTime = DateTime.Now;
            model.Del = 0;
            Entities.Bas_CardDiscountType.Add(model);
            if (Entities.SaveChanges() <= 0)
                throw new BusinessException(ResultCode.AddFaild.Name());


            return true;
        }

        /// <summary>
        /// 修改会员卡折扣类型信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Update(CardDiscountTypeAddOrUpdate param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            if (!Entities.Bas_CardDiscountType.Any(e => e.Discount_ID == param.Discount_ID))
                throw new BusinessException(ResultCode.DataNotFound.Name());
            if (Exists(param.Merchant_ID, param.Discount_Name, param.Discount_ID))
                throw new BusinessException(ResultCode.NameExisted.Name());
            Bas_CardDiscountType model = param.MapTo<Bas_CardDiscountType>();
            model.OperationTime = DateTime.Now;
            Entities.Entry(model).State = EntityState.Modified;
            Entities.Entry(model).Property(b => b.AddTime).IsModified = false;
            Entities.Entry(model).Property(b => b.Del).IsModified = false;
            if (Entities.SaveChanges() <= 0)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            return true;
        }
        /// <summary>
        /// 将会员卡折扣类型标记为删除
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
            int row = Entities.Bas_CardDiscountType
                     .Where(t => param.Record_ID.Contains(t.Discount_ID))
                     .Update(t => new Bas_CardDiscountType { Del = 1 });
            if (row == 0)
                throw new BusinessException(ResultCode.OperationFaild.Name());
            return true;
        }
        /// <summary>
        /// 获取会员卡折扣类型详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>  
        public CardDiscountTypeInfo GetInfo(RecordIDRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var info = (from a in Entities.Bas_CardDiscountType
                        where a.Discount_ID == param.Record_ID
                        select a).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            return info.MapTo<CardDiscountTypeInfo>();
        }
        /// <summary>
        /// 获取会员卡折扣类型列表集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>  
        public List<CardDiscountTypeInfo> GetList(MerchantIdRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var info = (from a in Entities.Bas_CardDiscountType
                        where a.Del != 1
                        && a.Merchant_ID == param.Merchant_ID
                        select a);
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            return info.MapTo<CardDiscountTypeInfo>();
        }
    }
}
