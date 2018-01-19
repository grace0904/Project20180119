using System.Web.Mvc;

namespace InkeAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Help", new { area = "" });
        }

        public ActionResult Upload()
        {
            return View();
        }
    }
}
