using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 商家职位基础类
    /// </summary>
    [Serializable]
    public class MerchantPositionInfo
    {
        public MerchantPositionInfo()
        { }
        #region Model
        /// <summary>
        /// ID
        /// </summary>
        public string Position_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 职位编码
        /// </summary>
        public string Position_Code
        {
            set;
            get;
        }
        /// <summary>
        /// 职位名称
        /// </summary>
        public string Position_Name
        {
            set;
            get;
        }
        /// <summary>
        /// 父职位
        /// </summary>
        public string Position_Parent
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
        /// 店铺ID
        /// </summary>
        public string Shop_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime
        {
            set;
            get;
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperationTime
        {
            set;
            get;
        }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OptionTimestamp
        {
            set;
            get;
        }
        #endregion Model
    }
}
