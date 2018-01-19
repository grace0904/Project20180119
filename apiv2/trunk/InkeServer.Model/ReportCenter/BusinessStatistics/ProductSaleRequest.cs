using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 营业报表 产品销售统计 请求实体类
    /// </summary>
    public  class ProductSaleRequest:BaseRequest
    {
        #region
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime DateForm { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime DateTo { get; set; }
        /// <summary>
        /// 会员性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 折扣类型ID
        /// </summary>
        public string Discount_ID { get; set; }
        /// <summary>
        /// 产品分类ID
        /// </summary>
        public string MerchantBaseInfo_ID { get; set; }
        /// <summary>
        /// 排列顺序  1  销量从高到低   2 销量从低到高
        /// </summary>
        public int? SortType { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string Operator { get; set; }
        #endregion
    }
}
