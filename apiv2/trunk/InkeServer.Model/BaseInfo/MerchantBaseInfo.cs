using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class MerchantBaseInfo
    {
        #region Model

        /// <summary>
        /// 基础信息设置ID
        /// </summary>
        public string MerchantBaseInfo_ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string MerchantBaseInfo_Name { get; set; }
        /// <summary>
        /// 基础信息ID(BassInfo表)
        /// </summary>
        public int BaseInfoClass { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public byte[] OptionTimestamp { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? Del { get; set; }

        #endregion Model
    }
}
