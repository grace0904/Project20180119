using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    ///  订单菜品基础类
    /// </summary>
    [Serializable]
    public class OrderBasket
    {
        #region Model
        /// <summary>
        /// 
        /// </summary>
        public string Bask_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Order_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Product_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShopProduct_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Bask_Units { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Bask_Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Bask_Count { get; set; }
        /// <summary>
        /// 折扣率
        /// </summary>
        public int? Bask_Discount { get; set; }
        /// <summary>
        /// 总计
        /// </summary>
        public decimal? Bask_Total { get; set; }
        /// <summary>
        /// 作法
        /// </summary>
        public string Bask_Zuofa { get; set; }
        /// <summary>
        /// 菜品状态 1即起 2叫起
        /// </summary>
        public int? Bask_Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Merchant_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Shop_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Member_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string User_Id { get; set; }
        /// <summary>
        /// 打印状态 0 未送单 1已送单
        /// </summary>
        public int? Bask_PrintStatus { get; set; }
        /// <summary>
        /// 终端
        /// </summary>
        public int? Bask_Terminal { get; set; }
        /// <summary>
        /// 上菜数量
        /// </summary>
        public int? Bask_ScCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Bask_GivenCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Bask_ReturnCount { get; set; }
        /// <summary>
        /// 套餐组ID
        /// </summary>
        public string Combo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Del { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OptionTimestamp { get; set; }
        #endregion Model
    }
}
