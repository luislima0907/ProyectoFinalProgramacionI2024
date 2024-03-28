using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public Rol oRol { get; set; }
        public string Documento { get; set; }
        public string Contraseña { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
        public string FechaDeRegistro { get; set; }

    }
}
