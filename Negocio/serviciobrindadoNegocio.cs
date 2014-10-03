using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Negocio
{
    public class serviciobrindadoNegocio
    {
        public void InsertServicioBrindado(Entidad.Cat_Servicio_Brindado sb, List<Entidad.Detalle_Servicio_Brindado> dsb)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Datos.serviciobrindadoData dc = new Datos.serviciobrindadoData();
                    sb.IdRecibo = NumeroRecibo();
                    sb.Fecha = DateTime.Now;
                    dc.InsertServicioBrindado(sb);
                    Datos.detalleserviciobrindadoData ds_detalle = new Datos.detalleserviciobrindadoData();
                    foreach (var ds in dsb)
                    {
                        ds.IdRecibo = sb.IdRecibo;
                        ds_detalle.InsertDetalleServicioBrindado(ds);
                    }
                    ts.Complete();
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                }
            }
        }

        protected string NumeroRecibo()
        {
            try
            {
                Datos.serviciobrindadoData dc = new Datos.serviciobrindadoData();
                string corr = (dc.GetCount() + 1).ToString("000000");
                string n_recibo = DateTime.Now.Year.ToString() + corr;
                return n_recibo;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }


    }
}
