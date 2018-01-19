using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 入库记录查询返回类
    /// </summary>
    public class StockQueryResult
    {
        /// <summary>
        /// 入库记录ID
        /// </summary>
        public string ProductStorage_ID { get; set; }
        /// <summary>
        /// 入库批次ID
        /// </summary>
        public string ProductStorageBatch_ID { get; set; }
        /// <summary>
        /// 入库单号
        /// </summary>
        public string StorageBatch_Num { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string Product_Code { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Product_Name { get; set; }
        /// <summary>
        /// 产品单位
        /// </summary>
        public string Product_Unit { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public int? Storage_Number { get; set; }
        /// <summary>
        /// 入库单价
        /// </summary>
        public decimal? Storage_Price { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime? StorageTime { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shop_Name { get; set; }
    }
}
