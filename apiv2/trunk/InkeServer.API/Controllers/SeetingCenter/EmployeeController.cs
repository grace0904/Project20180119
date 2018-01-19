
using Inke.Common.Paginations;
using InkeServer.Model;
using System.Web.Http;
using System.Web.Http.Description;
using InkeServer.GlobalVariable;
using InkeServer.Attributes;
using InkeServer.Service;
using System.Collections.Generic;
using InkeServer.API.Filters;


namespace InkeServer.API.Controllers
{
    /// <summary>
    /// 店铺员工
    /// </summary>
    public class EmployeeController : BaseController
    {
        // GET: Employee
        #region Property

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        #endregion

        /// <summary>
        /// 分页查询店铺员工
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("api/v2/GetShopEmployeePageList")]
        [ResponseType(typeof(BaseResult<IPaginationResult<EmploeeQueryResult>>))]
        [HttpPost]
        public IHttpActionResult GetShopEmployeePageList(EmploeeQueryRequest query)
        {
            IPaginationResult<EmploeeQueryResult> result = EmployeeService.Query(query);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 获取店铺员工信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetShopEmployeeInfo")]
        [ResponseType(typeof(BaseResult<EmploeeQueryResult>))]
        [HttpPost]
        public IHttpActionResult GetShopEmployeeInfo(RecordIDRequest param)
        {
            EmploeeQueryResult result = EmployeeService.GetInfo(param);
            return Json(result.CompleteResult());
        }
        /// <summary>
        /// 添加店铺员工
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("新增店铺员工")]
        [Route("api/v2/AddShopEmployee")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult AddShopEmployee(EmployeeAddOrUpdateRequest param)
        {
            EmployeeService.Insert(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 修改店铺员工
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("修改店铺员工")]
        [Route("api/v2/UpdateShopEmployee")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult UpdateShopEmployee(EmployeeAddOrUpdateRequest param)
        {
            EmployeeService.Update(param);
            return Json(MessageConverter.CompleteResult());
        }
        /// <summary>
        /// 删除店铺员工
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationLog("把店铺员工标记为删除")]
        [Route("api/v2/DeleteShopEmployee")]
        [ResponseType(typeof(BaseResult<object>))]
        [HttpPost]
        public IHttpActionResult DeleteShopEmployee(OperationBaseRequest param)
        {
            EmployeeService.Delete(param);
            return Json(MessageConverter.CompleteResult());
        }

        /// <summary>
        /// 获取店铺员工列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetShopEmployeeList")]
        [ResponseType(typeof(BaseResult<IList<EmployeeInfo>>))]
        [HttpPost]
        public IHttpActionResult GetShopEmployeeList(MerchantAndShopIdRequest param)
        {
            IList<EmployeeInfo> list = EmployeeService.GetListByShopId(param);
            return Json(list.CompleteResult());
        }
        /// <summary>
        /// 取得指定店铺所有未绑定账号的员工列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("api/v2/GetShopEmployeeListNoHasAccountID")]
        [ResponseType(typeof(BaseResult<IList<EmployeeIDAndName>>))]
        [HttpPost]
        public IHttpActionResult GetShopEmployeeListNoHasAccountID(MerchantAndShopIdRequest param)
        {
            IList<EmployeeIDAndName> list = EmployeeService.GetShopEmployeeListNoHasAccountID(param);
            return Json(list.CompleteResult());
        }
    }
}