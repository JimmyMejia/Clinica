using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace Clinica
{
    public partial class wf_Envio_Correo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_enviar_Click(object sender, EventArgs e)
        {

            ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "ocultarmensaje", "OcultarLabel();", true);
            //try
            //{
            //    string resp = "";
            //    Entidad.Utileria.SendMail u = new Entidad.Utileria.SendMail("jm_chap1987@hotmail.com","");
            //    resp = u.sendMail(tb_para.Text, tb_asunto.Text, tb_contenido.Text);
            //    if (resp == "Enviado")
            //    {
            //        lb_mensaje.ForeColor = System.Drawing.Color.Green;
            //        lb_mensaje.Text = "Correo enviado satisfactoriamente!!!";                     
            //    }
            //    else
            //    {
            //        lb_mensaje.ForeColor = System.Drawing.Color.Red;
            //        lb_mensaje.Text = "Error al enviar el correo!!!";
            //    }
            //}
            //catch (Exception err)
            //{                
            //    cv_Datos.IsValid = false;
            //    cv_Datos.ErrorMessage = "Error en boton enviar correo, " + err.Message;
            //}
        }


       
    }
}