using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 老板报表新增实体类
    /// </summary>
    public class BossPhoneInsert : BaseRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName("商家ID")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID列表
        /// </summary>
        [DisplayName("店铺ID")]
        public string ShopList { get; set; }

        /// <summary>
        /// 报表名称
        /// </summary>
        [DisplayName("报表名称")]
        public string BossReportName { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        [DisplayName("发送时间")]
        public int SendTime { get; set; }
        /// <summary>
        /// 状态  0 停止 1 生效
        /// </summary>
        [DisplayName("状态")]
        public int Status { get; set; }
        /// <summary>
        /// 接收手机号码
        /// </summary>
        [DisplayName("接收手机号码")]
        public string ReceiveMobilePhone { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string Memo { get; set; }
        /// <summary>
        /// 营业开始时间_小时
        /// </summary>
        [DisplayName("营业开始时间_小时")]
        public int BusinessBeginHour { get; set; }
        /// <summary>
        /// 营业开始时间_分钟
        /// </summary>
        [DisplayName("营业开始时间_分钟")]
        public int BusinessBeginMinute { get; set; }
        /// <summary>
        ///   营业天数 0 当天 1 第二天 
        /// </summary>
        [DisplayName("营业天数")]
        public int BusinessDate { get; set; }
        /// <summary>
        /// 营业结束时间_分钟
        /// </summary>
        [DisplayName("营业结束时间_分钟")]
        public int BusinessEndMinute { get; set; }
        /// <summary>
        /// 营业结束时间_小时
        /// </summary>
        [DisplayName("营业结束时间_小时")]
        public int BusinessEndHour { get; set; }
        /// <summary>
        /// 发送周期 1 天 2 周 3 月
        /// </summary>
        [DisplayName("发送周期")]
        public int SendCycle { get; set; }

        /// <summary>
        /// 会员增长数量 1
        /// </summary>
        [DisplayName("会员增长数量")]
        public int MemberIncrease { get; set; }


        /// <summary>
        /// 开卡数量 1
        /// </summary>
        [DisplayName("开卡数量")]
        public int CardIncrease { get; set; }

        /// <summary>
        /// 消费总金额  
        /// </summary>
        [DisplayName("消费总金额")]
        public int ConsumeTotal { get; set; }
        /// <summary>
        /// 会员消费总金额  
        /// </summary>
        [DisplayName("会员消费总金额")]
        public int MemberConsumeTotal { get; set; }

        /// <summary>
        /// 会员充值金额 1
        /// </summary>
        [DisplayName("会员充值金额")]
        public int MemberRechargeTotal { get; set; }

        /// <summary>
        /// 会员充值赠送 1
        /// </summary>
        public int MemberRechargeGiveTotal { get; set; }

        /// <summary>
        /// 散客消费 1
        /// </summary>
        public int IndividualConsumeTotal { get; set; }

        /// <summary>
        /// 优惠券充值数量 1
        /// </summary>
        public int CouponRechargeQuantity { get; set; }
        /// <summary>
        /// 优惠券使用数量   1
        /// </summary>
        public int CouponUseQuantity { get; set; }


        /// <summary>
        /// 会员产生积分 1
        /// </summary>
        public int MemberAddIntegral { get; set; }

        /// <summary>
        /// 会员扣除积分 1
        /// </summary>
        public int MemberReductionIntegral { get; set; }

        /// <summary>
        /// 会员总余额 1
        /// </summary>
        public int MemberMoneyTotal { get; set; }

        /// <summary>
        /// 会员总积分 1
        /// </summary>
        public int MemberIntegralTotal { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]
        public string Operator { get; set; }
    }
}
