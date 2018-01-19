using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 分页查询会员列表请求类
    /// </summary>
    public class MemberQueryRequest : PaginationRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string Member_Name { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Member_MobilePhone { get; set; }
        /// <summary>
        /// 注册开始时间
        /// </summary>
        public DateTime? RegisterTimeFrom { get; set; }
        /// <summary>
        /// 注册结束时间
        /// </summary>
        public DateTime? RegisterTimeTo { get; set; }
    }
}
