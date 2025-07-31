using controlCenter.Services;
using Microsoft.AspNetCore.Mvc;


namespace controlCenter.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService _userService;

        public AdminController(UserService userService)
        {
            _userService = userService?? throw new ArgumentNullException(nameof(userService));
        }

        public IActionResult Index()
        {
            // Retrieve all users from the database
            var users = _userService.GetAllUsers();

            // Pass the users list to the view
            return View(users);
        }

        [HttpPost]
        public IActionResult AddUser(string username, string password, string role)
        {
            // Call UserService to add the user to the database
            _userService.AddUser(username, password, role);

            // Redirect back to the Admin page
            return RedirectToAction("Index");
        }


    }
}