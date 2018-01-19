using Inke.Common.Exceptions;
using InkeServer.DataMapping;
using InkeServer.Enums;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Inke.Common.Extentions;
using System.Transactions;
using EntityFramework.Extensions;
using System.Data.Entity;

namespace InkeServer.Service.Impl
{
    public class MerchantConfigService : ServiceBase, IMerchantConfigService
    {
        /// <summary>
        /// pc端获取店铺配置/名称/其他相关信息
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        public MerchantConfigData GetMerchantconfig(string merchantId)
        {
            if (string.IsNullOrEmpty(merchantId))
            {
                throw new BusinessException(ResultCode.ArgumentsMiss.Name());
            }
            MerchantConfigData data = new MerchantConfigData();
            //得到商家名称和基本配置信息
            var merchantConfig = (from mer in Entities.Bas_Merchant
                                  join con in Entities.Bas_MerchantConfig
                                  on mer.Merchant_ID equals con.Merchant_ID into joined
                                  from j in joined.DefaultIfEmpty()
                                  where mer.Merchant_ID == merchantId
                                  select new
                                  {
                                      MerchantConfig = j,
                                      MerchantName = mer

                                  });
            var configData = merchantConfig.FirstOrDefault();
            if (configData != null)
            {
                MerchantConfigAndName config = new MerchantConfigAndName();
                config.MerchantName = configData.MerchantName.MapTo<MerchantName>();
                config.MerchantConfig = configData.MerchantConfig.MapTo<MerchantConfigBasic>();
                data.merchantConfigAndName = config;
            }
            //得到商家的店铺ID和名称
            var shoplist = (from a in Entities.Bas_Shop where a.Del != 1 && a.Merchant_ID == merchantId select new { Shop_ID = a.Shop_ID, Shop_Name = a.Shop_Name }).Distinct();
            data.shopIdAndNameList = shoplist.MapTo<ShopIdAndName>();
            int type = (int)UsableClass.OnlyCardConsumeShop;
            //得到允许使用会员卡的店铺ID集合
            var usableshop = (from a in Entities.Bas_UsableShop where a.UsableClass==type && a.Status == 1 && a.Merchant_ID == merchantId && !string.IsNullOrEmpty(a.Shop_ID) select new { Shop_ID = a.Shop_ID, Status = 1 }).Distinct();
            data.usableShopEnableIDList = usableshop.MapTo<UsableShopEnableID>();
            return data;
        }
        /// <summary>
        /// 更新商家配置PC
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool UpdatePc(MerchantConfigUpdateRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            using (var scope = new TransactionScope())
            {
                if (!Entities.Bas_Merchant.Any(e => e.Merchant_ID == param.Merchant_ID))
                    throw new BusinessException(ResultCode.DataNotFound.Name());
                //更新商家名称
                Entities.Bas_Merchant.Where(p => p.Merchant_ID == param.Merchant_ID).Update(p => new Bas_Merchant { Merchant_Name = param.Merchant_Name, Merchant_ShortName = param.Merchant_ShortName });
                //更新商家配置
                //1.若存在商家配置记录则更新否则添加
                Bas_MerchantConfig model = param.MapTo<Bas_MerchantConfig>();
                model.OperationTime = DateTime.Now;
                if (Entities.Bas_MerchantConfig.Any(e => e.Merchant_ID == param.Merchant_ID && e.MerchantConfig_ID == param.MerchantConfig_ID))
                {
                    //更新
                    Entities.Entry(model).State = EntityState.Modified;
                    if (Entities.SaveChanges() <= 0)
                        throw new BusinessException(ResultCode.UpdateFaild.Name());
                }
                else
                {
                    //插入
                    Entities.Bas_MerchantConfig.Add(model);
                    if (Entities.SaveChanges() <= 0)
                        throw new BusinessException(ResultCode.AddFaild.Name());
                }
               
                //更新记录表

                //1.先删除相关店铺配置记录
                int type = (int)UsableClass.OnlyCardConsumeShop;
                Entities.Bas_UsableShop.Where(p => p.Merchant_ID == param.Merchant_ID && p.Record_ID == param.MerchantConfig_ID && p.UsableClass == type).Delete();
                //2.再添加相关配置
                if (!string.IsNullOrEmpty(param.ShopList))
                {
                    var shopIdArry = param.ShopList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    if (shopIdArry.Length > 0)
                    {
                        IList<Bas_UsableShop> shopList = new List<Bas_UsableShop>();
                        foreach (var item in shopIdArry)
                        {
                            var collects = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (collects.Length >= 2)
                            {
                                Bas_UsableShop data = new Bas_UsableShop();
                                data.UsableShop_ID = Inke.Common.Helpers.GUID.CreateGUID();
                                data.UsableClass = (int)UsableClass.OnlyCardConsumeShop;
                                data.Record_ID = model.MerchantConfig_ID;
                                data.Merchant_ID = model.Merchant_ID;
                                data.Shop_ID = collects[0];
                                data.Status = Convert.ToInt32(collects[1]);
                                shopList.Add(data);
                            }
                        }
                        if (shopList.Count > 0)
                        {
                            Entities.Bas_UsableShop.AddRange(shopList);
                            Entities.SaveChanges();
                        }
                    }
                }
                scope.Complete();
            }
            return true;
        }
    }
}
