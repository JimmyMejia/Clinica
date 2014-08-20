using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class citasdeldia_spData
    {

        public List<Entidad.CitasdelDia_SP_Result> GetCitas(string fecha_cita)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.CitasdelDia_SP(fecha_cita).ToList();
            }
            catch (Exception err)
            {
                throw new Exception("Error en GetCitas " + err.Message);
            }
            
        }
    }
}
