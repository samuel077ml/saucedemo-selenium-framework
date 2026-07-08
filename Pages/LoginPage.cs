// Importa las clases principales de Selenium.
// Aquí se encuentran IWebDriver, By, IWebElement, etc.
using OpenQA.Selenium;

// Namespace que agrupa las páginas del proyecto.
// Sirve para organizar el código.
namespace SauceDemoFramework.Pages
{
    /// <summary>
    /// Representa la página de Login de SauceDemo.
    /// Implementa el patrón de diseño Page Object Model (POM).
    /// Cada página de la aplicación se representa mediante una clase.
    /// </summary>
    public class LoginPage : BasePage
    {
        /// <summary>
        /// Constructor de LoginPage.
        /// Recibe el navegador (driver) que viene desde LoginTests
        /// y lo envía a BasePage mediante ": base(driver)".
        /// </summary>
        public LoginPage(IWebDriver driver)
            : base(driver)
        {
            // No es necesario escribir nada aquí porque
            // BasePage ya se encarga de guardar el driver
            // y configurar WebDriverWait.
        }

        // =====================================
        // LOCATORS
        // =====================================

        // Localizador del campo Username.
        // Busca el elemento cuyo id es "user-name".
        private readonly By username =
            By.CssSelector("#user-name");

        // Localizador del campo Password.
        // Busca el elemento cuyo id es "password".
        private readonly By password =
            By.CssSelector("#password");

        // Localizador del botón Login.
        // Busca el elemento cuyo id es "login-button".
        private readonly By loginBtn =
            By.CssSelector("#login-button");

        // Localizador del mensaje de error.
        // Busca la etiqueta h3 que tiene el atributo
        // data-test='error'.
        private readonly By errorMsg =
            By.CssSelector("h3[data-test='error']");

        // =====================================
        // MÉTODOS DE ACCIÓN
        // =====================================

        /// <summary>
        /// Escribe el usuario recibido como parámetro.
        /// </summary>
        public void EnterUsername(string user)
        {
            // WaitForElement() viene de BasePage.
            // Espera hasta encontrar el elemento.
            // Luego SendKeys() escribe el texto.
            WaitForElement(username)
                .SendKeys(user);
        }

        /// <summary>
        /// Escribe la contraseña recibida como parámetro.
        /// </summary>
        public void EnterPassword(string pass)
        {
            // Espera el campo Password.
            // Luego escribe la contraseña.
            WaitForElement(password)
                .SendKeys(pass);
        }

        /// <summary>
        /// Hace clic en el botón Login.
        /// </summary>
        public void ClickLogin()
        {
            // Espera hasta encontrar el botón Login.
            // Luego ejecuta un clic.
            WaitForElement(loginBtn)
                .Click();
        }

        /// <summary>
        /// Limpia el contenido del campo Username.
        /// </summary>
        public void ClearUsername()
        {
            // Espera el campo Username.
            // Luego elimina el contenido escrito.
            WaitForElement(username)
                .Clear();
        }

        /// <summary>
        /// Limpia el contenido del campo Password.
        /// </summary>
        public void ClearPassword()
        {
            // Espera el campo Password.
            // Luego elimina el contenido escrito.
            WaitForElement(password)
                .Clear();
        }

        /// <summary>
        /// Obtiene el texto del mensaje de error.
        /// </summary>
        public string GetError()
        {
            // Espera hasta encontrar el mensaje de error.
            // Luego devuelve el texto que contiene.
            return WaitForElement(errorMsg)
                .Text;
        }
    }
}