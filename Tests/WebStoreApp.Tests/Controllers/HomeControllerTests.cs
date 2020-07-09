using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebStoreApp.Controllers;

using Assert = Xunit.Assert;

namespace WebStoreApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_returns_View()
        {
            var controller = new HomeController();

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void Throw_thrown_Exception()
        {
            var controller = new HomeController();

            Exception exception = null;
            try
            {
                _ = controller.Throw("Error");
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsType<ApplicationException>(exception);
        }

        [TestMethod, ExpectedException(typeof(ApplicationException))]
        public void Throw_thrown_ApplicationException()
        {
            var controller = new HomeController();

            _ = controller.Throw("Error");
        }
    }
}
