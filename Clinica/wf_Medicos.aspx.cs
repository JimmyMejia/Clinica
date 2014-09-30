using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class wf_Medicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CleanControls(ControlCollection controles)
        {
            try
            {
                foreach (Control control in controles)
                {
                    if (control is TextBox)
                        ((TextBox)control).Text = string.Empty;
                    else if (control is RadioButton)
                        ((RadioButton)control).Checked = false;
                    else if (control is DropDownList)
                        ((DropDownList)control).ClearSelection();
                    else if (control.HasControls())
                        CleanControls(control.Controls);
                }
            }
            catch (Exception err)
            {
                cv_datos.IsValid = false;
                cv_datos.ErrorMessage = "Error al limpiar los controles, " + err.Message;
            }
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                CleanControls(this.Controls);
                lb_mensajes.Text = "";
            }
            catch (Exception err)
            {
                cv_datos.IsValid = false;
                cv_datos.ErrorMessage = "Error al cancelar, " + err.Message;
            }
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidad.Medico med = new Entidad.Medico();
                med.NroCedula = tb_cedula.Text.Trim().ToUpper();
                med.Nombres = tb_nombres.Text.Trim().ToUpper();
                med.Apellidos = tb_apellidos.Text.Trim().ToUpper();
                med.NombreCompleto = tb_apellidos.Text.Trim().ToUpper() + " " + tb_nombres.Text.Trim().ToUpper();
                med.Fecha_nacimiento = Convert.ToDateTime(tb_fechaNacimiento.Text);
                med.Direccion = tb_direccion.Text.Trim().ToUpper();
                med.Celular = tb_celular.Text;
                med.Telefono = tb_telefono.Text;
                Negocio.medicoNegocio dc = new Negocio.medicoNegocio();
                string cedula = tb_cedula.Text.Trim();
                bool valida = false;
                valida = dc.ValidaCedula(cedula);
                if (valida == true)
                {
                    int existe;
                    existe = dc.ExisteCedula(cedula);
                    if (existe == 1)
                    {
                        //lb_mensajes.ForeColor = System.Drawing.Color.Red;
                        //lb_mensajes.Text = "Número de cedula ya existe, por favor verifique!!!";
                        string mensaje = "MostrarMensaje('ERROR','Número de cedula ya existe, por favor verifique!!!')";
                        //MOSTRAMOS EL MENSAJE
                        ClientScript.RegisterStartupScript(GetType(), "ocultar", mensaje, true);

                    }
                    else
                    {
                        dc.InsertarMedico(med);
                        //lb_mensajes.ForeColor = System.Drawing.Color.Green;
                        //lb_mensajes.Text = "Datos del médico insertado satisfactoriamente!!!";
                        CleanControls(this.Controls);
                        //MOSTRAMOS EL MENSAJE
                        string mensaje = "MostrarMensaje('SUCCESS','Datos del médico insertados satisfactoriamente!!!')";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "ocultar1", mensaje, true);
                    }
                }
                else
                {
                    string mensaje = "MostrarMensaje('ERROR','El número de cedula digitado es inválido!!!')";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                }
            }
            catch (Exception err)
            {
                cv_datos.IsValid = false;
                cv_datos.ErrorMessage = "Error al guardar los datos del médico, " + err.Message;
            }
        }

       
    }
}