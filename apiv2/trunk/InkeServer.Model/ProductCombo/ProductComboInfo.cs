using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    [Serializable]
    public class ProductComboInfo
    {
        #region Model
        /// <summary>
        /// 产品与套餐分组关系ID
        /// </summary>
        public string ProductCombo_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 产品ID
        /// </summary>
        public string Product_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 套餐分组ID
        /// </summary>
        public string ComboGroup_ID
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
        #endregion Model
    }
}
