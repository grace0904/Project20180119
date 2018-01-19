using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    public class SeatClassUpdate : BaseRequest
    {
        #region Model

        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public string ShopSeatClass_ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        public string ShopSeatClass_Name { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName(" 商家ID")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        [DisplayName("店铺ID")]
        public string Shop_ID { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]
        public string Operator { get; set; }


        #endregion Model
    }
}
