﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 会员卡记录分页请求
    /// </summary>
    public class MembershipCardPageRequest : PaginationRequest
    {
        /// <summary>
        /// 商家 ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public int? Log_Type { get; set; }
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string Card_Num { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string Member_Name { get; set; }
        /// <summary>
        /// 会员手机号
        /// </summary>
        public string Member_MobilePhone { get; set; }
        /// <summary>
        /// 日期起始
        /// </summary>
        public DateTime? DateFrom { get; set; }
        /// <summary>
        /// 日期结束
        /// </summary>
        public DateTime? DateTo { get; set; }
        /// <summary>
        /// 店铺ID列表 以逗号隔开 如：ID1,ID2,ID3
        /// </summary>
        public string ShopGroup { get; set; }
    }
}
