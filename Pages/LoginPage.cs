using OpenQA.Selenium;

namespace SauceDemoFramework.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By username = By.CssSelector("#user-name");
        private By password = By.CssSelector("#password");
        private By loginBtn = By.CssSelector("#login-button");
        private By errorMsg = By.CssSelector("h3[data-test='error']");

        public void EnterUsername(string user) => driver.FindElement(username).SendKeys(user);
        public void EnterPassword(string pass) => driver.FindElement(password).SendKeys(pass);
        public void ClickLogin() => driver.FindElement(loginBtn).Click();

        public void ClearUsername() => driver.FindElement(username).Clear();
        public void ClearPassword() => driver.FindElement(password).Clear();

        public string GetError() => driver.FindElement(errorMsg).Text;
    }
}
