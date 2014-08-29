using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class citaNegocio
    {
        /// <summary>
        /// METODO QUE NOS FACILITA LA INSERCION DE UNA NUEVA CITA
        /// PARA REGISTRAR UNA NUEVA CITA ES NECESARIO VALIDAR QUE LA FECHA DE LA CITA NO SEA ANTERIOR A LA FECHA ACTUAL
        /// </summary>
        /// <param name="cita"></param>
        public void InsertarCita(Entidad.Cat_Cita cita)
        {
            try
            {
                Datos.citaData dc = new Datos.citaData();
                cita.IdCita = Generar_Codigo();
                cita.FechaRegistroCita = DateTime.Now;
                /*OBTENEMOS LA FECHA DE LA CITA EN UNA VARIABLE PARA TRATARLA DESPUES*/
                DateTime fechacita = Convert.ToDateTime(cita.Fecha);
                /*GUARDAMOS EN UNA VARIABLE LA FECHA ACTUAL*/
                string fecha = Convert.ToString(DateTime.Now.ToString().Substring(0,10));//19/08/2014 10:00:20 a.m.
                DateTime fechaactual = Convert.ToDateTime(fecha);
                /*VERIFICAMOS QUE LA FECHA SOLICITADA PARA LA CITA NO SEA MENOR A LA FECHA ACTUAL*/
                if (fechacita < fechaactual)
                    throw new Exception("La fecha de la cita no puede ser anterior a la fecha actual!!!");
                else
                {
                    /*SI LA FECHA DE LA CITA NO ERA MENOR A LA FECHA ACTUAL ENTONCES LLAMAMOS AL METODO PARA VERIFICAR 
                     QUE LA FECHA Y HORA SOLICITADA PARA LA CITA NO ESTE REGISTRADA CON ANTERIORIDAD*/
                    int resp = dc.ValidarFechaHoraCita(fechacita,cita.Hora);
                    /*SI EL METODO RETORNA 0 INDICA QUE NO ENCONTRO REGISTRO PARA LA FECHA Y HORA SOLICITADA Y SE PROCEDE 
                     A INSERTAR LA CITA*/
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

        /// <summary>
        /// METODO UTILIZADO PARA ACTUALIZAR LA CITA DEL PACIENTE
        /// </summary>
        /// <param name="cita"></param>
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

        /// <summary>
        /// METODO QUE NOS PERMITE OBTENER LA INFORMACION DEL OBJETO DE TIPO CITA DEL IDCITA QUE PASAMOS COMO PARAMETRO
        /// </summary>
        /// <param name="id_cita"></param>
        /// <returns></returns>
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

        /// <summary>
        /// METODO DEDICADO A LA GENERACION DEL CODIGO DE LA NUEVA CITA
        /// </summary>
        /// <returns></returns>
        private string Generar_Codigo()
        {
            try
            {
                int correlativo = 0;
                string cadena_corr = "";
                Datos.citaData dc = new Datos.citaData();
                /*HACEMOS LLAMADO AL USO DEL METODO GETCOUNT EL CUAL NOS PERMITE OBTENER LA CANTIDAD DE CITAS REGISTRADAS HASTA EL MOMENTO
                 Y LE SUMAMOS UNO PARA OBTENER EL CONSECUTIVO*/
                correlativo = dc.GetCount() + 1;
                /*OBTENEMOS EL AÑO ACTUAL*/
                int anio = DateTime.Now.Year;
                /*ASIGNAMOS A LA CADENA CADENA_CORR EL CONTADOR OBTENIDO EN EL METODO GETCOUNT Y LO RELLENAMOS CON LOS CEROS NECESARIOS
                 HASTA COMPLETAR LA CADENA*/
                cadena_corr = correlativo.ToString("000000");
                /*ASIGNAMOS A LA VARIABLE FINAL LA CONCATENACION DE LAS VARIABLES NECESARIAS PARA GENERAR EL CODIGO DE LA NUEVA CITA*/
                string codigo_alumno = anio.ToString() + cadena_corr;
                return codigo_alumno;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        /// <summary>
        /// METODO UTIL PARA OBTENER LAS CITAS DE LA FECHA BRINDADA EN EL PARAMETRO
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<Entidad.Cat_Cita> ObtenerCitas(DateTime fecha)
        {
            
            try
            {
                List<Entidad.Cat_Cita> resp = new List<Entidad.Cat_Cita>();
                Datos.citaData dc = new Datos.citaData();
                /*OBTENEMOS LAS CITAS POR MEDIO DEL METODO GETCITAS Y LA ASIGNAMOS A UNA LISTA DE TIPO CAT_CITA*/
                List<Entidad.Cat_Cita> citas = dc.GetCitas(fecha);
                /*RECORREMOS LA LISTA Y LA ASIGNAMOS A LA ENTIDAD DE TIPO CAT_CITA*/
                foreach (var item in citas)
                {
                    Entidad.Cat_Cita p = new Entidad.Cat_Cita();
                    /*ASIGNAMOS LOS VALORES DEVUELTO POR LA LISTA A UNA ENTIDAD DE TIPO CAT_CITA*/
                    p.IdCita = item.IdCita;
                    p.IdPaciente = item.IdPaciente;
                    p.Fecha = item.Fecha;
                    p.Hora = item.Hora;
                    p.IdServicio = item.IdServicio;
                    /*AGREGAMOS A LA LISTA DE TIPO RESP LOS VALORES OBTENIDOS EN LA ENTIDAD*/
                    resp.Add(p);
                }
                return resp;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        /*public List<Entidad.Cat_Cita> ObteberCitaByIdPaciente(int idpaciente) //DateTime fecha,
        {
            try
            {
                Datos.citaData dc = new Datos.citaData();
                List<Entidad.Cat_Cita> resp = new List<Entidad.Cat_Cita>();
                List<Entidad.Cat_Cita> citas = dc.GetCitasByIdPaciente(idpaciente); //fecha,
                foreach (var item in citas)
                {
                    Entidad.Cat_Cita c = new Entidad.Cat_Cita();
                    c.Fecha = item.Fecha;
                    c.Hora = item.Hora;
                    resp.Add(c);
                }
                return resp;
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }*/

    }
}
