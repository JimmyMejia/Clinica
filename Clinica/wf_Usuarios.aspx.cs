using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class wf_Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.usuariosNegocio dc = new Negocio.usuariosNegocio();
                Entidad.Insertar_Usuario_Result  resp = null;
                string user = tb_usuario.Text;
                string pass = tb_contraseniaverificacion.Text;
                string activo = "1";
                bool existe = false;
                existe = dc.VerificarUsuario(user);
                if (existe != true)
                {
                    resp = dc.InsertarUsuario(user, pass, activo);
                    if (resp != null)
                    {
                        lb_mensajes.ForeColor = System.Drawing.Color.Green;
                        lb_mensajes.Text = "Datos almacenados sin problemas!!!";
                        CleanControls(this.Controls);
                    }
                    else
                    {
                        lb_mensajes.ForeColor = System.Drawing.Color.Red;
                        lb_mensajes.Text = "Error al almacenar el usuario!!!";
                    }
                }
                else
                {
                    lb_mensajes.ForeColor = System.Drawing.Color.Red;
                    lb_mensajes.Text = "El usuario ya existe, por favor seleccionar otro!!!";
                }

            }
            catch (Exception err)
            {
                cv_datos.IsValid = false;
                cv_datos.ErrorMessage ="Error al insertar al usuario " + err.Message;
            }
        }

        protected void CleanControls(ControlCollection controls)
        {
            try
            {
                foreach (Control control in controls)
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
                cv_datos.ErrorMessage ="Error al limpiar los controles " + err.Message;
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            CleanControls(this.Controls);
            lb_mensajes.Text = "";
        }
    }
}