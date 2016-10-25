﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace VentanaGzWeb.Registros
{
    public partial class ReMateriales : System.Web.UI.Page
    {
        Materiales mate = new Materiales();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void ObtenerDatos()
        {
            float cantidad = 0;
            float precio = 0;
            float.TryParse(CantidadTextBox.Text,out cantidad);
            float.TryParse(PrecioTextBox.Text, out precio);

            mate.Detalle = DetalleTextBox.Text;
            mate.Unidad = UnidadTextBox.Text;
            mate.Cantidad = cantidad;
            mate.Precio = precio;
        }
        public void LlenarDatos()
        {
            DetalleTextBox.Text = mate.Detalle;
            UnidadTextBox.Text = mate.Unidad;
            CantidadTextBox.Text = mate.Cantidad.ToString();
            PrecioTextBox.Text = mate.Precio.ToString();

        }
        public int ObtenerId()
        {
            int id = 0;

            int.TryParse(BuscarTextBox.Text, out id);
            return id;

        }
        public void Limpiar()
        {
            BuscarTextBox.Text = "";
            DetalleTextBox.Text = "";
            UnidadTextBox.Text = "";
            CantidadTextBox.Text = "";
            PrecioTextBox.Text = "";
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(DetalleTextBox.Text) || string.IsNullOrWhiteSpace(UnidadTextBox.Text) || string.IsNullOrWhiteSpace(CantidadTextBox.Text) || string.IsNullOrWhiteSpace(PrecioTextBox.Text))
            {
                Response.Write("<script>alert('LLene Todos los Campos')</script>");
            }
            else if(BuscarTextBox.Text=="")
            {
                ObtenerDatos();
                if(mate.Insertar())
                {
                    Response.Write("<script>alert('Guardado')</script>");
                }
            }else
            {
                ObtenerDatos();
                if(mate.Editar())
                {
                    Response.Write("<script>alert('Editado')</script>");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(BuscarTextBox.Text))
            {
                Response.Write("<script>alert('Introdusca Id')</script>");
            }
            else
            {
                if(mate.Eliminar())
                {
                    Response.Write("<script>alert('Eliminado')</script>");
                    Limpiar();
                }
            }
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text))
            {
                Response.Write("<script>alert('Introdusca Id')</script>");
            }
            else
            {

                if (mate.Buscar(ObtenerId()))
                {
                    LlenarDatos();
                }
            }
        }
    }
}