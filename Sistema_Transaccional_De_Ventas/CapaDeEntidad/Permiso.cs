using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad
{
    public class Permiso
    {
        public int IdPermiso { set; get; }
        public Rol oRol { set; get; }
        public string NombreDeMenu { set; get; }
        public string FechaDeRegistro { set; get; }

    }
}
