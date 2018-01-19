using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkeServer.Model
{
    /// <summary>
    /// 用于老板报表查询返回的实体类
    /// </summary>
    public class BossReportRecordResult
    {
        public string BossReport_ID { get; set; }

        /// <summary>
        /// 报表名称
        /// </summary>
        public string BossReportName { get; set; }

        /// <summary>
        /// 店铺名称 
        /// </summary>
        public string ShopNames { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopList { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public int SendTime { get; set; }
        /// <summary>
        /// 接收手机号码
        /// </summary>
        public string ReceiveMobilePhone { get; set; }
        /// <summary>
        /// 状态  0 停止 1 生效
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
    }
}
