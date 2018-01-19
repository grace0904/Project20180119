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
    public class MerchantBaseService : ServiceBase, IMerchantBaseService
    {
        [Dependency]
        public IShopService ShopService { get; set; }
        //标记为注入对象
        [InjectionConstructor]
        public MerchantBaseService() { }

        private static KeySelectors<Bas_MerchantBaseInfo, DefaultSortBy> _keySelectors =
            new KeySelectors<Bas_MerchantBaseInfo, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.AddTime);

        public void Insert(MerchantBaseInsert param)
        {
            #region Insert

            if (param.Merchant_ID.IsNullOrEmpty())
                throw new BusinessException(ResultCode.MerhcantCodeWrong.Name());
            string[] baseinfolist = param.MerchantBaseInfo_Name.Split(',');
            baseinfolist.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //检查当前类型的名称是否在该商家中存在
            var temp = (from m in Entities.Bas_MerchantBaseInfo
                        where m.Merchant_ID == param.Merchant_ID && m.Del != 1 && m.BaseInfoClass == param.BaseInfoClass && baseinfolist.Contains(m.MerchantBaseInfo_Name)
                        select m).FirstOrDefault();

            //  shopList.Select(s => s.Shop_ID).Distinct().ToArray();


            temp.MustIsNull(ResultCode.DataRepeated.Name());
            foreach (string item in baseinfolist)
            {
                var merchantbaseinfo = param.MapTo<Bas_MerchantBaseInfo>();
                merchantbaseinfo.MerchantBaseInfo_Name = item;
                merchantbaseinfo.MerchantBaseInfo_ID = Inke.Common.Helpers.GUID.CreateGUID();
                merchantbaseinfo.AddTime = DateTime.Now;
                merchantbaseinfo.OperationTime = DateTime.Now;
                merchantbaseinfo.Del = 0;
                Entities.Set<Bas_MerchantBaseInfo>().Add(merchantbaseinfo);
            }
            int rownum = Entities.SaveChanges();

            if (rownum == 0)//!Insert(merchantbaseinfo))
                throw new BusinessException(ResultCode.AddFaild.Name());

            #endregion
        }

        public void Update(MerchantBaseUpdate param)
        {
            #region Update
            var temp = (from m in Entities.Bas_MerchantBaseInfo
                        where m.MerchantBaseInfo_ID == param.MerchantBaseInfo_ID && m.Merchant_ID == param.Merchant_ID && m.Del != 1
                        select m).FirstOrDefault();

            temp.MustNotNull(ResultCode.DataNotFound.Name());

            temp.BaseInfoClass = param.BaseInfoClass;
            temp.MerchantBaseInfo_Name = param.MerchantBaseInfo_Name;
            temp.OperationTime = DateTime.Now;
            temp.Operator = param.Operator;
            temp.Shop_ID = param.Shop_ID;

            bool state = Entities.SaveChanges() > 0;

            if (!state)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }

        public void Delete(OperationBaseRequest param)
        {
            if (param.Record_ID.IsNullOrEmpty())
                throw new BusinessException(ResultCode.ArgumentsMiss.Name());
            #region Delete

            string[] idlist = param.Record_ID.Split(',');

            var temp = (from m in Entities.Bas_MerchantBaseInfo
                        where m.Del != 1
                        select m);

            temp = temp.WhereIf(
               l => idlist.Contains(l.MerchantBaseInfo_ID), idlist.Length > 0);

            temp.MustNotNull(ResultCode.DataNotFound.Name());

            int count = Entities.Bas_MerchantBaseInfo.Update(temp, m => new Bas_MerchantBaseInfo { Del = 1, OperationTime = DateTime.Now, Operator = param.Operator });

            if (count == 0)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            #endregion
        }

        public IPaginationResult<MerchantBaseQueryResult> GetMerchantBaseInfoPage(MerchantBasePageQueryRequest param)
        {
            #region Query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from l in Entities.Bas_MerchantBaseInfo
                         where l.Del != 1 && l.Merchant_ID == param.Merchant_ID && l.BaseInfoClass == param.BaseInfoClass
                         select l);
            return QueryPaginate<Bas_MerchantBaseInfo, MerchantBaseQueryResult>(query, param, _keySelectors);

            #endregion
        }
        public List<MerchantBaseQueryResult> GetMerchantBaseInfoList(MerchantBaseQueryRequest param)
        {
            #region Query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            List<MerchantBaseQueryResult> result = new List<MerchantBaseQueryResult>();
            //构造查询条件
            result = (from l in Entities.Bas_MerchantBaseInfo
                      where l.Del != 1 && l.Merchant_ID == param.Merchant_ID && l.BaseInfoClass == param.BaseInfoClass
                      select l).OrderBy(c=>c.MerchantBaseInfo_Name).ToList().MapTo<MerchantBaseQueryResult>();
            return result;
            #endregion
        }

        public MerchantBaseQueryResult GetMerchantBaseInfo(string id)
        {
            #region Query
            MerchantBaseQueryResult result = new MerchantBaseQueryResult();

            id.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            result = (from l in Entities.Bas_MerchantBaseInfo
                      where l.Del != 1 && l.MerchantBaseInfo_ID == id
                      select l).FirstOrDefault().MapTo<MerchantBaseQueryResult>();

            return result;

            #endregion
        }

        //根据商家id及店铺信息和分类id查询对应列表
        public ShopAndProductTypeResult QueryShopAndBaseInfo(ShopAndBaseInfoRequest param)
        {
            ShopAndProductTypeResult result = new ShopAndProductTypeResult();
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
           
            List<ShopIdAndName> shopList = ShopService.GetShopIDNameModelList(param.Account_ID);            

            //获取商家产品种类集合
            var IntegralProductType = (from l in Entities.Bas_MerchantBaseInfo
                                       where l.Merchant_ID == param.Merchant_ID && l.BaseInfoClass == param.BaseInfoClass_id && l.Del != 1
                                       select l).MapTo<MerchantBaseInfoIDAndName>();

            //获取店铺及店铺下产品类型的列表
            string strs = "";
            foreach (ShopIdAndName item in shopList)
            {
                ShopInfoAndProductTypeList shopInfo = new ShopInfoAndProductTypeList();
                shopInfo.Shop_ID = item.Shop_ID;
                shopInfo.Shop_Name = item.Shop_Name;
                //增加商家产品种类集合
                shopInfo.MerBaseInfoList = IntegralProductType;
                result.shopinfoandproducttype.Add(shopInfo);
                //拼接店铺ID字符串
                strs += "'" + item.Shop_ID + "',";
            }
            result.ableShoplist = strs;
            return result;          
        }
    }
}
