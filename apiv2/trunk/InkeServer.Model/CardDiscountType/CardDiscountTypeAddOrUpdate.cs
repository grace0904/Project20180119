using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 添加/修改 会员卡折扣类型请求类
    /// </summary>
    public class CardDiscountTypeAddOrUpdate : BaseRequest
    {
        #region
        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public string Discount_ID { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        [DisplayName("商家ID")]
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 折扣类型名称
        /// </summary>
        [DisplayName("折扣类型名称")]
        public string Discount_Name { get; set; }
        /// <summary>
        /// 消费获得积分
        /// </summary>
        [DisplayName("消费获得积分")]
        public Decimal ConsumeGetIntegral { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        [DisplayName("消费金额")]
        public Decimal ConsumeCash { get; set; }
        /// <summary>
        /// 充值获得积分
        /// </summary>
        [DisplayName("充值获得积分")]
        public Decimal RechargeGetIntegral { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        [DisplayName("充值金额")]
        public Decimal RechargeCash { get; set; }
        /// <summary>
        /// 开卡赠送积分
        /// </summary>
        [DisplayName("开卡赠送积分")]
        public Decimal OpenCardGetIntegral { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        [DisplayName("折扣")]
        public int Discount { get; set; }
        /// <summary>
        /// 是否允许网上申请 0 否 1 是
        /// </summary>
        [DisplayName("是否允许网上申请")]
        public int Apply { get; set; }
        /// <summary>
        /// 会员卡图片
        /// </summary>
        [DisplayName("会员卡图片")]
        public string Card_Pic { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string Memo { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [DisplayName("操作人")]
        public string Operator { get; set; }
        #endregion
    }
}
