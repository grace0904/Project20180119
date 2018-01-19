using Inke.Common.Helpers;
using InkeServer.API.Filters;
using InkeServer.GlobalVariable;
using InkeServer.Model;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace InkeServer.API.Controllers.Common
{
    public class FileUploadController : ApiController
    {
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="id">业务ID</param>
        /// <param name="type">文件业务类型</param>
        /// <returns></returns>
        [CrossSite]
        [Route("api/v2/FileUpload")]
        [ResponseType(typeof(BaseResult<FileUploadResult>))]
        [HttpPost]
        public async Task<IHttpActionResult> FileUpload(string id, int type)
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            //指定要将文件存入的服务器物理位置
            string savePath = FileUploadHelper.CreateUploadPath(id, type);
            string mapPath = HttpContext.Current.Server.MapPath(string.Format("~/{0}", savePath));
            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            FileUploadResult result = new FileUploadResult() { Files = new List<FileUploadStatus>() };
            foreach (var item in provider.Contents)
            {
                // 判断是否是文件
                if (item.Headers.ContentDisposition.FileName != null)
                {
                    //获取到流
                    var ms = item.ReadAsStreamAsync().Result;
                    //进行流操作
                    using (var br = new BinaryReader(ms))
                    {
                        if (ms.Length <= 0)
                            break;
                        //读取文件内容到内存中
                        var data = br.ReadBytes((int)ms.Length);

                        //重命名文件名
                        string filename = item.Headers.ContentDisposition.FileName.Replace("\"", "");
                        string newname = string.Format("{0}{1}", FileUploadHelper.GetFileName(), Path.GetExtension(filename));

                        //Info
                        FileInfo info = new FileInfo(filename);

                        //Write
                        try
                        {
                            //文件存储地址
                            string dirPath = Path.Combine(mapPath);
                            if (!Directory.Exists(dirPath))
                                Directory.CreateDirectory(dirPath);

                            File.WriteAllBytes(Path.Combine(mapPath, newname), data);

                            FileUploadStatus stauts = new FileUploadStatus()
                            {
                                Accepted = true,
                                VisitPath = string.Format("/{0}{1}", savePath, newname),
                                OldFileName = filename
                            };
                            result.Files.Add(stauts);
                        }
                        catch { }
                    }
                }
            }

            return Json(result.CompleteResult());
        }
    }
}
