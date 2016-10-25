﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
   public class Materiales : ClaseMaestra
    {

        public int IdMaterial { get; set; }
        public string Detalle { get; set; }
        public string Unidad { get; set; }
        public float Cantidad { get; set; }
        public float Precio { get; set; }
        public List<Materiales> Listar { get; set; }
        public Materiales()
        {
            this.IdMaterial = 0;
            this.Detalle = "";
            this.Unidad = "";
            this.Cantidad = 0;
            this.Precio = 0;
            this.Listar = new List<Materiales>();
        }
        public override bool Buscar(int IdBuscado)
        {
            DbVentana cone = new DbVentana();
            DataTable dt = new DataTable();
            bool Retornar = true;

            try
            {
                dt = cone.ObtenerDatos(String.Format("Select * from Materiales where idMaterial = {0}", IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.Detalle = dt.Rows[0]["Detalle"].ToString();
                    this.Unidad = dt.Rows[0]["Unidad"].ToString();
                    this.Cantidad = Convert.ToSingle(dt.Rows[0]["Cantidad"]);
                    this.Precio = Convert.ToSingle(dt.Rows[0]["Precio"]);
                }

            }
            catch (Exception ex)
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
                Retornar = cone.Ejecutar(String.Format("Update Materiales set Detalle='{0}',Unidad='{1}',Cantidad={3},Precio={4} where IdMaterial={5}", this.Detalle, this.Unidad, this.Cantidad, this.Precio, this.IdMaterial));

            }
            catch (Exception ex)
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
                Retornar = cone.Ejecutar(String.Format("Delete from Materiales where IdMaterial={0}", this.IdMaterial));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retornar;
        }

        public override bool Insertar()
        {
            DbVentana cone = new DbVentana();
            bool Retornar = false;

            try
            {
                Retornar = cone.Ejecutar(String.Format("Insert into Materiales(Detalle,Unidad,Cantidad,Precio) Values('{0}','{1}',{2},{3})", this.Detalle, this.Unidad, this.Cantidad, this.Precio));
                cone.Ejecutar(String.Format("Insert into TotalMateriales(Total) Values({0}", this.Precio));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retornar;

        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            DbVentana cone = new DbVentana();

            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = "Orden by" + Orden;

            return cone.ObtenerDatos("Select " + Campos + " from Materiales where " + Condicion + " ");

        }
        public DataTable ListadoTotal(string Campos, string Condicion, string Orden)
        {
            DbVentana cone = new DbVentana();

            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = "Orden by" + Orden;

            return cone.ObtenerDatos("Select " + Campos + " from Materiales as M inner join TotalMateriales T on M.IdMaterial = T.IdMaterial where " + Condicion + Orden);
        }




    }
}
