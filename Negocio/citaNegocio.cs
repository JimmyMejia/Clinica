using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class citaNegocio
    {
        public void InsertarCita(Entidad.Cat_Cita cita)
        {
            try
            {
                Datos.citaData dc = new Datos.citaData();
                cita.IdCita = Generar_Codigo();
                cita.FechaRegistroCita = DateTime.Now;
                DateTime fechacita = Convert.ToDateTime(cita.Fecha);
                string fecha = Convert.ToString(DateTime.Now.ToString().Substring(0,10));//19/08/2014 10:00:20 a.m.
                DateTime fechaactual = Convert.ToDateTime(fecha);
                if (fechacita < fechaactual)
                    throw new Exception("La fecha de la cita no puede ser anterior a la fecha actual!!!");
                else
                {
                    //string hora = "10:00";
                    int resp = dc.ValidarHoraCita(fechacita,cita.Hora);
                    if(resp == 0)
                        dc.Insert(cita);
                    else
                        throw new Exception("Ya existe una cita con la fecha y hora seleccionada!!!");
                }
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

        public void UpdateCita(Entidad.Cat_Cita cita)
        {
            try
            {
                Datos.citaData dc = new Datos.citaData();
                dc.Update(cita);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public Entidad.Cat_Cita ConsultarCita(string id_cita)
        {
            try
            {
                Datos.citaData dc = new Datos.citaData();
                return dc.GetList().Where(c => c.IdCita == id_cita).FirstOrDefault();
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

        private string Generar_Codigo()
        {
            try
            {
                int correlativo = 0;
                string cadena_corr = "";
                Datos.citaData dc = new Datos.citaData();
                correlativo = dc.GetCount() + 1;
                int anio = DateTime.Now.Year;
                cadena_corr = correlativo.ToString("00000");
                string codigo_alumno = anio.ToString() + cadena_corr;
                return codigo_alumno;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public List<Entidad.Cat_Cita> ObtenerCitas(DateTime fecha)
        {
            
            try
            {
                List<Entidad.Cat_Cita> resp = new List<Entidad.Cat_Cita>();
                Datos.citaData dc = new Datos.citaData();
                List<Entidad.Cat_Cita> citas = dc.GetCitas(fecha);
                foreach (var item in citas)
                {
                    Entidad.Cat_Cita p = new Entidad.Cat_Cita();
                    p.IdCita = item.IdCita;
                    p.IdPaciente = item.IdPaciente;
                    p.Fecha = item.Fecha;
                    p.Hora = item.Hora;
                    p.IdServicio = item.IdServicio;
                    resp.Add(p);
                }
                return resp;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

    }
}
