using Inke.Common.Paginations;
using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IShopSeatService
    {
        /// <summary>
        /// 获取店铺座位类型列表
        /// </summary>
        /// <param name="MerchantId"></param>
        /// <returns></returns>
        //ShopSeatClassResult QueryShopSeatClass(ShopSeatQueryRequest param);
        List<SeatClassIdAndName> QueryShopSeatClass(MerchantAndShopIdRequest param);
        /// <summary>
        /// 分页查询座位及店铺列表信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IPaginationResult<ShopSeatInfoResult> Query(ShopSeatInfoRequest param);
        /// <summary>
        /// 根据ID查询座位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ShopSeatInfobyIDResult GetMerchantBaseInfo(string id);
        /// <summary>
        /// 新增座位
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>        
        void Insert(ShopSeatInsert model);

        /// <summary>
        /// 修改座位
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>        
        void Update(ShopSeatUpdate model);

        /// <summary>
        /// 删除座位
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>        
        void Delete(OperationBaseRequest param);
    }
}
