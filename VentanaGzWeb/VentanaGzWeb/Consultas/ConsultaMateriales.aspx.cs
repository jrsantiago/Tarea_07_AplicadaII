using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Microsoft.Reporting.WebForms;

namespace VentanaGzWeb.Consultas
{
    public partial class ConsultaMaeriales : System.Web.UI.Page
    {
        Materiales mate = new Materiales();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
      

           MaterialesGridView.DataSource= mate.Listado("*"," IdMaterial="+ BuscarTextBox.Text," --");
            MaterialesGridView.DataBind();
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {

            MaterialesReportViewer.LocalReport.DataSources.Clear();
            MaterialesReportViewer.ProcessingMode = ProcessingMode.Local;

            MaterialesReportViewer.LocalReport.ReportPath = @"Reportes\MaterialesReport.rdlc";

            ReportDataSource source = new ReportDataSource("MaterialesDataSet", mate.ListadoTotal("M.IdMaterial,M.Detalle,M.Unidad,M.Cantidad,M.Precio,M.Total", " M.IdMaterial= " + BuscarTextBox.Text, " GROUP BY M.IdMaterial, M.Detalle,M.Unidad,M.Cantidad,M.Precio,M.Total"));

            MaterialesReportViewer.LocalReport.DataSources.Add(source);
            MaterialesReportViewer.LocalReport.Refresh();

           // mate.ListadoTotal("M.Detalle,M.Unidad,M.Cantidad,M.Precio,Sum(T.Total)", " M.IdMaterial= " + BuscarTextBox.Text, " --"));
        }
    }
}