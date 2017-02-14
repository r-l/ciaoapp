using Microsoft.AspNetCore.Mvc;

namespace CiaoApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(PromiseController.All), "Promise");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "The app was created as a Master Thesis for Faculty of Information Technology, Czech Technical University in Prague. It presents an application of the PSI theory of communication.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Roman Lanský";
            ViewData["Message"] = "Project author";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
