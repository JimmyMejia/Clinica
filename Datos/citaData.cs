using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Datos
{
    public class citaData
    {
        /// <summary>
        /// METODO QUE OBTIENEN LA INFORMACION EXISTENTE EN LA TABLA CAT_CITA
        /// </summary>
        /// <returns>LISTA DE TODOS LOS DATOS EN LA TABLA</returns>
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

        /// <summary>
        /// METODO QUE PERMITE AGREGAR UNA NUEVA CITA A LA TABLA
        /// </summary>
        /// <param name="cita"></param>
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

        /// <summary>
        /// METODO QUE PERMITE ACTUALIZAR LA INFORMACION DEL ELEMENTO CON EL ID ESPECIFICADO 
        /// </summary>
        /// <param name="cita"></param>
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
                    db_cita.NroCedula = cita.NroCedula;
                    db_cita.FechaModificacion = cita.FechaModificacion;
                    db_cita.Estado = cita.Estado;
                    dc.SaveChanges();
                }
            }
            catch (Exception err)
            {                
                throw new Exception ("Error en Update " + err.Message);
            }
        }

        /// <summary>
        /// METODO QUE NOS PERMITE OBTENER LA CANTIDAD DE CITAS REGISTRADAS EN LA TABLA PARA ASI PODER CREAR EL IDCITA DESDE LA CAPA
        /// DE NEGOCIO
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// METODO QUE NOS PERMITE VALIDAR LA FECHA Y HORA DE LA CITA QUE SE DESEA REGISTRAR
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="hora"></param>
        /// <returns></returns>
        public int ValidarFechaHoraCita(DateTime fecha, string hora)
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

        /// <summary>
        /// METODO QUE PERMITE DEVOLVERNOS LA LISTA DE LAS CITAS DE LA FECHA DADA
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<Entidad.Cat_Cita> GetCitas(DateTime fecha)
       {
           try
           {
               Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
               List<Entidad.Cat_Cita> citas = null;
               return citas = dc.Cat_Cita.Where(c => c.Fecha == fecha).ToList();               
           }
           catch (Exception err)
           {
               throw new Exception("Error en GetCitas "+err.Message);
           }
       }

        /*public List<Entidad.Cat_Cita> GetCitasByIdPaciente(int idpaciente) //DateTime fechacita, 
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                List<Entidad.Cat_Cita> citas = null;
                return citas = dc.Cat_Cita.Where(c => c.IdPaciente == idpaciente && c.Estado == "Activa").ToList(); // c.Fecha == fechacita &&
            }
            catch (Exception err)
            {
                throw new Exception("Error en GetCitasByIdUsuario " + err.Message);
            }
        }*/
        
    }
}
