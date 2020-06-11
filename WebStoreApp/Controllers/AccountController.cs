using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebStoreApp.Domain.Entities.Identity;
using WebStoreApp.ViewModels.Identity;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Register(RegisterViewModel Model)
        {
            if (!ModelState.IsValid)
            {
                return View(Model);
            }
            var user = new User
            {
                UserName = Model.UserName
            };

            var registration_result = await _UserManager.CreateAsync(user);
            if (registration_result.Succeeded)
            {
                await _SignInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var error in registration_result.Errors)
            {
                ModelState.AddModelError(string.Empty,error.Description);
            }

            return View(Model);
        }

        public IActionResult Login() => View();
        public IActionResult Logout() => View();
        public IActionResult AccessDenied() => View();
    }
}
