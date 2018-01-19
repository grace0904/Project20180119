using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IShopProductsService
    {
        /// <summary>
        /// 分页查询相关积分信息列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<ShopProductPageResult> QueryShopAndProductList(ShopProductsRequest param);
        /// <summary>
        /// 查询不再店铺中的产品列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        IPaginationResult<ShopProductPageResult> QueryShopAndProductNotExists(ShopProductsRequest param);
        /// <summary>
        /// 根据ID查询店铺积分产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ShopProductPageResult GetShopProductInfobyID(string id);
        /// <summary>
        /// 批量新增店铺产品
        /// </summary>
        /// <param name="param"></param>
        void Insert(ShopProductInsert param);
        /// <summary>
        /// 批量新增店铺产品
        /// </summary>
        /// <param name="param"></param>
        void InsertList(ShopProductInsertList param);
        /// <summary>
        /// 删除店铺产品
        /// </summary>
        /// <param name="param"></param>
        void Delete(OperationBaseRequest param);

        /// <summary>
        /// 修改店铺产品
        /// </summary>
        /// <param name="param"></param>
         void Update(ShopProductUpdate param);
    }
}
