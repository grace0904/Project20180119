
namespace InkeServer.Model
{
    /// <summary>
    /// 文件上传状态
    /// </summary>
    public class FileUploadStatus
    {
        #region Model

        /// <summary>
        /// 是否接收成功
        /// </summary>
        public bool Accepted { get; set; }

        /// <summary>
        /// 原文件名
        /// </summary>
        public string OldFileName { get; set; }

        /// <summary>
        /// 访问路径
        /// </summary>
        public string VisitPath { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        #endregion
    }
}
