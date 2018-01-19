using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface ITakeOutService
    {
        /// <summary>
        /// 获取相关外卖信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        TakeOutResult GetTakeOutInfo(ShopIdRequest param);
        /// <summary>
        /// 修改店铺外卖信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        void Update(TakeOutUpdate param);
    }
}
