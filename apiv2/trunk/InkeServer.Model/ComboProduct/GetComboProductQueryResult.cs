using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 套餐组产品列表返回基 类
    /// </summary>
    public class GetComboProductQueryResult : ComboProductInfo
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
    }
}
