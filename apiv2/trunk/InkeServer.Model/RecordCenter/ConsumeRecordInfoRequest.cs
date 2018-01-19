using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 消费记录调整/记录查找 请求实体类
    /// </summary>
    public class ConsumeRecordInfoRequest : BaseRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public string Order_ID { get; set; }
        /// <summary>
        /// 0-消费记录查找，1-调整记录查询
        /// </summary>
        public int Adjust { get; set; }
    }
}
