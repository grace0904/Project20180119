using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 套餐产品信息返回类
    /// </summary>
    public class ComboGroupProductInfoResult : ComboProductInfo
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Product_Name { get; set; }

        /// <summary>
        /// 产品单位名称
        /// </summary>
        public string Product_Unit { get; set; }

        /// <summary>
        /// 产品类型ID
        /// </summary>
        public string MerchantBaseInfo_ID { get; set; }

        #region 套餐组信息
        /// <summary>
        /// 套餐组名称
        /// </summary>
        public string ComboGroup_Name { get; set; }
        /// <summary>
        /// 套餐组最多选择数
        /// </summary>
        public int ComboGroup_MaxNum
        {
            set;
            get;
        }
        /// <summary>
        /// 套餐组最少选择数
        /// </summary>
        public int ComboGroup_MinNum
        {
            set;
            get;
        }
        #endregion
    }
}
