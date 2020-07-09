using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebStoreApp.Controllers;

using Assert = Xunit.Assert;

namespace WebStoreApp.Tests.Controllers
{
    [TestClass]
    public class ErrorControllerTests
    {
        [TestMethod]
        public void Error_return_View()
        {
            var controller = new ErrorController();
            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void StatusError_404_RedirectTo_Error404()
        {
            var controller = new ErrorController();
            const string status_code = "404";

            var result = controller.ErrorStatus(status_code);

            var redirect_to_action = Assert.IsType<RedirectToActionResult>(result);

            Assert.Null(redirect_to_action.ControllerName);
            Assert.Equal(nameof(ErrorController.Index), redirect_to_action.ActionName);

        }
    }
}
