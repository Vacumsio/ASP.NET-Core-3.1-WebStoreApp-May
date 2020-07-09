using Microsoft.AspNetCore.Mvc;

namespace WebStoreApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index() => View();
    }
}
