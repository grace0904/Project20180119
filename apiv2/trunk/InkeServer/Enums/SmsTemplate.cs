using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Enums
{
    /// <summary>
    /// 短信模板类型
    /// </summary>
    public enum SmsTemplate : int
    {
        #region
        [Description("开通手机")]
        OpenMobile = 1,
        [Description("开通会员卡")]
        OpenCard = 2,
        [Description("绑定卡")]
        BoundCard = 3,
        [Description("充值")]
        CardRecharge = 4,
        [Description("优惠券充值")]
        CouponsRecharge = 5,
        [Description("会员消费")]
        MemberConsumption = 6,
        [Description("余额不足")]
        LessThan = 7,
        [Description("兑换")]
        Exchange = 8,
        [Description("挂失")]
        TheLoss = 9,
        [Description("撤消挂失")]
        UndoTheLoss = 10,
        [Description("更换会员卡")]
        ReplaceCard = 11,
        [Description("生日短信")]
        BirthdayMessage = 12,
        [Description("卡到期提醒")]
        CardExpirationReminder = 13,
        [Description("优惠券到期提醒")]
        CouponsExpireReminder = 14,
        [Description("积分调整")]
        IntegralAdjustment = 15,
        [Description("积分清零提醒")]
        IntegralZeroReminder = 16,
        [Description("自动促销-新会员")]
        AutoPromotionMember = 17,
        [Description("自动促销-充值")]
        AutomaticPromotionRecharge = 18,
        [Description("自动促销-消费")]
        AutoPromotionConsumption = 19,
        [Description("自动促销-积分")]
        AutoPromotionIntegral = 20,
        [Description("自动促销-节假日")]
        AutoPromotionHoliday = 21,
        [Description("自动促销-消费产品")]
        AutoPromotionProduct = 22,
        [Description("充值调整")]
        RechargeAdjustment = 23,
        [Description("消费调整")]
        ConsumptionAdjustment = 24,
        [Description("优惠券充值调整")]
        CouponRechargeAdjustment = 25,
        [Description("积分兑换调整")]
        IntegralExchangeAdjustment = 26,
        [Description("外卖确认下单")]
        TakeOutConfirmationOrder = 27,
        [Description("外卖送餐提醒")]
        DeliveryReminder = 28,
        [Description("自动促销-生日")]
        AutoPromotionBirthday = 29,
        [Description("预约成功")]
        AppointmentSuccess = 30,
        [Description("预约失败")]
        ReservationFailure = 31,
        [Description("外卖下单")]
        TakeOutOrder = 32,
        [Description("外卖送货")]
        TakeawayDelivery = 33,
        [Description("预约取消")]
        ReservationCancellation = 34
        #endregion
    }
}
