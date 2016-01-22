using Microsoft.AspNet.Mvc;

namespace MinimalMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Hello = "Hello";
            return View();
        }

    }
}