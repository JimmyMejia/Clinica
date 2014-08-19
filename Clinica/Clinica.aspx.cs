using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Clinica
{
    public partial class Clinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        protected void tn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidad.Clinica ec = new Entidad.Clinica();
                ec.Nombre = tb_clinica.Text;
                ec.Direccion = tb_direccion.Text;
                ec.Email = tb_email.Text;
                ec.Telefono = tb_telefono.Text;
                ec.Celular = tb_celular.Text;
                //ec.Logo = fu_logo.FileName; //"Sin logo";
                Negocio.clinicaNegocio cn = new Negocio.clinicaNegocio();//
                if (chk_activa.Checked)
                {
                    ec.Activo = "1";
                    int estado = cn.VerificarActiva(ec);
                    if (estado == 1)
                    {
                        cv_Datos.IsValid = false;
                        cv_Datos.ErrorMessage = "Ya existe una clinica con estado activo, por favor verifique!!!";
                    }
                }
                else
                {
                    ec.Activo = "0";
                    CopiarImagen();
                    ec.Logo = (String)Session["s_Ruta_Imagen"];
                    cn.InsertarClinica(ec);
                    cv_Satisfactorio.IsValid = false;
                    cv_Satisfactorio.ErrorMessage = "Datos almacenados satisfacatoriamente!!!";
                    //Cuando se llama el método limpiar se pasa como parámetro
                    //la colección de controles de la página Web.
                    CleanControl(this.Controls);
                    LlenarGrid();
                    Session.Remove("s_Ruta_Imagen");
                }
                //Negocio.clinicaNegocio cn = new Negocio.clinicaNegocio();
                ////if (ec.Activo ="1")//
                ////{//
                //int estado = cn.VerificarActiva(ec);
                //if (estado == 1)
                //{
                //    cv_Datos.IsValid = false;
                //    cv_Datos.ErrorMessage = "Ya existe una clinica con estado activo, por favor verifique!!!";
                //}
                //else
                //{
                //    cn.InsertarClinica(ec);
                //    cv_Satisfactorio.IsValid = false;
                //    cv_Satisfactorio.ErrorMessage = "Datos almacenados satisfacatoriamente!!!";
                //    //Cuando se llama el método limpiar se pasa como parámetro
                //    //la colección de controles de la página Web.
                //    CleanControl(this.Controls);
                //}

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
        //Evento del control Button Limpiar controles de la página ASPX
        //protected void BtLimpiar_Click(object sender, EventArgs e)
        //{
        //    //Cuando se llama el método limpiar se pasa como parámetro
        //    //la colección de controles de la página Web.
        //    CleanControl(this.Controls);
        //}

        protected void LlenarGrid()
        {
            Negocio.clinicaNegocio dc = new Negocio.clinicaNegocio();
            List<Entidad.Clinica> clinica = null;
            clinica = dc.Clinicas();
            gv_clinicas.DataSource = clinica;
            gv_clinicas.DataBind();
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
           

        }


        protected void CopiarImagen()
        {
            if ((fu_logo.PostedFile != null) && (fu_logo.PostedFile.ContentLength > 0))
            {
                if (fu_logo.PostedFile.FileName.EndsWith(".JPG") || fu_logo.PostedFile.FileName.EndsWith(".jpg") || fu_logo.PostedFile.FileName.EndsWith(".ico") || fu_logo.PostedFile.FileName.EndsWith(".ICO") || fu_logo.PostedFile.FileName.EndsWith(".gif") || fu_logo.PostedFile.FileName.EndsWith(".GIF") || fu_logo.PostedFile.FileName.EndsWith(".png") || fu_logo.PostedFile.FileName.EndsWith(".PNG"))
                {
                    string nombre = System.IO.Path.GetFileName(fu_logo.PostedFile.FileName);
                    string rutaorigen = System.IO.Path.GetFullPath("nombre");

                    //string SaveLocation = Server.MapPath(@"~\Temporal") + "\\" + fn;
                    //string SaveLocation1 = Server.MapPath(@"~\imagenes") + "\\" + fn;
                    string SaveLocation = Server.MapPath(@"~\Images") + "\\" + nombre;
                    Session["s_Ruta_Imagen"] = SaveLocation;
                    try
                    {

                        fu_logo.PostedFile.SaveAs(SaveLocation);

                        this.lblmessage.Text = "El archivo se ha cargado.";

                        string WorkingDirectory = Server.MapPath(@"~\Images");
                        System.Drawing.Image img = System.Drawing.Image.FromStream(fu_logo.PostedFile.InputStream);

                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }

                }
                else
                    this.lblmessage.Text = "No se pudo cargar el archivo seleccionado, por favor seleccione una imagen .jpg, .gif o .png";
            }
            else
            {
                this.lblmessage.Text = "Seleccione un archivo que cargar.";
            }
        }
        
        
    }
}