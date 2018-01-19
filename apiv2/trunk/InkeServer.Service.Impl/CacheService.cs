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

namespace InkeServer.Service.Impl
{
    public class CacheService : ServiceBase, ICacheService
    {
        //标记为注入对象
        [InjectionConstructor]
        public CacheService() { }
        public CacheData CrmCache(CacheRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            CacheData cacheData = new CacheData();

            //根据商家NUMBER查询到商家ID
            var merchant = (from n in Entities.Bas_Merchant
                            where n.Merchant_Number == param.Merchant_Number
                            select n).FirstOrDefault();
            var merchantId = merchant.Merchant_ID;

            if (merchantId.IsNullOrEmpty())
                throw new BusinessException(ResultCode.MerhcantCodeWrong.Name());
            #region 创建缓存查询语句

            var accountInfo = (from n in Entities.Bas_Account
                               where n.Merchant_ID == merchantId && n.Account_Login == param.Account_Login 
                               select n).FirstOrDefault();

            accountInfo.MustNotNull(ResultCode.LoginFaild.Name());

            //创建模块权限字符串
            var MerchantModuleList = (from l in Entities.Sys_MerchantModule
                                      where l.Merchant_ID == merchantId && l.Module_Code.StartsWith(param.TerminalType.ToString())
                                      select l).Future();

            //当前登录用户的菜单权限
            var ShopPositionPower = (from f in Entities.Bas_Account
                                     join fc in Entities.Bas_ShopPositionPower on f.Position_ID equals fc.Position_ID
                                     where f.Account_Login == param.Account_Login && f.Merchant_ID == merchantId
                                     select new ShopPositionPowerInfo
                                     {
                                         ShopPostitionPowerID = fc.ShopPostitionPowerID,
                                         Position_ID = fc.Position_ID,
                                         Merchant_ID = fc.Merchant_ID,
                                         Status = fc.Status,
                                         PowerString = fc.PowerString
                                     }).Future();

            //当前用户类型的全部菜单
            var SysPowerList = (from f in Entities.Sys_Power
                                where f.Power_Code.StartsWith(param.TerminalType.ToString())
                                select f).Future();

            //创建商家配置字符串
            var MerchantConfig = (from m in Entities.Bas_Merchant
                                  join c in Entities.Bas_MerchantConfig on m.Merchant_ID equals c.Merchant_ID
                                  where m.Merchant_ID == merchantId
                                  select new MerchantConfigInfo
                                  {
                                      #region
                                      Merchant_Name = m.Merchant_Name,
                                      Merchant_ShortName = m.Merchant_ShortName,
                                      MerchantConfig_ID = c.MerchantConfig_ID,
                                      Merchant_ID = c.Merchant_ID,
                                      BusinessScope_ID = c.BusinessScope_ID,
                                      SmsCount = c.SmsCount,
                                      ConsumeAutoUpdate = c.ConsumeAutoUpdate,
                                      RechargeAutoUpdate = c.RechargeAutoUpdate,
                                      Pop = c.Pop,
                                      DiscountRate = c.DiscountRate,
                                      IntegralRate = c.IntegralRate,
                                      CashRate = c.CashRate,
                                      IntegraClear = c.IntegraClear,
                                      IntegraEndTime = c.IntegraEndTime.HasValue ? c.IntegraEndTime.Value.ToString() : "",
                                      IntegraClearTime = c.IntegraClearTime.HasValue ? c.IntegraClearTime.Value.ToString() : "",
                                      IntegraClearBeforeSms = c.IntegraClearBeforeSms,
                                      IntegraClearBeforeDate = c.IntegraClearBeforeDate,
                                      IntegraClearFinishSms = c.IntegraClearFinishSms,
                                      SpanMonthAdjust = c.SpanMonthAdjust,
                                      ConsumeInputType = c.ConsumeInputType,
                                      DeductMoneyAutoInput = c.DeductMoneyAutoInput,
                                      ShowAffirm = c.ShowAffirm,
                                      OnlyCardConsume = c.OnlyCardConsume,
                                      NotEditRate = c.NotEditRate,
                                      CanCloseIntegra = c.CanCloseIntegra,
                                      MemberMultiCard = c.MemberMultiCard,
                                      CardNumberNull = c.CardNumberNull,
                                      IntegraConvertManualInput = c.IntegraConvertManualInput,
                                      OpenTakeAway = c.OpenTakeAway,
                                      OpenReservation = c.OpenReservation,
                                      OpenSelfOrder = c.OpenSelfOrder,
                                      OpenSelfPay = c.OpenSelfPay,
                                      Taste = c.taste,
                                      MainScope = c.MainScope,
                                      SpecialRequire = c.SpecialRequire,
                                      Introduce = c.Introduce,
                                      Number = c.Number,
                                      ReduceMantissaSet = c.ReduceMantissaSet,
                                      Operator = c.Operator,
                                      #endregion
                                  }).Future();

            //获取商家名称
            //var mer = (from l in Entities.Bas_Merchant
            //           where l.Merchant_ID == merchantId
            //           select l).Future();

            //获取当前用户所在店铺名称
            var Shop_Name = (from l in Entities.Bas_Shop
                             where l.Shop_ID == accountInfo.Shop_ID
                             select l.Shop_Name).Future();

            //获取当前商家的店铺列表
            var MerchantShopList = (from l in Entities.Bas_Shop
                                    where l.Merchant_ID == merchantId && l.Shop_Status == 1
                                    select l).Future();        

            //获取当前商家对应的微信信息
            var wechat = (from l in Entities.Bas_WeChat where l.Merchant_ID == merchantId select l).FirstOrDefault();
            #endregion

            #region 创建缓存

            cacheData.MerchantModuleList = MerchantModuleList.ToList().MapTo<MerchantModuleInfo>();
            cacheData.ShopPositionPower = ShopPositionPower.FirstOrDefault();
            cacheData.SysPowerList = SysPowerList.ToList().MapTo<SysPowerInfo>();
            cacheData.MerchantConfig = MerchantConfig.FirstOrDefault();
            cacheData.MerchantShopList = MerchantShopList.ToList().MapTo<ShopIdAndName>();
            if (wechat!=null)
            {
               cacheData.Wechat = wechat.MapTo<WeChat>();
            }           
            //获取当前用户权限的店铺列表
            cacheData.ShopList = GetShopIDNameModelList(accountInfo);

            #endregion

            return cacheData;
        }


