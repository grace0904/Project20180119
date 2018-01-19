using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 结果明细返回类 
    /// </summary>
    public  class MarketingAnalyzeDetialsResult
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Card_ID
        /// </summary>
        public string Card_ID { get; set; }
        /// <summary>
        /// Card_BusinessID
        /// </summary>
        public string Card_BusinessID { get; set; }

        /// <summary>
        /// 方案名称
        /// </summary>
        public string MarketingAnalyze_Name { get; set; }
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string Card_Num { get; set; }
        /// <summary>
        /// Member_ID 
        /// </summary>
        public string Member_ID { get; set; }

        /// <summary>
        /// 会员名称
        /// </summary>
        public string Member_Name { get; set; }

        /// <summary>
        /// 会员电话
        /// </summary>
        public string Member_MobilePhone { get; set; }


        /// <summary>
        /// 会员生日
        /// </summary>
        public DateTime Member_Birthday { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime Member_RegisterTime { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Member_Sex { get; set; }

        /// <summary>
        /// 最后消费时间
        /// </summary>
        public DateTime? LastConsumeTime { get; set; }

        /// <summary>
        /// 卡余额
        /// </summary>
        public decimal Card_Cash { get; set; }
        /// <summary>
        /// 卡积分
        /// </summary>
        public decimal Card_Integral { get; set; }
        /// <summary>
        /// 消费次数
        /// </summary>
        public int ConsumeCount { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal ConsumeMoney { get; set; }

        /// <summary>
        /// 抵扣次数
        /// </summary>
        public int DeductionCount { get; set; }
        /// <summary>
        /// 抵扣金额
        /// </summary>
        public decimal DeductionMoney { get; set; }

        /// <summary>
        /// 充值次数
        /// </summary>
        public int RechargeCount { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal RechargeMoney { get; set; }
        /// <summary>
        /// 剩余优惠券
        /// </summary>
        public int UnusedCoupon { get; set; }
    }
}
