using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class usuariosData
    {
        public Entidad.Insertar_Usuario_Result InsertUser(string nombre, int idrol, string user, string pass, string activo)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.Insertar_Usuario(nombre, idrol, user, pass, activo).FirstOrDefault();
            }
            catch (Exception err)
            {                
                throw new Exception("Eror en InsertUser " + err.Message);
            }
        }

        public bool GetUser(string user)
        {
            bool resp = false;
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Usuario retorno = null;
                retorno = dc.Usuarios.Where(u => u.Usuario1 == user).FirstOrDefault();
                if (retorno != null)
                    resp = true;
            }
            catch (Exception err)
            {                
                throw new Exception("Error en GetUser " + err.Message);
            }
            return resp;
        }

    }
}
