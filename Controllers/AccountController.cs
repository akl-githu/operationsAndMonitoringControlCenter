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
        public IActionResult Login(string username, string password)
        {
            // Authenticate the user
            var user = _userService.GetUserByUsernameAndPassword(username, password);
            if (user != null)
            {
                // Record login action in the audit log
                _auditService.RecordAction(username, "Logged in");

                // Redirect based on the user's role
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.Role == "Viewer")
                {
                    return RedirectToAction("Index", "Viewer");
                }
            }

            // If authentication fails, show an error message
            ViewBag.Error = "Invalid username or password.";
            return View();
        }
    }
}

