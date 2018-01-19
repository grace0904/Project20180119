using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class MerchantConfigUpdateRequest : BaseRequest
    {
        #region basic
        /// <summary>
        /// 商家名称
        /// </summary>
        [DisplayName("商家名称")]
        public string Merchant_Name { get; set; }
        /// <summary>
        /// 商家简称
        /// </summary>
        [DisplayName("商家简称")]
        public string Merchant_ShortName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("ID")]
        public string MerchantConfig_ID { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName("商家ID")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 经营范围
        /// </summary>
        [DisplayName("经营范围")]
        public string BusinessScope_ID { get; set; }
        /// <summary>
        /// 短信数量
        /// </summary>
        [DisplayName("短信数量")]
        public int? SmsCount { get; set; }
        /// <summary>
        /// 是否开启消费自动升级 0 否 1 是
        /// </summary>
        [DisplayName("是否开启消费自动升级")]
        public int? ConsumeAutoUpdate { get; set; }
        /// <summary>
        /// 是否开启充值自动升级 0 否 1 是
        /// </summary>
        [DisplayName("是否开启充值自动升级")]
        public int? RechargeAutoUpdate { get; set; }
        /// <summary>
        /// 登录弹窗提示 0 否 1 是
        /// </summary>
        [DisplayName("登录弹窗提示")]
        public int? Pop { get; set; }
        /// <summary>
        /// 折扣比率
        /// </summary>
        [DisplayName("折扣比率")]
        public decimal DiscountRate { get; set; }
        /// <summary>
        /// 积分比率
        /// </summary>
        [DisplayName("积分比率")]
        public decimal IntegralRate { get; set; }
        /// <summary>
        /// 现金比率
        /// </summary>
        [DisplayName("现金比率")]
        public decimal CashRate { get; set; }
        /// <summary>
        /// 积分定时清空0 不清空 1 满一年清空 2 定时清空
        /// </summary>
        [DisplayName("积分定时清空")]
        public int IntegraClear { get; set; }
        /// <summary>
        /// 积分截止时间
        /// </summary>
        [DisplayName("积分截止时间")]
        public DateTime? IntegraEndTime { get; set; }
        /// <summary>
        /// 积分清空时间
        /// </summary>
        [DisplayName("积分清空时间")]
        public DateTime? IntegraClearTime { get; set; }
        /// <summary>
        /// 积分清空前短信提醒 0 不发送 1 发送
        /// </summary>
        [DisplayName("积分清空前短信提醒")]
        public int? IntegraClearBeforeSms { get; set; }
        /// <summary>
        /// 积分清空前几天发送(默认当天发送)
        /// </summary>
        [DisplayName("积分清空前几天发送")]
        public int? IntegraClearBeforeDate { get; set; }
        /// <summary>
        /// 积分清空后短信 0 不发送 1 发送
        /// </summary>
        [DisplayName("积分清空后短信")]
        public int? IntegraClearFinishSms { get; set; }
        /// <summary>
        /// 跨月数据调整 0 否 1 是
        /// </summary>
        [DisplayName("跨月数据调整")]
        public int? SpanMonthAdjust { get; set; }
        /// <summary>
        /// 消费金额输入方式 0 手动 1 自动
        /// </summary>
        [DisplayName("消费金额输入方式")]
        public int? ConsumeInputType { get; set; }
        /// <summary>
        /// 扣费金额自动输入 0 否 1 是
        /// </summary>
        [DisplayName("扣费金额自动输入")]
        public int? DeductMoneyAutoInput { get; set; }
        /// <summary>
        /// 显示消费确认框 0 否 1 是
        /// </summary>
        [DisplayName("显示消费确认框")]
        public int? ShowAffirm { get; set; }
        /// <summary>
        /// 仅支付会员卡消费 0 否 1 是
        /// </summary>
        [DisplayName("仅支付会员卡消费")]
        public int? OnlyCardConsume { get; set; }
        /// <summary>
        /// 消费时不允许修改折扣 0 否 1 是
        /// </summary>
        [DisplayName("消费时不允许修改折扣")]
        public int? NotEditRate { get; set; }
        /// <summary>
        /// 消费时允许关闭积分 0 否 1 是
        /// </summary>
        [DisplayName("消费时允许关闭积分")]
        public int? CanCloseIntegra { get; set; }
        /// <summary>
        /// 手机号绑定多张卡 0 否 1 是
        /// </summary>
        [DisplayName("手机号绑定多张卡")]
        public int? MemberMultiCard { get; set; }
        /// <summary>
        /// 会员卡号允许空 0 否 1 是
        /// </summary>
        [DisplayName("会员卡号允许空")]
        public int? CardNumberNull { get; set; }
        /// <summary>
        /// 积分兑换允许手动输入 0 否 1  是
        /// </summary>
        [DisplayName("积分兑换允许手动输入")]
        public int? IntegraConvertManualInput { get; set; }
        /// <summary>
        /// 支持外卖 0 否 1 是
        /// </summary>
        [DisplayName("支持外卖")]
        public int? OpenTakeAway { get; set; }
        /// <summary>
        /// 支持预约 0 否 1 是
        /// </summary>
        [DisplayName("支持预约")]
        public int? OpenReservation { get; set; }
        /// <summary>
        /// 支持堂食下单 0 否 1 是
        /// </summary>
        [DisplayName("支持堂食下单")]
        public int? OpenSelfOrder { get; set; }
        /// <summary>
        /// 支持堂食结帐 0 否 1 是
        /// </summary>
        [DisplayName("支持堂食结帐")]
        public int? OpenSelfPay { get; set; }
        /// <summary>
        /// 口味
        /// </summary>
        [DisplayName("口味")]
        public string Taste { get; set; }
        /// <summary>
        /// 主营
        /// </summary>
        [DisplayName("主营")]
        public string MainScope { get; set; }
        /// <summary>
        /// 特殊要求
        /// </summary>
        [DisplayName("特殊要求")]
        public string SpecialRequire { get; set; }
        /// <summary>
        /// 商家简介
        /// </summary>
        [DisplayName("商家简介")]
        public string Introduce { get; set; }
        /// <summary>
        /// 商家编号
        /// </summary>
        [DisplayName("商家编号")]
        public string Number { get; set; }
        /// <summary>
        /// 抹零设置 0 不抹零 1 抹小数 2 抹个位 3 抹十位
        /// </summary>
        [DisplayName("抹零设置")]
        public int? ReduceMantissaSet { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]
        public string Operator { get; set; }
        #endregion

        /// <summary>
        /// 选中店铺ID
        /// </summary>
        [DisplayName("选中店铺ID")]
        public string ShopList { get; set; }
    }
}
