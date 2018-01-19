using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 获取积分调整列表 请求实体类
    /// </summary>
    public class IntegralAdjustPageRequest : PaginationRequest
    {
        /// <summary>
        /// 商家 ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 业务号
        /// </summary>
        public string Business_Num { get; set; }
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
        /// 调整类型  1 清零 2 减少 3 增加 默认为0 即所有类型
        /// </summary>
        public int? AdjustType { get; set; }
        /// <summary>
        /// 日期起始
        /// </summary>
        public DateTime? DateFrom { get; set; }
        /// <summary>
        /// 日期结束
        /// </summary>
        public DateTime? DateTo { get; set; }
        /// <summary>
        /// 店铺ID列表 逗号隔开 如：ID1,ID2,ID3
        /// </summary>
        public string ShopGroup { get; set; }
    }
}
