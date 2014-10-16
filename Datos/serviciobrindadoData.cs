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

        public Entidad.Cat_Servicio_Brindado GetBy_Factura(string nfactura)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.Cat_Servicio_Brindado.Where(f => f.IdRecibo == nfactura).FirstOrDefault();
            }
            catch (Exception err)
            {
                throw new Exception("Error en GetBy_Factura " + err.Message);
            }
        }
    }
}
