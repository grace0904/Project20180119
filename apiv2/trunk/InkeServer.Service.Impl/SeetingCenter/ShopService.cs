using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using AutoMapper;
using Inke.Common.Exceptions;
using Inke.Common.Extentions;
using Inke.Common.Helpers;
using InkeServer.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using Inke.Common.Paginations;

namespace InkeServer.Service.Impl
{
    public class ShopService : ServiceBase, IShopService
    {
        //标记为注入对象
        [InjectionConstructor]
        public ShopService() { }

        /// <summary>
        /// 获取指定商家的店铺列表(店铺名、 ID)
        /// </summary>
        public List<ShopIdAndName> GetShopIdAndName(string Merchant_ID)
        {
            List<ShopIdAndName> shoplist = new List<ShopIdAndName>();
            shoplist = (from l in Entities.Bas_Shop
                                      where l.Merchant_ID == Merchant_ID
                                      select l).ToList().MapTo<ShopIdAndName>();
            return shoplist;
        }
        /// <summary>
        /// 获取可用的店铺列表(店铺名、 ID)
        /// </summary>
        /// <param name="accountid">登录id</param>
        /// <returns></returns>
        public List<ShopIdAndName> GetShopIDNameModelList(string accountid)
        {
            List<ShopIdAndName> shopList = new List<ShopIdAndName>();
            /*新的需求：因为商家的管理员是角色是超级管理员，
             * 判断登陆账号，如果位置是超级管理员，则返回商家的的店铺列表
             */           

            //获取当前账号信息
           
            var model=(from m in Entities.Bas_Account
                       where m.Account_ID == accountid && m.Del != 1
                           select m).FirstOrDefault();

            model.MustNotNull(ResultCode.DataNotFound.Name());

            var position = (from l in Entities.Bas_MerchantPosition
                            where l.Position_ID == model.Position_ID && l.Del != 1
                            select l.Position_Name).FirstOrDefault();

            if (position != null && position == "超级管理员")
            {
                shopList = (from l in Entities.Bas_Shop
                            where l.Merchant_ID == model.Merchant_ID && l.Shop_Status == 1 && l.Del != 1
                            select l).MapTo<ShopIdAndName>();
                return shopList;
            }

            int usableClass = (int)UsableClass.Account;

            shopList = (from l in Entities.Bas_Shop
                        where l.Del != 1 && ((from k in Entities.Bas_Account
                                              where k.Account_ID == model.Account_ID && k.Account_Status == 1 && k.Del != 1
                                              select k.Shop_ID).Union(from c in Entities.Bas_UsableShop
                                                                      where c.Status == 1 && c.Record_ID == model.Account_ID && c.UsableClass == usableClass
                                                                      select c.Shop_ID)).Contains(l.Shop_ID)
                        select l).MapTo<ShopIdAndName>();

            return shopList;
        }


        //获取店铺信息
        public ShopInfo GetShopInfo(string Shop_ID)
        {
            ShopInfo shopinfo = new ShopInfo();
            shopinfo = (from l in Entities.Bas_Shop
                        where l.Shop_ID == Shop_ID
                        select l).FirstOrDefault().MapTo<ShopInfo>();
            return shopinfo;
        }
        //修改店铺信息
        public void Update(ShopUpdate param)
        {
            #region Update
            var temp = (from m in Entities.Bas_Shop
                        where m.Shop_ID == param.Shop_ID
                        select m).FirstOrDefault();

            temp.MustNotNull(ResultCode.DataNotFound.Name());

            temp.Shop_Name = param.Shop_Name;
            temp.Shop_Tel = param.Shop_Tel;
            temp.Shop_LinkMan = param.Shop_LinkMan;
            temp.Prov_ID = param.Prov_ID;
            temp.City_ID = param.City_ID;
            temp.Area_ID = param.Area_ID;
            temp.Shop_Address = param.Shop_Address;
            temp.CommerceGroup_ID = param.CommerceGroup_ID;
            temp.Shop_RechargePassword = param.Shop_RechargePassword;
            temp.Shop_OpenDate = param.Shop_OpenDate;
            temp.Shop_EndDate = param.Shop_EndDate;
            temp.Shop_SmsCount = param.Shop_SmsCount;
            temp.Shop_Logo = param.Shop_Logo;
            temp.Shop_longitude = param.Shop_longitude;
            temp.Shop_latitude = param.Shop_latitude;
            temp.Shop_BusinessTime = param.Shop_BusinessTime;
            temp.Shop_Status = param.Shop_Status;
            temp.Operator = param.Operator;
            temp.OperationTime = DateTime.Now;

            temp.Deliveryamount = param.Deliveryamount;
            temp.Takeoutcost = param.Takeoutcost;
            temp.TakeOutTimeBegin = param.TakeOutTimeBegin;
            temp.TakeOutTimeEnd = param.TakeOutTimeEnd;
            temp.TakeOutStatus = param.TakeOutStatus; 
            
            bool state = Entities.SaveChanges() > 0;

            if (!state)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }
    }
}
