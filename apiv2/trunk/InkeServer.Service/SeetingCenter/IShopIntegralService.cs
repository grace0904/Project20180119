using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IShopIntegralService
    {       
        /// <summary>
        /// 分页查询相关积分信息列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<ShopIntegralProductsResult> QueryShopAndProductList(ShopProductsRequest param);
        /// <summary>
        /// 根据ID查询店铺积分产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ShopIntegralProductsResult GetShopIntegralInfobyID(string id);
        /// <summary>
        /// 批量新增店铺积分产品
        /// </summary>
        /// <param name="param"></param>
        void Insert(ShopProductInsert param);
        /// <summary>
        /// 批量新增店铺积分产品
        /// </summary>
        /// <param name="param"></param>
        void Delete(OperationBaseRequest param);
        /// <summary>
        /// 修改店铺积分产品
        /// </summary>
        /// <param name="param"></param>
        void Update(ShopIntegralProductsUpdate param);
    }
}
