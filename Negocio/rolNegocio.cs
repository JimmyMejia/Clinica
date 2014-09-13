using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class rolNegocio
    {
        public List<Entidad.Cat_Rol> GetListRol()
        {
            try
            {
                Datos.rolData dc = new Datos.rolData();
                return dc.GetList_Rol();
            }
            catch (Exception err)
            {
                throw new Exception("Error en GetListRol (Negocio): " + err.Message);
            }
        }

    }
}
