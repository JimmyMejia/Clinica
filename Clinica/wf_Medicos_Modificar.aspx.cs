using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class wf_Medicos_Modificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            try
            {
                tb_cedula.Text = "";
                tb_nombres.Text = "";
                tb_apellidos.Text = "";
                tb_fechaNacimiento.Text = "";
                tb_direccion.Text = "";
                tb_telefono.Text = "";
                tb_celular.Text = "";
                btn_Modificar.Enabled = false;
                //DESHABILITAMOS LOS CONTROLES PARA QUE SEAN EDITADOS
                DeshabilitarCajasdeTexto();
                BuscarMedico();
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void BuscarMedico()
        {
            try
            {
                if (tb_apellidosfiltro.Text.Trim() != "")
                {
                    string apellidos = tb_apellidosfiltro.Text.Trim();
                    Negocio.buscarmedicos_spNegocio dc = new Negocio.buscarmedicos_spNegocio();
                    List<Entidad.Buscar_Medicos_Result> medicos = null;
                    medicos = dc.BuscarMedicos(apellidos);
                    if (medicos.Count != 0)
                    {
                        gv_Medicos.DataSource = medicos;
                        gv_Medicos.DataBind();
                        //gv_Pacientes.HeaderRow.Cells[0].Text = "Seleccione";
                        //gv_Pacientes.HeaderRow.Cells[1].Text = "Cod. paciente";
                        //gv_Pacientes.HeaderRow.Cells[2].Text = "Nombre del paciente";
                    }
                    else
                    {
                        Entidad.Medico p = null;
                        gv_Medicos.DataSource = p;
                        gv_Medicos.DataBind();
                        //lb_mensajes.ForeColor = System.Drawing.Color.Red;
                        //lb_mensajes.Text = "No se pudieron encontrar pacientes con la coincidencia: " + apellidos.ToUpper() + ", por favor verifique.";
                        string mensaje = "MostrarMensaje('ERROR','No se pudieron encontrar medicos con la coincidencia: " + apellidos.ToUpper() + ", por favor verifique.')";
                        ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                    }
                }
                else
                {
                    Entidad.Medico p = null;
                    gv_Medicos.DataSource = p;
                    gv_Medicos.DataBind();
                    //lb_mensajes.ForeColor = System.Drawing.Color.Red;
                    //lb_mensajes.Text = "Por favor digite los apellidos a buscar.";
                    string mensaje = "MostrarMensaje('INFO','Por favor digite los apellidos a filtrar')";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje1", mensaje, true);
                }
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void DeshabilitarCajasdeTexto()
        {
            try
            {
                tb_cedula.Enabled = false;
                tb_nombres.Enabled = false;
                tb_apellidos.Enabled = false;
                tb_fechaNacimiento.Enabled = false;
                tb_direccion.Enabled = false;
                tb_telefono.Enabled = false;
                tb_celular.Enabled = false;
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al deshabilitar las cajas de texto :" + err.Message;
            }
        }

        protected void gv_Medicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gv_Medicos.SelectedRow;
                string sel = gv_Medicos.DataKeys[row.RowIndex].Values["NroCedula"].ToString();
                Session["S_NroCedula"] = sel;
                Seleccion_Medico(sel);
                btn_Modificar.Enabled = true;
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void gv_Medicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gv_Medicos.PageIndex = e.NewPageIndex;
                CargarGrid();
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void CargarGrid()
        {
            try
            {
                Negocio.medicoNegocio dc = new Negocio.medicoNegocio();
                List<Entidad.Medico> pa = null;
                pa = dc.ListaMedicos();
                gv_Medicos.DataSource = pa;
                gv_Medicos.DataBind();
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

        protected void Seleccion_Medico(string nro_cedula)
        {
            try
            {
                Negocio.medicoNegocio dc = new Negocio.medicoNegocio();
                Entidad.Medico cs = dc.ConsultarMedico(nro_cedula);
                if (cs != null)
                {
                    Session["S_NroCedula"] = cs.NroCedula;
                    tb_cedula.Text = cs.NroCedula;
                    tb_nombres.Text = cs.Nombres;
                    tb_apellidos.Text = cs.Apellidos;
                    tb_fechaNacimiento.Text = Convert.ToString(cs.Fecha_nacimiento);
                    tb_direccion.Text = cs.Direccion;
                    tb_telefono.Text = cs.Telefono;
                    tb_celular.Text = cs.Celular;
                    //HABILITAMOS LOS CONTROLES PARA QUE SEAN EDITADOS
                    tb_cedula.Enabled = true;
                    tb_nombres.Enabled = true;
                    tb_apellidos.Enabled = true;
                    tb_fechaNacimiento.Enabled = true;
                    tb_direccion.Enabled = true;
                    tb_telefono.Enabled = true;
                    tb_celular.Enabled = true;
                }
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
            //LIMPIAMOS LOS DATOS DEL GRID
            List<Entidad.Medico> pa = null;
            gv_Medicos.DataSource = pa;
            gv_Medicos.DataBind();
        }

        protected void btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidad.Medico dc = new Entidad.Medico();
                dc.NroCedula = (string)Session["S_NroCedula"];  
                dc.Nombres = tb_nombres.Text.Trim().ToUpper();
                dc.Apellidos = tb_apellidos.Text.Trim().ToUpper();
                dc.Fecha_nacimiento = Convert.ToDateTime(tb_fechaNacimiento.Text);
                dc.Direccion = tb_direccion.Text.Trim().ToUpper();
                dc.Celular = tb_celular.Text;
                dc.Telefono = tb_telefono.Text;
                Negocio.medicoNegocio mn = new Negocio.medicoNegocio();
                string cedula = tb_cedula.Text.Trim();
                bool valida = false;
                valida = mn.ValidaCedula(cedula);
                if (valida == true)
                {
                    int existe;
                    existe = mn.ExisteCedula(cedula);
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
                        string error = "";
                        error = mn.UpdateMedico(dc,cedula); //LE PASAMOS EL OBJETO Y EL VALOR DE LA CEDULA NUEVA
                        if (error != "")
                        {
                            string mensaje = "MostrarMensaje('ERROR','La fecha de nacimiento no puede ser mayor a la fecha actual!!!')";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                        }
                        else
                        {
                            //lb_mensajes.ForeColor = System.Drawing.Color.Green;
                            //lb_mensajes.Text = "Datos actualizados correctamente!!!";
                            string mensaje = "MostrarMensaje('SUCCESS','Datos actualizados correctamente!!!')";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                            //CargarGrid();

                            string busqueda = tb_apellidosfiltro.Text;
                            Session.Remove("S_NroCedula");
                            CleanControls(this.Controls);
                            tb_apellidosfiltro.Text = busqueda;
                            BuscarMedico();
                            //DESHABILITAMOS LOS CONTROLES PARA QUE SEAN EDITADOS
                            DeshabilitarCajasdeTexto();
                            btn_Modificar.Enabled = false;
                        }
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
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }


    }
}