using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 添加/修改 套餐组别请求类
    /// </summary>
    public class AddOrUpdateComboGroupRequest : BaseRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public string ComboGroup_ID { get; set; }
        /// <summary>
        /// 组别名称
        /// </summary>
        [DisplayName("组别名称")]
        public string Group_Name { get; set; }
        /// <summary>
        /// 最多选择数
        /// </summary>
        [DisplayName("最多选择数")]
        public int MaxNum { get; set; }
        /// <summary>
        /// 最少选择数
        /// </summary>
        [DisplayName("最少选择数")]
        public int MinNum { get; set; }
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
    }
}
