using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 自动促销统计 返回类
    /// </summary>
    public  class PromotionStatistics
    {
        /// <summary>
        /// 自动促销类型
        /// </summary>
        public int PromotionType { get; set; }
        /// <summary>
        /// 方案总数
        /// </summary>
        public int PromotionTotal { get; set; }
        /// <summary>
        /// 赠送积分总数
        /// </summary>
        public double? GivenIntegralTotal { get; set; }
        /// <summary>
        /// 赠送优惠券总数
        /// </summary>
        public int GivenCouponsTotal { get; set; }
        /// <summary>
        /// 消费优惠券总数
        /// </summary>
        public int ComsumeCouponsTotal { get; set; }
        /// <summary>
        ///带动消费金额
        /// </summary>
        public decimal? ComsumeMoneyTotal { get; set; }
        /// <summary>
        /// 已发放人数 
        /// </summary>
        public int SendedPeopel { get; set; }
    }
}
