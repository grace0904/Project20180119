using Inke.Common.Paginations;
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
using EntityFramework.Extensions;
using System.Transactions;
using Inke.Common.Exceptions;
using System.Data.Entity;
using Inke.Common.Helpers;

namespace InkeServer.Service.Impl
{
    public class AccountService : ServiceBase, IAccountService
    {
        //标记为注入对象
        [InjectionConstructor]
        public AccountService() { }
        /// <summary>
        /// 分页查询 账号集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<AccountInfoResult> Query(AccountQueryRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from a in Entities.Bas_Account
                         join p in Entities.Bas_MerchantPosition on a.Position_ID equals p.Position_ID into pj
                         from pos in pj.DefaultIfEmpty()
                         join s in Entities.Bas_Shop on a.Shop_ID equals s.Shop_ID into pjs
                         from poss in pjs.DefaultIfEmpty()
                         join e in Entities.Bas_ShopEmployee on a.Employee_ID equals e.Employee_ID into pjse
                         from posse in pjse.DefaultIfEmpty()
                         where a.Del != 1
                         && a.Merchant_ID.Equals(param.Merchant_ID)
                         && (string.IsNullOrEmpty(param.Shop_ID) || a.Shop_ID.Equals(param.Shop_ID))
                         && (string.IsNullOrEmpty(param.Position_ID) || a.Position_ID.Equals(param.Position_ID))
                         select new AccountInfoResult
                         {
                             Shop_Name = poss == null ? "" : (poss.Shop_Name == null ? "" : poss.Shop_Name),
                             Position_Name = pos == null ? "" : (pos.Position_Name == null ? "" : pos.Position_Name),
                             Employee_Name = posse == null ? "" : (posse.Employee_Name == null ? "" : posse.Employee_Name),
                             AddTime = a.AddTime,
                             Account_ID = a.Account_ID,
                             Account_Login = a.Account_Login,
                             Account_Memo = a.Account_Memo,
                             Account_Status = a.Account_Status,
                             Account_LoginPOS = a.Account_LoginPOS,
                             Account_LoginKFT = a.Account_LoginKFT,
                             Account_LoginCRM = a.Account_LoginCRM,
                             Employee_ID = a.Employee_ID,
                             Position_ID = a.Position_ID,
                             Merchant_ID = a.Merchant_ID,
                             OperationTime = a.OperationTime,
                             Operator = a.Operator,
                             Shop_ID = a.Shop_ID,
                             Del = a.Del
                         });

            //若查询所有员工账号 根据当前登录账号获得所有店铺 排除无权限的员工账号
            #region 根据账号获得店铺 排除无权限的店铺员工
            if (string.IsNullOrEmpty(param.Shop_ID))
            {
                List<ShopIdAndName> shopList = GetUserShoplist(param.Merchant_ID, param.LoginAccount_ID);
                string shopIds = shopList.Count == 0 ? "" : string.Join(",", shopList.Select(s => s.Shop_ID).Distinct().ToArray());
                query = query.Where(
                   e => !string.IsNullOrEmpty(shopIds) && shopIds.Contains(e.Shop_ID));
            }
            #endregion

