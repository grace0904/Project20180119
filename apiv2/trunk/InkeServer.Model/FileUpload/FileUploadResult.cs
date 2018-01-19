using System.Collections.Generic;

namespace InkeServer.Model
{
    /// <summary>
    /// 文件上传返回值
    /// </summary>
    public class FileUploadResult
    {
        #region Model

        /// <summary>
        /// 文件访问地址
        /// </summary>
        public List<FileUploadStatus> Files { get; set; }

        #endregion
    }
}
