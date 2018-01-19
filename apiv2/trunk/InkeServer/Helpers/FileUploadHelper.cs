using InkeServer.Model;
using System;
using System.Collections.Generic;

namespace Inke.Common.Helpers
{
    /// <summary>
    /// 图片帮助
    /// </summary>
    public class FileUploadHelper
    {
        /// <summary>
        /// 文件上传目录
        /// </summary>
        public const string UPLOAD_PATH = "UploadFile";

        /// <summary>
        /// 创建文件上传目录
        /// </summary>
        /// <param name="param"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string CreateUploadPath(string id, int type, string fileName = "")
        {
            FileBusinessType etype = type.ToEnum<FileBusinessType>();
            return string.Format(@"{0}/{1}/{2}/{3}", UPLOAD_PATH, etype.Name(), id, fileName);
        }

        /// <summary>
        /// 检查是否为合法的上传图片
        /// </summary>
        /// <param name="imageExt">图片后缀</param>
        public static bool CheckImageExt(string imageExt)
        {
            List<string> allowExt = new List<string>() { ".gif", ".jpg", ".jpeg", ".bmp", ".png" };

            return allowExt.Contains(imageExt);
        }

        /// <summary>
        /// 图片重命名
        /// </summary>
        /// <returns>图片名称</returns>
        public static string GetFileName()
        {
            return string.Format("{0}{1}",
                DateTime.Now.ToString("yyyyMMddHHmmssff"), new Random().Next(0, 999999).ToString());
        }

        #region 帮助方法

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="saveFolder">保存路径</param>
        /// <param name="context">HTTP上下文</param>
        /// <returns>上传结果</returns>
        //private List<string> UpLoadImage(string saveFolder, HttpContext context)
        //{
        //    List<string> relativePaths = new List<string>();
        //    try
        //    {
        //        for (int i = 0; i < context.Request.Files.Count; i++)
        //        {
        //            FileInfo fileInfo = new FileInfo(context.Request.Files[i].FileName);
        //            string fileNameExt = fileInfo.Extension;

        //            if (CheckImageExt(fileNameExt))
        //            {
        //                string newFileName = GetImageName() + fileNameExt;
        //                string serverFileName = context.Server.MapPath(@"/UploadFile/" + saveFolder + "/") + newFileName;

        //                if (!Directory.Exists(context.Server.MapPath(@"/UploadFile/" + saveFolder + "/")))
        //                {
        //                    Directory.CreateDirectory(context.Server.MapPath(@"/UploadFile/" + saveFolder + "/"));
        //                }

        //                context.Request.Files[0].SaveAs(serverFileName);

        //                relativePaths.Add("/UploadFile/" + saveFolder + "/" + newFileName);
        //            }
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        relativePaths.Add(e.Message);
        //    }

        //    return relativePaths;
        //}



        #endregion
    }
}
