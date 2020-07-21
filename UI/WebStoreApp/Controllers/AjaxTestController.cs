using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using WebStoreApp.Domain.ViewModels;

namespace WebStoreApp.Controllers
{
    public class AjaxTestController : Controller
    {
        public IActionResult Index() => View();

        public async Task<IActionResult> GetJSON(int? id, string msg)
        {
            await Task.Delay(2000);

            return Json(new 
            {
                Message = $"Response(id:{id ?? -1}:{msg ?? "null"})",
                ServerTime = DateTime.Now
            });
        }

        public async Task<IActionResult> GetTestView(int? id, string msg)
        {
            await Task.Delay(2000);

            return PartialView("Partial/_DataView", new AjaxTestViewModel
            {
                Id = id ?? -1,
                Message = $"Response(id:{id ?? -1}:{msg ?? "null"})",
                DateTime = DateTime.Now
            });
        }

        public IActionResult SignalRTest() => View();
    }
}
