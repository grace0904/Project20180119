using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 订单基础类
    /// </summary>
    [Serializable]
    public class Order
    {
        #region Model

        /// <summary>
        /// ID
        /// </summary>
        public string Order_ID { get; set; }
        /// <summary>
        /// 业务号
        /// </summary>
        public string Business_Num { get; set; }
        /// <summary>
        /// 消费流水号
        /// </summary>
        public string SN { get; set; }
        /// <summary>
        /// 订单类别 1 堂食 2 外卖 3 会员扣费
        /// </summary>
        public int Order_Class { get; set; }
        /// <summary>
        /// 订单流程 0 新订单 9 已完成
        /// 
        /// </summary>
        public int Order_Process { get; set; }
        /// <summary>
        /// 订单状态 0 未支付 1 已支付
        /// </summary>
        public int Order_Status { get; set; }
        /// <summary>
        /// 座位ID
        /// </summary>
        public string Seat_ID { get; set; }
        /// <summary>
        /// 就餐人数
        /// </summary>
        public int? Order_People { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal ConsumeMoney { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Discount { get; set; }
        /// <summary>
        /// 折扣金额
        /// </summary>
        public decimal DiscountMoney { get; set; }
        /// <summary>
        /// 项目抵扣
        /// </summary>
        public decimal CouponMoney { get; set; }
        /// <summary>
        /// 积分抵扣
        /// </summary>
        public decimal IntegralMoney { get; set; }
        /// <summary>
        /// 抹零金额
        /// </summary>
        public decimal ReduceMantissaMoney { get; set; }
        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal FinalMoney { get; set; }
        /// <summary>
        /// 实收金额
        /// </summary>
        public decimal ActualIncomeMoney { get; set; }
        /// <summary>
        /// 是否挂帐 0 否 1 是
        /// </summary>
        public int IsGuaZhang { get; set; }
        /// <summary>
        /// 挂帐金额
        /// </summary>
        public decimal GuaZhangMoney { get; set; }
        /// <summary>
        /// 订单获取积分
        /// </summary>
        public decimal Order_GetIntegral { get; set; }
        /// <summary>
        /// 是否关闭积分
        /// </summary>
        public int CloseIntegral { get; set; }
        /// <summary>
        /// 开台服务员
        /// </summary>
        public string Employee_ID { get; set; }
        /// <summary>
        /// 开台时间
        /// </summary>
        public DateTime OpenSeatTime { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime FinalTime { get; set; }
        /// <summary>
        /// 订单密码
        /// </summary>
        public string Order_Password { get; set; }
        /// <summary>
        /// 发票抬头
        /// </summary>
        public string Order_Invoice { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        public string Member_ID { get; set; }
        /// <summary>
        /// 会员卡ID
        /// </summary>
        public string Card_ID { get; set; }
        /// <summary>
        /// 会员卡业务ID
        /// </summary>
        public string Card_BusinessID { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public string Terminal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Adjust { get; set; }
        #endregion Model
    }
}
