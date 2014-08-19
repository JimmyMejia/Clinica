using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Datos
{
    public class citaData
    {
        public List<Entidad.Cat_Cita> GetList()
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.Cat_Cita.ToList();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en GetList " + err.Message);
            }            
        }

        public void Insert(Entidad.Cat_Cita cita)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                dc.Cat_Cita.AddObject(cita);
                dc.SaveChanges();
            }
            catch (Exception err)
            {
                throw new Exception("Error en Insert " + err.Message);
            }            
        }

        public void Update(Entidad.Cat_Cita cita)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Cat_Cita db_cita = null;
                db_cita = dc.Cat_Cita.Where(c => c.IdCita == cita.IdCita).FirstOrDefault();
                if (db_cita != null)
                {
                    db_cita.Fecha = cita.Fecha;
                    db_cita.Hora = cita.Hora;
                    db_cita.IdServicio = cita.IdServicio;
                    db_cita.Estado = cita.Estado;
                    dc.SaveChanges();
                }
            }
            catch (Exception err)
            {                
                throw new Exception ("Error en Update " + err.Message);
            }
        }

       public int GetCount()
       {
           try
           {
               Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
               return dc.Cat_Cita.Count();
           }
           catch (Exception err)
           {               
               throw new Exception("Error en GetCount " + err.Message);
           }
       }

       public int ValidarHoraCita(DateTime fecha, string hora)
       {
           try
           {
               int resp = 0;
               Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
               Entidad.Cat_Cita db_cita = null;
               db_cita = dc.Cat_Cita.Where(c => c.Fecha == fecha && c.Hora == hora).FirstOrDefault();
               if (db_cita != null)
                   resp = 1;

               return resp;
           }
           catch (Exception err)
           {
               throw new Exception("Error en ValidarHoraCita " + err.Message);
           }
           
       }

        
    }
}
