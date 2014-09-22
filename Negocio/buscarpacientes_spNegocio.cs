using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class buscarpacientes_spNegocio
    {
        public List<Entidad.Buscar_Pacientes_Result> BuscarPacientes(string apellidos)
        {
            try
            {
                Datos.buscarpacientes_spData dc = new Datos.buscarpacientes_spData();
                return dc.FindPacientes(apellidos);
            }
            catch (Exception err)
            {
                throw new Exception("Error en BuscarPacientes, data: " + err.Message);
            }
        }

    }
}
