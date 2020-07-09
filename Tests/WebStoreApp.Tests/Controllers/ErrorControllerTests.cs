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
    }
}
