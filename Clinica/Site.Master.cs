using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {                
                /*if (!IsPostBack)
                {
                    Entidad.Validar_Login_Result login = null;
                    login = (Entidad.Validar_Login_Result)Session["S_Login"];
                    string url1 = HttpContext.Current.Request.Url.AbsoluteUri;
                    // http://localhost:1302/TESTERS/Default6.aspx
                    string path = HttpContext.Current.Request.Url.AbsolutePath;
                    // /TESTERS/Default6.aspx
                    string host = HttpContext.Current.Request.Url.Host;
                    // localhost
                    string pagina = path.Substring(path.LastIndexOf("/") + 1);
                    string url = HttpContext.Current.Request.Url.AbsoluteUri.Substring(HttpContext.Current.Request.Url.AbsoluteUri.LastIndexOf('/') + 1);
                    Response.Write("<sript language=javascript>alert('La url es: " + url + "')</script>");

                    string idrol;
                    if (login != null)
                    {
                        idrol = login.IdRol.ToString();
                        List<Entidad.OpcionesXRol_Result> opciones = null;
                        Negocio.opcionesxrol_spData dc = new Negocio.opcionesxrol_spData();
                        opciones = dc.GetListOpcionesRol(int.Parse(idrol));
                        if (opciones != null)
                        {
                            foreach (var item in opciones)
                            {
                                if (item.Opcion != url)
                                {
                                    Response.Write("<sript language=javascript>alert('No tiene permiso para esta pagina!!!')</script>");
                                }
                                else
                                {
                                    Response.Redirect(url);
                                }
                            }

                        }
                        else
                        {
                            Response.Write("<sript language=javascript>alert('No tiene permisos en la aplicación!!! :(')</script>");
                        }
                    }

                }*/
            }
            catch (Exception)
            {

                throw;
            }

        }     

      
    }
}
