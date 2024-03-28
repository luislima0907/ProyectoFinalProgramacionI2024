using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDePresentacion.Utilidades
{
    public class OpcionCombo
    {
        // creamos una propiedad de texto para almacenar si esta activo o no
        public string Texto { get; set; }

        // creamos una propiedad de objeto para almacenar el tipo de dato que se le de a la opcion
        public object Valor { get; set; }
    }
}
