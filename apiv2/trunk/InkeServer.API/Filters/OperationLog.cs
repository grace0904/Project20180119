using Inke.Common.Helpers;
using InkeServer.API.DI;
using InkeServer.Attributes;
using InkeServer.Enums;
using InkeServer.Model;
using InkeServer.Service;
using InkeServer.Service.Impl;
using Microsoft.Practices.Unity;
using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace InkeServer.API.Filters
{
    /// <summary>
    ///  操作日志拦截(目前暂不支持List<T>类型参数，如需使用集合，请使用数组)
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class OperationLog : ActionFilterAttribute
    {
        #region Property

        public ISysLogService SysLogService
        {
            get
            {
                IUnityContainer unity = UnityAppContext.Current[ContainerHelper.CONTAINER];
                return (ISysLogService)unity.Resolve(typeof(SysLogService));
            }
        }

        /// <summary>
        /// 操作信息
        /// </summary>
        public string OperationMsg { get; set; }

        #endregion

        public OperationLog() { }

        public OperationLog(string msg)
        {
            this.OperationMsg = msg;
        }

        public override Task OnActionExecutedAsync(
            HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            WriteLog(actionExecutedContext);
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }

        private void WriteLog(HttpActionExecutedContext actionExecutedContext)
        {
            try
            {
                //日志内容
                string content = GetContent(actionExecutedContext);
                //日志类型
                int type = OperateType.Operation.Value<int>();
                //操作人IP
                string ip = actionExecutedContext.Request.GetClientIpAddress();
                //记录日志

                //string log = string.Format(
                //    "操作时间: [{0}] 操作人IP: [{1}], 日志内容:[{2}]", 
                //    DateTime.Now.DefaultFormat(), ip, content);
                //LogHelper.WriteLog(log);

                SysLogInsert model = new SysLogInsert()
                {
                    SysLog_ID = GUID.CreateGUID(),
                    SysLog_Type = 3,
                    Operator = ip,
                    SysLog_Content = content
                };

                SysLogService.Insert(model);
            }
            catch { }
        }

        //获取日志内容
        private string GetContent(HttpActionExecutedContext actionExecutedContext)
        {
            //获取请求的参数
            var model = actionExecutedContext.ActionContext.ActionArguments.Values.FirstOrDefault();
            var props = model.GetType().GetProperties();
            var contentBuilder = new StringBuilder();
            CreateContent(contentBuilder, model);

            string content = contentBuilder.ToString();
            if (!string.IsNullOrEmpty(OperationMsg))
                content = string.Format("操作信息：{0}，提交参数：[ {1} ]", OperationMsg, contentBuilder.ToString());

            return content;
        }

        private void CreateContent(StringBuilder content, object model)
        {
            var props = model.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var prop in props)
            {
                var filters = prop.GetCustomAttributes(typeof(UnLogAttribute), false);
                if (filters.Length > 0)
                    continue;

                //如果是非密封的class(自定义复杂类型)
                if (prop.PropertyType.IsClass && !prop.PropertyType.IsSealed
                    && !prop.PropertyType.IsGenericType && !prop.PropertyType.IsArray && !prop.PropertyType.IsEnum)
                {
                    //递归获取复杂类型属性
                    CreateContent(content, prop.GetValue(model));
                    continue;
                }

                var attrs = prop.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                if (attrs.Length == 0)
                    continue;

                var attr = (DisplayNameAttribute)attrs.FirstOrDefault();

                //集合
                if (prop.PropertyType.IsArray)
                {
                    object[] objs = prop.GetValue(model) as object[];
                    content.AppendFormat("{0}:[", attr.DisplayName);
                    for (int i = 0; i < objs.Length; i++)
                    {
                        if (i > 0)
                            content.Append(", ");

                        content.Append("{");
                        //递归获取复杂类型属性
                        CreateContent(content, objs[i]);
                        content.Append("}");
                        continue;
                    }
                    content.Append("] ");
                    continue;
                }

                object value = prop.GetValue(model);
                content.AppendFormat("{0}:{1} ", attr.DisplayName, value);
            }
        }
    };
}