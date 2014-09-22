using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class validarexistenciapaciente_spNegocio
    {

        public Entidad.Validar_Existencia_Paciente_Result ValidarPaciente(string nombres, string apellidos)
        {
            try
            {
                Datos.validarexistenciapaciente_spData dc = new Datos.validarexistenciapaciente_spData();
                return dc.ValidarPacientes(nombres, apellidos);
            }
            catch (Exception err)
            {
                throw new Exception("Error en ValidarPaciete, negocio: " + err.Message);
            }
        }
    }
}
