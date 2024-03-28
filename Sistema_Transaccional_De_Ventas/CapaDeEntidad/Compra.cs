using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeEntidad
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public Usuario oUsuario { get; set; }
        public Proveedor oProveedor { get; set; }
        public string TipoDeDocumento { get; set; }
        public string NumeroDeDocumento { get; set; }
        public decimal MontoTotal { get; set; }
        // se crea una lista para almacenar todos los productos involucrados en una venta, ya que una compra puede contener mas de un producto
        public List<Detalle_Compra> oDetalleCompra { get; set; }
        public string FechaDeRegistro { get; set; }
    }
}
