using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 账号信息 返回类
    /// </summary>
    public class AccountInfoResult
    {
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shop_Name { get; set; }
        /// <summary>
        /// 员工名称
        /// </summary>
        public string Employee_Name { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>

        public string Position_Name { get; set; }
        #region
        /// <summary>
        /// 账号ID
        /// </summary>
        public string Account_ID { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public string Account_Login { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Account_Memo { get; set; }
        /// <summary>
        /// 帐号状态 0 停用 1 启用
        /// </summary>
        public int? Account_Status { get; set; }
        /// <summary>
        /// 支持登录Pos机0否，1是
        /// </summary>
        public int? Account_LoginPOS { get; set; }
        /// <summary>
        /// 支持登录客服通 0 否 1 是
        /// </summary>
        public int? Account_LoginKFT { get; set; }
        /// <summary>
        /// 支持登录管理后台 0 否 1 是
        /// </summary>
        public int? Account_LoginCRM { get; set; }
        /// <summary>
        /// 支持登录盒子INPOS
        /// </summary>
        public int? Account_LoginINPOS { get; set; }
        /// <summary>
        /// 员工ID
        /// </summary>
        public string Employee_ID { get; set; }
        /// <summary>
        /// 职位ID
        /// </summary>
        public string Position_ID { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperationTime { get; set; }
        #endregion
        //是否已删除
        public int? Del { get; set; }
        /// <summary>
        /// 已经选中的店铺ID集合
        /// </summary>
        public string UsableShopList { get; set; }
    }
}
