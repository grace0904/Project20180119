using InkeServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Service
{
    public interface IMerchantConfigService
    {
        /// <summary>
        /// pc端获取店铺配置/名称/其他相关信息
        /// </summary>
        /// <param name="merchantId"></param>
        /// <returns></returns>
        MerchantConfigData GetMerchantconfig(string merchantId);
        /// <summary>
        /// 更新商家配置PC
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool UpdatePc(MerchantConfigUpdateRequest param);
    }
}
