using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeEntidad;
using CapaDeNegocio;
using FontAwesome.Sharp;

namespace CapaDePresentacion
{
    public partial class Inicio : Form
    {
        // estas variables seran globales para poder usarlas en todos los metodos que se declaren en el formulario de inicio
        private static Usuario usuarioActual;
        private static IconMenuItem menuActivo = null;
        private static Form formularioActivo = null;

        public Inicio(Usuario objUsuario = null)
        {
            // creamos una condicional que no reciba ningun usuario de nuestra base de datos, sino que lo creamos desde la instacia de Usuario
            if (objUsuario == null)
            {
                usuarioActual = new Usuario() { NombreCompleto = "ADMIN POR DEFECTO", IdUsuario = 1};
            }
            else
            {
                usuarioActual = objUsuario;
            }
            //usuarioActual = objUsuario;
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            // Creamos una lista al momento de pasar al formulario de inicio sobre los permisos del usuario ingresado, todo esto recibiendo como parametro el id del mismo usuario
            List<Permiso> ListaPermiso = new CN_Permiso().Listar(usuarioActual.IdUsuario);

            foreach (IconMenuItem iconMenu in menu.Items)
            {
                bool encontrado = ListaPermiso.Any(m => m.NombreDeMenu == iconMenu.Name);

                if (encontrado == false)
                {
                    iconMenu.Visible = false;
                }
            }

            // al momento de pasar al formulario de inicio, que nos muestre el nombre del usuario que acaba de ingresar, o bien, su tipo de usuario.
            lblUsuario.Text = usuarioActual.NombreCompleto;
        }

        // Creamos un metodo para abrir los formularios que esten dentro de cada menu, le pasamos como parametros el iconmenu que este seleccionado en el formulario de inicio junto con su formulario aparte 
        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (menuActivo != null)
            {
                // si el menu no esta seleccionado, entonces que vuelva a su color anterior, en este caso el blanco
                menuActivo.BackColor = Color.White;
            }
            // el menu que se seleccione que quede marcado con este color
            menu.BackColor = Color.Silver;
            menuActivo = menu;

            if (formularioActivo != null)
            {
                // cerramos el formulario que este activo, para que el nuevo que abramos este dentro del contenedor y no los dos al mismo tiempo.
                formularioActivo.Close();
            }

            // Antes de que se abra el formulario, que tenga estas propiedades:

            // primero almacenamos el formulario que vamos a abrir en el formulario activo para que se muestre ese y no el anterior.
            formularioActivo = formulario;

            // Que el formulario no este en el lado superior al iniciar, sino que se mantenga en el contenedor
            formulario.TopLevel = false;
            
            // Que no tenga ningun borde al abrirse
            formulario.FormBorderStyle = FormBorderStyle.None;
            
            // Cuando el formulario quiera rellenar el contenedor, que lo haga en todo el contenedor, es decir, que no queden espacios sin rellenar dentro de este
            formulario.Dock = DockStyle.Fill;
            
            // Que al abrirse tenga un color de fondo, en este caso el verde
            formulario.BackColor = Color.Green;

            // Una vez ya definidas las propiedades del formulario, se procede a agregarlo al contenedor
            contenedor.Controls.Add(formulario);

            // Se muestra el resultado final junto con el formulario
            formulario.Show();
        }

        private void menuUsuario_Click(object sender, EventArgs e)
        {
            // el metodo se ejecutara cuando tengamos un menu seleccionado, en este caso sera de tipo IconMenuItem, y tambien le pasamos el parametro de la instacia al Formulario usuario
            AbrirFormulario((IconMenuItem)sender, new FormUsuarios());
        }

        private void subMenuCategoria_Click(object sender, EventArgs e)
        {
            // aqui hacemos referencia al menu principal del mantenedor en el objeto, y luego iniciamos el formulario de categoria
            AbrirFormulario(menuMantenedor, new FormCategoria());
        }

        private void subMenuProducto_Click(object sender, EventArgs e)
        {
            // hacemos lo mismo que en categoria, pero esta vez iniciamos el formulario de producto
            AbrirFormulario(menuMantenedor, new FormProducto());
        }

        private void subMenuRegistrarVenta_Click(object sender, EventArgs e)
        {
            // Referenciamos al menu que contiene las ventas e iniciamos su formulario
            AbrirFormulario(menuVentas, new FormVentas());
        }

        private void subMenuVerDetalleDeLaVenta_Click(object sender, EventArgs e)
        {
            // Referenciamos al menu que contiene las ventas e iniciamos el formulario del detalle de las ventas
            AbrirFormulario(menuVentas, new FormDetalleDeLaVenta());
        }

        private void subMenuRegistrarCompra_Click(object sender, EventArgs e)
        {
            // Referenciamos al menu que contiene las compras e iniciamos su formulario
            AbrirFormulario(menuCompras, new FormCompras());
        }

        private void subMenuVerDetalleDeLaCompra_Click(object sender, EventArgs e)
        {
            // Referenciamos al menu que contiene las compras e iniciamos el formulario que contiene el detalle de las compras
            AbrirFormulario(menuCompras, new FormDetalleDeLaCompra());
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            // el metodo se ejecutara cuando tengamos un menu seleccionado, en este caso sera de tipo IconMenuItem, y tambien le pasamos el parametro de la instacia al Formulario clientes
            AbrirFormulario((IconMenuItem)sender, new FormClientes());
        }

        private void menuProveedores_Click(object sender, EventArgs e)
        {
            // el metodo se ejecutara cuando tengamos un menu seleccionado, en este caso sera de tipo IconMenuItem, y tambien le pasamos el parametro de la instacia al Formulario proveedores
            AbrirFormulario((IconMenuItem)sender, new FormProveedores());
        }

        private void menuReportes_Click(object sender, EventArgs e)
        {
            // el metodo se ejecutara cuando tengamos un menu seleccionado, en este caso sera de tipo IconMenuItem, y tambien le pasamos el parametro de la instacia al Formulario reportes
            AbrirFormulario((IconMenuItem)sender, new FormReportes());
        }
    }
}
