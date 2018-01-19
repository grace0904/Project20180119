using InkeServer.API.DI;
using InkeServer.Helpers;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace InkeServer.API
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
  
            //初始日志的配置
            LogHelper.SetConfig();
            //注册Unity
            UnityAppContext.Current.Register("InkeServer.Service", "InkeServer.Service.Impl");
            //初始化依赖注入容器
            UnityAppContext.Current.InitContainer();
        }
    }
}