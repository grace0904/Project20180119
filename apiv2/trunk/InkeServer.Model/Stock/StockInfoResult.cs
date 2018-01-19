using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 入库单 详细信息
    /// </summary>
    public class StockInfoResult
    {
        /// <summary>
        /// 库存批次ID
        /// </summary>
        public string ProductStorageBatch_ID { get; set; }
        /// <summary>
        /// 库存单号
        /// </summary>
        public string StorageBatch_Num { get; set; }
        /// <summary>
        /// 经办人-员工ID
        /// </summary>
        public string Handler { get; set; }
        /// <summary>
        /// 经办人名称-员工名称
        /// </summary>
        public string Handler_Name { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shop_Name { get; set; }
        /// <summary>
        /// 进库时间
        /// </summary>
        public DateTime? StorageTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        ///入库产品集合
        /// </summary>
        public List<StorageProductInfoReuslt> StorageProductList { get; set; }
    }
}
