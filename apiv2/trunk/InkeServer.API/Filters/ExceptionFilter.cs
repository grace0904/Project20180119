using Inke.Common.Exceptions;
using InkeServer.Enums;
using InkeServer.GlobalVariable;
using InkeServer.Helpers;
using InkeServer.Model;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace InkeServer.API.Filters
{
    /// <summary>
    /// 异常拦截器
    /// </summary>
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            BaseResult<object> result;

            if (actionExecutedContext.Exception.GetType() == typeof(BusinessException))
            {
                BusinessException e = (BusinessException)actionExecutedContext.Exception;
                result = e.ErrorResult();
            }
            else
            {
                result = ResultCode.Unexpected.ErrorResult();
            }

            //记录异常日志
            LogHelper.WriteLog(result.Message, actionExecutedContext.Exception);

            actionExecutedContext.Response =
                actionExecutedContext.ActionContext.Request.CreateResponse(
                HttpStatusCode.OK,
                result,
                "application/json");
        }
    }
}