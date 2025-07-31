/*
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
*/

using controlCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace controlCenter.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService _userService;

        public AdminController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            // Retrieve all users from the database
            var users = _userService.GetAllUsers();

            // Pass the users list to the view
            return View(users);
        }
    }
}