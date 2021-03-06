﻿using System;
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
                    tb_nombres.Text = cs.Nombres;
                    tb_apellidos.Text = cs.Apellidos;
                    tb_fechaNacimiento.Text = Convert.ToString(cs.Fecha_nacimiento);
                    tb_direccion.Text = cs.Direccion;
                    tb_telefono.Text = cs.Telefono;
                    tb_celular.Text = cs.Celular;
                    //HABILITAMOS LOS CONTROLES PARA QUE SEAN EDITADOS
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
                string error = "";
                    error = pn.UpdatePaciente(dc);
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
                        Session.Remove("S_IdPaciente");
                        CleanControls(this.Controls);
                        tb_apellidosfiltro.Text = busqueda;
                        BuscarPaciente();
                        //DESHABILITAMOS LOS CONTROLES PARA QUE SEAN EDITADOS
                        DeshabilitarCajasdeTexto();
                        btn_Modificar.Enabled = false;
                    }
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
            //LIMPIAMOS LOS DATOS DEL GRID
            List<Entidad.Paciente> pa = null;
            gv_Pacientes.DataSource = pa;
            gv_Pacientes.DataBind();
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

        protected void DeshabilitarCajasdeTexto()
        {
            try
            {
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

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            try
            {
                tb_nombres.Text = "";
                tb_apellidos.Text = "";
                tb_fechaNacimiento.Text = "";
                tb_direccion.Text = "";
                tb_telefono.Text = "";
                tb_celular.Text = "";
                btn_Modificar.Enabled = false;
                //DESHABILITAMOS LOS CONTROLES PARA QUE SEAN EDITADOS
                DeshabilitarCajasdeTexto();
                BuscarPaciente();
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void BuscarPaciente()
        {
            try
            {
                if (tb_apellidosfiltro.Text.Trim() != "")
                {
                    string apellidos = tb_apellidosfiltro.Text.Trim();
                    Negocio.buscarpacientes_spNegocio dc = new Negocio.buscarpacientes_spNegocio();
                    List<Entidad.Buscar_Pacientes_Result> pacientes = null;
                    pacientes = dc.BuscarPacientes(apellidos);
                    if (pacientes.Count != 0)
                    {
                        gv_Pacientes.DataSource = pacientes;
                        gv_Pacientes.DataBind();
                        //gv_Pacientes.HeaderRow.Cells[0].Text = "Seleccione";
                        //gv_Pacientes.HeaderRow.Cells[1].Text = "Cod. paciente";
                        //gv_Pacientes.HeaderRow.Cells[2].Text = "Nombre del paciente";
                    }
                    else
                    {
                        Entidad.Paciente p = null;
                        gv_Pacientes.DataSource = p;
                        gv_Pacientes.DataBind();
                        //lb_mensajes.ForeColor = System.Drawing.Color.Red;
                        //lb_mensajes.Text = "No se pudieron encontrar pacientes con la coincidencia: " + apellidos.ToUpper() + ", por favor verifique.";
                        string mensaje = "MostrarMensaje('ERROR','No se pudieron encontrar pacientes con la coincidencia: " + apellidos.ToUpper() + ", por favor verifique.')";
                        ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                    }
                }
                else
                {
                    Entidad.Paciente p = null;
                    gv_Pacientes.DataSource = p;
                    gv_Pacientes.DataBind();
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

          
    }
}