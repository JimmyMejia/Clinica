using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class wf_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_entrar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.validar_login_spNegocio dc = new Negocio.validar_login_spNegocio();
                string user = username.Value.ToString().Trim();
                string pass = password.Value.ToString().Trim();
                bool existe = false;
                existe = dc.ValidarUsuario(user, pass);
                if (existe != true)
                {
                    lb_mensajes.ForeColor = System.Drawing.Color.Red;
                    lb_mensajes.Text = "Datos incorrectos por favor verifique!!!";
                }
                else
                {
                    Response.Redirect("Clinica.aspx");
                }
            }
            catch (Exception err)
            {
                cv_datos.IsValid = false;
                cv_datos.ErrorMessage = "Error al validar el usuario y la contraseña " + err.Message;
            }
        }
    }
}