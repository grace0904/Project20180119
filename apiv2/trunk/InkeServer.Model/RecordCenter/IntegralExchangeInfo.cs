using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 积分兑换
    /// </summary>
    public class IntegralExchangeInfo
    {       
        #region
        /// <summary>
        /// ID
        /// </summary>
        public string Exchange_ID { get; set; }
        /// <summary>
        /// 业务号
        /// </summary>
        public string Business_Num { get; set; }
        /// <summary>
        /// 积分产品ID
        /// </summary>
        public string IntegralProduct_ID { get; set; }
        /// <summary>
        /// 店铺积分产品ID
        /// </summary>
        public string ShopIntegralProduct_ID { get; set; }
        /// <summary>
        /// 积分产品名
        /// </summary>
        public string Product_Name { get; set; }
        /// <summary>
        /// 产品所需积分
        /// </summary>
        public decimal? Product_Price { get; set; }
        /// <summary>
        /// 兑换产品数量
        /// </summary>
        public int? ProductQuantity { get; set; }
        /// <summary>
        /// 优惠券ID
        /// </summary>
        public string Coupon_ID { get; set; }
        /// <summary>
        /// 兑换优惠券
        /// </summary>
        public string Coupon_Name { get; set; }
        /// <summary>
        /// 优惠券所需积分
        /// </summary>
        public decimal? Coupon_Price { get; set; }
        /// <summary>
        /// 兑换优惠券数量
        /// </summary>
        public int? CouponQuantity { get; set; }
        /// <summary>
        /// 兑换储值
        /// </summary>
        public decimal? Exchange_Cash { get; set; }
        /// <summary>
        /// 扣除积分
        /// </summary>
        public decimal DeductIntegral { get; set; }
        /// <summary>
        /// 会员卡ID 
        /// </summary>
        public string Card_ID { get; set; }
        /// <summary>
        /// 业务卡号
        /// </summary>
        public string Card_BusinessID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        public string Member_ID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string User_ID { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperationTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 操作终端
        /// </summary>
        public string Terminal { get; set; }
        #endregion
    }
}
