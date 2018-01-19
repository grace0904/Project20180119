using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 添加/修改套餐产品请求类
    /// </summary>
    public class AddOrUpdateComboProduct : BaseRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public string ComboProduct_ID { get; set; }
        /// <summary>
        /// 套餐组别
        /// </summary>
        [DisplayName("套餐组别")]
        public string ComboGroup_ID { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        [DisplayName("产品ID")]
        public string Product_ID { get; set; }
        /// <summary>
        /// 可选数量 0 表示不限
        /// </summary>
        [DisplayName("可选数量")]
        public int OptionalNum { get; set; }
        /// <summary>
        /// 影响价格
        /// </summary>
        [DisplayName("影响价格")]
        public Decimal InfluencePrice { get; set; }
        /// <summary>
        /// 是否必选 0 否 1 是
        /// </summary>
        [DisplayName("是否必选")]
        public int IsRequired { get; set; }
        /// <summary>
        /// 默认选中 0 否 1 是
        /// </summary>
        [DisplayName("默认选中")]
        public int IsSelected { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName("商家ID")]
        public string Merchant_ID { get; set; }
    }
}
