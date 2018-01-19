using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class MerchantScoreProductInfoResult
    {
        /// <summary>
        /// 产品类型名称
        /// </summary>
        public string MerchantBaseInfo_Name
        {
            get;
            set;
        }


        #region MerchantScoreProductInfo
        /// <summary>
        /// ID
        /// </summary>
        public string IntegralProduct_ID { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperationTime { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 产品类别
        /// </summary>
        public string Dictionary_ID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string IntegralProduct_Name { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string IntegralProduct_Code { get; set; }
        /// <summary>
        /// 拼音简码
        /// </summary>
        public string IntegralProduct_SpellCode { get; set; }
        /// <summary>
        /// 产品单位
        /// </summary>
        public string IntegralProduct_Unit { get; set; }
        /// <summary>
        /// 所需积分
        /// </summary>
        public decimal IntegralProduct_Price { get; set; }
        /// <summary>
        /// 产品大图
        /// </summary>
        public string IntegralProduct_BPic { get; set; }
        /// <summary>
        /// 产品小图
        /// </summary>
        public string IntegralProduct_SPic { get; set; }
        /// <summary>
        /// 产品说明
        /// </summary>
        public string IntegralProduct_Memo { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        #endregion
    }
}
