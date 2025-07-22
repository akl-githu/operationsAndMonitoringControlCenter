using Microsoft.AspNetCore.Mvc;

namespace controlCenter.Controllers
{
    public class ViewerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}