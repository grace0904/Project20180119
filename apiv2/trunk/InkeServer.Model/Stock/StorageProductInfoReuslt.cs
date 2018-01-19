using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 入库产品详细信息
    /// </summary>
   public   class StorageProductInfoReuslt
    {
        /// <summary>
        /// 店铺产品ID
        /// </summary>
        public string ShopProduct_ID { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public string Product_ID { get; set; }
        /// <summary>
        /// 产品分类
        /// </summary>
        public string MerchantBaseInfo_ID { get; set; }
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
        /// 入库数量
        /// </summary>
        public int? Storage_Number { get; set; }
        /// <summary>
        /// 入库单价
        /// </summary>
        public decimal? Storage_Price { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
