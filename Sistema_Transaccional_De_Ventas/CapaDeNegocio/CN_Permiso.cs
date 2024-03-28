using CapaDeDatos;
using CapaDeEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio
{
    public class CN_Permiso
    {
        // instanciamos CD_Permiso en la capa de Negocio
        private CD_Permiso objcd_permiso = new CD_Permiso();

        // el metodo recibe una lista con el parametro de IdUsuario
        public List<Permiso> Listar(int IdUsuario)
        {
            // devolvemos el metodo de listar la tabla de permisos con el parametro del IdUsuario
            return objcd_permiso.Listar(IdUsuario);
        }
    }
}
