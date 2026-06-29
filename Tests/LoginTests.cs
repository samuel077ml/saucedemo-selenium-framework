using NUnit.Framework;
using FluentAssertions;
using SauceDemoFramework.Pages;
using SauceDemoFramework.TestData;
using SauceDemoFramework.Drivers;
using OpenQA.Selenium;
using System.Threading;

namespace SauceDemoFramework.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)]
    public class LoginTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateDriver("chrome");
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

            Thread.Sleep(2000); // 👈 ver página cargando
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(1000); // 👈 ver cierre
            driver.Quit();
        }

        [TestCaseSource(typeof(LoginData), nameof(LoginData.UC1))]
        public void UC1_EmptyCredentials(string user, string pass, string expected)
        {
            var login = new LoginPage(driver);

            Thread.Sleep(1000);

            login.EnterUsername(user);
            Thread.Sleep(1000);

            login.EnterPassword(pass);
            Thread.Sleep(1000);

            login.ClickLogin();
            Thread.Sleep(2000);

            login.GetError().Should().Contain(expected);

            Thread.Sleep(2000);
        }

        [TestCaseSource(typeof(LoginData), nameof(LoginData.UC2))]
        public void UC2_OnlyUsername(string user, string pass, string expected)
        {
            var login = new LoginPage(driver);

            Thread.Sleep(1000);

            login.EnterUsername(user);
            Thread.Sleep(1000);

            login.EnterPassword(pass);
            Thread.Sleep(1000);

            login.ClickLogin();
            Thread.Sleep(2000);

            login.GetError().Should().Contain(expected);

            Thread.Sleep(2000);
        }

        [TestCaseSource(typeof(LoginData), nameof(LoginData.UC3))]
        public void UC3_ValidLogin(string user, string pass)
        {
            var login = new LoginPage(driver);

            Thread.Sleep(1000);

            login.EnterUsername(user);
            Thread.Sleep(1000);

            login.EnterPassword(pass);
            Thread.Sleep(1000);

            login.ClickLogin();
            Thread.Sleep(3000);

            var inventory = new InventoryPage(driver);

            Thread.Sleep(2000);

            inventory.IsBurgerDisplayed().Should().BeTrue();
            inventory.IsTitleDisplayed().Should().BeTrue();
            inventory.IsCartDisplayed().Should().BeTrue();
            inventory.IsSortDisplayed().Should().BeTrue();
            inventory.AreItemsDisplayed().Should().BeTrue();

            Thread.Sleep(2000);
        }
    }
}