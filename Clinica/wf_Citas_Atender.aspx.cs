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
                ddl_paciente.Items.Clear();
                Negocio.citasdeldia_spNegocio dc = new Negocio.citasdeldia_spNegocio();
                List<Entidad.CitasdelDia_SP_Result> p = null;
                p = dc.CitasdelDia(fecha);
                Session.Add("s_PacienteCitas", p);
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
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al cargar los pacientes " + err.Message;
            }
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_fechafiltro.Text == "")
                {
                    lb_mensajes.ForeColor = System.Drawing.Color.Red;
                    lb_mensajes.Text = "Debe seleccionar la fecha a buscar!!!";
                }
                else
                {
                    Negocio.citasdeldia_spNegocio dc = new Negocio.citasdeldia_spNegocio();
                    List<Entidad.CitasdelDia_SP_Result> sd = null;
                    sd = dc.CitasdelDia(tb_fechafiltro.Text);
                    if (sd.Count != 0)
                    {
                        CargarPacientes(tb_fechafiltro.Text);
                        //foreach (var item in sd)
                        //{
                        //    ddl_paciente.SelectedValue = item.IdPaciente.ToString();
                        //    tb_fecha.Text = item.Fecha.ToString();
                        //    tb_hora.Text = item.Hora.ToString();
                        //    tb_motivo.Text = item.Descripcion.ToString();                        
                        //}
                    }
                    else
                    {
                        /*SI EL METODO NO RETORNA DATOS SE MUESTRA UN MENSAJE AL USUARIO*/
                        lb_mensajes.ForeColor = System.Drawing.Color.Red;
                        lb_mensajes.Text = "No hay citas para la fecha seleccionada!!!";
                    }
                }
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al filtrar las citas del dia " + err.Message;
            }
        }

        protected void ddl_paciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<Entidad.CitasdelDia_SP_Result> citas = (List<Entidad.CitasdelDia_SP_Result>)Session["s_PacienteCitas"];
                if (citas != null)
                {
                    Entidad.CitasdelDia_SP_Result c = citas.Where(ct=>ct.IdPaciente == int.Parse(ddl_paciente.SelectedValue)).FirstOrDefault();
                    tb_fecha.Text = c.Fecha.ToString(); 
                    tb_hora.Text = c.Hora.ToString();
                    tb_motivo.Text = c.Descripcion;
                    btn_atender.Enabled = true;
                }
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al cargar la información de la cita " + err.Message;
            }
        }

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
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al limpiar los controles " + err.Message;
            }
        }

        protected void tb_fechafiltro_TextChanged(object sender, EventArgs e)
        {
            tb_fecha.Text = "";
            tb_hora.Text = "";
            tb_motivo.Text = "";
            btn_atender.Enabled = false;
        }

        protected void btn_atender_Click(object sender, EventArgs e)
        {
            try
            {
                CleanControl(this.Controls);
                btn_atender.Enabled = false;
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al limpiar los controles " + err.Message;
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                /*List<Entidad.CitasdelDia_SP_Result> c = null;
                ddl_paciente.DataSource = c;
                ddl_paciente.DataTextField = "";
                ddl_paciente.DataValueField = "";
                ddl_paciente.DataBind();*/

                ddl_paciente.Items.Clear();

                CleanControl(this.Controls);
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al cancelar " + err.Message;
            }
            
        }

    }
}