using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 职位权限 基础类
    /// </summary>
    public class ShopPositionPowerInfo
    {
        public ShopPositionPowerInfo()
        { }
        #region Model
        /// <summary>
        /// 
        /// </summary>
        public string ShopPostitionPowerID
        {
            set;
            get;
        }
        /// <summary>
        /// 职位ID
        /// </summary>
        public string Position_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 0是启用数据
        /// </summary>
        public int Status
        {
            set;
            get;
        }
        /// <summary>
        /// 权限字符串（格式如菜单编码-菜单功能ID,菜单功能ID|菜单编码-菜单功能ID,菜单功能ID ）   
        /// </summary>
        public string PowerString
        {
            set;
            get;
        }
        #endregion Model
    }
}
