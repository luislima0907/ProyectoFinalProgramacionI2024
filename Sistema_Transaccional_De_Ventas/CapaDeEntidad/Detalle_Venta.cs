using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad
{
    public class Detalle_Venta
    {
        public int IdDetalleDeLaVenta { get; set; }
        public Producto oProducto { get; set; }
        public decimal PrecioDeVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public string FechaDeRegistro { get; set; }

    }
}
