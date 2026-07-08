// Framework de pruebas NUnit.
// Permite crear y ejecutar pruebas automatizadas.
using NUnit.Framework;

// Librería para realizar validaciones más legibles.
using FluentAssertions;

// Importa las páginas creadas con Page Object Model.
using SauceDemoFramework.Pages;

// Importa los datos de prueba (Data Driven Testing).
using SauceDemoFramework.TestData;

// Importa la fábrica de navegadores.
using SauceDemoFramework.Drivers;

// Importa la interfaz principal de Selenium.
using OpenQA.Selenium;

// Importa Exception para manejar errores con try-catch.
using System;

// Namespace que agrupa las pruebas del proyecto.
namespace SauceDemoFramework.Tests
{
    /// <summary>
    /// Clase que contiene todos los escenarios de prueba
    /// relacionados con Login.
    /// </summary>

    // Indica que esta clase contiene pruebas NUnit.
    [TestFixture]

    // Evita la ejecución paralela de los tests.
    // Los casos se ejecutan uno después del otro.
    [Parallelizable(ParallelScope.None)]
    public class LoginTests
    {
        // Variable que almacenará la instancia del navegador.
        private IWebDriver driver;

        // =====================================
        // SETUP
        // =====================================

        /// <summary>
        /// Se ejecuta antes de cada prueba.
        /// Su función es preparar el entorno.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Crea el navegador utilizando DriverFactory.
            driver = DriverFactory.CreateDriver("chrome");

            // Navega hacia la página de SauceDemo.
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }

        // =====================================
        // TEARDOWN
        // =====================================

        /// <summary>
        /// Se ejecuta después de cada prueba.
        /// Libera recursos y cierra el navegador.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            // El operador ? evita errores si driver es null.
            driver?.Quit();
        }

        // =====================================
        // UC1
        // Login con usuario y contraseña vacíos
        // =====================================

        /// <summary>
        /// Valida que aparezca el mensaje de error
        /// cuando usuario y contraseña están vacíos.
        /// </summary>

        // Obtiene los datos desde LoginData.UC1.
        [TestCaseSource(typeof(LoginData), nameof(LoginData.UC1))]
        public void UC1_EmptyCredentials(
            string user,
            string pass,
            string expected)
        {
            try
            {
                // Crea una instancia de LoginPage.
                var login = new LoginPage(driver);

                // Ingresa el usuario recibido.
                login.EnterUsername(user);

                // Ingresa la contraseña recibida.
                login.EnterPassword(pass);

                // Hace clic en Login.
                login.ClickLogin();

                // Obtiene el mensaje de error y valida
                // que contenga el texto esperado.
                login.GetError()
                    .Should()
                    .Contain(expected);
            }
            catch (Exception ex)
            {
                // Si ocurre algún error,
                // el test falla mostrando el mensaje.
                Assert.Fail($"UC1 failed: {ex.Message}");
            }
        }

        // =====================================
        // UC2
        // Login con contraseña vacía
        // =====================================

        /// <summary>
        /// Valida que aparezca el mensaje de error
        /// cuando la contraseña está vacía.
        /// </summary>

        [TestCaseSource(typeof(LoginData), nameof(LoginData.UC2))]
        public void UC2_OnlyUsername(
            string user,
            string pass,
            string expected)
        {
            try
            {
                // Crea la página Login.
                var login = new LoginPage(driver);

                // Ingresa usuario.
                login.EnterUsername(user);

                // Ingresa contraseña vacía.
                login.EnterPassword(pass);

                // Hace clic en Login.
                login.ClickLogin();

                // Verifica el mensaje de error.
                login.GetError()
                    .Should()
                    .Contain(expected);
            }
            catch (Exception ex)
            {
                Assert.Fail($"UC2 failed: {ex.Message}");
            }
        }

        // =====================================
        // UC3
        // Login exitoso
        // =====================================

        /// <summary>
        /// Valida que el login sea exitoso y
        /// que se cargue correctamente Inventory.
        /// </summary>

        [TestCaseSource(typeof(LoginData), nameof(LoginData.UC3))]
        public void UC3_ValidLogin(
            string user,
            string pass)
        {
            try
            {
                // Crea la página Login.
                var login = new LoginPage(driver);

                // Ingresa usuario.
                login.EnterUsername(user);

                // Ingresa contraseña.
                login.EnterPassword(pass);

                // Hace clic en Login.
                login.ClickLogin();

                // Crea la página Inventory.
                var inventory = new InventoryPage(driver);

                // =====================================
                // VALIDACIONES
                // =====================================

                // Verifica que el menú hamburguesa exista.
                inventory.IsBurgerDisplayed()
                    .Should()
                    .BeTrue();

                // Verifica que el logo exista.
                inventory.IsTitleDisplayed()
                    .Should()
                    .BeTrue();

                // Verifica que el carrito exista.
                inventory.IsCartDisplayed()
                    .Should()
                    .BeTrue();

                // Verifica que el filtro exista.
                inventory.IsSortDisplayed()
                    .Should()
                    .BeTrue();

                // Verifica que existan productos.
                inventory.AreItemsDisplayed()
                    .Should()
                    .BeTrue();
            }
            catch (Exception ex)
            {
                Assert.Fail($"UC3 failed: {ex.Message}");
            }
        }
    }
}