// Importa clases básicas de .NET como TimeSpan y ArgumentException
using System;

// Importa las interfaces y clases principales de Selenium
using OpenQA.Selenium;

// Importa las clases necesarias para controlar Google Chrome
using OpenQA.Selenium.Chrome;

// Importa las clases necesarias para controlar Microsoft Edge
using OpenQA.Selenium.Edge;

// Namespace que agrupa todas las clases relacionadas con los drivers
namespace SauceDemoFramework.Drivers
{
    // Clase estática encargada de crear y configurar navegadores
    // Implementa el patrón Factory
    public static class DriverFactory
    {
        // Método estático que recibe el nombre del navegador
        // y devuelve un IWebDriver configurado
        public static IWebDriver CreateDriver(string browser)
        {
            // Declaración de una variable de tipo IWebDriver
            // Aquí se almacenará ChromeDriver o EdgeDriver
            IWebDriver driver;

            // Evalúa el navegador recibido
            // ToLower() convierte el texto a minúsculas
            // para evitar problemas con mayúsculas y minúsculas
            switch (browser.ToLower())
            {
                // Si el navegador es Chrome
                case "chrome":

                    // Crea una nueva instancia de Chrome
                    driver = new ChromeDriver();

                    // Sale del switch
                    break;

                // Si el navegador es Edge
                case "edge":

                    // Crea una nueva instancia de Edge
                    driver = new EdgeDriver();

                    // Sale del switch
                    break;

                // Si el navegador no está soportado
                default:

                    // Lanza una excepción indicando el error
                    throw new ArgumentException("Browser not supported");
            }

            // Maximiza la ventana del navegador
            // para evitar problemas de visualización
            driver.Manage().Window.Maximize();

            // Configura un Implicit Wait de 10 segundos
            // Si Selenium no encuentra un elemento inmediatamente,
            // esperará hasta 10 segundos antes de lanzar una excepción
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Devuelve el navegador ya configurado
            return driver;
        }
    }
}