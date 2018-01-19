using Inke.Common.Paginations;
using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using Microsoft.Practices.Unity;
using System;
using Inke.Common.Extentions;
using AutoMapper;
using Inke.Common.Exceptions;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using EntityFramework.Extensions;

namespace InkeServer.Service.Impl
{
    /// <summary>
    /// 店铺员工服务类
    /// </summary>
    public class EmployeeService : ServiceBase, IEmployeeService
    {
        //标记为注入对象
        [InjectionConstructor]
        public EmployeeService() { }
        /// <summary>
        /// 新增店铺员工
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Insert(EmployeeAddOrUpdateRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            if (ExistsByCode("", param.Employee_Code, param.Merchant_ID))
                throw new BusinessException(ResultCode.DataRepeated.Name());
            Bas_ShopEmployee model = param.MapTo<Bas_ShopEmployee>();
            model.Employee_ID = Inke.Common.Helpers.GUID.CreateGUID();
            model.AddTime = DateTime.Now;
            model.OperationTime = DateTime.Now;
            model.Del = 0;
            Entities.Bas_ShopEmployee.Add(model);
            if (Entities.SaveChanges() <= 0)
                throw new BusinessException(ResultCode.AddFaild.Name());
            return true;
        }

        /// <summary>
        /// 修改店铺员工信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Update(EmployeeAddOrUpdateRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            if (!Entities.Bas_ShopEmployee.Any(e => e.Employee_ID == param.Employee_ID))
                throw new BusinessException(ResultCode.DataNotFound.Name());
            if (ExistsByCode(param.Employee_ID, param.Employee_Code, param.Merchant_ID))
                throw new BusinessException(ResultCode.DataRepeated.Name());

            Bas_ShopEmployee model = param.MapTo<Bas_ShopEmployee>();
            model.OperationTime = DateTime.Now;

            Entities.Entry(model).State = EntityState.Modified;
            //设置不需要更新的属性 主键除外
            Entities.Entry(model).Property(b => b.AddTime).IsModified = false;
            Entities.Entry(model).Property(b => b.Del).IsModified = false;
            if (Entities.SaveChanges() == 0)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            return true;
        }

