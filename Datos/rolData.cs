using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class rolData
    {
        public List<Entidad.Cat_Rol> GetList_Rol()
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.Cat_Rol.ToList();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en GetList_Rol: " + err.Message);
            }
        }

    }
}
