using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class wf_Factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tb_fecha.Text = DateTime.Now.ToShortDateString();
            if (!IsPostBack)
            {
                /*CARGO EL CONTROL DDL_PACIENTE PARA TENER DISPONIBLE AL PACIENTE AL CUAL SELE VA A MODIFICAR LA CITA*/
                //CargarPacientes();
                /* CARGAMOS EL CONTROL DDL_MOTIVO PARA USARLO CUANDO SE VAYA A CAMBIAR EL TIPO DE SERVICIO A BRINDAR*/
                //CargarServicios();
                tb_fecha.Text = DateTime.Now.ToShortDateString();
            }
            //else
            //{
            //    tb_fecha.Text = DateTime.Now.ToShortDateString();
            //}

        }

        protected void CargarServicios()
        {
            try
            {
                ddl_motivo.Items.Clear();
                Negocio.serviciosNegocio dcservicios = new Negocio.serviciosNegocio();
                List<Entidad.Cat_Servicio> servicios = null;
                servicios = dcservicios.ListaServicios();
                ListItem ini1 = new ListItem();
                ini1.Value = "0";
                ini1.Text = "Seleccione...";
                ddl_motivo.Items.Add(ini1);
                ddl_motivo.DataSource = servicios;
                ddl_motivo.DataTextField = "Descripcion";
                ddl_motivo.DataValueField = "IdServicio";
                ddl_motivo.DataBind();
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void CargarPacientes(string fecha)
        {
            try
            {
                //LIMPIAMOS EN CONTROL POR CUALQUIER COSA
                ddl_paciente.Items.Clear();
                //INSTANCIAMOS LO NECESARIO PARA OBTENER LA INFORMACION REQUERIDA
                Negocio.citasdeldia_spNegocio dc = new Negocio.citasdeldia_spNegocio();
                List<Entidad.CitasdelDia_SP_Result> p = null;
                p = dc.CitasdelDia(fecha);
                //ASIGNAMOS EN UNA VARIABLE SESSION LA LISTA DEVUELTA POR EL METODO CITASDELDIA 
                Session.Add("s_PacienteCitas", p);
                //CARGAMOS EL CONTROL PARA MOSTRAR LA LISTA DE PACIENTES
                ListItem item = new ListItem();
                item.Text = "Seleccione...";
                item.Value = "0";
                ddl_paciente.Items.Add(item);
                ddl_paciente.DataSource = p;
                ddl_paciente.DataTextField = "Paciente";
                ddl_paciente.DataValueField = "IdPaciente";
                ddl_paciente.DataBind();
            }
            catch (Exception err)
            {
                //MANEJAMOS EL ERROR
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al cargar los pacientes " + err.Message;
            }
        }

        protected void CargarGrid(string fecha)
        {
            try
            {
                /*CARGAMOS EL GRID CON LA INFORMACION OBTENIDA EN LA ENTIDAD CITASDELDIA_SP_RESULT*/
                Negocio.citasdeldia_spNegocio dc = new Negocio.citasdeldia_spNegocio();
                List<Entidad.CitasdelDia_SP_Result> citas = null;
                citas = dc.CitasdelDia(fecha);
                if (citas.Count != 0)
                {
                    gv_citas.DataSource = citas;
                    gv_citas.DataBind();
                }
                else
                {
                    /*SI EL METODO NO RETORNA DATOS SE MUESTRA UN MENSAJE AL USUARIO*/
                    //lb_mensajes.ForeColor = System.Drawing.Color.Red;
                    //lb_mensajes.Text = "No hay citas para la fecha seleccionada!!!";
                    string mensaje = "MostrarMensaje('ERROR','No se encontraron citas para la fecha digitada!!!')";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                    //tb_fechafiltro.Focus();
                    List<Entidad.CitasdelDia_SP_Result> ct = new List<Entidad.CitasdelDia_SP_Result>();
                    gv_citas.DataSource = ct;
                    gv_citas.DataBind();
                }
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            try
            {
                //VALIDAMOS QUE LA FECHA A BUSCAR CONTENGA INFORMACION
                if (tb_fechafiltro.Text == "")
                {
                    //lb_mensajes.ForeColor = System.Drawing.Color.Red;
                    //lb_mensajes.Text = "Debe seleccionar la fecha a buscar!!!";
                    string mensaje = "MostrarMensaje('INFO','Debe digitar la fecha a buscar!!!')";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                }
                else
                {
                    //DECLARAMOS LAS INSTANCIAS NECESARIA PARA CONSUMIR Y OBTENER LA INFORMACION
                    Negocio.citasdeldia_spNegocio dc = new Negocio.citasdeldia_spNegocio();
                    List<Entidad.CitasdelDia_SP_Result> sd = null;
                    sd = dc.CitasdelDia(tb_fechafiltro.Text);
                    //VERIFICAMOS SI SE ENCUENTRAN CITAS PARA EL DIA SELECCIONADO
                    if (sd.Count != 0)
                    {
                        //CARGAMOS LOS PACIENTES EN EL DROPDOWNLIST
                        CargarPacientes(tb_fechafiltro.Text);
                        lb_mensajes.Text = "";
                        //CARGAMOS LOS SERVICIOS 
                        CargarServicios();
                        ddl_motivo.Enabled = true;
                        btn_agregar.Enabled = true;
                    }
                    else
                    {
                        /*SI EL METODO NO RETORNA DATOS SE MUESTRA UN MENSAJE AL USUARIO*/
                        //lb_mensajes.ForeColor = System.Drawing.Color.Red;
                        //lb_mensajes.Text = "No hay citas para la fecha seleccionada!!!";
                        string mensaje = "MostrarMensaje('ERROR','No se encontraron citas para la fecha seleccionada!!!')";
                        ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", mensaje, true);
                        ddl_paciente.Items.Clear();
                    }
                }
            }
            catch (Exception err)
            {
                //MANEJAMOS EL ERROR
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al filtrar las citas del dia " + err.Message;
            }
        }

        private class DetalleFactura
        {
            public int id { get; set; }
            public string descripcion { get; set; }
            public int cantidad { get; set; }
            public int precio { get; set; }
            public int importe { get; set; }
        }

        private bool ExisteServicio(int idproducto, List<DetalleFactura> dfactura)
        {
            bool existe = false;
            try
            {
                foreach (var item in dfactura)
                {
                    if (item.id == idproducto)
                        existe = true;
                }
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = true;
                cv_informacion.ErrorMessage = err.Message;
            }
            return existe;
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                List<DetalleFactura> detallef = new List<DetalleFactura>();
                if (Session["S_DetalleFac"] != null)
                    detallef = (List<DetalleFactura>)Session["S_DetalleFac"];
                if (!ExisteServicio(int.Parse(ddl_motivo.SelectedValue), detallef))
                {
                    DetalleFactura df = new DetalleFactura();
                    //int idservicio = int.Parse(ddl_motivo.SelectedValue);
                    df.id = int.Parse(ddl_motivo.SelectedValue);
                    df.descripcion = ddl_motivo.SelectedItem.Text;
                    Negocio.serviciosNegocio dc = new Negocio.serviciosNegocio();
                    df.precio = (int)dc.BuscarServicio(df.id).Precio;
                    df.cantidad = int.Parse(tb_cantidad.Text);
                    df.importe = df.precio * df.cantidad;
                    //Calculando el total de la factura ------------------
                    /*decimal Total = 0;
                    if (lb_Total.Text != "")
                        Total = decimal.Parse(lb_Total.Text) + df.importe;
                    else
                        Total = df.importe;
                    lb_Total.Text = Total.ToString();
                    lb_TotalFac.Text = Total.ToString("C");
                    //--- Termina el calculo ----------------------------*/                    
                    Label1.Visible = true;
                    lb_total.Visible = true;
                    lb_moneda.Visible = true;
                    //lb_moneda.Text = "C$";
                    //Calculando el total de la factura ------------------
                    int totalfact = 0;
                    if (lb_total.Text != "")
                        totalfact = int.Parse(lb_total.Text) + df.importe;
                    else
                        totalfact = df.importe;
                    lb_total.Text = totalfact.ToString();
                    lb_moneda.Text = totalfact.ToString("C");
                    //--- Termina el calculo ----------------------------*/
                    detallef.Add(df);
                    /*int totalfact = 0;
                    lb_total.Text = detallef.Sum(dep => dep.precio).ToString();
                    totalfact = int.Parse(lb_total.Text);
                    lb_moneda.Text = totalfact.ToString("C");*/
                    /*Label2.Text = (from x in detallef select x.importe).Sum().ToString("C"); //----*/
                    Session.Add("S_DetalleFac", detallef);
                    gv_detalle.DataSource = detallef;
                    gv_detalle.DataBind();
                    btn_facturar.Enabled = true;
                    btn_cancelar.Enabled = true;
                    ddl_paciente.Enabled = false;
                    ddl_motivo.SelectedIndex = 0;
                    tb_cantidad.Text = "";
                }
                else
                {
                    cv_informacion.IsValid = false;
                    cv_informacion.ErrorMessage = "El servicio ya esta incluido en la lista!!!";
                }             

            }
            catch (Exception err)
            {
                //MANEJAMOS EL ERROR
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al agregar el servicio al detalle, " + err.Message;
            }
        }

        protected void btn_facturar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.serviciobrindadoNegocio dc = new Negocio.serviciobrindadoNegocio();
                Entidad.Cat_Servicio_Brindado fac = new Entidad.Cat_Servicio_Brindado();
                fac.IdPaciente = int.Parse(ddl_paciente.SelectedValue);
                fac.Monto = int.Parse(lb_total.Text);
                Entidad.Validar_Login_Result login = null;
                login = (Entidad.Validar_Login_Result)Session["S_Login"];
                string user = "";
                if (login != null)
                {
                    user = login.Usuario;
                }                            
                fac.Usuario = user;
                //fac.Usuario = (string)Session["S_Login"]; 
                //fac.Usuario = "Jimmy";
                fac.Fecha = DateTime.Now;
                List<Entidad.Detalle_Servicio_Brindado> fdetalle = new List<Entidad.Detalle_Servicio_Brindado>();
                List<DetalleFactura> dfactura = (List<DetalleFactura>)Session["S_DetalleFac"];
                foreach (var item in dfactura)
                {
                    Entidad.Detalle_Servicio_Brindado fd = new Entidad.Detalle_Servicio_Brindado();
                    fd.IdServicio = item.id;
                    fd.Cantidad = item.cantidad;
                    fd.Valor = item.precio;
                    fdetalle.Add(fd);
                }
                //dc.InsertServicioBrindado(fac, fdetalle);
                /*****************************************************************************/
                /*HABILITAMOS EL BOTON IMPRIMIR*/
                btn_imprimir.Enabled = true;
                /*PONEMOS EN VACIO EL CONTENIDO DE LB_TOTAL PARA NO TOMAR DATOS ANTERIORES QUE ESTE POSEA*/
                lb_total.Text = "";
                /*Removemos la variable session*/
                Session.Remove("S_DetalleFac");
                ddl_paciente.Enabled = true;
                /*INABILITAMOS EL BOTON FACTURAR*/
                btn_facturar.Enabled = false;                
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al guardar en factura y detalle de la factura!!!" + err.Message;
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                CleanControl(this.Controls);
                ddl_paciente.Enabled = true;
                ddl_paciente.Items.Clear();
                ddl_motivo.Enabled = false;
                Session.Remove("S_DetalleFac");
                List<DetalleFactura> df = null;
                gv_detalle.DataSource = df;
                gv_detalle.DataBind();
                Label1.Visible = false;
                lb_moneda.Visible = false;
                lb_total.Visible = false;
                /*PONEMOS EN VACIO EL CONTENIDO DE LB_TOTAL PARA NO TOMAR DATOS ANTERIORES QUE ESTE ALLA OBTENIDO*/
                lb_total.Text = "";
                tb_fecha.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = "Error al cancelar, " + err.Message;
            }
            
        }

        protected void CleanControl(ControlCollection controls)
        {
            try
            {
                /*METODO UTILIZADO PARA LIMPIAR LOS CONTROLES*/
                foreach (Control controles in controls)
                {
                    if (controles is TextBox)
                        ((TextBox)controles).Text = string.Empty;
                    else if (controles is DropDownList)
                        ((DropDownList)controles).ClearSelection();
                    else if (controles is RadioButton)
                        ((RadioButton)controles).Checked = false;
                    else if (controles is CheckBox)
                        ((CheckBox)controles).Checked = false;
                    else if (controles.HasControls())
                        CleanControl(controles.Controls);
                }
            }
            catch (Exception err)
            {
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {
            try
            {
                string reporte = "FACTURA";
                Response.Redirect("~/wf_Reportes.aspx?reporte=" + reporte);
            }
            catch (Exception err)
            {                
                cv_informacion.IsValid = false;
                cv_informacion.ErrorMessage = err.Message;
            }
        }      

    }
}