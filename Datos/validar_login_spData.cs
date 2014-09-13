using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class validar_login_spData
    {
        /*public bool GetResult(string user, string pass)
        {
            bool resp = false;
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Validar_Login_Result result = null; 
                result = dc.Validar_Login(user, pass).FirstOrDefault();
                if (result != null)
                    resp = true;
            }
            catch (Exception err)
            {                
                throw new Exception("Error en GetResult " + err.Message);
            }
            return resp;
        }*/

        public Entidad.Validar_Login_Result GetResult(string user, string pass)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Validar_Login_Result result = null;
                return result = dc.Validar_Login(user, pass).FirstOrDefault();               
            }
            catch (Exception err)
            {
                throw new Exception("Error en GetResult " + err.Message);
            }
        }

    }
}
