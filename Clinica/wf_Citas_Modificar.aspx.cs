using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class wf_Citas_Modificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Negocio.pacienteNegocio dcpaciente = new Negocio.pacienteNegocio();
                List<Entidad.Paciente> listpacientes = null;
                listpacientes = dcpaciente.Pacientes();
                ListItem ini = new ListItem();
                ini.Value = "0";
                ini.Text = "Selecccione...";
                ddl_paciente.Items.Add(ini);
                ddl_paciente.DataSource = listpacientes;
                ddl_paciente.DataTextField = "Nombres";
                ddl_paciente.DataValueField = "IdPaciente";
                ddl_paciente.DataBind();


                // Cargamos el control del motivo de la cita
                Negocio.serviciosNegocio dcservicios = new Negocio.serviciosNegocio();
                List<Entidad.Cat_Servicio> servicios = null;
                servicios = dcservicios.ListaServicios();
                ListItem ini1 = new ListItem();
                ini1.Value = "0";
                ini1.Text = "Seleccione...";
                ddl_motivo.Items.Add(ini1);
                ddl_motivo.DataSource = servicios;
                ddl_motivo.DataTextField = "Descripcion";
                ddl_motivo.DataValueField = "IdServicio";
                ddl_motivo.DataBind();
            }
        }

        protected void gv_citas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gv_citas.SelectedRow;
                string cita = gv_citas.DataKeys[row.RowIndex].Values["IdCita"].ToString();
                Session["s_idcita"] = cita;
                SeleccionCita(cita);                
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }
        
        protected void SeleccionCita(string id_cita)
        {
            try
            {
                Negocio.citaNegocio dc = new Negocio.citaNegocio();
                Entidad.Cat_Cita cs = dc.ConsultarCita(id_cita);
                if (cs != null)
                {
                    Session["s_idcita"] = cs.IdCita;
                    ddl_paciente.SelectedIndex = int.Parse(cs.IdPaciente.ToString());
                    tb_fecha.Text = cs.Fecha.ToString();
                    tb_hora.Text = cs.Hora;
                    ddl_motivo.SelectedIndex = int.Parse(cs.IdServicio.ToString());
                }
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void gv_citas_PageIndexChanging(object o, GridViewPageEventArgs e)
        {
            try
            {
                gv_citas.PageIndex = e.NewPageIndex;
                CargarGrid((string)Session["s_fecha"]);
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
            
        }
        protected void CargarGrid(string fecha)
        {
            try
            {
                Negocio.citasdeldia_spNegocio dc = new Negocio.citasdeldia_spNegocio();
                List<Entidad.CitasdelDia_SP_Result> citas = null;
                citas = dc.CitasdelDia(fecha);
                gv_citas.DataSource = citas;
                gv_citas.DataBind();
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            try
            {
                string fechafiltro = tb_fechafiltro.Text;
                Session["s_fecha"] = fechafiltro;
                CargarGrid((string)Session["s_fecha"]);
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }        


    }
}