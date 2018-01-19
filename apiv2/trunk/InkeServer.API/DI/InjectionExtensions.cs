using InkeServer.API.DI;
using InkeServer.Attributes;
using Microsoft.Practices.Unity;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace System.Web.Http
{
    public static class InjectionExtensions
    {
        public static void Injection(this ApiController controller, string container = null)
        {
            _injection(controller, container);
        }

        public static void Injection(this Attribute attribute, string container = null)
        {
            _injection(attribute, container);
        }

        private static void _injection(object obj, string container = null)
        {
            if (string.IsNullOrEmpty(container))
                container = ContainerHelper.CONTAINER;

            var props = obj.GetType().GetProperties().Where(p => p.PropertyType.IsInterface);

            foreach (PropertyInfo prop in props)
            {
                object[] attr = prop.GetCustomAttributes(typeof(InjectAttribute), false);
                if (attr != null && attr.Length > 0)
                {
                    IUnityContainer unity = UnityAppContext.Current[container];
                    object value = unity.Resolve(prop.PropertyType);
                    prop.SetMethod.Invoke(obj, new object[] { value });
                }
            }
        }
    }
}