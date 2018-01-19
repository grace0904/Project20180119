using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 营业时段报表结果集
    /// </summary>
    public class BusinessTimeSlotResult
    {
        
        //\":[{\"Title\":\"16:00:00\",\"Total\":97,\"TotalPercent\":\"52.15%\",\"Customer\":1622.00,\"CustomerPercent\":\"30.65%\",\"Member\":13398.00,\"MemberPercent\":\"70.71%\",\"TotalMoney\":15020.00,\"TotalMoneyPercent\":\"61.97%\"},
        //时段	消费次数	比例	散客消费金额	比例	会员消费金额	比例	总消费金额	比例
   //16:00~16:59	97	  52.15%	1622	     30.65%	   13398         	70.71%	15020	    61.97%
        /// <summary>
        /// 时段
        /// </summary>
        public TimeSpan? Title { get; set; }
        /// <summary>
        /// 消费次数
        /// </summary>
        public int? Total { get; set; }
        /// <summary>
        /// 消费次数百分率
        /// </summary>
        public string TotalPercent { get; set; }
        /// <summary>
        /// 散客消费金额
        /// </summary>
        public decimal? Customer { get; set; }
        /// <summary>
        /// 散客消费金额比例
        /// </summary>
        public string CustomerPercent { get; set; }
        /// <summary>
        /// 会员消费金额
        /// </summary>
        public decimal? Member { get; set; }
        /// <summary>
        /// 会员消费金额百分率
        /// </summary>
        public string MemberPercent { get; set; }
        /// <summary>
        /// 总消费金额
        /// </summary>
        public decimal? TotalMoney { get; set; }
        /// <summary>
        /// 总消费金额百分率
        /// </summary>
        public string TotalMoneyPercent { get; set; }
    }
}
