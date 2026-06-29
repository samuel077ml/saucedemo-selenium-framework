using NUnit.Framework;
using FluentAssertions;
using SauceDemoFramework.Pages;
using SauceDemoFramework.TestData;
using SauceDemoFramework.Drivers;
using OpenQA.Selenium;

namespace SauceDemoFramework.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.None)] // 👈 IMPORTANTE (evita 4 Chromes)
    public class LoginTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DriverFactory.CreateDriver("chrome");
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestCaseSource(typeof(LoginData), nameof(LoginData.UC1))]
        public void UC1_EmptyCredentials(string user, string pass, string expected)
        {
            var login = new LoginPage(driver);

            login.EnterUsername(user);
            login.EnterPassword(pass);
            login.ClickLogin();

            login.GetError().Should().Contain(expected);
        }

        [TestCaseSource(typeof(LoginData), nameof(LoginData.UC2))]
        public void UC2_OnlyUsername(string user, string pass, string expected)
        {
            var login = new LoginPage(driver);

            login.EnterUsername(user);
            login.EnterPassword(pass);
            login.ClickLogin();

            login.GetError().Should().Contain(expected);
        }

        [TestCaseSource(typeof(LoginData), nameof(LoginData.UC3))]
        public void UC3_ValidLogin(string user, string pass)
        {
            var login = new LoginPage(driver);

            login.EnterUsername(user);
            login.EnterPassword(pass);
            login.ClickLogin();

            var inventory = new InventoryPage(driver);

            inventory.Burger().Should().BeTrue();
            inventory.Title().Should().BeTrue();
            inventory.Cart().Should().BeTrue();
            inventory.Sort().Should().BeTrue();
            inventory.Items().Should().BeTrue();
        }
    }
}