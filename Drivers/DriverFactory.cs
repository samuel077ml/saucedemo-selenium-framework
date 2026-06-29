using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace SauceDemoFramework.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(string browser)
        {
            IWebDriver driver;

            switch (browser.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;

                case "edge":
                    driver = new EdgeDriver();
                    break;

                default:
                    throw new ArgumentException("Browser not supported");
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }
    }
}
