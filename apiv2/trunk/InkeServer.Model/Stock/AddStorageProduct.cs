using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 添加 入库产品
    /// </summary>
    public  class AddStorageProduct
    {
        /// <summary>
        /// 店铺产品ID
        /// </summary>
        [DisplayName("店铺产品ID")]
        public string ShopProduct_ID { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        [DisplayName("产品ID")]
        public string Product_ID { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        [DisplayName("入库数量")]
        public int StorageNum { get; set; }
        /// <summary>
        /// 入库单价
        /// </summary>
        [DisplayName("入库单价")]
        public decimal ProductPrice { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string Memo { get; set; }
    }
}
