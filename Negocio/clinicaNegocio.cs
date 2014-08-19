using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class clinicaNegocio
    {

        public void InsertarClinica(Entidad.Clinica clinicaNegocio )
        {
            try
            {
                Datos.clinicaData cd = new Datos.clinicaData();
                cd.Insert(clinicaNegocio);
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

        public int VerificarClinicaActiva()
        {
            try
            {
                int activa;
                Datos.clinicaData dc = new Datos.clinicaData();
                activa = dc.BuscarClinicaActiva();
                return activa;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
           
        }

        public int VerificarActiva(Entidad.Clinica clinica)
        {
            try
            {
                int activa;
                Datos.clinicaData dc = new Datos.clinicaData();
                return activa = dc.BuscarEstadoActivo(clinica);
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }            
        }

        public List<Entidad.Clinica> Clinicas()
        {
            try
            {
                Datos.clinicaData dc = new Datos.clinicaData();
                return dc.GetList();
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

    }
}
