using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class validarexistenciapaciente_spData
    {
        public Entidad.Validar_Existencia_Paciente_Result ValidarPacientes(string nombres, string apellidos)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.Validar_Existencia_Paciente(nombres, apellidos).FirstOrDefault();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en ValidarPacietes, data: " + err.Message);
            }
        }


    }
}
