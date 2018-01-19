using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 产品库存统计结果集
    /// </summary>
    public class StorageStatisticsResult
    {
        public int ID { get; set; }
        /// <summary>
        ///  产品ID
        /// </summary>
        public string Product_ID { get; set; }
        /// <summary>
        /// 产品分类名称
        /// </summary>
        public string MerchantBaseInfo_Name { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Product_Name { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string Product_Code { get; set; }
        /// <summary>
        /// 产品单位
        /// </summary>
        public string Product_Unit { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shop_Name { get; set; }
        /// <summary>
        /// 入库总数
        /// </summary>
        public int? StorageTotal { get; set; }
        /// <summary>
        /// 销售总数
        /// </summary>
        public int? SaleTotal { get; set; }
        /// <summary>
        /// 期初库存
        /// </summary>
        public int? InitialStorageTotal { get; set; }
    }
}
