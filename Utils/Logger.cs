// Importa funcionalidades básicas de .NET
// En este caso se utiliza Console.WriteLine()
using System;

namespace SauceDemoFramework.Utils
{
    // Clase estática de utilidad para registrar mensajes
    // en la consola durante la ejecución de las pruebas
    public static class Logger
    {
        // Método estático que recibe un mensaje
        // y lo imprime en consola con el prefijo [INFO]
        public static void Info(string msg)
        {
            Console.WriteLine("[INFO] " + msg);
        }
    }
}