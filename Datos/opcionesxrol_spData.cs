using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class opcionesxrol_spData
    {
        public List<Entidad.OpcionesXRol_Result> GetList_OpcionesRol(int idrol)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.OpcionesXRol(idrol).ToList();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en GetList_OpcionesRol, data: " + err.Message);
            }
        }


    }
}
