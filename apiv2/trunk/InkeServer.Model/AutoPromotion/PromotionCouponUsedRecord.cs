using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 营销中心 使用记录返回类
    /// </summary>
    public class PromotionCouponUsedRecord
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public string CardCoupon_ID { get; set; }

        /// <summary>
        /// 方案名称名称
        /// </summary>
        public string PromotionName { get; set; }
        /// <summary>
        /// 促销类型 
        /// </summary>
        public string PromotionType { get; set; }
 
        /// <summary>
        /// 卡号
        /// </summary>
        public string Card_Num { get; set; }

        /// <summary>
        /// 会员姓名
        /// </summary>
        public string Member_Name { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Member_MobilePhone { get; set; }
        /// <summary>
        /// 使用时间
        /// </summary>
        public DateTime? UsedTime { get; set; }
        /// <summary>
        /// 使用店铺
        /// </summary>
        public string Shop_Name { get; set; }

        /// <summary>
        /// 使用优惠券名称
        /// </summary>
        public string Coupon_Name { get; set; }
        /// <summary>
        /// 抵扣金额
        /// </summary>
        public decimal? Coupon_DeductionPrice { get; set; }

    }
}
