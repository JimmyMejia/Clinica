using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class usuariosNegocio
    {
        public Entidad.Insertar_Usuario_Result InsertarUsuario(string nombre, int idrol, string user, string pass, string activo)
        {
            try
            {
                Datos.usuariosData dc = new Datos.usuariosData();
                //activo = "1";
                return dc.InsertUser(nombre,idrol,user,pass,activo);
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

        public bool VerificarUsuario(string user)
        {
            bool existe = false;
            try
            {
                Datos.usuariosData dc = new Datos.usuariosData();
                bool resp = dc.GetUser(user);
                if (resp == true)
                    existe = true;
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
            return existe;
        }

    }
}
