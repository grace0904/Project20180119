using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 分页获取账号集合 请求类
    /// </summary>
    public class AccountQueryRequest:PaginationRequest
    {
        /// <summary>
        /// 当前登陆账号ID
        /// </summary>
        public string LoginAccount_ID { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID，如为"",则查询当前账号可查看的全部店铺
        /// </summary>
        public string Shop_ID { get; set; }
        /// <summary>
        /// 职位ID
        /// </summary>
        public string Position_ID { get; set; }
    }
}
