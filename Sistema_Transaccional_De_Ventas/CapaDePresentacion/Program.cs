using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDePresentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Aqui hacemos una instancia hacia la pantalla de iniciar sesion para que se pueda loguear el usuario
            //Application.Run(new Login());
            // Corremos el programa desde el formulario de inicio
            Application.Run(new Inicio());
        }
    }
}
