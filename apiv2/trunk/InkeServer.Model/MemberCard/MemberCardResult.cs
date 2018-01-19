using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 会员卡列表结果集
    /// </summary>
    public class MemberCardResult
    {//卡状态，卡号，折扣类型 discount，会员名称 member，会员电话，开通店铺，卡余额，卡积分，卡有效期

        /// <summary>
        /// Shop_ID
        /// </summary>
        public string Shop_ID { get; set; }
         /// <summary>
        /// Card_BusinessID
        /// </summary>
        public string Card_BusinessID { get; set; }
         /// <summary>
        /// Card_BusinessID
        /// </summary>
        public string Member_ID { get; set; }
        
        /// <summary>
        /// Card_ID
        /// </summary>
        public string Card_ID { get; set; }
        /// <summary>
        /// 是否卡有效期
        /// </summary>
        public int? Card_Validity { get; set; }
        /// <summary>
        /// 有效期开始时间
        /// </summary>
        public DateTime? Card_FDate { get; set; }
        /// <summary>
        /// 有效期结束时间
        /// </summary>
        public DateTime? Card_LDate { get; set; }
        /// <summary>
        /// 开卡时间
        /// </summary>
        public DateTime? AddTime { get; set; }

        /// <summary>
        /// 卡积分
        /// </summary>
        public decimal? Card_Integral { get; set; }
        /// <summary>
        /// 卡余额
        /// </summary>
        public decimal? Card_Cash { get; set; }
        /// <summary>
        /// 店铺
        /// </summary>
        public string Shop_Name { get; set; }
        /// <summary>
        /// 会员电话
        /// </summary>
        public string Member_MobilePhone { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string Member_Name { get; set; }
        /// <summary>
        /// 折扣类型
        /// </summary>
        public string Discount_Name { get; set; }
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