        /// <summary>
        /// 将员工标记为删除
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
            int rows = Entities.Bas_ShopEmployee
                 .Where(t => param.Record_ID.Contains(t.Employee_ID))
                 .Update(t => new Bas_ShopEmployee { Del = 1, Operator = param.Operator });
            if (rows == 0)
                throw new BusinessException(ResultCode.OperationFaild.Name());
            return true;
        }
        /// <summary>
        /// 获取店铺员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmploeeQueryResult GetInfo(RecordIDRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var info = (from e in Entities.Bas_ShopEmployee
                        join s in Entities.Bas_Shop on e.Shop_ID equals s.Shop_ID
                        join p in Entities.Bas_MerchantPosition on e.Position_ID equals p.Position_ID into pj
                        from pos in pj.DefaultIfEmpty()
                        where e.Employee_ID.Equals(param.Record_ID)
                        select new EmploeeQueryResult
                        {
                            Shop_Name = s.Shop_Name,
                            Position_Name = pos == null ? "" : (pos.Position_Name == null ? "" : pos.Position_Name),
                            AddTime = e.AddTime,
                            Employee_Address = e.Employee_Address,
                            Employee_birthday = e.Employee_birthday,
                            Employee_Code = e.Employee_Code,
                            Employee_ID = e.Employee_ID,
                            Employee_Lead_ID = e.Employee_Lead_ID,
                            Employee_Name = e.Employee_Name,
                            Employee_Pic = e.Employee_Pic,
                            Employee_Salary = e.Employee_Salary,
                            Employee_Sex = e.Employee_Sex,
                            Employee_Tel = e.Employee_Tel,
                            Memo = e.Memo,
                            Merchant_ID = e.Merchant_ID,
                            OperationTime = e.OperationTime,
                            Operator = e.Operator,
                            Position_ID = e.Position_ID,
                            Shop_ID = e.Shop_ID

                        }).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            return info.MapTo<EmploeeQueryResult>();

        }
        /// <summary>
        /// 分页查询店铺员工
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<EmploeeQueryResult> Query(EmploeeQueryRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from e in Entities.Bas_ShopEmployee
                         join s in Entities.Bas_Shop on e.Shop_ID equals s.Shop_ID
                         join p in Entities.Bas_MerchantPosition on e.Position_ID equals p.Position_ID into pj
                         from pos in pj.DefaultIfEmpty()
                         where e.Del != 1
                         && e.Merchant_ID.Equals(param.Merchant_ID)
                         && (string.IsNullOrEmpty(param.Shop_ID) || e.Shop_ID.Equals(param.Shop_ID))
                         && (string.IsNullOrEmpty(param.Employee_Code) || e.Employee_Code.Equals(param.Employee_Code))
                         && (string.IsNullOrEmpty(param.Employee_Name) || e.Employee_Name.IndexOf(param.Employee_Name)>-1)
                           && (string.IsNullOrEmpty(param.Employee_Tel) || e.Employee_Tel.Equals(param.Employee_Tel))
                         select new EmploeeQueryResult
                         {
                             Shop_Name = s.Shop_Name,
                             Position_Name = pos == null ? "" : (pos.Position_Name == null ? "" : pos.Position_Name),
                             //EmployeeInfo = e.MapTo<EmployeeInfo>()
                             AddTime = e.AddTime,
                             Employee_Address = e.Employee_Address,
                             Employee_birthday = e.Employee_birthday,
                             Employee_Code = e.Employee_Code,
                             Employee_ID = e.Employee_ID,
                             Employee_Lead_ID = e.Employee_Lead_ID,
                             Employee_Name = e.Employee_Name,
                             Employee_Pic = e.Employee_Pic,
                             Employee_Salary = e.Employee_Salary,
                             Employee_Sex = e.Employee_Sex,
                             Employee_Tel = e.Employee_Tel,
                             Memo = e.Memo,
                             Merchant_ID = e.Merchant_ID,
                             OperationTime = e.OperationTime,
                             Operator = e.Operator,
                             Position_ID = e.Position_ID,
                             Shop_ID = e.Shop_ID
                         });

            //若查询所有店铺员工 根据账号获得所有店铺 排除无权限的店铺员工
            #region 根据账号获得店铺 排除无权限的店铺员工
            if (string.IsNullOrEmpty(param.Shop_ID))
            {
                List<ShopIdAndName> shopList = new List<ShopIdAndName>();
                var acount = (from a in Entities.Bas_Account where a.Account_ID.Equals(param.Account_ID) && a.Del != 1 select a).FirstOrDefault();
                if (acount != null)
                {
                    var position = (from l in Entities.Bas_MerchantPosition
                                    where l.Position_ID == acount.Position_ID && l.Del != 1
                                    select l.Position_Name).FirstOrDefault();

                    if (position != null && position == "超级管理员")
                    {
                        shopList = (from l in Entities.Bas_Shop
                                    where l.Merchant_ID == param.Merchant_ID && l.Shop_Status == 1 && l.Del != 1
                                    select l).MapTo<ShopIdAndName>();
                    }
                    else
                    {
                        int usableClass = (int)UsableClass.Account;

                        shopList = (from l in Entities.Bas_Shop
                                    where l.Del != 1 && ((from k in Entities.Bas_Account
                                                          where k.Account_ID == param.Account_ID && k.Account_Status == 1 && k.Del != 1
                                                          select k.Shop_ID).Union(from c in Entities.Bas_UsableShop
                                                                                  where c.Status == 1 && c.Record_ID == param.Account_ID && c.UsableClass == usableClass
                                                                                  select c.Shop_ID)).Contains(l.Shop_ID)
                                    select l).MapTo<ShopIdAndName>();
                    }
                }
                string shopIds = shopList.Count == 0 ? "" : string.Join(",", shopList.Select(s => s.Shop_ID).Distinct().ToArray());
                query = query.Where(
                   e => !string.IsNullOrEmpty(shopIds) && shopIds.Contains(e.Shop_ID));
            }
            #endregion


            //检查排序(无效)
            //if (param.OrderField.IsNullOrEmpty())
            //    param.OrderField = "Employee_Name";

            KeySelectors<EmploeeQueryResult, DefaultSortBy> _keySelectors =
            new KeySelectors<EmploeeQueryResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.Employee_Name);
            return QueryPaginate<EmploeeQueryResult, EmploeeQueryResult>(query, param, _keySelectors);
            #endregion

        }
        /// <summary>
        ///判断是否已存在员工记录
        /// </summary>
        /// <param name="id"></param>
        ///  <param name="code"></param>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        public bool ExistsByCode(string id, string code, string merchantId)
        {
            var record = (from e in Entities.Bas_ShopEmployee where !e.Employee_ID.Equals(id) && e.Employee_Code.Equals(code) && e.Merchant_ID.Equals(merchantId) select e).FirstOrDefault();
            return record != null;
        }
        /// <summary>
        /// 获取店铺员工列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IList<EmployeeInfo> GetListByShopId(MerchantAndShopIdRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var list = (from e in Entities.Bas_ShopEmployee where e.Merchant_ID.Equals(param.Merchant_ID) && e.Shop_ID.Equals(param.Shop_ID) && e.Del!=1 select e);
            list.ForEach(e => e.OptionTimestamp = null);//OptionTimestamp附为空值 方便转换

            return list.MapTo<EmployeeInfo>();
        }
        /// <summary>
        /// 取得指定店铺所有未绑定账号的员工列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IList<EmployeeIDAndName> GetShopEmployeeListNoHasAccountID(MerchantAndShopIdRequest param)
        {
            var list = (from e in Entities.Bas_ShopEmployee
                        where e.Merchant_ID == param.Merchant_ID && e.Shop_ID == param.Shop_ID
                            && e.Del != 1 &&
                            (from a in Entities.Bas_Account where a.Del != 1 && a.Employee_ID == e.Employee_ID select a).Count() == 0
                        select new EmployeeIDAndName { Employee_ID = e.Employee_ID, Employee_Name = e.Employee_Name });
            return list.MapTo<EmployeeIDAndName>();
        }
    }
}
