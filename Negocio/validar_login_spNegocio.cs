using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class validar_login_spNegocio
    {
        /*public bool ValidarUsuario(string user, string pass)
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
        }*/

        public Entidad.Validar_Login_Result ValidarUsuario(string user, string pass)
        {
            try
            {
                Datos.validar_login_spData dc = new Datos.validar_login_spData();
                Entidad.Validar_Login_Result result = null;
                return result = dc.GetResult(user, pass);                
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

    }
}
