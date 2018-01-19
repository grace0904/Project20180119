using AutoMapper;
using Inke.Common.Exceptions;
using Inke.Common.Extentions;
using Inke.Common.Paginations;
using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using EntityFramework.Extensions;

namespace InkeServer.Service.Impl
{
    /// <summary>
    /// 商家职位服务类 
    /// </summary>
    public class PositionService : ServiceBase, IPositionService
    {
        //标记为注入对象
        [InjectionConstructor]
        public PositionService() { }
        public bool Exits(string merchantId, string name, string id)
        {
            var info = (from p in Entities.Bas_MerchantPosition where p.Merchant_ID == merchantId && p.Position_Name == name && p.Position_ID != id && p.Del!=1 select p).FirstOrDefault();
            return info != null;
        }
        /// <summary>
        /// 新增商家职位
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Insert(PositionAddOrUpdateRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                if (Exits(param.Merchant_ID, param.Position_Name, ""))
                    throw new BusinessException(ResultCode.NameExisted.Name());
                Bas_MerchantPosition model = param.MapTo<Bas_MerchantPosition>();
                model.Position_ID = Inke.Common.Helpers.GUID.CreateGUID();
                model.AddTime = DateTime.Now;
                model.OperationTime = DateTime.Now;
                model.Del = 0;
                model.Position_Parent = param.Position_Parent == null ? "" : param.Position_Parent;
                model.Shop_ID = param.Shop_ID == null ? "" : param.Shop_ID;
                Entities.Bas_MerchantPosition.Add(model);
               

                Bas_ShopPositionPower power = new Bas_ShopPositionPower();
                power.Position_ID = model.Position_ID;
                power.Merchant_ID = model.Merchant_ID;
                power.PowerString = param.PowerString;
                power.ShopPostitionPowerID = Inke.Common.Helpers.GUID.CreateGUID();
                power.Status = 1;
                Entities.Bas_ShopPositionPower.Add(power);
                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.AddFaild.Name());
                //提交事务
                scope.Complete();
            }

            return true;
        }

        /// <summary>
        /// 修改商家职位信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Update(PositionAddOrUpdateRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            using (var scope = new TransactionScope())
            {
                if (!Entities.Bas_MerchantPosition.Any(e => e.Position_ID == param.Position_ID))
                    throw new BusinessException(ResultCode.DataNotFound.Name());
                if (Exits(param.Merchant_ID, param.Position_Name, param.Position_ID))
                    throw new BusinessException(ResultCode.NameExisted.Name());
                Bas_MerchantPosition model = param.MapTo<Bas_MerchantPosition>();
                model.OperationTime = DateTime.Now;
                Entities.Entry(model).State = EntityState.Modified;
                Entities.Entry(model).Property(b => b.AddTime).IsModified = false;
                Entities.Entry(model).Property(b => b.Del).IsModified = false;
                
                Entities.Bas_ShopPositionPower
                   .Where(t => t.Position_ID == param.Position_ID && t.Merchant_ID == param.Merchant_ID)
                   .Update(t => new Bas_ShopPositionPower { PowerString = param.PowerString, Status = 1 });

                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.UpdateFaild.Name());
                //提交事务
                scope.Complete();
            }

            return true;
        }

        /// <summary>
        /// 删除商家职位
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
            var row = Entities.Bas_MerchantPosition
                 .Where(t => param.Record_ID.Contains(t.Position_ID))
                 .Update(t => new Bas_MerchantPosition { Del = 1, Operator = param.Operator });
            if (row == 0)
                throw new BusinessException(ResultCode.OperationFaild.Name());

            return true;
        }
        /// <summary>
        /// 分页查询商家职位
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<MerchantPositionInfo> Query(MerchantIdPageRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from p in Entities.Bas_MerchantPosition
                         where p.Del != 1
                         && p.Merchant_ID == (param.Merchant_ID)
                         select p);
            query.ForEach(e => e.OptionTimestamp = null);

            //检查排序
            //if (param.OrderField.IsNullOrEmpty())
            //    param.OrderField = "Position_Name";
            //else
            //{
            //    //利用反射来判断对象是否包含排序属性
            //    System.Reflection.PropertyInfo _findedPropertyInfo = (new Bas_MerchantPosition()).GetType().GetProperty(param.OrderField);
            //    if (_findedPropertyInfo == null)
            //    {
            //        param.OrderField = "Position_Name";
            //        //throw new BusinessException(ResultCode.SortColumnNotFound.Name());
            //    }
            //}
            KeySelectors<Bas_MerchantPosition, DefaultSortBy> _keySelectors =
          new KeySelectors<Bas_MerchantPosition, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.Position_Name);
            return QueryPaginate<Bas_MerchantPosition, MerchantPositionInfo>(query, param, _keySelectors);
            #endregion
        }
        /// <summary>
        /// 获取商家职位列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IList<MerchantPositionInfo> GetList(MerchantIdRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var list = (from p in Entities.Bas_MerchantPosition
                        where p.Del != 1
                        && p.Merchant_ID == (param.Merchant_ID)
                        select p).ToList();
            list.ForEach(e => e.OptionTimestamp = null);
            return list.MapTo<MerchantPositionInfo>(); ;
        }
        /// <summary>
        /// 获取 职位详细信息 包括（职位菜单权限）
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ShopPositionPowerInfoResult GetPositionPowerInfo(RecordIDRequest param)
        {
            var info = (from c in Entities.Bas_ShopPositionPower 
                        join p in Entities.Bas_MerchantPosition on c.Position_ID equals p.Position_ID
                        where c.Position_ID == param.Record_ID
                        select new ShopPositionPowerInfoResult
                        {
                            Merchant_ID=p.Merchant_ID,
                            Position_ID=p.Position_ID,
                            Position_Name=p.Position_Name,
                            PowerString=c.PowerString,
                            ShopPostitionPowerID=c.ShopPostitionPowerID,
                            Status=c.Status
                        }
                        ).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            return info;
        }

        /// <summary>
        /// 查询商家对应的所有菜单权限
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<SysPositionPower> GetAllSysPowerList(MerchantIdRequest param)
        {
            var info = (from c in Entities.Sys_Power
                        where (from l in Entities.Sys_MerchantModule
                               where l.Merchant_ID == param.Merchant_ID
                               select l.Module_Code).Contains(c.Power_Code)
                        select c);
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            return info.ToList().MapTo<SysPositionPower>();
        }
    }
}
