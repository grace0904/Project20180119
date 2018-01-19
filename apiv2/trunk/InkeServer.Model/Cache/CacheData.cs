using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 终端模块和商家配置详细信息
    /// </summary>
    public class CacheData
    {
        /// <summary>
        /// 商家的功能模块
        /// </summary>
        public List<MerchantModuleInfo> MerchantModuleList = new List<MerchantModuleInfo>();

        /// <summary>
        /// 商家配置信息
        /// </summary>
        public MerchantConfigInfo MerchantConfig { get; set; }

        /// <summary>
        /// 用户登录后当前职位的菜单权限
        /// </summary>
        public ShopPositionPowerInfo ShopPositionPower { get; set; }

        /// <summary>
        /// 当前身份类型拥有的菜单列表：（POS，PC等）
        /// </summary>
        public List<SysPowerInfo> SysPowerList = new List<SysPowerInfo>();

        /// <summary>
        /// 登陆用户所在商家的职位列表
        /// </summary>
        public List<MerchantPositionInfo> MerchantPositionList = new List<MerchantPositionInfo>();

        /// <summary>
        /// 登陆账号的可用店铺列表usableShop表
        /// </summary>
        public List<ShopIdAndName> ShopList = new List<ShopIdAndName>();

        /// <summary>
        /// 商家可用店铺列表
        /// </summary>
        public List<ShopIdAndName> MerchantShopList = new List<ShopIdAndName>();

        ///// <summary>
        ///// 员工列表
        ///// </summary>
        //public List<EmployeeIDAndName> EmployeeIDAndNameList = new List<EmployeeIDAndName>();
        /// <summary>
        /// 商家对应的微信信息
        /// </summary>
        public WeChat Wechat { get; set; }
    }
}
