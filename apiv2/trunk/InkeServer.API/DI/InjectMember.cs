using InkeServer.Attributes;
using Microsoft.Practices.Unity;
using System.Linq;
using System.Reflection;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace InkeServer.API.DI
{
    /// <summary>
    /// 注入成员拦截器
    /// </summary>
    public class InjectMember : ActionFilterAttribute
    {
        public readonly string Injector = ContainerHelper.CONTAINER;

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var controller = actionContext.ControllerContext.Controller;
            var props = controller.GetType().GetProperties().Where(p => p.PropertyType.IsPublic);

            foreach (PropertyInfo prop in props)
            {
                object[] attr = prop.GetCustomAttributes(typeof(InjectAttribute), false);
                if (attr != null && attr.Length > 0)
                {
                    IUnityContainer unity = UnityAppContext.Current[this.Injector];
                    object obj = unity.Resolve(prop.PropertyType);
                    prop.SetMethod.Invoke(controller, new object[] { obj });
                }
            }
        }
    }
}