using CapaDeEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDeDatos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int IdUsuario)
        {
            List<Permiso> lista = new List<Permiso>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    // Instanciamos StringBuilder, ya que nos permite hacer consultas con saltos de linea en sql
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.IdRol,p.NombreDeMenu from PERMISO p");
                    query.AppendLine("inner join ROL r on r.IdRol = p.IdRol");
                    query.AppendLine("inner join USUARIO u on u.IdRol = r.IdRol");
                    // para asignar los menus a cada usuario en nuestro porgrama, nos basamos en el id que tenga el usuario segun su rol y permiso anteriormente definido, ademas se enviara como parametro el id del usuario
                    query.AppendLine("where u.IdUsuario = @idUsuario");


                    // instanciamos la seleccion de la tabla con el query y la conexion a nuestra base de datos
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);

                    // aqui le estamos diciendo que el tipo de comando que ejecutara sera un texto
                    cmd.CommandType = CommandType.Text;

                    // abrimos la conexion hacia nuestra base de datos
                    oConexion.Open();

                    // hacemos que pueda leer nuestro comando y ejecutarlo
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // mientras pueda leer la seleccion que hicimos hacia la tabla de usuarios
                        while (dr.Read())
                        {
                            // que pueda crear una lista que contenga los usuarios de la tabla
                            lista.Add(new Permiso()
                            {
                                // aqui convertimos el tipo de valor que contendra cada dato de nuestra tabla, tenemos que definirlo igual que cuando lo declaramos en sql
                                
                                // Instanciamos el objeto Rol para guardar el valor que tenga IdRol en la tabla de rol de sql, y convertirlo a entero de 32 bits
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) } ,
                                NombreDeMenu = dr["NombreDeMenu"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // si hay algun error a la hora de llamar a la lista, que la devuelva vacia
                    lista = new List<Permiso>();
                }
            }
            return lista;
        }
    }
}
