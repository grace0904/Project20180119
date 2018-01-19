using InkeServer.DataMapping;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inke.Common.Extentions;
using InkeServer.Enums;
using InkeServer.Model;
using Inke.Common.Paginations;
using Inke.Common.Exceptions;
using AutoMapper;
using System.Data.Entity;
using EntityFramework.Extensions;

namespace InkeServer.Service.Impl
{
    public class ComboGroupService : ServiceBase, IComboGroupService
    {
        //标记为注入对象
        [InjectionConstructor]
        public ComboGroupService() { }
        /// <summary>
        /// 分页获取套餐组别集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IPaginationResult<ComboGroupInfo> Query(MerchantIdPageRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());

            //构造查询条件
            var query = (from a in Entities.Bas_ComboGroup
                         where a.Del != 1
                         && a.Merchant_ID.Equals(param.Merchant_ID)
                         select a);

            KeySelectors<Bas_ComboGroup, DefaultSortBy> _keySelectors =
            new KeySelectors<Bas_ComboGroup, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.ComboGroup_ID);

            return QueryPaginate<Bas_ComboGroup, ComboGroupInfo>(query, param, _keySelectors);
            #endregion
        }

        /// <summary>
        /// 获取套餐组别集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<ComboGroupInfo> ComboGroupInfoQuery(MerchantIdRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            List<ComboGroupInfo> combogroup = new List<ComboGroupInfo>();

            //构造查询条件
            var query = (from a in Entities.Bas_ComboGroup
                         where a.Del != 1
                         && a.Merchant_ID.Equals(param.Merchant_ID)
                         select a);

            KeySelectors<Bas_ComboGroup, DefaultSortBy> _keySelectors =
            new KeySelectors<Bas_ComboGroup, DefaultSortBy>().Add(DefaultSortBy.Default, r => r.Group_Name);
            combogroup = query.OrderBy(c => c.Group_Name).ToList().MapTo<ComboGroupInfo>();
            return combogroup;
            #endregion
        }
        /// <summary>
        /// 获取套餐组别详细信息 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ComboGroupInfo GetInfo(RecordIDRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            var info = (from a in Entities.Bas_ComboGroup
                        where a.ComboGroup_ID.Equals(param.Record_ID)
                        select a).FirstOrDefault();
            if (info == null)
                throw new BusinessException(ResultCode.DataNotFound.Name());
            return info.MapTo<ComboGroupInfo>();
        }
        public bool Exists(string merchantId, string name, string id)
        {
            var info = (from a in Entities.Bas_ComboGroup where a.Del != 1 && a.Merchant_ID == merchantId && a.Group_Name.Equals(name) && !a.ComboGroup_ID.Equals(id) select a).FirstOrDefault();
            return info != null;
        }
        /// <summary>
        /// 新增套餐组别
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Insert(AddOrUpdateComboGroupRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            if (Exists(param.Merchant_ID, param.Group_Name, ""))
                throw new BusinessException(ResultCode.DataRepeated.Name());

            Bas_ComboGroup model = param.MapTo<Bas_ComboGroup>();
            model.ComboGroup_ID = Inke.Common.Helpers.GUID.CreateGUID();
            model.AddTime = DateTime.Now;
            model.OperationTime = DateTime.Now;
            model.Del = 0;
            Entities.Bas_ComboGroup.Add(model);
            if (Entities.SaveChanges() <= 0)
                throw new BusinessException(ResultCode.AddFaild.Name());


            return true;
        }

        /// <summary>
        /// 修改套餐组别信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        public bool Update(AddOrUpdateComboGroupRequest param)
        {
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            if (!Entities.Bas_ComboGroup.Any(e => e.ComboGroup_ID == param.ComboGroup_ID))
                throw new BusinessException(ResultCode.DataNotFound.Name());
            if (Exists(param.Merchant_ID, param.Group_Name, param.ComboGroup_ID))
                throw new BusinessException(ResultCode.NameExisted.Name());
            Bas_ComboGroup model = param.MapTo<Bas_ComboGroup>();
            model.OperationTime = DateTime.Now;
            Entities.Entry(model).State = EntityState.Modified;
            Entities.Entry(model).Property(b => b.AddTime).IsModified = false;
            Entities.Entry(model).Property(b => b.Del).IsModified = false;
            Entities.Entry(model).Property(b => b.Merchant_ID).IsModified = false;
            if (Entities.SaveChanges() <= 0)
                throw new BusinessException(ResultCode.UpdateFaild.Name());
            return true;
        }
        /// <summary>
        /// 将套餐组别标记为删除
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
            //检查该套餐组是否被产品使用
            var check = (from l in Entities.Bas_MerchantProducts where (from t in Entities.Bas_ProductCombo where t.ComboGroup_ID == param.Record_ID && t.Del != 1 select t.Product_ID).Contains(l.Product_ID) select l);
            if (check.Count()>0)
            {
                 throw new BusinessException(ResultCode.ProductComboGroupUsed.Name());
            }
            int row = Entities.Bas_ComboGroup
                     .Where(t => param.Record_ID.Contains(t.ComboGroup_ID))
                     .Update(t => new Bas_ComboGroup { Del = 1 });
            if (row == 0)
                throw new BusinessException(ResultCode.OperationFaild.Name());
            return true;
        }

        /// <summary>
        /// 获取套餐产品的套餐分组及商家的套餐分组列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ProComboListAndMerComboListData GetProductComboListAndMerchantComboList(GetProductInfoRequest param)
        {
            #region query
            param.MustNotNull(ResultCode.ArgumentsMiss.Name());
            ProComboListAndMerComboListData data = new ProComboListAndMerComboListData();
            var merchantComboIDAndNameList = (from a in Entities.Bas_ComboGroup where a.Del != 1 && a.Merchant_ID == param.Merchant_ID select new ComboGroupIDAndName { ComboGroup_ID = a.ComboGroup_ID, Group_Name = a.Group_Name }).Future();
            data.MerchantComboIDAndNameList = merchantComboIDAndNameList.ToList();
            if (!string.IsNullOrEmpty(param.Product_ID))
            {
                var productComboIDAndNameList = (from a in Entities.Bas_ProductCombo
                                                 join c in Entities.Bas_ComboGroup on a.ComboGroup_ID equals c.ComboGroup_ID
                                                 where a.Del != 1 && c.Del != 1 && a.Merchant_ID == param.Merchant_ID && a.Product_ID == param.Product_ID
                                                 select new ComboGroupIDAndName
                                                 {
                                                     ComboGroup_ID = a.ProductCombo_ID,
                                                     Group_Name = c.Group_Name
                                                 }).Future();
                data.ProductComboIDAndNameList = productComboIDAndNameList.ToList();
            }
            return data;
            #endregion
        }
    }
}
