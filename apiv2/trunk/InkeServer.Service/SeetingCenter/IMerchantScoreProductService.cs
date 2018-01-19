using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IMerchantScoreProductService
    {
        /// <summary>
        /// 分页查询 商家积分产品集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<MerchantScoreProductInfoResult> Query(MerchantScoreProductQueyRequest param);
        /// <summary>
        /// 将商家积分产品标记为删除
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool Delete(OperationBaseRequest param);
        /// <summary>
        /// 获得商家积分产品详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        MerchantScoreProductInfoResult GetInfo(RecordIDRequest param);
        /// <summary>
        /// 新增商家积分产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool Insert(AddOrUpdateMerchantScoreProduct param);
        /// <summary>
        /// 修改商家积分产品信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool Update(AddOrUpdateMerchantScoreProduct param);
        /// <summary>
        /// 获取店铺尚未拥有的商家积分产品列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<MerchantScoreProductInfo> GetMerchantScoreProductByShopID(MerchantShopAndBaseInfo param);
    }
}
