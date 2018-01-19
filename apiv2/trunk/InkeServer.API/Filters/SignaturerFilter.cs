using Inke.Common.Exceptions;
using InkeServer.API.DI;
using InkeServer.Enums;
using InkeServer.Service;
using InkeServer.Service.Impl;
using Microsoft.Practices.Unity;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace InkeServer.API.Filters
{
    /// <summary>
    /// 签名验证拦截
    /// </summary>
    public class SignaturerFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 是否进行接口签名校检
        /// </summary>
        public bool SignValidationEnabled
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["SignValidationEnabled"]); }
        }

        public ISignaturerService SignaturerService
        {
            get
            {
                IUnityContainer unity = UnityAppContext.Current[ContainerHelper.CONTAINER];
                return (ISignaturerService)unity.Resolve(typeof(SignaturerService));
            }
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            SignaturerVerify(actionContext);
        }

        //签名验证
        private void SignaturerVerify(HttpActionContext filterContext)
        {
            //检查配置文件，是否需要进行签名检验(取消检测，必须要验证)
            //if (!SignValidationEnabled)
            //    return;

            bool flag = false;
            var model = filterContext.ActionArguments.Values.FirstOrDefault();
            try
            {
                flag = SignaturerService.IsValid(model);
            }
            catch { flag = false; }

            if (!flag)
                throw new BusinessException(ResultCode.SignInvalid.Value().ToString());
        }
    }
}