using Microsoft.AspNetCore.Mvc;

namespace WebStoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
