using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp.Controllers;
using CalculatorApp.Models;

namespace CalculatorApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.CalculationForm() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_MultiplyMethodWithDoubleNumbers()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var output = controller.Multiply(0.5, 0.5);

            // Assert
            Assert.AreEqual(output, 0.25);
        }

        [TestMethod]
        public void Test_MultiplyMethodWithWholeNumbers()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var output = controller.Multiply(1, 1);

            // Assert
            Assert.AreEqual(output, 1);
        }

        [TestMethod]
        public void Test_MultiplyMethodWithWholeNumbers_Zero()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var output = controller.Multiply(1, 0);

            // Assert
            Assert.AreEqual(output, 0);
        }

        [TestMethod]
        public void Test_MultiplyMethodWithLongDoubleNumbers()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var output = controller.Multiply(0.99, 0.9999);

            // Assert
            Assert.AreEqual(output, 0.989901);
        }

        [TestMethod]
        public void Test_MultiplyMethodWithDoubleAndWholeNumbers()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var output = controller.Multiply(0.99345, 1);

            // Assert
            Assert.AreEqual(output, 0.99345);
        }

        [TestMethod]
        public void Test_AddMethodWithDoubleNumbers()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var output = controller.Add(0.5, 0.5);

            // Assert
            Assert.AreEqual(output, 1);
        }

        [TestMethod]
        public void Test_AddMethodWithWholeNumbers()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var output = controller.Add(1, 0);

            // Assert
            Assert.AreEqual(output, 1);
        }

        [TestMethod]
        public void Test_AddMethodWithLongDoubleNumbers()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var output = controller.Add(0.99999, 0.89999);

            // Assert
            Assert.AreEqual(output, 1.89998);
        }

        [TestMethod]
        public void Test_AddMethodWithDoubleAndWholeNumbers()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var output = controller.Add(0.99345, 1);

            // Assert
            Assert.AreEqual(output, 1.99345, 0.00001);
        }
    }
}
