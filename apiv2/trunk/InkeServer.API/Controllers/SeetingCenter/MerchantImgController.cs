using InkeServer.API.Filters;
using InkeServer.Attributes;
using InkeServer.GlobalVariable;
using InkeServer.Model;
using InkeServer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 商家图片
    /// </summary>
    public class MerchantImgController : BaseController
    {
        // GET: MerchantImg
        #region Property

        [Inject]
        public IMerchantImgService MerchantImgService { get; set; }

        #endregion

        /// <summary>
        /// 添加商家图片 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("添加商家图片")]
        [Route("api/v2/AddMerchantImg")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult AddMerchantImg(AddOrUpdateMerchantImg param)
        {
            MerchantImgService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 修改商家图片 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改商家图片 ")]
        [Route("api/v2/UpdateMerchantImg")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult UpdateMerchantImg(AddOrUpdateMerchantImg param)
        {
            MerchantImgService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 删除商家图片 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("删除商家图片 ")]
        [Route("api/v2/DeleteMerchantImg")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteMerchantImg(OperationBaseRequest param)
        {
            MerchantImgService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 根据图片地址删除商家图片 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("根据图片地址删除商家图片 ")]
        [Route("api/v2/DeleteMerchantImgByUrl")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteMerchantImgByUrl(MerchantImgDelete param)
        {
            MerchantImgService.DeleteByUrl(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 获取商家图片列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetMerchantImgList")]
        [ResponseType(typeof(BaseResult<List<MerchantImg>>))]
        [HttpPost]
        public IHttpActionResult GetMerchantImgList(MerchantImgListRequest param)
        {
            List<MerchantImg> list = MerchantImgService.GetList(param);
            return Json(list.CompleteResult());
        }
        /// <summary>
        /// 获取商家图片信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetMerchantImgInfo")]
        [ResponseType(typeof(BaseResult<MerchantImg>))]
        [HttpPost]
        public IHttpActionResult GetMerchantImgInfo(RecordIDRequest param)
        {
            MerchantImg info = MerchantImgService.GetInfo(param);
            return Json(info.CompleteResult());
        }
    }
}