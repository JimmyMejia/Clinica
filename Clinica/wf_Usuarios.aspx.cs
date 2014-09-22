using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class wf_Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                Entidad.Validar_Login_Result login = (Entidad.Validar_Login_Result)Session["S_Login"];
                if (login != null)
                {
                    //    CargarRoles();
                    //    //ddl_rol.SelectedValue = "Invitado";
                    //    ddl_rol.Items.FindByText("Invitado").Selected = true;
                    //    //ddl_rol.Enabled = false;

                    //else 
                    if (login.Rol == "Administrador")
                    {
                        CargarRoles();
                        lb_rol.Visible = true;
                        ddl_rol.Visible = true;
                    }
                }
            }

        }

        protected void CargarRoles()
        {
            try
            {
                List<Entidad.Cat_Rol> roles = null;
                Negocio.rolNegocio dc = new Negocio.rolNegocio();
                roles = dc.GetListRol();
                ListItem item = new ListItem();
                item.Value = "0";
                item.Text = "Seleccione...";
                ddl_rol.Items.Add(item);
                ddl_rol.DataSource = roles;
                ddl_rol.DataValueField = "IdRol";
                ddl_rol.DataTextField = "Rol";
                ddl_rol.DataBind();
            }
            catch (Exception err)
            {
                cv_datos.IsValid = false;
                cv_datos.ErrorMessage = "Error al cargar los roles en ddl_rol: " + err.Message;
            }
        
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.usuariosNegocio dc = new Negocio.usuariosNegocio();
                Entidad.Insertar_Usuario_Result  resp = null;
                string nombre = tb_nombre.Text;
                int idrol ;
                Entidad.Validar_Login_Result login = (Entidad.Validar_Login_Result)Session["S_Login"];
                if (login == null)
                {
                    idrol = 3;
                }
                else
                {
                    idrol = int.Parse(ddl_rol.SelectedValue);
                }
                string user = tb_usuario.Text;
                string pass = tb_contraseniaverificacion.Text;
                string activo = "1";
                bool existe = false;
                existe = dc.VerificarUsuario(user);
                if (existe != true)
                {
                    resp = dc.InsertarUsuario(nombre, idrol, user, pass, activo);
                    if (resp != null)
                    {
                        lb_mensajes.ForeColor = System.Drawing.Color.Green;
                        lb_mensajes.Text = "Datos almacenados satisfactoriamente!!!";
                        CleanControls(this.Controls);
                    }
                    else
                    {
                        lb_mensajes.ForeColor = System.Drawing.Color.Red;
                        lb_mensajes.Text = "Error al almacenar el usuario!!!";
                    }
                }
                else
                {
                    lb_mensajes.ForeColor = System.Drawing.Color.Red;
                    lb_mensajes.Text = "El usuario ya existe, por favor seleccionar otro!!!";
                }

            }
            catch (Exception err)
            {
                cv_datos.IsValid = false;
                cv_datos.ErrorMessage ="Error al insertar al usuario " + err.Message;
            }
        }

        protected void CleanControls(ControlCollection controls)
        {
            try
            {
                foreach (Control control in controls)
                {
                    if (control is TextBox)
                        ((TextBox)control).Text = string.Empty;
                    else if (control is RadioButton)
                        ((RadioButton)control).Checked = false;
                    else if (control is DropDownList)
                        ((DropDownList)control).ClearSelection();
                    else if (control.HasControls())
                        CleanControls(control.Controls);
                }
            }
            catch (Exception err)
            {                
                cv_datos.IsValid = false;
                cv_datos.ErrorMessage ="Error al limpiar los controles " + err.Message;
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            CleanControls(this.Controls);
            lb_mensajes.Text = "";
        }
    }
}