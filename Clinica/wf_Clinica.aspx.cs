﻿using System;
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

        public string GetLabelText(object dataItem)
        {
            string text = "";
            try
            {                
                string val = dataItem as string;
                switch (val)
                {
                    case "0":
                        text = "Inactiva";
                        break;
                    case "1":
                        text = "Activa";
                        break;
                }                
            }
            catch (Exception err)
            {
                cv_Datos.IsValid = false;
                cv_Datos.ErrorMessage = "Error al mostrar el estado de la clinica: " + err.Message;
            }
            return text;               
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
            else
            {
                Entidad.Validar_Login_Result login = null;
                login = (Entidad.Validar_Login_Result)Session["S_Login"];
                if (login != null)
                {
                    //lb_previa.Visible = true;
                    //Logo.Visible = true;
                }
                
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidad.Clinica ec = new Entidad.Clinica();
                ec.Nombre = tb_clinica.Text;
                ec.Direccion = tb_direccion.Text;
                ec.Email = tb_email.Text;
                ec.Telefono = tb_telefono.Text;
                ec.Celular = tb_celular.Text;                
                string activa = "0"; //VARIABLE UTILIZADA PARA PODER MANEJAR EL ESTADO A ALMACENAR DE LA CLINICA
                Negocio.clinicaNegocio cn = new Negocio.clinicaNegocio();
                if (chk_activa.Checked == true)
                {                    
                    int estado = cn.VerificarActiva(ec);
                    if (estado == 1)
                    {
                        activa = "1"; //SI SE ENCUENTRA UNA CLINICA ACTIVA
                        string mensaje = "MostrarMensaje('ERROR','Ya existe una clinica con estado activo, por favor verifique!!!')";
                        ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                    }                    
                }

                if (activa == "0")
                {
                    ec.Activo = activa;
                    //CARGAMOS LA IMAGEN SELECCIONADA EN EL CONTROL PARA QUE EL USUARIO VEA LA IMAGEN QUE SELECCIONO
                    //if ((fu_logo.PostedFile != null) && (fu_logo.PostedFile.ContentLength > 0))
                    //{
                    //    string nombre = System.IO.Path.GetFileName(fu_logo.PostedFile.FileName);
                    //    string rutaorigen = System.IO.Path.GetFullPath("nombre");
                    //    string fileExtension = System.IO.Path.GetExtension(this.fu_logo.FileName);
                    //    HttpPostedFile file = fu_logo.PostedFile;
                    //    //almacenar fichero en byte[]
                    //    int lengthFile = file.ContentLength;
                    //    byte[] fileArray = new byte[lengthFile];
                    //    file.InputStream.Read(fileArray, 0, lengthFile);
                    //    //grabar en Session
                    //    Session["IMAGEN"] = fileArray;
                    //    //mostrar imagen en control Image
                    //    ByteArrayToImageControl(fileArray, fileExtension);
                    //}

                    CopiarImagen();
                    ec.Logo = (String)Session["S_RutaImagen"];
                    cn.InsertarClinica(ec);
                    //lb_mensajes.ForeColor = System.Drawing.Color.Green;
                    //lb_mensajes.Text = "Datos almacenados satisfacatoriamente!!!";
                    string mensaje1 = "MostrarMensaje('SUCCESS','Datos almacenados satisfactoriamente!!!')";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje1, true);
                    CleanControl(this.Controls);
                    LlenarGrid();
                    Session.Remove("S_RutaImagen");
                }                
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }            
        }

        protected void CopiarImagen()
        {
            try
            {
                //if ((fu_logo.PostedFile != null) && (fu_logo.PostedFile.ContentLength > 0))
                //{
                    if (fu_logo.PostedFile.FileName.EndsWith(".JPG") || fu_logo.PostedFile.FileName.EndsWith(".jpg") || fu_logo.PostedFile.FileName.EndsWith(".ico") || fu_logo.PostedFile.FileName.EndsWith(".ICO") || fu_logo.PostedFile.FileName.EndsWith(".gif") || fu_logo.PostedFile.FileName.EndsWith(".GIF") || fu_logo.PostedFile.FileName.EndsWith(".png") || fu_logo.PostedFile.FileName.EndsWith(".PNG"))
                    {
                        string nombre = System.IO.Path.GetFileName(fu_logo.PostedFile.FileName);
                        string rutaorigen = System.IO.Path.GetFullPath("nombre");
                        string SaveLocation = Server.MapPath(@"~\Images") + "\\" + nombre;
                        Session["S_RutaImagen"] = SaveLocation;
                        fu_logo.PostedFile.SaveAs(SaveLocation);
                        //this.lblmessage.Text = "El archivo se ha cargado.";
                        string WorkingDirectory = Server.MapPath(@"~\Images");
                        //System.Drawing.Image img = System.Drawing.Image.FromStream(fu_logo.PostedFile.InputStream);
                    }
                    else
                    {
                        cv_Datos.IsValid = false;
                        cv_Datos.ErrorMessage = "No se pudo cargar el archivo seleccionado, por favor seleccione una imagen .jpg, .gif o .png";
                    }
                //}
                //else
                //{
                //    cv_Datos.IsValid = false;
                //    cv_Datos.ErrorMessage = "Seleccione un archivo que cargar.";
                //}
            }
            catch (Exception err)
            {                
                cv_Datos.IsValid = false;
                cv_Datos.ErrorMessage = "Error al guardar la imagen seleccionada," + err.Message;
            }
            
        }

        //protected void chk_previa_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chk_previa.Checked == true)
        //    {
        //        if ((fu_logo.PostedFile != null) && (fu_logo.PostedFile.ContentLength > 0))
        //        {
        //            string nombre = System.IO.Path.GetFileName(fu_logo.PostedFile.FileName);
        //            string rutaorigen = System.IO.Path.GetFullPath("nombre");
        //            string fileExtension = System.IO.Path.GetExtension(this.fu_logo.FileName);
        //            HttpPostedFile file = fu_logo.PostedFile;
        //            //almacenar fichero en byte[]
        //            int lengthFile = file.ContentLength;
        //            byte[] fileArray = new byte[lengthFile];
        //            file.InputStream.Read(fileArray, 0, lengthFile);
        //            //grabar en Session
        //            Session["IMAGEN"] = fileArray;
        //            //mostrar imagen en control Image
        //            ByteArrayToImageControl(fileArray, fileExtension);
        //        }
        //    }
        //    else
        //    {
        //        Logo.ImageUrl = "";
        //        Logo.Visible = false;
        //    }
        //}

        //protected void ByteArrayToImageControl(byte[] fileArray, string fileExtension)
        //{
        //    try
        //    {
        //        string base64String = Convert.ToBase64String(fileArray, 0, fileArray.Length);
        //        this.Logo.ImageUrl = "data:image/" + fileExtension + "png;base64," + base64String;
        //        this.Logo.Visible = true;                
        //        Session.Remove("IMAGEN");
        //    }
        //    catch (Exception err)
        //    {
        //        cv_Datos.IsValid = false;
        //        cv_Datos.ErrorMessage = "Error al método auxiliar para mostrar el preview de la imagen: " + err.Message;
        //    }
            
        //}
       
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
       
        protected void LlenarGrid()
        {
            try
            {
                Negocio.clinicaNegocio dc = new Negocio.clinicaNegocio();
                List<Entidad.Clinica> clinica = null;
                clinica = dc.Clinicas();
                gv_clinicas.DataSource = clinica;
                gv_clinicas.DataBind();
            }
            catch (Exception err)
            {
                cv_Datos.IsValid = false;
                cv_Datos.ErrorMessage = "Error al llenargrid: " + err.Message;
            }
            
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            CleanControl(this.Controls);            
        }        

        //protected void lnkbtn_previa_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if ((fu_logo.PostedFile != null) && (fu_logo.PostedFile.ContentLength > 0))
        //        {
        //            string nombre = System.IO.Path.GetFileName(fu_logo.PostedFile.FileName);
        //            string rutaorigen = System.IO.Path.GetFullPath("nombre");
        //            string fileExtension = System.IO.Path.GetExtension(this.fu_logo.FileName);
        //            HttpPostedFile file = fu_logo.PostedFile;
        //            //almacenar fichero en byte[]
        //            int lengthFile = file.ContentLength;
        //            byte[] fileArray = new byte[lengthFile];
        //            file.InputStream.Read(fileArray, 0, lengthFile);
        //            //grabar en Session
        //            Session["IMAGEN"] = fileArray;
        //            //mostrar imagen en control Image
        //            ByteArrayToImageControl(fileArray, fileExtension);
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        cv_Datos.IsValid = false;
        //        cv_Datos.ErrorMessage = "Error al cargar el preview, " + err.Message;
        //    }
        //}        

        protected void gv_clinicas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                // Convert the row index stored in the CommandArgument
              // property to an Integer.
              int index = Convert.ToInt32(e.CommandArgument);    

              // Get the last name of the selected author from the appropriate
              // cell in the GridView control.
              GridViewRow selectedRow = gv_clinicas.Rows[index];
              TableCell IdClinica = selectedRow.Cells[1];
              string contact = IdClinica.Text;
              lb_mensajes.Text = "Seleccionastes el registro: " + contact + ".";
            }
        }

        protected void gv_clinicas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Label lbl = (Label)e.Row.FindControl("Activo");

            //if (lbl.Text == "1")
            //{
            //    lbl.Text = "Activo";
            //}
            //else
            //{
            //    lbl.Text = "Inactivo";
            //}
        }
               
        
    }
}