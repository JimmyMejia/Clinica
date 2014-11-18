using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class buscarmedicos_spNegocio
    {
        public List<Entidad.Buscar_Medicos_Result> BuscarMedicos(string apellidos)
        {
            try
            {
                Datos.buscarmedicos_spData dc = new Datos.buscarmedicos_spData();
                return dc.FindMedicos(apellidos);
            }
            catch (Exception err)
            {                
                throw new Exception("Error en BuscarMedicos, negocio: " +err.Message);
            }
        }

    }
}
