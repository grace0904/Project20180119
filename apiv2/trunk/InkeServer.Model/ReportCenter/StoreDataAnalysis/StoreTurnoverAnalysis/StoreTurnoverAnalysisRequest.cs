using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 门店营业额分析  和  客流量走势
    /// </summary>
    public class StoreTurnoverAnalysisRequest : BaseRequest
    {
        /// <summary>
        /// 分析最大年龄
        /// </summary>
        public int Max { get; set; }
        /// <summary>
        /// 分析最小年龄
        /// </summary>
        public int min { get; set; }
        /// <summary>
        /// 分析年龄间隔
        /// </summary>
        public int Range { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public string Merchant_ID { get; set; }
        /// <summary>
        /// ShopID
        /// </summary>
        public string Shop_IDs { get; set; }
        /// <summary>
        ///  0  会员+散客   1会员年龄  2会员性别
        /// </summary>
        public string Analysis { get; set; }
        /// <summary>
        /// 'D' 日  'M'月 'Y'年
        /// </summary>
        public string Rangetype { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
