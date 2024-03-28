using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocio;
using CapaDeEntidad;

namespace CapaDePresentacion
{
    public partial class Login : Form
    {
        // aqui se almacenan todos los elementos que implementemos al formulario junto con sus metodos si asi lo desearamos
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CN_Usuario().Listar();
            // como no tenemos usuarios registrados, pedimos que registre lo que ingresemos en la pantalla de login
            Usuario oUsuario = new CN_Usuario().Listar().Where(u => u.Documento == txtDocumento.Text && u.Contraseña == txtContraseña.Text).FirstOrDefault();

            if (oUsuario != null)
            {
                // cuando el usuario ingrese un usuario valido, se le mostrara el formulario de inicio que contiene todas las tareas del programa
                Inicio form = new Inicio(oUsuario);
                form.Show();
                // este metodo hide es para ocultar la ventana anterior y solo mostrar la actual
                this.Hide();

                // cuando se cierre el formulario de inicio, que tambien ejecute el metodo de cerrarFormulario y nos muestre al formulario de login
                form.FormClosed += cerrarFormulario;
            }
            else
            {
                MessageBox.Show("No se encontro el usuario","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // creamos un metodo que nos permita mostrar la ventana de usuarios al momento de cerrar el formulario de inicio
        private void cerrarFormulario(object sender, FormClosedEventArgs e)// EventArgs es el mayor de la jerarquia porque es una clase generica de los eventos que se encuentran guardados en el objeto de sender.
        {
            // aqui decimos que cuando cerremos el formulario de inicio, no muestre nada en los campos de texto del formulario de login
            txtDocumento.Text = "";
            txtContraseña.Text = "";
            // con este metodo mostramos el formulario anterior a este, en este caso, el de login
            this.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // cuando le demos click al boton de cancelar, se cerrara el programa con el metodo close
            this.Close();
        }
    }
}
