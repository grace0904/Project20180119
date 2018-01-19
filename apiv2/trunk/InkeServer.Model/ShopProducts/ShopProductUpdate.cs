using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class ShopProductUpdate : BaseRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("店铺产品ID")]
        public string ShopProduct_ID { get; set; }
        /// <summary>
        /// 商家产品ID
        /// </summary>
        [DisplayName("商家产品ID")]
        public string Product_ID { get; set; }
        /// <summary>
        /// 产品类别
        /// </summary>
        [DisplayName("产品类别")]
        public string MerchantBaseInfo_ID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        [DisplayName("产品名称")]
        public string Name { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [DisplayName("产品编号")]
        public string Code { get; set; }
        /// <summary>
        /// 拼音简码
        /// </summary>
        public string SpellCode { get; set; }
        /// <summary>
        /// 产品单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 产品单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 产品大图
        /// </summary>
        public string BPic { get; set; }
        /// <summary>
        /// 产品小图
        /// </summary>
        public string SPic { get; set; }
        /// <summary>
        /// 折扣 0 不打折 1 打折
        /// </summary>
        public int Discount { get; set; }
        /// <summary>
        /// 是否套餐 0 否 1 是
        /// </summary>
        public int Combo { get; set; }
        /// <summary>
        /// 产品说明
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 沽清 0 否 1 是
        /// </summary>
        public int? GuQing { get; set; }
        /// <summary>
        /// 库存数
        /// </summary>
        [DisplayName("库存数")]
        public int? ProductNum { get; set; }
        /// <summary>
        /// 是否受库存限制
        /// </summary>
        [DisplayName("是否受库存限制")]
        public int UseRepertory { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName("商家ID")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        [DisplayName("店铺ID")]
        public string Shop_ID { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]
        public string Operator { get; set; }
    }
}
