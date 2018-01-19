using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 产品详细信息- 返回类
    /// </summary>
    public  class MerchantProductInfoResult
    {
        /// <summary>
        /// 产品种类名称
        /// </summary>
        public string MerchantBaseInfo_Name { get; set; }
        #region Model
      
        /// <summary>
        /// ID
        /// </summary>
        public string Product_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 产品类别
        /// </summary>
        public string MerchantBaseInfo_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Product_Name
        {
            set;
            get;
        }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string Product_Code
        {
            set;
            get;
        }
        /// <summary>
        /// 拼音简码
        /// </summary>
        public string Product_SpellCode
        {
            set;
            get;
        }
        /// <summary>
        /// 产品单位
        /// </summary>
        public string Product_Unit
        {
            set;
            get;
        }
        /// <summary>
        /// 产品单价
        /// </summary>
        public decimal Product_Price
        {
            set;
            get;
        }
        /// <summary>
        /// 产品大图
        /// </summary>
        public string Product_BPic
        {
            set;
            get;
        }
        /// <summary>
        /// 产品小图
        /// </summary>
        public string Product_SPic
        {
            set;
            get;
        }
        /// <summary>
        /// 折扣 0 不打折 1 打折
        /// </summary>
        public int Product_Discount
        {
            set;
            get;
        }
        /// <summary>
        /// 是否套餐 0 否 1 是
        /// </summary>
        public int Combo
        {
            set;
            get;
        }
        /// <summary>
        /// 产品说明
        /// </summary>
        public string Product_Memo
        {
            set;
            get;
        }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime
        {
            set;
            get;
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperationTime
        {
            set;
            get;
        }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator
        {
            set;
            get;
        }

        #endregion Model
        /// <summary>
        /// 可用店铺集合
        /// </summary>
        public string UseableShopList { get; set; }
        /// <summary>
        /// 已选套餐组集合
        /// </summary>
        public string ComboGroupList { get; set; }
    }
}
