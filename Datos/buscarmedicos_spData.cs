using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class buscarmedicos_spData
    {
        public List<Entidad.Buscar_Medicos_Result> FindMedicos(string apellidos)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.Buscar_Medicos(apellidos).ToList();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en FindMedicos, data: " + err.Message);
            }
        }

    }
}
