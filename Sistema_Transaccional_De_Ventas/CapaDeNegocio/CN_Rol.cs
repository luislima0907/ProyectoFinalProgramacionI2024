using CapaDeDatos;
using CapaDeEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio
{
    public class CN_Rol
    {
        // instanciamos CD_Rol en la capa de Negocio
        private CD_Rol objcd_rol = new CD_Rol();

        // el metodo para listar la tabla de rol
        public List<Rol> Listar()
        {
            // devolvemos el metodo de listar la tabla rol
            return objcd_rol.Listar();
        }
    }
}
