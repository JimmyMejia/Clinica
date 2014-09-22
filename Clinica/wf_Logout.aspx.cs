using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica
{
    public partial class wf_logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session.RemoveAll();
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}