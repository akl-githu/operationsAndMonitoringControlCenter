using Microsoft.AspNetCore.Mvc;

namespace controlCenter.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}