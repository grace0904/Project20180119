using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IMerchantProductService
    {
        /// <summary>
        /// 分页查询 商家产品集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<MerchantProductInfoResult> Query(MerchantProductQueryRequest param);
        /// <summary>
        /// 根据商家ID和类型获取商家产品集合
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<MerchantProductInfoResult> GetList(MerchantAndBaseInfoRequest param);
        /// <summary>
        /// 把商家产品标记为删除
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Delete(OperationBaseRequest param);
        /// <summary>
        /// 获取商家产品详细信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        MerchantProductInfoResult GetInfo(GetProductInfoRequest param);
        /// <summary>
        /// 添加商家产品
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Insert(AddOrUpdateMerchantProduct param);
        /// <summary>
        /// 修改会员卡折扣类型信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        bool Update(AddOrUpdateMerchantProduct param);
        /// <summary>
        /// 获取店铺尚未拥有的商家产品列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<MerchantProductInfo> GetMerchantProductByShopID(MerchantShopAndBaseInfo param);
    }
}
