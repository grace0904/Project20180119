using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IComboGroupService
    {
        /// <summary>
        /// 分页获取套餐组别集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<ComboGroupInfo> Query(MerchantIdPageRequest param);
        /// <summary>
        /// 获取套餐组别集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<ComboGroupInfo> ComboGroupInfoQuery(MerchantIdRequest param);
        /// <summary>
        /// 获取套餐组别详细信息 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ComboGroupInfo GetInfo(RecordIDRequest param);
            /// <summary>
        /// 新增套餐组别
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Insert(AddOrUpdateComboGroupRequest param);
        /// <summary>
        /// 修改套餐组别信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Update(AddOrUpdateComboGroupRequest param);
        /// <summary>
        /// 将套餐组别标记为删除
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Delete(OperationBaseRequest param);
         /// <summary>
        /// 获取套餐产品的套餐分组及商家的套餐分组列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ProComboListAndMerComboListData GetProductComboListAndMerchantComboList(GetProductInfoRequest param);
    }
}
