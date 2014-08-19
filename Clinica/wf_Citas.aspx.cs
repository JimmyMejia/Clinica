using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class wf_Citas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try 
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
	        catch (Exception err)
	        {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage= err.Message;
	        }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                lb_mensajes.Text = "";
                Entidad.Cat_Cita c = new Entidad.Cat_Cita();
                c.IdPaciente = int.Parse(ddl_paciente.SelectedValue);
                c.Fecha = DateTime.Parse(tb_fecha.Text);
                c.Hora = tb_hora.Text;
                c.IdServicio = int.Parse(ddl_motivo.SelectedValue);
                c.Estado = "Activa";

                Negocio.citaNegocio dc = new Negocio.citaNegocio();                
                dc.InsertarCita(c);
                lb_mensajes.ForeColor = System.Drawing.Color.Green;
                lb_mensajes.Text = "Datos almacenados correctamente!!!";
                CleanControls(this.Controls);
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage =err.Message;
            }            
        }

        protected void CleanControls(ControlCollection controles)
        {
            try
            {
                foreach (Control control in controles)
                {
                    if (control is TextBox)
                        ((TextBox)control).Text = string.Empty;
                    else if (control is DropDownList)
                        ((DropDownList)control).ClearSelection();
                    else if (control.HasControls())
                        CleanControls(control.Controls);
                }
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage =err.Message;
            }            
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                CleanControls(this.Controls);
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage =err.Message;
            }            
        }


    }
}