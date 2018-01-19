using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*2016-08-10取消会员日促销*/

namespace InkeServer.Enums
{
    /// <summary>
    ///  促销方案类型
    /// </summary>
    public enum AutoPromotion : int
    {
        /// <summary>
        /// 新开通会员促销
        /// </summary>
        [Description("新开通会员促销")]
        NewMember = 1,
        /// <summary>
        /// 单笔充值促销
        /// </summary>
        [Description("单笔充值促销")]
        RechargePromotion = 2,
        /// <summary>
        /// 单笔消费促销
        /// </summary>
        [Description("单笔消费促销")]
        ConsumptionPromotion = 3,
        /// <summary>
        /// 剩余积分促销
        /// </summary>
        [Description("剩余积分促销")]
        IntegralPromotion = 4,
        /// <summary>
        /// 节假日促销
        /// </summary>
        [Description("节假日促销")]
        DateTimePromotion = 5,
        /// <summary>
        /// 生日促销
        /// </summary>
        [Description("生日促销")]
        BrithdayPromotion = 6,
        /// <summary>
        /// 累积充值促销
        /// </summary>
        [Description("累计充值促销")]
        MultipleRechargePromotion = 7,
        /// <summary>
        /// 累计消费促销
        /// </summary>
        [Description("累计消费促销")]
        MultipleConsumptionPromotion = 8,
        ///// <summary>
        ///// 会员日促销
        ///// </summary>
        //[Description("会员日促销")]
        //MemberPromotion = 9,
    }
}
