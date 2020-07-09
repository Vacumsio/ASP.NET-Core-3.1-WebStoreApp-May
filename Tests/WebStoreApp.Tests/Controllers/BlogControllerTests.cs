using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebStoreApp.Controllers;

using Assert = Xunit.Assert;

namespace WebStoreApp.Tests.Controllers
{
    [TestClass]
    public class BlogControllerTests
    {
        [TestMethod]
        public void BlogList_return_View()
        {
            var controller = new BlogController();
            var result = controller.BlogList();
            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void BlogSingle_return_View()
        {
            var controller = new BlogController();
            var result = controller.BlogSingle();
            Assert.IsType<ViewResult>(result);
        }
    }
}
