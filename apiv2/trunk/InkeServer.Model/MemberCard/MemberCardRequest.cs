using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 会员卡列表请求类
    /// </summary>
    public class MemberCardRequest : PaginationRequest
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
        /// 会员姓名
        /// </summary>
        public string Member_Name { get; set; }
        /// <summary>
        /// 会员电话
        /// </summary>
        public string Member_MobilePhone { get; set; }
        /// <summary>
        /// card_id
        /// </summary>
        public string Card_ID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        public string Member_ID { get; set; }
        /// <summary>
        /// 卡业务id
        /// </summary>
        public string Card_BusinessID { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string Card_Num { get; set; }
        /// <summary>
        /// 卡状态  0 库存 1 开通 2 挂失 3 损坏 9过期
        /// </summary>
        public int? Card_Status { get; set; }
    }
}
