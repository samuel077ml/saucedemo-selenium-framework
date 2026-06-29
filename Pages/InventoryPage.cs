using OpenQA.Selenium;

namespace SauceDemoFramework.Pages
{
    public class InventoryPage
    {
        private IWebDriver driver;

        public InventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By burger = By.CssSelector("#react-burger-menu-btn");
        private By title = By.CssSelector(".app_logo");
        private By cart = By.CssSelector(".shopping_cart_link");
        private By sort = By.CssSelector(".product_sort_container");
        private By items = By.CssSelector(".inventory_item");

        public bool Burger() => driver.FindElement(burger).Displayed;
        public bool Title() => driver.FindElement(title).Displayed;
        public bool Cart() => driver.FindElement(cart).Displayed;
        public bool Sort() => driver.FindElement(sort).Displayed;
        public bool Items() => driver.FindElements(items).Count > 0;
    }
}
