using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 营业报表 产品销售统计 返回类
    /// </summary>
    public class StatisticsProductResult
    {
        /// <summary>
        /// 产品类别名称
        /// </summary>
        public string MerchantBaseInfo_Name { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Product_Name { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string Product_Code { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shop_Name { get; set; }
        /// <summary>
        /// 产品售价
        /// </summary>
        public decimal? Product_Price { get; set; }
        /// <summary>
        /// 产品库存
        /// </summary>
        public int? ProductNum { get; set; }
        /// <summary>
        /// 销售数量
        /// </summary>
        public int? SalesQuantity { get; set; }
        /// <summary>
        /// 赠菜数量
        /// </summary>
        public int? GivenQuantity { get; set; }
        /// <summary>
        /// 退菜数量
        /// </summary>
        public int? ReturnQuantity { get; set; }
        /// <summary>
        /// 销售金额
        /// </summary>
        public decimal? SalesMoney { get; set; }
        /// <summary>
        /// 进货数量
        /// </summary>
        public int? StorageQuantity { get; set; }
        /// <summary>
        /// 进货金额
        /// </summary>
        public decimal? StoragePrice { get; set; }
    }
}
