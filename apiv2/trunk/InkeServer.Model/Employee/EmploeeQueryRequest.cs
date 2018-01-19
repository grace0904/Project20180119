using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 分页查询店铺员工请求类
    /// </summary>
    public class EmploeeQueryRequest : PaginationRequest
    {
        /// <summary>
        /// 账号ID
        /// </summary>
        public string Account_ID { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_ID { get; set; }

        /// <summary>
        /// 员工Code
        /// </summary>
        public string Employee_Code { get; set; }
        /// <summary>
        /// 员工名称
        /// </summary>
        public string Employee_Name { get; set; }
        /// <summary>
        /// 员工电话
        /// </summary>
        public string Employee_Tel { get; set; }
    }
}
