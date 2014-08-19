using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class serviciosNegocio
    {

        public bool InsertarServicio(Entidad.Cat_Servicio serviciosNegocio)
        {
            try
            {
                Datos.serviciosData sd = new Datos.serviciosData();

                if(!sd.ExisteServicio(serviciosNegocio))
                {
                    sd.Insert(serviciosNegocio);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

        public void EliminarServicio(int id_servicio)
        {
            try
            {
                Datos.serviciosData dc = new Datos.serviciosData();
                dc.Delete(id_servicio);
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

        public void ActualizarServicio(Entidad.Cat_Servicio servicioNegocio)
        {
            try
            {
                Datos.serviciosData dc = new Datos.serviciosData();
                dc.Update(servicioNegocio);
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

        public Entidad.Cat_Servicio BuscarServicio(int myid)
        {
            try
            {
                Datos.serviciosData sd = new Datos.serviciosData();
                return sd.Find(myid);
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

        public List<Entidad.Cat_Servicio> BuscarDescripcionServicio(String Descripcion)
        {
            try
            {
                Datos.serviciosData sd = new Datos.serviciosData();
                return sd.FindDescripcion(Descripcion);
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

        public List<Entidad.Cat_Servicio> ListaServicios()
        {
            try
            {
                Datos.serviciosData dc = new Datos.serviciosData();
                return dc.GetList();
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }
        

    }
}
