using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace VentanaGzWeb.Registros
{
    public partial class ReCliente : System.Web.UI.Page
    {
        Cliente cli = new Cliente();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void LLenarCampos()
        {
            NombreTextBox.Text = cli.Nombre;
            TelefonoTextBox.Text = cli.Telefono;
            DireccionTextBox.Text = cli.Direccion;
            CedulaTextBox.Text = cli.Cedula;
            EmailTextBox.Text = cli.Email;
        }
        public bool ObtenerDatos()
        {
            bool Retornar = false;
          
            if(string.IsNullOrWhiteSpace(NombreTextBox.Text) || string.IsNullOrWhiteSpace(TelefonoTextBox.Text) || string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                //Verifica Campos Vacios

            }else
            {
               cli.Nombre = NombreTextBox.Text;
               cli.Telefono = TelefonoTextBox.Text;
               cli.Direccion = DireccionTextBox.Text;
               cli.Cedula = CedulaTextBox.Text;
               cli.Email = EmailTextBox.Text;
               Retornar = true;
            }
          

            return Retornar;
        }
        public void Limpiar()
        {
            BuscarTextBox.Text = "";
            NombreTextBox.Text = "";
            DireccionTextBox.Text = "";
            CedulaTextBox.Text = "";
            EmailTextBox.Text = "";
            TelefonoTextBox.Text = "";

        }
        public int convertirId()
        {
            int id = 0;
            int.TryParse(BuscarTextBox.Text, out id);
            return id;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
           
            if(string.IsNullOrWhiteSpace(BuscarTextBox.Text))
            {
                //Mensaje de Error...
            }else
            {
                if(cli.Buscar(convertirId()))
                {
                    LLenarCampos();
                    //mensaje de guardado
                }
            }

                 
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ObtenerDatos() == false)
            {
                //mensaje de campos vacios
            }
            else
            {
                ObtenerDatos();
                if (string.IsNullOrWhiteSpace(BuscarTextBox.Text))
                {
                    if (cli.Insertar())
                    {
                        //mensaje de insertior
                    }
                }
                else
                {
                    if (cli.Editar())
                    {
                        //Mensaje de Editar
                    }
                }
            }

        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(BuscarTextBox.Text))
            {
                //Mensaje de llenar
            }else
            {
                if(cli.Eliminar())
                {
                    //Mensaje de Eliminar..
                }
            }
        }
    }
}