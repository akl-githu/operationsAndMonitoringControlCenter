//using controlCenter.Models;
using controlCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace controlCenter.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;
        private readonly AuditService _auditService;

        public AccountController(UserService userService, AuditService auditService)
        {
            _userService = userService;
            _auditService = auditService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password, string role)
        {
            var user = _userService.GetUserByUsernameAndPassword(username, password);
            if (user != null && user.Role == role)
            {
                _auditService.RecordAction(username, "Logged in");

                if (role == "Admin")
                    return RedirectToAction("Index", "Admin");
                else if (role == "Viewer")
                    return RedirectToAction("Index", "Viewer");
            }

            ViewBag.Error = "Invalid credentials or role.";
            return View();
        }
    }
}
