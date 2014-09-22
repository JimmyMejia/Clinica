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

        protected void gv_citas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                /*OBTENEMOS DEL GRID LA FILA SELECCIONADA*/
                GridViewRow row = gv_citas.SelectedRow;
                string cita = gv_citas.DataKeys[row.RowIndex].Values["IdCita"].ToString();
                Session["s_idcita"] = cita;
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
                    Session["s_idcita"] = cs.IdCita;
                    ddl_paciente.SelectedValue = cs.IdPaciente.ToString();
                    tb_fecha.Text = cs.Fecha.ToString();
                    tb_hora.Text = cs.Hora;
                    ddl_motivo.SelectedValue = cs.IdServicio.ToString();
                    if (cs.Estado == "Activa")
                        rb_activa.Checked = true;
                    else
                        rb_cancelada.Checked = true;
                    tb_fecha.Enabled = true;
                    tb_hora.Enabled = true;
                    ddl_motivo.Enabled = true;
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
                    lb_mensajes.ForeColor = System.Drawing.Color.Red;
                    lb_mensajes.Text = "No hay citas para la fecha seleccionada!!!";
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
                /*LLAMAMOS AL METODO CARGAR GRID PARA PODER LLENAR EL GRID CON LA INFORMACION OBTENIDA EN ESTE METODO*/
                lb_mensajes.Text = "";                
                string fechafiltro = tb_fechafiltro.Text;
                Session["s_fecha"] = fechafiltro;
                CargarGrid((string)Session["s_fecha"]);
                //CleanControl(this.Controls);
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
                cs.IdCita = (string)Session["s_idcita"];
                cs.IdPaciente = int.Parse(ddl_paciente.SelectedValue);
                cs.Fecha = DateTime.Parse(tb_fecha.Text);
                cs.Hora = tb_hora.Text;
                cs.IdServicio = int.Parse(ddl_motivo.SelectedValue);
                cs.FechaModificacion = DateTime.Now;
                if (rb_activa.Checked == true)
                    cs.Estado = "Activa";
                else
                    cs.Estado = "Cancelada";
                /*DECLARAMOS UN OBJETO DE TIPO NEGOCIO PARA PODER HACER EL LLAMADO DEL METODO QUE UTILIZAREMOS*/                
                Negocio.citaNegocio dc = new Negocio.citaNegocio();
                /*LLAMAMOS AL METODO UPDATECITA Y PASAMOS COMO PARAMETRO LA */
                dc.UpdateCita(cs);
                lb_mensajes.ForeColor = System.Drawing.Color.Green;
                lb_mensajes.Text = "Datos actualizados correctamente!!!";
                /*CARGAMOS EL GRID PARA REFLEJAR EL CAMBIO DE LA INFORMACION*/
                CargarGrid((string)Session["s_fecha"]);
                /*LIMPIAMOS LOS CONTROLES*/
                CleanControl(this.Controls);
                /*INHABILITAMOS LOS CONTROLES*/
                tb_fecha.Enabled = false;
                tb_hora.Enabled = false;
                ddl_motivo.Enabled = false;
                rb_activa.Enabled = false;
                rb_cancelada.Enabled = false;
                btn_modificar.Enabled = false;


                /*ELIMINAMOS LAS SESIONES*/
                Session.Remove("s_fecha");
                Session.Remove("s_idcita");

            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            /*LIMPIAMOS LOS CONTROLES*/
            CleanControl(this.Controls);
            tb_fecha.Enabled = false;
            tb_hora.Enabled = false;
            ddl_motivo.Enabled = false;
            rb_activa.Enabled = false;
            rb_cancelada.Enabled = false;
            btn_modificar.Enabled = false;
        }

    }
}