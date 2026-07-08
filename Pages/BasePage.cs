// Importa funcionalidades básicas de .NET.
// Aquí se encuentra la clase TimeSpan.
using System;

// Importa las clases principales de Selenium.
// Aquí están IWebDriver, IWebElement y By.
using OpenQA.Selenium;

// Importa WebDriverWait.
// Esta clase permite implementar esperas explícitas (Explicit Waits).
using OpenQA.Selenium.Support.UI;

// Namespace que agrupa todas las páginas del proyecto.
namespace SauceDemoFramework.Pages
{
    /// <summary>
    /// Clase base para todas las páginas del framework.
    /// Contiene funcionalidades comunes que serán reutilizadas
    /// por LoginPage, InventoryPage y futuras páginas.
    /// </summary>
    public class BasePage
    {
        // =====================================
        // ATRIBUTOS
        // =====================================

        // Protected significa que las clases hijas
        // (LoginPage, InventoryPage, etc.)
        // pueden acceder a esta variable.
        //
        // Almacena la instancia del navegador.
        protected IWebDriver driver;

        // Objeto encargado de realizar esperas explícitas.
        // Se utilizará para esperar elementos antes de interactuar con ellos.
        protected WebDriverWait wait;

        // =====================================
        // CONSTRUCTOR
        // =====================================

        /// <summary>
        /// Constructor de BasePage.
        /// Recibe el driver y configura WebDriverWait.
        /// </summary>
        public BasePage(IWebDriver driver)
        {
            // Guarda el navegador recibido.
            // El "this" hace referencia al atributo de la clase.
            this.driver = driver;

            // Crea un WebDriverWait con un tiempo máximo
            // de espera de 10 segundos.
            //
            // Si un elemento aparece antes,
            // continúa inmediatamente.
            //
            // Si pasan los 10 segundos y no aparece,
            // Selenium lanza una excepción.
            wait = new WebDriverWait(
                driver,
                TimeSpan.FromSeconds(10));
        }

        // =====================================
        // MÉTODOS COMUNES
        // =====================================

        /// <summary>
        /// Espera hasta encontrar un elemento.
        /// Devuelve el elemento encontrado.
        /// </summary>
        protected IWebElement WaitForElement(By locator)
        {
            // wait.Until() ejecuta repetidamente la búsqueda
            // hasta que el elemento exista o se alcance el timeout.
            //
            // "d" representa el driver.
            //
            // Es equivalente a:
            //
            // return driver.FindElement(locator);
            //
            // pero con espera inteligente.
            return wait.Until(d =>
                d.FindElement(locator));
        }
    }
}