using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaDeEntidad;


namespace CapaDeDatos
{
    public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Instanciamos StringBuilder, ya que nos permite hacer consultas con saltos de linea en sql
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.IdUsuario,u.Documento,u.NombreCompleto,u.Correo,u.Contraseña,u.Estado,r.IdRol,r.Descripcion from USUARIO u");
                    query.AppendLine("inner join rol r on r.IdRol = u.IdRol");
                    // instanciamos la seleccion de la tabla con el query y la conexion a nuestra base de datos
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    // aqui le estamos diciendo que el tipo de comando que ejecutara sera un texto
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    // hacemos que pueda leer nuestro comando y ejecutarlo
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // mientras pueda leer la seleccion que hicimos hacia la tabla de usuarios
                        while (dr.Read())
                        {
                            // que pueda crear una lista que contenga los usuarios de la tabla
                            lista.Add(new Usuario()
                            {
                                // aqui convertimos el tipo de valor que contendra cada dato de nuestra tabla, tenemos que definirlo igual que cuando lo declaramos en sql
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Contraseña = dr["Contraseña"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString() }
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // si hay algun error a la hora de crear la lista, que la devuelva vacia
                    lista = new List<Usuario>();
                }
            }
            return lista;
        }

        // Creamos un metodo para registrar los usuarios y almacenarlos en nuestra base de datos
        public int RegistrarUsuario(Usuario objUsuario, out string Mensaje)
        {
            int idUsuarioGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    // Por medio de los parametros con valores hacemos posible el registro de los usuarios
                    SqlCommand cmd = new SqlCommand("SP_REGISTRAR_USUARIO", oConexion);
                    cmd.Parameters.AddWithValue("Documento", objUsuario.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", objUsuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", objUsuario.Correo);
                    cmd.Parameters.AddWithValue("Contraseña", objUsuario.Contraseña);
                    cmd.Parameters.AddWithValue("IdRol", objUsuario.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", objUsuario.Estado);
                    // Para los datos de salida tenemos que darle el nombre del parametro en sql y despues definir de que tipo es, asi mismo le especificamos por medio de direction el tipo de dato que es, si es de entrada o salida
                    cmd.Parameters.Add("IdUsuarioResultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    idUsuarioGenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            // Si causa algun fallo a la hora de registrar, que nos muestre el error de la excepcion por medio de un mensaje
            catch (Exception ex)
            {
                idUsuarioGenerado = 0;
                Mensaje = ex.Message;
            }

            return idUsuarioGenerado;

        }

        // Creamos un metodo para editar a los usuarios en nuestra base de datos
        public bool EditarUsuario(Usuario objUsuario, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    // Por medio de los parametros con valores hacemos posible el registro de los usuarios
                    SqlCommand cmd = new SqlCommand("SP_EDITAR_USUARIO", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", objUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("Documento", objUsuario.Documento);
                    cmd.Parameters.AddWithValue("Correo", objUsuario.Correo);
                    cmd.Parameters.AddWithValue("Contraseña", objUsuario.Contraseña);
                    cmd.Parameters.AddWithValue("IdRol", objUsuario.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", objUsuario.Estado);
                    // Para los datos de salida tenemos que darle el nombre del parametro en sql y despues definir de que tipo es, asi mismo le especificamos por medio de direction el tipo de dato que es, si es de entrada o salida
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            // Si causa algun fallo a la hora de editar, que nos muestre el error de la excepcion por medio de un mensaje
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;

        }


        // Creamos un metodo para editar a los usuarios en nuestra base de datos
        public bool EliminarUsuario(Usuario objUsuario, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    // Por medio de los parametros con valores hacemos posible el registro de los usuarios
                    SqlCommand cmd = new SqlCommand("SP_ELIMINAR_USUARIO", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", objUsuario.IdUsuario);
                    // Para los datos de salida tenemos que darle el nombre del parametro en sql y despues definir de que tipo es, asi mismo le especificamos por medio de direction el tipo de dato que es, si es de entrada o salida
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            // Si causa algun fallo a la hora de editar, que nos muestre el error de la excepcion por medio de un mensaje
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;

        }
    }
}
