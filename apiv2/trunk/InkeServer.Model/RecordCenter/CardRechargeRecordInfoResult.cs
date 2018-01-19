using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 充值记录详细信息结果集
    /// </summary>
    public class CardRechargeRecordInfoResult
    {
        /// <summary>
        /// 充值详细信息
        /// </summary>
        public CardRechargeRecordInfo CardRechargeInfo { get; set; }
        /// <summary>
        /// 历史记录
        /// </summary>
        public List<CardRechargeRecordInfo> HistoryCardRechargeRecord { get; set; }
    }
}
