using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class AddOrUpdateMerchantScoreProduct : BaseRequest
    {
        #region Model
        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public string IntegralProduct_ID { get; set; }

        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName("商家ID")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 产品类别
        /// </summary>
        [DisplayName("产品类别")]
        public string Dictionary_ID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        [DisplayName("产品名称")]
        public string IntegralProduct_Name { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [DisplayName("产品编号")]
        public string IntegralProduct_Code { get; set; }
        /// <summary>
        /// 拼音简码
        /// </summary>
        [DisplayName("拼音简码")]
        public string IntegralProduct_SpellCode { get; set; }
        /// <summary>
        /// 产品单位
        /// </summary>
        [DisplayName("产品单位")]
        public string IntegralProduct_Unit { get; set; }
        /// <summary>
        /// 所需积分
        /// </summary>
        [DisplayName("所需积分")]
        public decimal IntegralProduct_Price { get; set; }
        /// <summary>
        /// 产品大图
        /// </summary>
        [DisplayName("产品大图")]
        public string IntegralProduct_BPic { get; set; }
        /// <summary>
        /// 产品小图
        /// </summary>
        [DisplayName("产品小图")]
        public string IntegralProduct_SPic { get; set; }
        /// <summary>
        /// 产品说明
        /// </summary>
        [DisplayName("产品说明")]
        public string IntegralProduct_Memo { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]
        public string Operator { get; set; }
        #endregion
    }
}
