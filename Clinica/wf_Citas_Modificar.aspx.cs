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
                /*CARGO EL CONTROL DDL_PACIENTE PARA TENER DISPONIBLE AL PACIENTE AL CUAL SELE VA A MODIFICAR LA CITA*/
                CargarPacientes();
                /* CARGAMOS EL CONTROL DDL_MOTIVO PARA USARLO CUANDO SE VAYA A CAMBIAR EL TIPO DE SERVICIO A BRINDAR*/
                CargarServicios();
                /*CARGO EL CONTROL DDL_MEDICO PARA TENER DISPONIBLE AL MEDICO QUE SELE ASIGNO DICHA CITA*/
                CargarMedicos();
                
            }
        }

        protected void CargarServicios()
        {
            try
            {
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
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void CargarPacientes()
        {
            try
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
            }
            catch (Exception err)
            {
                 cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void CargarMedicos()
        {
            Negocio.medicoNegocio dc = new Negocio.medicoNegocio();
            List<Entidad.Medico> medicos = null;
            medicos = dc.ListaMedico();
            ListItem ini2 = new ListItem();
            ini2.Text = "Seleccione...";
            ini2.Value = "0";
            ddl_medico.Items.Add(ini2);
            ddl_medico.DataSource = medicos;
            ddl_medico.DataTextField = "NombreCompleto";
            ddl_medico.DataValueField = "NroCedula";
            ddl_medico.DataBind();
        }

        protected void gv_citas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                /*OBTENEMOS DEL GRID LA FILA SELECCIONADA*/
                GridViewRow row = gv_citas.SelectedRow;
                string cita = gv_citas.DataKeys[row.RowIndex].Values["IdCita"].ToString();
                Session["S_IdCita"] = cita;
                /*LLAMAMOS AL METODO ENCARGADO PARA OBTENER LA CITA SELECCIONADA*/
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
                /*MANDAMOS A CARGAR LOS CAMPOS DEL FORMULARIO CON LO QUE POSEE LA ENTIDAD DE TIPO CAT_CITA OBTENIDOS EN EL METODO CONSULTARCITA*/
                Negocio.citaNegocio dc = new Negocio.citaNegocio();
                Entidad.Cat_Cita cs = dc.ConsultarCita(id_cita);
                if (cs != null)
                {
                    Session["S_IdCita"] = cs.IdCita;
                    ddl_paciente.SelectedValue = cs.IdPaciente.ToString();
                    tb_fecha.Text = cs.Fecha.ToString();
                    tb_hora.Text = cs.Hora;
                    ddl_motivo.SelectedValue = cs.IdServicio.ToString();
                    ddl_medico.SelectedValue = cs.NroCedula;
                    if (cs.Estado == "Activa")
                        rb_activa.Checked = true;
                    else
                        rb_cancelada.Checked = true;
                    tb_fecha.Enabled = true;
                    tb_hora.Enabled = true;
                    ddl_motivo.Enabled = true;
                    ddl_medico.Enabled = true;
                    rb_activa.Enabled = true;
                    rb_cancelada.Enabled = true;
                    btn_modificar.Enabled = true;
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
                /*PAGINAMOS EL GRID Y PERMITIMOS LA NAVEGACION EN ESTE*/
                /*LIMPIAMOS CON CONTROLES POR SI SE TENIA ALGO SELECCIONADO*/
                /*VOLVEMOS A CARGAR EL GRID PARA PODER NAVEGAR POR SUS PAGINAS*/
                gv_citas.PageIndex = e.NewPageIndex;
                CleanControl(this.Controls);
                CargarGrid((string)Session["S_Fecha"]);
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
                /*CARGAMOS EL GRID CON LA INFORMACION OBTENIDA EN LA ENTIDAD CITASDELDIA_SP_RESULT*/
                Negocio.citasdeldia_spNegocio dc = new Negocio.citasdeldia_spNegocio();
                List<Entidad.CitasdelDia_SP_Result> citas = null;
                citas = dc.CitasdelDia(fecha);
                if (citas.Count != 0)
                {
                    gv_citas.DataSource = citas;
                    gv_citas.DataBind();
                }
                else
                {
                    /*SI EL METODO NO RETORNA DATOS SE MUESTRA UN MENSAJE AL USUARIO*/
                    //lb_mensajes.ForeColor = System.Drawing.Color.Red;
                    //lb_mensajes.Text = "No hay citas para la fecha seleccionada!!!";
                    string mensaje = "MostrarMensaje('ERROR','No se encontraron citas para la fecha digitada!!!')";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                    //tb_fechafiltro.Focus();
                    List<Entidad.CitasdelDia_SP_Result> ct = new List<Entidad.CitasdelDia_SP_Result>();
                    gv_citas.DataSource = ct;
                    gv_citas.DataBind();
                }
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
                if (tb_fechafiltro.Text == "")
                {
                    string mensaje = "MostrarMensaje('INFO','Debe digitar la fecha a filtrar!!!')";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                    List<Entidad.CitasdelDia_SP_Result> ct = new List<Entidad.CitasdelDia_SP_Result>();
                    gv_citas.DataSource = ct;
                    gv_citas.DataBind();
                }
                else
                {
                    /*LLAMAMOS AL METODO CARGAR GRID PARA PODER LLENAR EL GRID CON LA INFORMACION OBTENIDA EN ESTE METODO*/
                    lb_mensajes.Text = "";
                    string fechafiltro = tb_fechafiltro.Text;
                    Session["S_Fecha"] = fechafiltro;
                    CargarGrid((string)Session["S_Fecha"]);
                    //CleanControl(this.Controls);
                }
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }
        
        protected void CleanControl(ControlCollection controls)
        {
            try
            {
                /*METODO UTILIZADO PARA LIMPIAR LOS CONTROLES*/
                foreach (Control controles in controls)
                {
                    if (controles is TextBox)
                        ((TextBox)controles).Text = string.Empty;
                    else if (controles is DropDownList)
                        ((DropDownList)controles).ClearSelection();
                    else if (controles is RadioButton)
                        ((RadioButton)controles).Checked = false;
                    else if (controles is CheckBox)
                        ((CheckBox)controles).Checked = false;                    
                    else if (controles.HasControls())
                        CleanControl(controles.Controls);
                }
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                /*ASIGNAMOS A UNA ENTIDAD DE TIPO CAT_CITA*/
                Entidad.Cat_Cita cs = new Entidad.Cat_Cita();
                cs.IdCita = (string)Session["S_IdCita"];
                cs.IdPaciente = int.Parse(ddl_paciente.SelectedValue);
                cs.Fecha = DateTime.Parse(tb_fecha.Text);
                cs.Hora = tb_hora.Text;
                cs.IdServicio = int.Parse(ddl_motivo.SelectedValue);
                cs.NroCedula = ddl_medico.SelectedValue;
                cs.FechaModificacion = DateTime.Now;
                if (rb_activa.Checked == true)
                    cs.Estado = "Activa";
                else
                    cs.Estado = "Cancelada";
                /*DECLARAMOS UN OBJETO DE TIPO NEGOCIO PARA PODER HACER EL LLAMADO DEL METODO QUE UTILIZAREMOS*/                
                Negocio.citaNegocio dc = new Negocio.citaNegocio();
                /*LLAMAMOS AL METODO UPDATECITA Y PASAMOS COMO PARAMETRO LA */
                dc.UpdateCita(cs);
                //lb_mensajes.ForeColor = System.Drawing.Color.Green;
                //lb_mensajes.Text = "Datos actualizados correctamente!!!";
                string mensaje = "MostrarMensaje('SUCCESS','Datos actualizados correctamente!!!')";
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                /*CARGAMOS EL GRID PARA REFLEJAR EL CAMBIO DE LA INFORMACION*/
                CargarGrid((string)Session["S_Fecha"]);
                /*LIMPIAMOS LOS CONTROLES*/
                CleanControl(this.Controls);
                /*INHABILITAMOS LOS CONTROLES*/
                InhabilitarControles();
                btn_modificar.Enabled = false;


                /*ELIMINAMOS LAS SESIONES*/
                Session.Remove("S_Fecha");
                Session.Remove("S_IdCita");

            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void InhabilitarControles()
        {
            tb_fecha.Enabled = false;
            tb_hora.Enabled = false;
            ddl_motivo.Enabled = false;
            ddl_medico.Enabled = false;
            rb_activa.Enabled = false;
            rb_cancelada.Enabled = false;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            /*LIMPIAMOS LOS CONTROLES*/
            CleanControl(this.Controls);
            InhabilitarControles();
            btn_modificar.Enabled = false;
        }

        protected void tb_fechafiltro_TextChanged(object sender, EventArgs e)
        {
            ddl_paciente.ClearSelection();
            tb_fecha.Text = "";
            tb_hora.Text = "";
            ddl_motivo.ClearSelection();
            InhabilitarControles();
            btn_modificar.Enabled = false;
        }

    }
}