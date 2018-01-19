using InkeServer.API.Filters;
using InkeServer.Attributes;
using InkeServer.GlobalVariable;
using InkeServer.Model;
using InkeServer.Service;
using System.Web.Http;
using System.Web.Http.Description;

namespace InkeServer.API.Controllers
{
    public class CacheController : BaseController
    {
        #region Property

        [Inject]
        public ICacheService CacheService { get; set; }

        #endregion

        ///<summary>
        /// 缓存查询
        /// </summary>
        /// <returns></returns>
        [Route("api/v2/CrmCache")]
        [ResponseType(typeof(BaseResult<CacheData>))]
        [HttpPost]
        public IHttpActionResult CrmCache(CacheRequest query)
        {
            CacheData result = CacheService.CrmCache(query);
            return Json(result.CompleteResult());
        }
    }
}
