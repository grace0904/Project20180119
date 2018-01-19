using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 自动促销详细信息返回类
    /// </summary>
    public class AutoPromotionInfoResult
    {
        public AutoPromotionInfo AutoPromotionInfo { get; set; }
        public List<AutoPromotionTime> AutoPromotionTimeList { get; set; }
    }
}
