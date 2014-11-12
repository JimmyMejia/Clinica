using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class wf_Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string parametro;
                    parametro = Request.QueryString.Get("reporte");
                    if (parametro == "FACTURA")
                    {
                        Negocio.serviciobrindadoNegocio dc1 = new Negocio.serviciobrindadoNegocio();
                        Entidad.Cat_Servicio_Brindado fac = dc1.GetBy_NumFactura("2014000001");
                        //Negocio.DatosImpresion dcimpresion = new Negocio.DatosImpresion();
                        rv_reportes.LocalReport.ReportEmbeddedResource = "Clinica.Reportes.rpt_Factura.rdlc";
                        /*rv_reporte.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", dcimpresion.DatosFactura(fac)));
                        rv_reporte.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", dcimpresion.DatosFacturaDet(fac.Id)));*/
                        rv_reportes.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("nro_factura", "2014000001"));
                        rv_reportes.LocalReport.Refresh();
                    }

                    if (parametro == "CLINICAACTIVA")
                    {
                        Negocio.clinicaNegocio dc = new Negocio.clinicaNegocio();
                        rv_reportes.LocalReport.ReportEmbeddedResource = "Clinica.Reportes.rpt_ClinicaActiva.rdlc";
                        rv_reportes.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", dc.ClinicaActiva()));
                        rv_reportes.LocalReport.Refresh();
                    }
                }
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }  
        }


    }
}