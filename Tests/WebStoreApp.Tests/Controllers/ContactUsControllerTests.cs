using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebStoreApp.Controllers;

using Assert = Xunit.Assert;

namespace WebStoreApp.Tests.Controllers
{
    [TestClass]
    public class ContactUsControllerTests
    {
        [TestMethod]
        public void ContactUs_return_View()
        {
            var controller = new ContactUsController();
            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
        }
    }
}
