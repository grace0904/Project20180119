using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 返回给PC端的商家配置和商家名称信息
    /// </summary>
    public class MerchantConfigAndName
    {
        /// <summary>
        /// 商家名称信息
        /// </summary>
        public MerchantName MerchantName { get; set; }
        /// <summary>
        /// 商家配置信息
        /// </summary>
        public MerchantConfigBasic MerchantConfig { get; set; }
    }
    public class MerchantName
    {
        #region name
        public string Merchant_ID { get; set; }
        public string Merchant_Name { get; set; }
        public string Merchant_ShortName { get; set; }
        #endregion
    }
    public class MerchantConfigBasic
    {
        #region config

        /// <summary>
        /// 
        /// </summary>
        public string MerchantConfig_ID { get; set; }
        /// <summary>
        /// 经营范围
        /// </summary>
        public string BusinessScope_ID { get; set; }
        /// <summary>
        /// 短信数量
        /// </summary>
        public int? SmsCount { get; set; }
        /// <summary>
        /// 是否开启消费自动升级 0 否 1 是
        /// </summary>
        public int? ConsumeAutoUpdate { get; set; }
        /// <summary>
        /// 是否开启充值自动升级 0 否 1 是
        /// </summary>
        public int? RechargeAutoUpdate { get; set; }
        /// <summary>
        /// 登录弹窗提示 0 否 1 是
        /// </summary>
        public int? Pop { get; set; }
        /// <summary>
        /// 折扣比率
        /// </summary>
        public decimal DiscountRate { get; set; }
        /// <summary>
        /// 积分比率
        /// </summary>
        public decimal IntegralRate { get; set; }
        /// <summary>
        /// 现金比率
        /// </summary>
        public decimal CashRate { get; set; }
        /// <summary>
        /// 积分定时清空0 不清空 1 满一年清空 2 定时清空
        /// </summary>
        public int IntegraClear { get; set; }
        /// <summary>
        /// 积分截止时间
        /// </summary>
        public DateTime? IntegraEndTime { get; set; }
        /// <summary>
        /// 积分清空时间
        /// </summary>
        public DateTime? IntegraClearTime { get; set; }
        /// <summary>
        /// 积分清空前短信提醒 0 不发送 1 发送
        /// </summary>
        public int? IntegraClearBeforeSms { get; set; }
        /// <summary>
        /// 积分清空前几天发送(默认当天发送)
        /// </summary>
        public int? IntegraClearBeforeDate { get; set; }
        /// <summary>
        /// 积分清空后短信 0 不发送 1 发送
        /// </summary>
        public int? IntegraClearFinishSms { get; set; }
        /// <summary>
        /// 跨月数据调整 0 否 1 是
        /// </summary>
        public int? SpanMonthAdjust { get; set; }
        /// <summary>
        /// 消费金额输入方式 0 手动 1 自动
        /// </summary>
        public int? ConsumeInputType { get; set; }
        /// <summary>
        /// 扣费金额自动输入 0 否 1 是
        /// </summary>
        public int? DeductMoneyAutoInput { get; set; }
        /// <summary>
        /// 显示消费确认框 0 否 1 是
        /// </summary>
        public int? ShowAffirm { get; set; }
        /// <summary>
        /// 仅支付会员卡消费 0 否 1 是
        /// </summary>
        public int? OnlyCardConsume { get; set; }
        /// <summary>
        /// 消费时不允许修改折扣 0 否 1 是
        /// </summary>
        public int? NotEditRate { get; set; }
        /// <summary>
        /// 消费时允许关闭积分 0 否 1 是
        /// </summary>
        public int? CanCloseIntegra { get; set; }
        /// <summary>
        /// 手机号绑定多张卡 0 否 1 是
        /// </summary>
        public int? MemberMultiCard { get; set; }
        /// <summary>
        /// 会员卡号允许空 0 否 1 是
        /// </summary>
        public int? CardNumberNull { get; set; }
        /// <summary>
        /// 积分兑换允许手动输入 0 否 1  是
        /// </summary>
        public int? IntegraConvertManualInput { get; set; }
        /// <summary>
        /// 支持外卖 0 否 1 是
        /// </summary>
        public int? OpenTakeAway { get; set; }
        /// <summary>
        /// 支持预约 0 否 1 是
        /// </summary>
        public int? OpenReservation { get; set; }
        /// <summary>
        /// 支持堂食下单 0 否 1 是
        /// </summary>
        public int? OpenSelfOrder { get; set; }
        /// <summary>
        /// 支持堂食结帐 0 否 1 是
        /// </summary>
        public int? OpenSelfPay { get; set; }
        /// <summary>
        /// 口味
        /// </summary>
        public string Taste { get; set; }
        /// <summary>
        /// 主营
        /// </summary>
        public string MainScope { get; set; }
        /// <summary>
        /// 特殊要求
        /// </summary>
        public string SpecialRequire { get; set; }
        /// <summary>
        /// 商家简介
        /// </summary>
        public string Introduce { get; set; }
        /// <summary>
        /// 商家编号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 抹零设置 0 不抹零 1 抹小数 2 抹个位 3 抹十位
        /// </summary>
        public int? ReduceMantissaSet { get; set; }
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
