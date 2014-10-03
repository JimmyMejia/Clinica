using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class serviciobrindadoData
    {
        public void InsertServicioBrindado(Entidad.Cat_Servicio_Brindado sb)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                dc.Cat_Servicio_Brindado.AddObject(sb);
                dc.SaveChanges();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en InsertServicioBrindado: " + err.Message);
            }
        }

        public int GetCount()
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.Cat_Servicio_Brindado.Count();
            }
            catch (Exception err)
            {                
                 throw new Exception("Error en GetCount: " + err.Message);
            }
        }
    }
}
