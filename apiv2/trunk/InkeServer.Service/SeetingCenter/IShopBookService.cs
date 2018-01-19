using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IShopBookService
    {
        /// <summary>
        /// 获取相关预约信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        ShopBookResult GetShopBookInfo(ShopIdRequest param);
        /// <summary>
        /// 修改店铺预约信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        void Update(ShopBookUpdate param);
    }
}
