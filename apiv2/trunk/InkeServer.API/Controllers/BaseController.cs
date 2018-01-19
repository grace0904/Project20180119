using InkeServer.API.DI;
using InkeServer.API.Filters;
using System.Web.Http;

namespace InkeServer.API.Controllers
{
    /// <summary>
    /// Controller基类，继承获得公用特性
    /// </summary>
    [InjectMember]
    [SignaturerFilter]
    [ExceptionFilter]
    public class BaseController : ApiController
    {

    }
}