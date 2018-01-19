﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 发放记录返回类
    /// </summary>
    public class PromotionRecord
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public string PromotionRecord_ID { get; set; }

        /// <summary>
        /// 自动促销名称
        /// </summary>
        public string PromotionName { get; set; }
        /// <summary>
        /// 自动促销类型
        /// </summary>
        public string PromotionType { get; set; }
        /// <summary>
        /// 赠送积分
        /// </summary>
        public double? GivenIntegral { get; set; }

        /// <summary>
        /// 赠送优惠券名称
        /// </summary>
        public string Coupon_Name { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string Card_Num { get; set; }

        /// <summary>
        /// 会员姓名
        /// </summary>
        public string Member_Name { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Member_MobilePhone { get; set; }
        /// <summary>
        /// 发放时间
        /// </summary>
        public DateTime? ExecuteTime { get; set; }
    }
}
