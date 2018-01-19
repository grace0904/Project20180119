using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 优惠券信息
    /// </summary>
    public class CouponRechargeInfo
    {
        #region Model
        /// <summary>
        /// ID
        /// </summary>
        public string CouponRecord_ID { get; set; }
        /// <summary>
        /// 业务号
        /// </summary>
        public string Business_Num { get; set; }
        /// <summary>
        /// 项目描述（文字描述项目与数量)
        /// </summary>
        public string Coupon_Record { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal Coupon_Total { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal PayCash { get; set; }
        /// <summary>
        /// 会员卡支付金额
        /// </summary>
        public decimal? CardPayCash { get; set; }
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
        /// 员工姓名
        /// </summary>
        public string Employee_ID { get; set; }

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
        #endregion Model
    }
}
