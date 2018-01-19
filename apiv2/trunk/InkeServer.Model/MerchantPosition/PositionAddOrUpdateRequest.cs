using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 商家职位 添加/修改 请求类
    /// </summary>
    public class PositionAddOrUpdateRequest : BaseRequest
    {
        /// <summary>
        /// 职位ID
        /// </summary>
        [DisplayName("职位ID")]
        public string Position_ID { get; set; }
        /// <summary>
        /// 职位编码
        /// </summary>
        [DisplayName("职位编码")]
        public string Position_Code { get; set; }
        /// <summary>
        /// 职位名称
        /// </summary>
        [DisplayName("职位编码")]
        public string Position_Name { get; set; }
        /// <summary>
        /// 父职位
        /// </summary>
        [DisplayName(" 商家ID")]
        public string Position_Parent { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName(" 商家ID")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        [DisplayName("店铺ID")]
        public string Shop_ID { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]
        public string Operator { get; set; }

        /// <summary>
        /// 权限字符串（菜单编码-菜单操作功能，菜单功能ID|菜单编码-菜单操作功能，菜单功能ID）
        /// </summary>
        [DisplayName("权限字符串")]
        public string PowerString { get; set; }
    }
}
