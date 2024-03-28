using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDeDatos;
using CapaDeEntidad;

namespace CapaDeNegocio
{
    public class CN_Usuario
    {
        // instanciamos CD_Usuario en la capa de Negocio
        private CD_Usuario objcd_usuario = new CD_Usuario();

        public List<Usuario> Listar()
        {
            // devolvemos el metodo de listar la tabla de usuarios
            return objcd_usuario.Listar();
        }

        // creamos y llamamos a los metodos de registrar, editar y eliminar usuario
        public int RegistrarUsuario(Usuario objUsuario, out string Mensaje)
        {
            // Hacemos unas validaciones al momento de registrar un nuevo usuario
            Mensaje = string.Empty;

            if (objUsuario.Documento == "") Mensaje += "Es necesario añadir el documento del usuario.\n";
            if (objUsuario.NombreCompleto == "") Mensaje += "Es necesario añadir el nombre completo del usuario.\n";
            if (objUsuario.Contraseña == "") Mensaje += "Es necesario añadir una contraseña al usuario.\n";

            if (Mensaje != string.Empty) return 0;
            else return objcd_usuario.RegistrarUsuario(objUsuario, out Mensaje);
        }

        public bool EditarUsuario(Usuario objUsuario, out string Mensaje)
        {
            // Hacemos las mismas validaciones de registrar un usuario pero ahora en editar para que se mantenga la igualdad en ambos metodos
            Mensaje = string.Empty;

            if (objUsuario.Documento == "") Mensaje += "Es necesario añadir el documento del usuario.\n";
            if (objUsuario.NombreCompleto == "") Mensaje += "Es necesario añadir el nombre completo del usuario.\n";
            if (objUsuario.Contraseña == "") Mensaje += "Es necesario añadir una contraseña al usuario.\n";

            if (Mensaje != string.Empty) return false;
            else return objcd_usuario.EditarUsuario(objUsuario, out Mensaje);
        }

        public bool EliminarUsuario(Usuario objUsuario, out string Mensaje)
        {
            return objcd_usuario.EliminarUsuario(objUsuario, out Mensaje);
        }
    }
}
