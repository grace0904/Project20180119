using System;

namespace InkeServer.Model
{
    public class SysLogInfo
    {
        #region Model

        /// <summary>
        /// ID
        /// </summary>
        public string SysLog_ID { get; set; }

        /// <summary>
        /// 日志类型
        /// </summary>
        public int SysLog_Type { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string SysLog_Content { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; set; }

        #endregion
    }
}
