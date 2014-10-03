using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class detalleserviciobrindadoData
    {
        public void InsertDetalleServicioBrindado(Entidad.Detalle_Servicio_Brindado dsb)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                dc.Detalle_Servicio_Brindado.AddObject(dsb);
                dc.SaveChanges();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en InsertDetalleServicioBrindado: " + err.Message);
            }
        }


    }
}
