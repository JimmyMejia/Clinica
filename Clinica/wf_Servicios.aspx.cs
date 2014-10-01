using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class Servicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               /* if (!IsPostBack)
                {
                    if (Session["s_Servicio"] != null)
                    {
                        //List<Entidad.Cat_Servicio> cs = (List<Entidad.Cat_Servicio>)Session["s_Servicio"];
                        Entidad.Cat_Servicio cs = (Entidad.Cat_Servicio)Session["s_Servicio"];
                        tb_id.Text = Convert.ToString(cs.IdServicio);
                        tb_descripcion.Text = cs.Descripcion;
                        tb_precio.Text = cs.Precio.ToString();
                        Session.Contents.Remove("s_Servicio");
                        btn_guardar.Text = "Editar";
                    }
                }*/

                CargarGrid();
            }
            catch (Exception err)
            {
                cv_servicios.IsValid = false;
                cv_servicios.ErrorMessage = err.Message;
            }           

        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {

            try
            {
                if (btn_guardar.Text == "Guardar")
                {
                    //try
                    //{                    
                        Entidad.Cat_Servicio es = new Entidad.Cat_Servicio();
                        es.Descripcion = tb_descripcion.Text.ToUpper().Trim();
                        es.Precio = Convert.ToInt32(tb_precio.Text.Trim());
                        Negocio.serviciosNegocio sn = new Negocio.serviciosNegocio();
                        if (sn.InsertarServicio(es) == true)
                        {
                            //lb_mensajes.ForeColor = System.Drawing.Color.Green;
                            //lb_mensajes.Text = "Registro insertado satisfactoriamente!!!";
                            string mensaje = "MostrarMensaje('SUCCESS','Registro insertado satisfactoriamente!!!')";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                            CargarGrid();
                            CleanControl(this.Controls);
                        }
                        else
                        {
                            //lb_mensajes.ForeColor = System.Drawing.Color.Red;
                            //lb_mensajes.Text = "Ya existe el servicio!!!";
                            string mensaje = "MostrarMensaje('INFO','El servicio ya existe por favor verifique!!!')";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                            tb_descripcion.Focus();
                        }
                    //}
                    //catch (Exception err)
                    //{
                    //    cv_servicios.IsValid = false;
                    //    cv_servicios.ErrorMessage = err.Message;
                    //}
                }
                else
                {
                
                        Entidad.Cat_Servicio es = new Entidad.Cat_Servicio();
                        es.IdServicio = int.Parse(Session["S_IdServicio"].ToString());
                        es.Descripcion = tb_descripcion.Text.ToUpper().Trim();
                        es.Precio = Convert.ToInt32(tb_precio.Text);
                        Negocio.serviciosNegocio sn = new Negocio.serviciosNegocio();
                        bool actualiza = true;
                        actualiza = sn.ActualizarServicio(es);
                        if (actualiza == false)
                        {
                            string mensaje = "MostrarMensaje('INFO','El servicio ya existe por favor verifique!!!')";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                        }
                        else
                        {
                            //Response.Write("<script>window.alert('Servicio actualizado!!!');</script>");                        
                            //lb_mensajes.ForeColor = System.Drawing.Color.Green;
                            //lb_mensajes.Text = "Registro actualizado satisfactoriamente!!!";
                            string mensaje = "MostrarMensaje('SUCCESS','Registro actualizado satisfactoriamente!!!')";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                            Session.Remove("S_IdServicio");
                            CargarGrid();
                            CleanControl(this.Controls);
                            //btn_Eliminar.Enabled = false;
                            btn_guardar.Text = "Guardar";
                        }    
                }
            }            
            catch (Exception err)
            {
                cv_servicios.IsValid = false;
                cv_servicios.ErrorMessage = err.Message;
            }           
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                CleanControl(this.Controls);
                //btn_Eliminar.Enabled = false;
                btn_guardar.Text = "Guardar";
            }
            catch (Exception err)
            {                
                cv_servicios.IsValid = false;
                cv_servicios.ErrorMessage = err.Message;
            }
        }

        protected void gv_servicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lb_mensajes.Text = "";
                GridViewRow row = gv_servicios.SelectedRow;
                string seleccion = gv_servicios.DataKeys[row.RowIndex].Values["IdServicio"].ToString();
                Session["S_IdServicio"] = seleccion;
                CargarControles(int.Parse(seleccion));
                //btn_Eliminar.Enabled = true;
            }
            catch (Exception err)
            {
                cv_servicios.IsValid = false;
                cv_servicios.ErrorMessage = err.Message;
            }            
        }

        protected void CargarControles(int idservicio)
        {
            try
            {
                Negocio.serviciosNegocio sv = new Negocio.serviciosNegocio();
                Entidad.Cat_Servicio serv = sv.BuscarServicio(idservicio);
                if (serv != null)
                {
                    //tb_id.Text = serv.IdServicio.ToString();
                    tb_descripcion.Text = serv.Descripcion;
                    tb_precio.Text = serv.Precio.ToString();
                    btn_guardar.Text = "Modificar";
                }
            }
            catch (Exception err)
            {
                cv_servicios.IsValid = false;
                cv_servicios.ErrorMessage = err.Message;
            }
        }

        //protected void DeleteRowButton_Click(Object sender, GridViewDeleteEventArgs e)
        //{
        //    try
        //    {
        //        /*GridViewRow row = gv_servicios.SelectedRow;
        //        //string strID = gv_servicios.Rows[0].Cells[0].ToString();
        //        if (tb_id.Text.Trim() != "")
        //        {
        //            Entidad.Cat_Servicio serv = new Entidad.Cat_Servicio();
        //            serv.IdServicio = int.Parse(Session["s_idservicio"].ToString());                    
        //            Negocio.serviciosNegocio cs = new Negocio.serviciosNegocio();
        //            cs.EliminarServicio(serv.IdServicio);
        //            CargarGrid();
        //            lb_mensajes.ForeColor = System.Drawing.Color.Green;
        //            lb_mensajes.Text = "Registro eliminado satisfactoriamente!!!";
        //            btn_guardar.Text = "Guardar";
        //            CleanControl(this.Controls);                
        //        }
        //        else
        //        {*/
        //            lb_mensajes.ForeColor = System.Drawing.Color.Red;
        //            lb_mensajes.Text = "Debe seleccionar un registro!!!";
        //        //}
        //    }
        //    catch (Exception err)
        //    {
        //        cv_servicios.IsValid = false;
        //        cv_servicios.ErrorMessage = err.Message;
        //    }
        //}

        protected void CargarGrid()
        {
            try
            {
                Negocio.serviciosNegocio sn = new Negocio.serviciosNegocio();
                List<Entidad.Cat_Servicio> servicios = null;
                servicios = sn.ListaServicios();
                gv_servicios.DataSource = servicios;
                gv_servicios.DataBind();
                //gv_servicios.HeaderRow.Cells[0].Text = "Seleccione";
                //gv_servicios.HeaderRow.Cells[1].Text = "Cod. Servicio";
                //gv_servicios.HeaderRow.Cells[2].Text = "Descripción";
            }
            catch (Exception err)
            {
                cv_servicios.IsValid = false;
                cv_servicios.ErrorMessage = err.Message;
            }
        }

        protected void gv_servicios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_servicios.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

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

        //protected void btn_Eliminar_Click(object sender, EventArgs e)
        //{
        //     try
        //    {
        //        if (tb_id.Text.Trim() != "")
        //        {
        //            Entidad.Cat_Servicio serv = new Entidad.Cat_Servicio();
        //            serv.IdServicio = int.Parse(Session["s_idservicio"].ToString());                    
        //            Negocio.serviciosNegocio cs = new Negocio.serviciosNegocio();
        //            cs.EliminarServicio(serv.IdServicio);
        //            CargarGrid();
        //            lb_mensajes.ForeColor = System.Drawing.Color.Green;
        //            lb_mensajes.Text = "Registro eliminado satisfactoriamente!!!";
        //            btn_guardar.Text = "Guardar";
        //            //btn_Eliminar.Enabled = false;
        //            CleanControl(this.Controls);   
             
        //        }
        //        else
        //        {
        //            lb_mensajes.ForeColor = System.Drawing.Color.Red;
        //            lb_mensajes.Text = "Debe seleccionar un registro!!!";
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        cv_servicios.IsValid = false;
        //        cv_servicios.ErrorMessage = err.Message;
        //    }        
        //}
      
               
    }
}