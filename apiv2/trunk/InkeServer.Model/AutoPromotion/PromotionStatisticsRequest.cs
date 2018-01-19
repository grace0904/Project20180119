using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 统计请求类
    /// </summary>
    public  class PromotionStatisticsRequest:BaseRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID，以逗号分隔
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 统计开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 统计结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 0-营销分析，1-自定义营销活动
        /// </summary>
        public int AutoExec { get; set; }
    }
}
