using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 添加/修改入库 请求类
    /// </summary>
    public class AddOrUpdateStockRequest : BaseRequest
    {
        /// <summary>
        /// 库存批次ID
        /// </summary>
        [DisplayName("库存批次ID")]
        public string ProductStorageBatch_ID { get; set; }
        /// <summary>
        /// 经办人
        /// </summary>
        [DisplayName("经办人")]
        public string Handler { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        [DisplayName("店铺ID")]
        public string Shop_ID { get; set; }
        /// <summary>
        /// 进库时间
        /// </summary>
        [DisplayName("进库时间")]
        public DateTime StorageTime { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName("商家ID")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]

        public string Operator { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]

        public string Remark { get; set; }
        /// <summary>
        /// 添加入库的产品集合
        /// </summary>
        public List<AddStorageProduct> StorageProductList { get; set; }
    }
}
