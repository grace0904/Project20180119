using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 会员卡记录
    /// </summary>
    public class MembershipCardInfo
    {
        #region Model
        /// <summary>
        /// ID
        /// </summary>
        public string Log_Id { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_Id { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string Shop_Id { get; set; }
        /// <summary>
        /// 操作类型  2 挂失 3 卡损坏 4 卡回收 5 撤销挂失 6 补卡换卡 7 更改卡折扣 8 更改会员卡密码
        /// </summary>
        public int Log_Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Log_Content { get; set; }
        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Member_Id { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string Card_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Card_BusinessID { get; set; }
        #endregion Model
    }
}
