using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class detalleserviciobrindadoNegocio
    {
        public void InsertarDetalleServicioBrindado(Entidad.Detalle_Servicio_Brindado dsb)
        {
            try
            {
                Datos.detalleserviciobrindadoData dc = new detalleserviciobrindadoData();
                dc.InsertDetalleServicioBrindado(dsb);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }


    }
}
