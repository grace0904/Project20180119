using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    ///  查询自动促销返回结果类
    /// </summary>
    public class AutoPromotionQueryResult
    {
        /// <summary>
        /// 优惠劵名称(name*count)
        /// </summary>
        public IList<string> Coupon_Name { get; set; }
        /// <summary>
        /// 促销店铺
        /// </summary>
        public IList<string> ShopNames { get; set; }
        #region Model


        /// <summary>
        /// 自动促销ID
        /// </summary>
        public string Promotion_ID
        {
            set;
            get;
        }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_Id
        {
            set;
            get;
        }

        /// <summary>
        /// 自动促销名称
        /// </summary>
        public string PromotionName
        {
            set;
            get;
        }
        /// <summary>
        /// 1新会员促销2充值促销3消费促销4积分促销5日期促销
        /// </summary>
        public int PromotionType
        {
            set;
            get;
        }
        /// <summary>
        /// 0 不有效期 1 限制有效期
        /// </summary>
        public int? ValidityType
        {
            set;
            get;
        }

        /// <summary>
        /// 有效期起始
        /// </summary>
        public DateTime? DateFrom
        {
            set;
            get;
        }
        /// <summary>
        /// 有效期结束
        /// </summary>
        public DateTime? DateTo
        {
            set;
            get;
        }


        /// <summary>
        /// 赠送积分数量
        /// </summary>
        public int? GivenIntegral
        {
            set;
            get;
        }
        /// <summary>
        /// 积分赠送倍数
        /// </summary>
        public int? GivenIntegralMultiple
        {
            set;
            get;
        }
        /// <summary>
        /// 0 停止 1 生效
        /// </summary>
        public int? State
        {
            set;
            get;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime
        {
            set;
            get;
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperationTime
        {
            set;
            get;
        }
        /// <summary>
        /// 操作者
        /// </summary>
        public string Operator
        {
            set;
            get;
        }

        #endregion Model
    }
}
