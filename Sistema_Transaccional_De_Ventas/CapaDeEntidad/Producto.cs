using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public Categoria oCategoria { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal PrecioDeCompra { get; set; }
        public decimal PrecioDeVenta { get; set; }
        public bool Estado { get; set; }
        public string FechaDeRegistro { get; set; }

    }
}
