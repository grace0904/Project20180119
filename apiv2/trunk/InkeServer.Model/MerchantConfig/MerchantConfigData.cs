using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public  class MerchantConfigData
    {
        /// <summary>
        /// 商家配置
        /// </summary>
        public MerchantConfigAndName merchantConfigAndName;

        public List<ShopIdAndName> shopIdAndNameList;
        /// <summary>
        /// 只允许使用会员卡的店铺ID
        /// </summary>

        public List<UsableShopEnableID> usableShopEnableIDList;
    }
}
