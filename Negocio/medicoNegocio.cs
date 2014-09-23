using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class medicoNegocio
    {

        public List<Entidad.Medico> ListaMedico()
        {
            try
            {
                Datos.medicoData dc = new Datos.medicoData();
                return dc.GetListMedico();
            }
            catch (Exception err)
            {
                throw new Exception("Error en ListaMedico: " + err.Message);
            }

        }

        public void InsertarMedico(Entidad.Medico m)
        {
            try
            {
                Datos.medicoData dc = new Datos.medicoData();
                dc.InsertMedico(m);
            }
            catch (Exception err)
            {
                throw new Exception("Error en InsertarMedico: " + err.Message);
            }
        }

        public int ExisteCedula(string cedula)
        {
            try
            {
                int resp;
                Datos.medicoData dc = new Datos.medicoData();
                return resp = dc.ExistCedula(cedula);                
            }
            catch (Exception err)
            {
                throw new Exception("Error en ExisteCedula: " + err.Message);
            }
        }
    }
}
