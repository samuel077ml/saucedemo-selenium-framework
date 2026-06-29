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

        private By burgerMenu = By.Id("react-burger-menu-btn");
        private By title = By.ClassName("app_logo");
        private By cart = By.ClassName("shopping_cart_link");
        private By sort = By.ClassName("product_sort_container");
        private By inventoryItems = By.ClassName("inventory_item");

        public bool IsBurgerDisplayed() =>
            driver.FindElement(burgerMenu).Displayed;

        public bool IsTitleDisplayed() =>
            driver.FindElement(title).Displayed;

        public bool IsCartDisplayed() =>
            driver.FindElement(cart).Displayed;

        public bool IsSortDisplayed() =>
            driver.FindElement(sort).Displayed;

        public bool AreItemsDisplayed() =>
            driver.FindElements(inventoryItems).Count > 0;
    }
}