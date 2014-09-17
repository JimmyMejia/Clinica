using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class wf_Paciente_Modificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                CargarGrid();
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }           
        }

        protected void gv_Pacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gv_Pacientes.SelectedRow;
                string sel = gv_Pacientes.DataKeys[row.RowIndex].Values["IdPaciente"].ToString();
                Session["S_IdPaciente"] = sel;
                Seleccion_Paciente(int.Parse(sel));                
                btn_Modificar.Enabled = true;
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }            
        }

        protected void gv_Pacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gv_Pacientes.PageIndex = e.NewPageIndex;
                CargarGrid();
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void Seleccion_Paciente(int id)
        {
            try
            {
               Negocio.pacienteNegocio dc = new Negocio.pacienteNegocio();
               Entidad.Paciente cs = dc.ConsultarPaciente(id);
               if (cs != null)
               {
                   Session["S_IdPaciente"] = cs.IdPaciente;
                   tb_id.Text = Session["S_IdPaciente"].ToString();
                   tb_nombres.Text = cs.Nombres;
                   tb_apellidos.Text = cs.Apellidos;
                   tb_fechaNacimiento.Text = Convert.ToString(cs.Fecha_nacimiento);
                   tb_direccion.Text = cs.Direccion;
                   tb_telefono.Text = cs.Telefono;
                   tb_celular.Text = cs.Celular;
               }
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }          
        }

        protected void btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidad.Paciente dc = new Entidad.Paciente();
                dc.IdPaciente = (int) Session["S_IdPaciente"];//int.Parse(tb_id.Text);                               
                //dc.IdPaciente = (int)Session["s_idpaciente"];
                dc.Nombres = tb_nombres.Text.Trim().ToUpper();
                dc.Apellidos = tb_apellidos.Text.Trim().ToUpper();
                dc.Fecha_nacimiento = Convert.ToDateTime(tb_fechaNacimiento.Text);
                dc.Direccion = tb_direccion.Text.Trim().ToUpper();
                dc.Celular = tb_celular.Text;
                dc.Telefono = tb_telefono.Text;
                Negocio.pacienteNegocio pn = new Negocio.pacienteNegocio();
                /*int existe = pn.ValidarPaciente(dc);
                if (existe == 1)
                {
                    lb_mensajes.ForeColor = System.Drawing.Color.Red;
                    lb_mensajes.Text = "El paciente ya existe, porfavor verifique!!!";
                }
                else
                {*/
                    pn.UpdatePaciente(dc);
                    lb_mensajes.ForeColor = System.Drawing.Color.Green;
                    lb_mensajes.Text = "Datos actualizados correctamente!!!";
                    CargarGrid();
                    CleanControls(this.Controls);
                    btn_Modificar.Enabled = false;
                //}
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {
            CleanControls(this.Controls);
            btn_Modificar.Enabled = false;
            lb_mensajes.Text = "";
        }

        protected void CargarGrid()
        {
            try
            {
                Negocio.pacienteNegocio dc = new Negocio.pacienteNegocio();
                List<Entidad.Paciente> pa = null;
                pa = dc.ListaPacientes();
                gv_Pacientes.DataSource = pa;
                gv_Pacientes.DataBind();
            }
            catch (Exception err)
            {                
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }
        public void CleanControls(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    CleanControls(control.Controls);
            }
        }

      
    }
}