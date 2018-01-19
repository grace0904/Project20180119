using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class AddOrUpdateMerchantProduct : BaseRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
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
        public string Product_Name { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        [DisplayName("产品编号")]
        public string Product_Code { get; set; }
        /// <summary>
        /// 拼音简码
        /// </summary>
        [DisplayName("拼音简码")]
        public string Product_SpellCode { get; set; }
        /// <summary>
        /// 产品单位
        /// </summary>
        [DisplayName("产品单位")]
        public string Product_Unit { get; set; }
        /// <summary>
        /// 产品单价
        /// </summary>
        [DisplayName("产品单价")]
        public Decimal Product_Price { get; set; }
        /// <summary>
        /// 产品大图
        /// </summary>
        [DisplayName("产品大图")]
        public string Product_BPic { get; set; }
        /// <summary>
        /// 产品小图
        /// </summary>
        [DisplayName("产品小图")]
        public string Product_SPic { get; set; }
        /// <summary>
        /// 折扣 0 不打折 1 打折
        /// </summary>
        [DisplayName("折扣")]
        public int Product_Discount { get; set; }
        /// <summary>
        /// 是否套餐 0 否 1 是
        /// </summary>
        [DisplayName("是否套餐")]
        public int Combo { get; set; }
        /// <summary>
        /// 产品说明
        /// </summary>
        [DisplayName("产品说明")]
        public string Product_Memo { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName("产品类别")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]
        public string Operator { get; set; }
        /// <summary>
        /// 产品的可用店铺列表ID集合
        /// </summary>
        [DisplayName("产品的可用店铺列表")]
        public string UsableShopList { get; set; }

        /// <summary>
        /// 套餐产品的套餐列表:如是套餐产品：ID1，ID2,否则为""
        /// </summary>
        [DisplayName("套餐产品的套餐列表")]
        public string ComboGroupList { get; set; }
    }
}
