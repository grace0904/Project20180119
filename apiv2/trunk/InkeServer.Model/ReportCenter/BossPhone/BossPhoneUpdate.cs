using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 老板报表修改实体类
    /// </summary>
    public class BossPhoneUpdate : BaseRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        public string BossReport_ID { get; set; }

        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID列表
        /// </summary>
        public string ShopList { get; set; }

        /// <summary>
        /// 报表名称
        /// </summary>
        public string BossReportName { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public int SendTime { get; set; }
        /// <summary>
        /// 状态  0 停止 1 生效
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 接收手机号码
        /// </summary>
        public string ReceiveMobilePhone { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 营业开始时间_小时
        /// </summary>
        public int BusinessBeginHour { get; set; }
        /// <summary>
        /// 营业开始时间_分钟
        /// </summary>
        public int BusinessBeginMinute { get; set; }
        /// <summary>
        ///   营业天数 0 当天 1 第二天 
        /// </summary>
        public int BusinessDate { get; set; }
        /// <summary>
        /// 营业结束时间_分钟
        /// </summary>
        public int BusinessEndMinute { get; set; }
        /// <summary>
        /// 营业结束时间_小时
        /// </summary>
        public int BusinessEndHour { get; set; }
        /// <summary>
        /// 发送周期 1 天 2 周 3 月
        /// </summary>
        public int SendCycle { get; set; }

        /// <summary>
        /// 会员增长数量 1
        /// </summary>
        public int MemberIncrease { get; set; }


        /// <summary>
        /// 开卡数量 1
        /// </summary>
        public int CardIncrease { get; set; }

        /// <summary>
        /// 消费总金额  
        /// </summary>
        public int ConsumeTotal { get; set; }
        /// <summary>
        /// 会员消费总金额  
        /// </summary>
        public int MemberConsumeTotal { get; set; }

        /// <summary>
        /// 会员充值金额 1
        /// </summary>
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
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
    }
}
