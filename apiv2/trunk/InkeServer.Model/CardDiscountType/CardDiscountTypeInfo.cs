using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 会员卡折扣类型 基础类
    /// </summary>
    [Serializable]
    public class CardDiscountTypeInfo
    {
        #region Model
        /// <summary>
        /// ID
        /// </summary>
        public string Discount_ID { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 折扣名称
        /// </summary>
        public string Discount_Name { get; set; }
        /// <summary>
        /// 消费获得积分
        /// </summary>
        public decimal ConsumeGetIntegral { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal ConsumeCash { get; set; }
        /// <summary>
        /// 充值获得积分
        /// </summary>
        public decimal RechargeGetIntegral { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal RechargeCash { get; set; }
        /// <summary>
        /// 开卡赠送积分
        /// </summary>
        public decimal OpenCardGetIntegral { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public int Discount { get; set; }
        /// <summary>
        /// 是否允许网上申请 0 否 1 是
        /// </summary>
        public int Apply { get; set; }
        /// <summary>
        /// 会员卡图片
        /// </summary>
        public string Card_Pic { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 充值自动升级 0 关闭 1 开启
        /// </summary>
        public int? RechargeAutoUpdate { get; set; }
        /// <summary>
        /// 自动升级充值金额
        /// </summary>
        public decimal? RechargeMoney { get; set; }

        public string RechargeUpdateTo { get; set; }
        /// <summary>
        /// 消费自动升级 0 关闭 1 开启
        /// </summary>
        public int? ConsumeAutoUpdate { get; set; }
        /// <summary>
        /// 消费自动升级累计金额
        /// </summary>
        public decimal? ConsumeMoney { get; set; }

        public string ConsumeUpdateTo { get; set; }
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
