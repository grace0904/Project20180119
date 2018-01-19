using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IShopService
    {
        /// <summary>
        /// 获取店铺ID及名称
        /// </summary>
        /// <param name="Merchant_ID">商家ID</param>
        /// <returns></returns>
        List<ShopIdAndName> GetShopIdAndName(string Merchant_ID);
        /// <summary>
        /// 获取店铺ID及名称
        /// </summary>
        /// <param name="Merchant_ID">用户ID</param>
        /// <returns></returns>
        List<ShopIdAndName> GetShopIDNameModelList(string accountid);
        /// <summary>
        /// 获取店铺详细信息
        /// </summary>
        /// <param name="Shop_ID">店铺ID</param>
        /// <returns></returns>
        ShopInfo GetShopInfo(string Shop_ID);
        /// <summary>
        /// 修改店铺信息
        /// </summary>
        /// <param name="model"></param>
        void Update(ShopUpdate param);
    }
}
