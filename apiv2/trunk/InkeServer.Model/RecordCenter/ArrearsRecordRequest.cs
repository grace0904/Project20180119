using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 挂帐记录查询 请求实体类
    /// </summary>
    public class ArrearsRecordRequest : PaginationRequest
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// 店铺ID列表 以逗号隔开 如：ID1,ID2,ID3
        /// </summary>
        public string ShopGroup { get; set; }
        /// <summary>
        /// 挂帐状态 1 正常 2 已结帐 0 是所有
        /// </summary>
        public int Arrears_Status { get; set; }
        /// <summary>
        /// 会员姓名 
        /// </summary>
        public string Member_Name { get; set; }
        /// <summary>
        /// 会员手机号
        /// </summary>
        public string Member_MobilePhone { get; set; }
        /// <summary>
        /// 挂帐金额起始
        /// </summary>
        public decimal ArrearsMoneyFrom { get; set; }
        /// <summary>
        /// 挂帐金额结束
        /// </summary>
        public decimal ArrearsMoneyTo { get; set; }
        /// <summary>
        /// 挂帐日期起始
        /// </summary>
        public DateTime? ArrearsDateFrom { get; set; }
        /// <summary>
        /// 挂帐日期结束
        /// </summary>
        public DateTime? ArrearsDateTo { get; set; }
        /// <summary>
        /// 记录起始
        /// </summary>
        public int StartIndex { get; set; }
        /// <summary>
        /// 记录结束
        /// </summary>
        public int EndIndex { get; set; }
    }
}
