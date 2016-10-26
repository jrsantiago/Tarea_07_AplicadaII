using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class Cliente : ClaseMaestra
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string  Direccion { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public List<Cliente>Listar { get; set; }

        public Cliente()
        {
            this.IdCliente = IdCliente;
            this.Nombre = "";
            this.Telefono = "";
            this.Direccion = "";
            this.Cedula = "";
            this.Email = "";
            this.Listar = new List<Cliente>();

        }
        public override bool Insertar()
        {
            DbVentana cone = new DbVentana();
            bool Retornar = false;
            try
            {
                Retornar = cone.Ejecutar(String.Format("Insert into Cliente(Nombre,Telefono,Cedula,Direccion,Email)Values('{0}','{1}','{2}','{3}','{4}')", this.Nombre, this.Telefono, this.Cedula, this.Direccion, this.Email));

            }catch(Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }

        public override bool Editar()
        {
            DbVentana cone = new DbVentana();
            bool Retornar = false;
            try
            {
                Retornar = cone.Ejecutar(String.Format("Update Cliente set Nombre='{0}',Telefono='{1}',Cedula='{2}',Direccion='{3}',Email='{4}' where IdCliente={5} ", this.Nombre, this.Telefono, this.Cedula, this.Direccion, this.Email, this.IdCliente));

            }catch(Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }

        public override bool Eliminar()
        {
            DbVentana cone = new DbVentana();
            bool Retornar = false;
            try
            {
                Retornar = cone.Ejecutar(String.Format("Delete from Cliente where IdCliente= ", this.IdCliente));

            }catch(Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            DbVentana cone = new DbVentana();
            bool Retornar = false;
            try
            {
                dt = cone.ObtenerDatos(String.Format("Select * from Cliente where IdCliente= {0}", IdBuscado));
                if(dt.Rows.Count>0)
                {
                    this.IdCliente = (int)dt.Rows[0]["IdCliente"];
                    this.Nombre = dt.Rows[0]["Nombre"].ToString();
                    this.Telefono =  dt.Rows[0]["Telefono"].ToString();
                    this.Cedula = dt.Rows[0]["Cedula"].ToString();
                    this.Direccion = dt.Rows[0]["Direccion"].ToString();
                    this.Email = dt.Rows[0]["Email"].ToString();
                }

            }catch(Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            DataTable dt = new DataTable();
            DbVentana cone = new DbVentana();
            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = "Orden BY " + Orden;
            return dt = cone.ObtenerDatos("Select " + Campos + " From Cliente "+Condicion+" "+ Orden);
        }
    }
}
