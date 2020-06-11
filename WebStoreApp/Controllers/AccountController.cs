using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebStoreApp.Domain.Entities.Identity;
using WebStoreApp.ViewModels.Identity;

namespace WebStoreApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;

        public AccountController(UserManager<User> UserManager, SignInManager<User> SignInManager)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
        }


        public IActionResult Register() => View(new RegisterViewModel());
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel Model) => RedirectToAction("Index", "Home");


        public IActionResult Login() => View();
        public IActionResult Logout() => View();
        public IActionResult AccessDenied() => View();
    }
}
