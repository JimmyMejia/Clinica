using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class wf_Factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*CARGO EL CONTROL DDL_PACIENTE PARA TENER DISPONIBLE AL PACIENTE AL CUAL SELE VA A MODIFICAR LA CITA*/
                //CargarPacientes();
                /* CARGAMOS EL CONTROL DDL_MOTIVO PARA USARLO CUANDO SE VAYA A CAMBIAR EL TIPO DE SERVICIO A BRINDAR*/
                //CargarServicios();
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

        protected void CargarPacientes(string fecha)
        {
            try
            {
                //LIMPIAMOS EN CONTROL POR CUALQUIER COSA
                ddl_paciente.Items.Clear();
                //INSTANCIAMOS LO NECESARIO PARA OBTENER LA INFORMACION REQUERIDA
                Negocio.citasdeldia_spNegocio dc = new Negocio.citasdeldia_spNegocio();
                List<Entidad.CitasdelDia_SP_Result> p = null;
                p = dc.CitasdelDia(fecha);
                //ASIGNAMOS EN UNA VARIABLE SESSION LA LISTA DEVUELTA POR EL METODO CITASDELDIA 
                Session.Add("s_PacienteCitas", p);
                //CARGAMOS EL CONTROL PARA MOSTRAR LA LISTA DE PACIENTES
                ListItem item = new ListItem();
                item.Text = "Seleccione...";
                item.Value = "0";
                ddl_paciente.Items.Add(item);
                ddl_paciente.DataSource = p;
                ddl_paciente.DataTextField = "Paciente";
                ddl_paciente.DataValueField = "IdPaciente";
                ddl_paciente.DataBind();
            }
            catch (Exception err)
            {
                //MANEJAMOS EL ERROR
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al cargar los pacientes " + err.Message;
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
                //VALIDAMOS QUE LA FECHA A BUSCAR CONTENGA INFORMACION
                if (tb_fechafiltro.Text == "")
                {
                    //lb_mensajes.ForeColor = System.Drawing.Color.Red;
                    //lb_mensajes.Text = "Debe seleccionar la fecha a buscar!!!";
                    string mensaje = "MostrarMensaje('INFO','Debe digitar la fecha a buscar!!!')";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                }
                else
                {
                    //DECLARAMOS LAS INSTANCIAS NECESARIA PARA CONSUMIR Y OBTENER LA INFORMACION
                    Negocio.citasdeldia_spNegocio dc = new Negocio.citasdeldia_spNegocio();
                    List<Entidad.CitasdelDia_SP_Result> sd = null;
                    sd = dc.CitasdelDia(tb_fechafiltro.Text);
                    //VERIFICAMOS SI SE ENCUENTRAN CITAS PARA EL DIA SELECCIONADO
                    if (sd.Count != 0)
                    {
                        //CARGAMOS LOS PACIENTES EN EL DROPDOWNLIST
                        CargarPacientes(tb_fechafiltro.Text);
                        lb_mensajes.Text = "";
                    }
                    else
                    {
                        /*SI EL METODO NO RETORNA DATOS SE MUESTRA UN MENSAJE AL USUARIO*/
                        //lb_mensajes.ForeColor = System.Drawing.Color.Red;
                        //lb_mensajes.Text = "No hay citas para la fecha seleccionada!!!";
                        string mensaje = "MostrarMensaje('ERROR','No se encontraron citas para la fecha seleccionada!!!')";
                        ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                        ddl_paciente.Items.Clear();
                    }
                }
            }
            catch (Exception err)
            {
                //MANEJAMOS EL ERROR
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al filtrar las citas del dia " + err.Message;
            }
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {

        }

        protected void btn_facturar_Click(object sender, EventArgs e)
        {

        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            CleanControl(this.Controls);
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

    }
}