// Namespace que contiene todos los datos de prueba
namespace SauceDemoFramework.TestData
{
    // Clase que almacena los datos utilizados por los tests
    // Esto evita escribir datos directamente dentro de las pruebas
    public class LoginData
    {
        // =========================================
        // UC1 - Login con usuario y contraseña vacíos
        // =========================================

        // Arreglo estático que contiene los datos
        // para el caso de prueba UC1
        public static object[] UC1 =
        {
            // username, password, mensaje esperado
            new object[] { "", "", "Epic sadface: Username is required" }
        };

        // =========================================
        // UC2 - Usuario válido y contraseña vacía
        // =========================================

        public static object[] UC2 =
        {
            // username, password, mensaje esperado
            new object[] { "standard_user", "", "Epic sadface: Password is required" }
        };

        // =========================================
        // UC3 - Login exitoso
        // =========================================

        public static object[] UC3 =
        {
            // Usuario válido
            new object[] { "standard_user", "secret_sauce" },

            // Otro usuario válido
            new object[] { "problem_user", "secret_sauce" }
        };
    }
}