        private List<ShopIdAndName> GetShopIDNameModelList(Bas_Account account)
        {
            List<ShopIdAndName> shopList = new List<ShopIdAndName>();
            /*新的需求：因为商家的管理员是角色是超级管理员，
             * 判断登陆账号，如果位置是超级管理员，则返回商家的的店铺列表
             */
           
            var position = (from l in Entities.Bas_MerchantPosition
                                             where l.Position_ID == account.Position_ID && l.Del != 1
                                             select l.Position_Name).FirstOrDefault();

            if (position != null && position == "超级管理员")
            {
                shopList = (from l in Entities.Bas_Shop
                            where l.Merchant_ID == account.Merchant_ID && l.Shop_Status == 1 && l.Del != 1
                            select l).MapTo<ShopIdAndName>();
                return shopList;
            }

            int usableClass = (int)UsableClass.Account;

            shopList = (from l in Entities.Bas_Shop
                        where l.Del != 1 && ((from k in Entities.Bas_Account
                                              where k.Account_ID == account.Account_ID && k.Account_Status == 1 && k.Del != 1
                                              select k.Shop_ID).Union(from c in Entities.Bas_UsableShop
                                                                      where c.Status == 1 && c.Record_ID == account.Account_ID && c.UsableClass == usableClass
                                                                      select c.Shop_ID)).Contains(l.Shop_ID)
                        select l).MapTo<ShopIdAndName>();

            return shopList;
        }
    }
}
