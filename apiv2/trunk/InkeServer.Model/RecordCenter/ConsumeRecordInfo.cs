using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 消费记录详细信息
    /// </summary>
    public class ConsumeRecordInfo
    {
        #region
        /// <summary>
        /// 订单ID
        /// </summary>
        public string Order_ID { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public int Order_Class { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string Business_Num { get; set; }
        /// <summary>
        /// 会员卡ID
        /// </summary>
        public string Card_ID { get; set; }
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string Card_Num { get; set; }
        /// <summary>
        /// 会员卡业务ID
        /// </summary>
        public string Card_BusinessID { get; set; }
        /// <summary>
        /// 折扣类型
        /// </summary>
        public string Discount_Name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Member_MobilePhone { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        public string Member_ID { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string Member_Name { get; set; }
        /// <summary>
        /// 开台时间
        /// </summary>
        public DateTime? OpenSeatTime { get; set; }
        /// <summary>
        /// 订单折扣
        /// </summary>
        //   public decimal Discount { get; set; }
        public int? Discount { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal ConsumeMoney { get; set; }
        /// <summary>
        /// 折扣金额
        /// </summary>
        public decimal? DiscountMoney { get; set; }
        /// <summary>
        /// 优惠券抵扣金额
        /// </summary>
        public decimal? CouponMoney { get; set; }
        /// <summary>
        /// 积分抵扣金额
        /// </summary>
        public decimal? IntegralMoney { get; set; }
        /// <summary>
        /// 抹零金额
        /// </summary>
        public decimal? ReduceMantissaMoney { get; set; }
        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal? FinalMoney { get; set; }
        /// <summary>
        /// 实收金额
        /// </summary>
        public decimal? ActualIncomeMoney { get; set; }
        /// <summary>
        /// 获得积分 
        /// </summary>
        public decimal? Order_GetIntegral { get; set; }
        /// <summary>
        /// 现金支付
        /// </summary>
        public decimal? CashPay { get; set; }
        /// <summary>
        /// 银行卡支付
        /// </summary>
        public decimal? BankCardPay { get; set; }
        /// <summary>
        /// 会员卡支付
        /// </summary>
        public decimal? MemberCardPay { get; set; }
        /// <summary>
        /// 支付宝支付
        /// </summary>
        public decimal? AliPayPay { get; set; }
        /// <summary>
        /// 微信支付
        /// </summary>
        public decimal? WeiXinPay { get; set; }
        /// <summary>
        /// 团购券支付
        /// </summary>
        public decimal? GroupbuyPay { get; set; }
        /// <summary>
        /// 挂帐金额
        /// </summary>
        public decimal? GuaZhangMoney { get; set; }
        /// <summary>
        /// 就餐座位
        /// </summary>
        public string Seat_Name { get; set; }
        /// <summary>
        /// 就餐人数
        /// </summary>
        public int? Order_People { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperationTime { get; set; }
        /// <summary>
        /// 操作终端
        /// </summary>
        public string Terminal { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shop_Name { get; set; }
        /// <summary>
        /// 调整标识 0 正常记录 1 历史记录
        /// </summary>
        public int? Adjust { get; set; }
        /// <summary>
        /// 结账时间 
        /// </summary>
        public DateTime? FinalTime { get; set; }
        #endregion
    }
}