            KeySelectors<AccountInfoResult, DefaultSortBy> _keySelectors =
            new KeySelectors<AccountInfoResult, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.Employee_Name);
            return QueryPaginate<AccountInfoResult, AccountInfoResult>(query, param, _keySelectors);
            #endregion

        }
        /// <summary>
        /// 得到可用店铺
        /// </summary>
        /// <returns></returns>
        private List<ShopIdAndName> GetUserShoplist(string merchantId, string loginAccount_ID)
        {
            List<ShopIdAndName> shopList = new List<ShopIdAndName>();
            var acount = (from a in Entities.Bas_Account where a.Account_ID.Equals(loginAccount_ID) && a.Del != 1 select a).FirstOrDefault();
            if (acount != null)
            {
                var position = (from l in Entities.Bas_MerchantPosition
                                where l.Position_ID == acount.Position_ID && l.Del != 1
                                select l.Position_Name).FirstOrDefault();

                if (position != null && position == "超级管理员")
                {
                    shopList = (from l in Entities.Bas_Shop
                                where l.Merchant_ID == merchantId && l.Shop_Status == 1 && l.Del != 1
                                select l).MapTo<ShopIdAndName>();
                    return shopList;
                }
            }
            int usableClass = (int)UsableClass.Account;

            shopList = (from l in Entities.Bas_Shop
                        where l.Del != 1 && ((from k in Entities.Bas_Account
                                              where k.Account_ID == loginAccount_ID && k.Account_Status == 1 && k.Del != 1
                                              select k.Shop_ID).Union(from c in Entities.Bas_UsableShop
                                                                      where c.Status == 1 && c.Record_ID == loginAccount_ID && c.UsableClass == usableClass
                                                                      select c.Shop_ID)).Contains(l.Shop_ID)
                        select l).MapTo<ShopIdAndName>();
            return shopList;
        }
        /// <summary>
        /// 将员工账号标记为删除
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
            if (!string.IsNullOrEmpty(param.Record_ID))
            {
                using (var scope = new TransactionScope())
                {
                    int type = (int)InkeServer.Enums.UsableClass.Account;
                    Entities.Bas_UsableShop
               .Where(t => param.Record_ID.Contains(t.Record_ID) && t.UsableClass == type)
               .Delete();
                    int row = Entities.Bas_Account
                 .Where(t => param.Record_ID.Contains(t.Account_ID))
                 .Update(t => new Bas_Account { Del = 1, Operator = param.Operator });

                    if (row == 0)
                        throw new BusinessException(ResultCode.DeleteFaild.Name());
                    scope.Complete();
                }
            }
            return true;
        }
        /// <summary>
        /// 获得员工账号详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public AccountInfoResult GetInfo(RecordIDRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var info = (from a in Entities.Bas_Account
                        join p in Entities.Bas_MerchantPosition on a.Position_ID equals p.Position_ID into pj
                        from pos in pj.DefaultIfEmpty()
                        join s in Entities.Bas_Shop on a.Shop_ID equals s.Shop_ID into pjs
                        from poss in pjs.DefaultIfEmpty()
                        join e in Entities.Bas_ShopEmployee on a.Employee_ID equals e.Employee_ID into pjse
                        from posse in pjse.DefaultIfEmpty()
                        where a.Account_ID.Equals(param.Record_ID)
                        select new AccountInfoResult
                        {
                            Shop_Name = poss == null ? "" : (poss.Shop_Name == null ? "" : poss.Shop_Name),
                            Position_Name = pos == null ? "" : (pos.Position_Name == null ? "" : pos.Position_Name),
                            Employee_Name = posse == null ? "" : (posse.Employee_Name == null ? "" : posse.Employee_Name),
                            AddTime = a.AddTime,
                            Account_ID = a.Account_ID,
                            Account_Login = a.Account_Login,
                            Account_Memo = a.Account_Memo,
                            Account_Status = a.Account_Status,
                            Account_LoginPOS = a.Account_LoginPOS,
                            Account_LoginKFT = a.Account_LoginKFT,
                            Account_LoginCRM = a.Account_LoginCRM,
                            Account_LoginINPOS = a.Account_LoginINPOS,
                            Employee_ID = a.Employee_ID,
                            Position_ID = a.Position_ID,
                            Merchant_ID = a.Merchant_ID,
                            OperationTime = a.OperationTime,
                            Operator = a.Operator,
                            Shop_ID = a.Shop_ID,
                            Del = a.Del
                        }).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            int type = (int)InkeServer.Enums.UsableClass.Account;
            var usershopIdlist = (from us in Entities.Bas_UsableShop
                                  join s in Entities.Bas_Shop on us.Shop_ID equals s.Shop_ID
                                  where us.Status == 1 && us.Record_ID == param.Record_ID && us.UsableClass == type
                                  select s.Shop_ID);
            info.UsableShopList = string.Join(",", usershopIdlist.ToArray());
            return info.MapTo<AccountInfoResult>();
        }
        /// <summary>
        /// 是否存在该记录
        /// 该方法用于添加和修改账号时，不允许同一商家有多个相同的Login_Name
        /// </summary>
        public bool Exists(string accountLogin, string merchantId, string accountId)
        {
            var one = (from a in Entities.Bas_Account where a.Account_ID != accountId && a.Merchant_ID == merchantId && a.Del != 1 && a.Account_Login == accountLogin select a).FirstOrDefault();
            return one != null;
        }
        /// <summary>
        /// 新增员工账号
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Insert(AddOrUpdateAccountRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                if (Exists(param.Account_Login, param.Merchant_ID, ""))
                    throw new BusinessException(ResultCode.DataRepeated.Name());
                Bas_Account model = param.MapTo<Bas_Account>();
                model.Account_ID = Inke.Common.Helpers.GUID.CreateGUID();
                model.AddTime = DateTime.Now;
                model.OperationTime = DateTime.Now;
                model.Del = 0;
                // 加密密码
                model.Account_Password = MD5er.Encrypt(param.Account_Password.ToString().ToLower());
                Entities.Bas_Account.Add(model);


                //添加相关记录表  model.UsableShopList
                if (!string.IsNullOrEmpty(param.UsableShopList))
                {
                    string[] items = param.UsableShopList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    IList<Bas_UsableShop> shoplist = new List<Bas_UsableShop>();
                    foreach (string shopId in items)
                    {
                        Bas_UsableShop temp = new Bas_UsableShop();
                        temp.UsableShop_ID = Inke.Common.Helpers.GUID.CreateGUID();
                        temp.UsableClass = (int)InkeServer.Enums.UsableClass.Account;
                        temp.Record_ID = model.Account_ID;
                        temp.Merchant_ID = model.Merchant_ID;
                        temp.Shop_ID = shopId;
                        temp.Status = 1;
                        temp.Memo = "账号关联的店铺";
                        shoplist.Add(temp);
                    }
                    if (shoplist.Count > 0)
                    {
                        Entities.Bas_UsableShop.AddRange(shoplist);
                    }
                }
                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.AddFaild.Name());
                scope.Complete();
            }

            return true;
        }

        /// <summary>
        /// 修改员工账号信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Update(AddOrUpdateAccountRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                var model = Entities.Bas_Account.SingleOrDefault(t => t.Account_ID == param.Account_ID);
                if (model == null)
                    throw new BusinessException(ResultCode.DataNotFound.Name());
                if (Exists(param.Account_Login, param.Merchant_ID, param.Account_ID))
                    throw new BusinessException(ResultCode.DataRepeated.Name());
                model.Account_Login = param.Account_Login;
                model.Account_LoginCRM = param.Account_LoginCRM;
                model.Account_LoginKFT = param.Account_LoginKFT;
                model.Account_LoginPOS = param.Account_LoginPOS;
                model.Account_LoginINPOS = param.Account_LoginINPOS;
                model.Account_Memo = param.Account_Memo;
                model.Account_Status = param.Account_Status;
                model.Employee_ID = param.Employee_ID;
                model.Merchant_ID = param.Merchant_ID;
                model.Operator = param.Operator;
                model.OperationTime = DateTime.Now;
                model.Position_ID = param.Position_ID;
                model.Shop_ID = param.Shop_ID;
                if (!string.IsNullOrEmpty(param.Account_Password))
                {
                    // 加密密码
                    model.Account_Password = MD5er.Encrypt(param.Account_Password.ToLower());
                }

                //更新usabtable表记录
                //先删除相关记录表   model.Account_ID,model.Merchant_ID,usableClass
                int type = (int)InkeServer.Enums.UsableClass.Account;
                Entities.Bas_UsableShop
                    .Where(t => t.Merchant_ID == param.Merchant_ID && t.Record_ID == model.Account_ID && t.UsableClass == type)
                    .Delete();

                //再添加相关记录表  model.UsableShopList
                if (!string.IsNullOrEmpty(param.UsableShopList))
                {
                    string[] items = param.UsableShopList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    IList<Bas_UsableShop> shoplist = new List<Bas_UsableShop>();
                    foreach (string shopId in items)
                    {
                        Bas_UsableShop temp = new Bas_UsableShop();
                        temp.UsableShop_ID = Inke.Common.Helpers.GUID.CreateGUID();
                        temp.UsableClass = (int)InkeServer.Enums.UsableClass.Account;
                        temp.Record_ID = model.Account_ID;
                        temp.Merchant_ID = model.Merchant_ID;
                        temp.Shop_ID = shopId;
                        temp.Status = 1;
                        temp.Memo = "账号关联的店铺";
                        shoplist.Add(temp);
                    }
                    if (shoplist.Count > 0)
                    {
                        Entities.Bas_UsableShop.AddRange(shoplist);
                    }
                }
                if (Entities.SaveChanges() <= 0)
                    throw new BusinessException(ResultCode.UpdateFaild.Name());

                scope.Complete();
            }

            return true;
        }
    }
}
