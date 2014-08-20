using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class citasdeldia_spNegocio
    {
        public List<Entidad.CitasdelDia_SP_Result> CitasdelDia(string fecha_cita)
        {
            try
            {
                Datos.citasdeldia_spData dc = new Datos.citasdeldia_spData();
                return dc.GetCitas(fecha_cita);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

    }
}
