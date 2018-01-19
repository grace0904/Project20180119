using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class RecordCenterIndexRequest : BaseRequest
    {
        /// <summary>
        /// 商家 ID
        /// </summary>
        public string Merchant_ID { get; set; }
        ///<summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Begin_Time { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime End_Time { get; set; }

    }
}
