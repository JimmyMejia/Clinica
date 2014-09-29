using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class wf_Citas_Atender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

        protected void ddl_paciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //DECLARAMOS UNA LISTA DEL TIPO DEL RESULTADO DEL SP Y LE ASIGNAMOS EL CONTENIDO DE LA VARIABLE SESSION
                List<Entidad.CitasdelDia_SP_Result> citas = (List<Entidad.CitasdelDia_SP_Result>)Session["s_PacienteCitas"];
                //VERIFICAMOS SI LA VARIABLE TIENE INFORMACION
                if (citas != null)
                {
                    //SI LA VARIABLE CONTINE INFORMACION SE OBTIENE EL ID DEL PACIENTE QUE TIENE LA LISTA Y SE COMPARA PARA OBTENER
                    //LA INFORMACION REFERENTE A ESE PACIENTE
                    Entidad.CitasdelDia_SP_Result c = citas.Where(ct=>ct.IdPaciente == int.Parse(ddl_paciente.SelectedValue)).FirstOrDefault();
                    //CARGAMOS LA INFORMACION EN LOS CONTROLES CORRESPONDIENTES
                    tb_fecha.Text = c.Fecha.ToString(); 
                    tb_hora.Text = c.Hora.ToString();
                    tb_motivo.Text = c.Descripcion;
                    tb_observaciones.Enabled = true;
                    btn_atender.Enabled = true;
                }
            }
            catch (Exception err)
            {
                //MANEJAMOS EL ERROR
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al cargar la información de la cita " + err.Message;
            }
        }

        /// <summary>
        /// METODO PARA LIMPIAR LOS CONTROLES
        /// </summary>
        /// <param name="controls"></param>
        protected void CleanControl(ControlCollection controls)
        {
            try
            {
                foreach (Control controles in controls)
                {
                    if (controles is TextBox)
                        ((TextBox)controles).Text = string.Empty;
                    else if (controles is DropDownList)
                        ((DropDownList)controles).ClearSelection();
                    else if (controles is RadioButton)
                        ((RadioButton)controles).Checked = false;
                    else if (controles.HasControls())
                        CleanControl(controles.Controls);
                }
            }
            catch (Exception err)
            {
                //MANEJAMOS EL ERROR
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al limpiar los controles " + err.Message;
            }
        }

        protected void tb_fechafiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //LIMPIAMOS LOS CONTROLES
                tb_fecha.Text = "";
                tb_hora.Text = "";
                tb_motivo.Text = "";
                tb_observaciones.Text = "";
                //RESETEAMOS EL CONTROL PARA LIMPIARLO
                ddl_paciente.Items.Clear();
                btn_atender.Enabled = false;
            }
            catch (Exception err)
            {
                //MANEJAMOS EL ERROR
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }            
        }

        protected void btn_atender_Click(object sender, EventArgs e)
        {
            try
            {
                //LIMPIAMOS LOS CONTROLES 
                CleanControl(this.Controls);
                ddl_paciente.Items.Clear();
                tb_observaciones.Enabled = false;
                btn_atender.Enabled = false;
            }
            catch (Exception err)
            {
                //MANEJAMOS EL ERROR
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al limpiar los controles " + err.Message;
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                //LIMPIAMOS LA LISTA DE LOS PACIENTES
                ddl_paciente.Items.Clear();
                //LIMPIAMOSLOS CONTROLES
                CleanControl(this.Controls);
                //ELIMINAMOS LA SESSION
                Session.Remove("s_PacienteCitas");
                tb_observaciones.Enabled = false;
                btn_atender.Enabled = false;

            }
            catch (Exception err)
            {
                //MANEJAMOS EL ERROR
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al cancelar " + err.Message;
            }            
        }


    }
}