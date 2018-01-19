using Inke.Common.Paginations;
using InkeServer.Enums;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IMerchantBaseService
    {
        /// <summary>
        /// 分页查询基础资料
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IPaginationResult<MerchantBaseQueryResult> GetMerchantBaseInfoPage(MerchantBasePageQueryRequest param);

        /// <summary>
        /// 根据ID获取基础资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MerchantBaseQueryResult GetMerchantBaseInfo(string id);
        /// <summary>
        /// 获取基础资列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<MerchantBaseQueryResult> GetMerchantBaseInfoList(MerchantBaseQueryRequest param);
        /// <summary>
        /// 获取店铺及对应基础信息
        /// </summary>
        /// <param name="param"></param>
        /// <param name="BaseInfoid"></param>
        /// <returns></returns>
        ShopAndProductTypeResult QueryShopAndBaseInfo(ShopAndBaseInfoRequest param);
        /// <summary>
        /// 新增基础资料
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>        
        void Insert(MerchantBaseInsert model);

        /// <summary>
        /// 修改基础资料
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>        
        void Update(MerchantBaseUpdate model);

         /// <summary>
        /// 删除基础资料
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>        
        void Delete(OperationBaseRequest param);
    }
}
