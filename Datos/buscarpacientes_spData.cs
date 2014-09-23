using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class buscarpacientes_spData
    {
        public List<Entidad.Buscar_Pacientes_Result> FindPacientes(string apellidos)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.Buscar_Pacientes(apellidos).ToList();
            }
            catch (Exception err)
            {
                throw new Exception("Error en FindPacientes, data: " + err.Message);
            }
        }

    }
}
