using Microsoft.AspNetCore.Mvc;

namespace WebStoreApp.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index() => View();
    }
}
