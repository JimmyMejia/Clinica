using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class opcionesxrol_spData
    {
        public List<Entidad.OpcionesXRol_Result> GetListOpcionesRol(int idrol)
        {
            try
            {
                Datos.opcionesxrol_spData dc = new Datos.opcionesxrol_spData();
                return dc.GetList_OpcionesRol(idrol);
            }
            catch (Exception err)
            {
                throw new Exception("Error en GetListOpcionesRol, negocio: " + err.Message);
            }
        }

    }
}
