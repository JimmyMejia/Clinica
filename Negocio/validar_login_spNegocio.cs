using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class validar_login_spNegocio
    {
        public bool ValidarUsuario(string user, string pass)
        {
            bool resp = false;
            try
            {
                Datos.validar_login_spData dc = new Datos.validar_login_spData();
                bool result = false;
                result = dc.GetResult(user, pass);
                if (result == true)
                    resp = true;
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
            return resp;
        }

    }
}
