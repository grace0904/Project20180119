using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 获取积分调整列表
    /// </summary>
    public class IntegralAdjustInfo
    {
        #region Model
        /// <summary>
        /// 
        /// </summary>
        public string IntegralAdjust_ID { get; set; }
        public string Business_Num { get; set; }
        /// <summary>
        /// 1 清零 2 减少 3 增加
        /// </summary>
        public int AdjustType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal AdjustIntegral { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Card_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Card_BussinessID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Member_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Operator { get; set; }
        #endregion Model
    }
}
