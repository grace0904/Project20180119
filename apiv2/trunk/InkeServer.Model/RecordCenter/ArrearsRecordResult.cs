using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 挂帐记录返回结果
    /// </summary>
    public class ArrearsRecordResult : ArrearsRecordInfo
    {
        /// <summary>
        /// 订单业务号
        /// </summary>
        public string Business_Num { get; set; }
        /// <summary>
        /// 会员姓名 
        /// </summary>
        public string Member_Name { get; set; }
        /// <summary>
        /// 会员手机号
        /// </summary>
        public string Member_MobilePhone { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shop_Name { get; set; }
        /// <summary>
        /// 会员卡ID
        /// </summary>
        public string Card_ID { get; set; }
        /// <summary>
        /// 卡号 
        /// </summary>
        public string Card_Num { get; set; }
        /// <summary>
        /// 消费金额 
        /// </summary>
        public decimal ConsumeMoney { get; set; }
    }
}
