using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 会员查询结果类
    /// </summary>
    public class MemberQueryResult
    {
        public string Member_ID { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string Member_Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Member_Sex { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Member_MobilePhone { get; set; }
        /// <summary>
        /// 家庭电话
        /// </summary>
        public string Member_HomePhone { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string Member_Birthday { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Member_Email { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? Member_RegisterTime { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? Operation { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
    }
}
