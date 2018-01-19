using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 添加/修改 员工账号信息请求类
    /// </summary>
    public class AddOrUpdateAccountRequest : BaseRequest
    {
        #region
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("账号ID")]
        public string Account_ID { get; set; }
        /// <summary>
        /// 登录帐号
        /// </summary>
        [DisplayName("登录帐号")]
        public string Account_Login { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [DisplayName("登录密码")]
        public string Account_Password { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string Account_Memo { get; set; }
        /// <summary>
        /// 帐号状态 0 停用 1 启用
        /// </summary>
        [DisplayName("帐号状态")]
        public int Account_Status { get; set; }
        /// <summary>
        /// 支持登录Pos机0否，1是
        /// </summary>
        [DisplayName("支持登录Pos机")]
        public int Account_LoginPOS { get; set; }
        /// <summary>
        /// 支持登录客服通 0 否 1 是
        /// </summary>
        [DisplayName("支持登录客服通")]
        public int Account_LoginKFT { get; set; }
        /// <summary>
        /// 支持登录管理后台 0 否 1 是
        /// </summary>
        [DisplayName("支持登录管理后台")]
        public int Account_LoginCRM { get; set; }
        /// <summary>
        /// 支持登录盒子INPOS 0 否 1 是
        /// </summary>
        [DisplayName("支持登录盒子INPOS")]
        public int Account_LoginINPOS { get; set; }
        /// <summary>
        /// 员工ID
        /// </summary>
        [DisplayName("员工ID")]
        public string Employee_ID { get; set; }
        /// <summary>
        /// 职位ID
        /// </summary>
        [DisplayName("职位ID")]
        public string Position_ID { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName("商家ID")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]

        public string Operator { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        [DisplayName("店铺ID")]
        public string Shop_ID { get; set; }
        #endregion
        /// <summary>
        /// 选中的店铺ID集合
        /// </summary>
        [DisplayName("选中的店铺ID集合")]
        public string UsableShopList { get; set; }
    }
}
