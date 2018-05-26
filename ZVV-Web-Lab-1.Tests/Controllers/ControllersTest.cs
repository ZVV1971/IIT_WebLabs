using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZVV_Web_Lab_1.Controllers;

namespace ZVV_Web_Lab_1.Tests.Controllers
{
    [TestClass]
    public class ControllersTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}