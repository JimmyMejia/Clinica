using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidad.Paciente p = new Entidad.Paciente();
                p.Nombres = tb_nombres.Text.Trim().ToUpper();
                p.Apellidos = tb_apellidos.Text.Trim().ToUpper();
                p.Fecha_nacimiento = Convert.ToDateTime(tb_fechaNacimiento.Text);
                p.Direccion = tb_direccion.Text.Trim().ToUpper();
                p.Telefono = tb_telefono.Text;
                p.Celular = tb_celular.Text;
                Negocio.pacienteNegocio pn = new Negocio.pacienteNegocio();
                int existe = pn.ValidarPaciente(p);
                if (existe == 0)
                {
                    pn.InsertarPaciente(p);
                    //lb_mensajes.ForeColor = System.Drawing.Color.Green;
                    //lb_mensajes.Text = "Paciente insertado correctamente!!!";
                    string mensaje = "MostrarMensaje('SUCCESS','Paciente insertado satisfactoriamente!!!')";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                    CleanControl(this.Controls);
                }
                else
                {
                    //lb_mensajes.ForeColor = System.Drawing.Color.Red;
                    //lb_mensajes.Text = "Paciente ya existe!!!";
                    string mensaje = "MostrarMensaje('ERROR','El paciente ya existe, por favor verifique!!!')";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                }
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }            
        }


        //Función que permite limpiar todos los controles de una página Web
        //recursivamente. Útil cuando en la página existen varios controles
        //evita tener que limpiar uno por uno.
        public void CleanControl(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).ClearSelection();
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    CleanControl(control.Controls);
            }
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            CleanControl(this.Controls);
            lb_mensajes.Text = "";
        }
    }
}