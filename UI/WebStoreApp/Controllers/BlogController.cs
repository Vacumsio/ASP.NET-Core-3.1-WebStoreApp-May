using Microsoft.AspNetCore.Mvc;

namespace WebStoreApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult BlogList() => View();

        public IActionResult BlogSingle() => View();
    }
}
