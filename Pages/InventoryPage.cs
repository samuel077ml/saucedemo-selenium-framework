// Importa las clases principales de Selenium
using OpenQA.Selenium;

// Namespace que agrupa todas las páginas del proyecto
namespace SauceDemoFramework.Pages
{
    // Clase que representa la página Inventory de SauceDemo
    // En Page Object Model cada página de la aplicación
    // se representa mediante una clase
    public class InventoryPage
    {
        // Variable privada que almacenará la instancia del navegador
        // Se usa para interactuar con los elementos de la página
        private IWebDriver driver;

        // Constructor de la clase
        // Recibe el driver creado previamente y lo guarda
        // para que todos los métodos de esta página puedan utilizarlo
        public InventoryPage(IWebDriver driver)
        {
            // "this" hace referencia al atributo de la clase
            this.driver = driver;
        }

        // ==========================
        // LOCATORS
        // ==========================

        // Localizador del menú hamburguesa
        private By burgerMenu = By.Id("react-burger-menu-btn");

        // Localizador del logo "Swag Labs"
        private By title = By.ClassName("app_logo");

        // Localizador del carrito de compras
        private By cart = By.ClassName("shopping_cart_link");

        // Localizador del selector de ordenamiento
        private By sort = By.ClassName("product_sort_container");

        // Localizador de todos los productos mostrados
        private By inventoryItems = By.ClassName("inventory_item");

        // ==========================
        // MÉTODOS DE VALIDACIÓN
        // ==========================

        // Verifica si el menú hamburguesa está visible
        public bool IsBurgerDisplayed() =>
            driver.FindElement(burgerMenu).Displayed;

        // Verifica si el logo está visible
        public bool IsTitleDisplayed() =>
            driver.FindElement(title).Displayed;

        // Verifica si el carrito está visible
        public bool IsCartDisplayed() =>
            driver.FindElement(cart).Displayed;

        // Verifica si el filtro de ordenamiento está visible
        public bool IsSortDisplayed() =>
            driver.FindElement(sort).Displayed;

        // Verifica que exista al menos un producto cargado
        public bool AreItemsDisplayed() =>
            driver.FindElements(inventoryItems).Count > 0;
    }
}