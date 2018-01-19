using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 套餐产品基础类
    /// </summary>
    [Serializable]
    public class ComboProductInfo
    {
        #region Model
        /// <summary>
        /// ID
        /// </summary>
        public string ComboProduct_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 套餐组别
        /// </summary>
        public string ComboGroup_ID
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
        /// 可选数量 0 表示不限
        /// </summary>
        public int OptionalNum
        {
            set;
            get;
        }
        /// <summary>
        /// 影响价格
        /// </summary>
        public decimal InfluencePrice
        {
            set;
            get;
        }
        /// <summary>
        /// 是否必选 0 否 1 是
        /// </summary>
        public int IsRequired
        {
            set;
            get;
        }
        /// <summary>
        /// 默认选中 0 否 1 是
        /// </summary>
        public int IsSelected
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
