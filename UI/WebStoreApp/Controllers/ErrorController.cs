using Microsoft.AspNetCore.Mvc;

namespace WebStoreApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult ErrorStatus(string Status_code)
        {
            switch (Status_code)
            {
                default:
                    return Content($"Error status code: {Status_code}");
                case "404":
                    return RedirectToAction(nameof(Index));
                
            }
        }
    }
}
