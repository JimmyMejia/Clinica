using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class BuscarServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                //Entidad.Cat_Servicio cs = new Entidad.Cat_Servicio();
                //cs.IdServicio = Convert.ToInt32(tb_id.Text);
                Negocio.serviciosNegocio sn = new Negocio.serviciosNegocio();
                Entidad.Cat_Servicio cs = sn.BuscarServicio(int.Parse(tb_id.Text));
                if (cs != null)
                {
                    tb_descripcion.Text = cs.Descripcion;
                    tb_precio.Text = Convert.ToString(cs.Precio);
                    Session["s_Servicio"] = cs;
                    Response.Redirect("Servicios.aspx",false);
                    //Session["id_servicio"] = tb_id.Text;
                    //Session["descripcion_servicio"] = tb_descripcion.Text;
                    //Session["precio_servicio"] = tb_precio.Text;
                    /*Response.Redirect("Servicios.aspx");
                    Response.End();*/
                }
                else
                {
                    tb_descripcion.Text = "";
                    tb_precio.Text = "";
                    cv_validacion.IsValid = false;
                    cv_validacion.ErrorMessage = "No existe registro con ese id!!!";
                    tb_id.Focus();
                    //Response.Write("<script>window.alert('No existe registro con ese ID!!!');</script>");
                }

            }
            catch (Exception err)
            {

                //throw new Exception(err.Message);
                cv_validacion.IsValid = false;
                cv_validacion.ErrorMessage = err.Message;
            }
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Entidad.Cat_Servicio cs = new Entidad.Cat_Servicio();
                //cs.IdServicio = Convert.ToInt32(tb_id.Text);
                Negocio.serviciosNegocio sn = new Negocio.serviciosNegocio();
                List<Entidad.Cat_Servicio> cs = null;
                cs = sn.BuscarDescripcionServicio(tb_descripcion.Text);
                if (cs != null)
                {
                    if (cs.Count > 0)
                    {
                        //tb_id.Text = Convert.ToString(cs.IdServicio);
                        //tb_precio.Text = Convert.ToString(cs.Precio);
                        gv_CatServicios.DataSource = cs;
                        gv_CatServicios.DataBind();
                        ListItem ini = new ListItem();
                        ini.Value = "0";
                        ini.Text = "Selecccione...";
                        ddl_CatServicios.Items.Add(ini);
                        ddl_CatServicios.DataSource = cs;
                        ddl_CatServicios.DataTextField = "Descripcion";
                        ddl_CatServicios.DataValueField = "IdServicio";
                        ddl_CatServicios.DataBind();
                        Session["s_Servicio"] = cs;
                        //Response.Redirect("Servicios.aspx", false);
                        
                    }
                    else
                    {
                        gv_CatServicios.DataSource = cs;
                        gv_CatServicios.DataBind();
                        ddl_CatServicios.Items.Clear();
                    }
                }
                else
                {
                    tb_id.Text = "";
                    tb_precio.Text = "";
                    cv_validacion.IsValid = false;
                    cv_validacion.ErrorMessage = "No existe registro con esa descripcion!!!";
                    tb_descripcion.Focus();
                    //gv_CatServicios.DataSource = cs;
                    //gv_CatServicios.DataBind();
                    ddl_CatServicios.Items.Clear();
                    for (int i = 0; i < gv_CatServicios.Rows.Count; i++)
                    {
                        gv_CatServicios.DeleteRow(i);
                    }
                    //Response.Write("<script>window.alert('No existe registro con ese ID!!!');</script>");
                }

            }
            catch (Exception err)
            {

                //throw new Exception(err.Message);
                cv_validacion.IsValid = false;
                cv_validacion.ErrorMessage = err.Message;
            }
        }

        protected void ddl_CatServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Seleccion_Servicio(int.Parse(ddl_CatServicios.SelectedValue));
            //Negocio.serviciosNegocio sn = new Negocio.serviciosNegocio();
            //Entidad.Cat_Servicio cs = sn.BuscarServicio(int.Parse(ddl_CatServicios.SelectedValue));
            //if (cs != null)
            //{
            //    tb_id.Text = Convert.ToString(cs.IdServicio);
            //    tb_descripcion.Text = cs.Descripcion;
            //    tb_precio.Text = Convert.ToString(cs.Precio);
            //    Session["s_Servicio"] = cs;
            //    Response.Redirect("Servicios.aspx", false);
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Button1.Attributes.Add("onclick", "history.back(1); return false;");
            Response.Write("<script language=javascript> history.back(1);</script>");
        }

        protected void gv_CatServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TxtIdarea.Text = Grdactivid.SelectedRow.Cells[2].Text;
            //tb_id.Text = gv_CatServicios.SelectedRow.Cells[1].Text;
            //tb_precio.Text = gv_CatServicios.SelectedRow.Cells[3].Text;
            GridViewRow row = gv_CatServicios.SelectedRow;
            string sel = gv_CatServicios.DataKeys[row.RowIndex].Values["IdServicio"].ToString();
            Seleccion_Servicio(int.Parse(sel));
        }

        protected void Seleccion_Servicio(int id)
        {
            Negocio.serviciosNegocio sn = new Negocio.serviciosNegocio();
            Entidad.Cat_Servicio cs = sn.BuscarServicio(id);
            if (cs != null)
            {
                tb_id.Text = Convert.ToString(cs.IdServicio);
                tb_descripcion.Text = cs.Descripcion;
                tb_precio.Text = Convert.ToString(cs.Precio);
                Session["s_Servicio"] = cs;
                Response.Redirect("Servicios.aspx", false);
            }
        }

       
    }
}