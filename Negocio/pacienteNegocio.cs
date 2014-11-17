using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class pacienteNegocio
    {

        //public void InsertarPaciente(Entidad.Paciente pacienteNegocio)
        //{
        //    try
        //    {
        //        Datos.pacienteData pd = new Datos.pacienteData();
        //        //pd.ValidarPaciente(pacienteNegocio);
        //        pd.Insert(pacienteNegocio);
        //    }
        //    catch (Exception err)
        //    {
        //        throw new Exception(err.Message);
        //    }
        //}

        public string ValidarFechas(Entidad.Paciente pacienteNegocio)
        {
            try
            {
                string error = "";
                //Datos.pacienteData pd = new Datos.pacienteData();
                //pd.ValidarPaciente(pacienteNegocio);
                /*OBTENEMOS LA FECHA DE NACIMIENTO EN UNA VARIABLE PARA TRATARLA DESPUES*/
                DateTime fecha_nac = Convert.ToDateTime(pacienteNegocio.Fecha_nacimiento);
                /*GUARDAMOS EN UNA VARIABLE LA FECHA ACTUAL*/
                string fecha = Convert.ToString(DateTime.Now.ToString().Substring(0, 10));//19/08/2014 10:00:20 a.m.
                DateTime fechaactual = Convert.ToDateTime(fecha);
                /*VERIFICAMOS QUE LA FECHA DIJITADA NO SEA MAYOR A LA FECHA ACTUAL*/
                if (fecha_nac > fechaactual)
                    //throw new Exception("La fecha de nacimiento no puede ser mayor a la fecha actual!!!");
                    error = "La fecha de nacimiento no puede ser mayor a la fecha actual!!!";
                return error;          
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

        public string InsertarPaciente(Entidad.Paciente pacienteNegocio)
        {
            try
            {
                //string error = "";
                //Datos.pacienteData pd = new Datos.pacienteData();
                ////pd.ValidarPaciente(pacienteNegocio);
                ///*OBTENEMOS LA FECHA DE NACIMIENTO EN UNA VARIABLE PARA TRATARLA DESPUES*/
                //DateTime fecha_nac = Convert.ToDateTime(pacienteNegocio.Fecha_nacimiento);
                ///*GUARDAMOS EN UNA VARIABLE LA FECHA ACTUAL*/
                //string fecha = Convert.ToString(DateTime.Now.ToString().Substring(0, 10));//19/08/2014 10:00:20 a.m.
                //DateTime fechaactual = Convert.ToDateTime(fecha);
                ///*VERIFICAMOS QUE LA FECHA DIJITADA NO SEA MAYOR A LA FECHA ACTUAL*/
                //if (fecha_nac > fechaactual)
                //    //throw new Exception("La fecha de nacimiento no puede ser mayor a la fecha actual!!!");
                //    error = "La fecha de nacimiento no puede ser mayor a la fecha actual!!!";
                //else
                //{
                //    pd.Insert(pacienteNegocio);
                //}
                //return error;                
                string error = "";
                Datos.pacienteData dc = new Datos.pacienteData();
                error = ValidarFechas(pacienteNegocio);
                if (error == "")
                {
                    dc.Insert(pacienteNegocio);
                }
                return error;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public string UpdatePaciente(Entidad.Paciente pacienteNegocio)
        {
            try
            {
                string error = "";
                Datos.pacienteData dc = new Datos.pacienteData();
                error = ValidarFechas(pacienteNegocio);
                if (error == "")
                {                    
                    dc.Update(pacienteNegocio);
                }
                return error;
            }
            catch (Exception err)
            {                
                  throw new Exception(err.Message);
            }            
        }

        public int ValidarPaciente(Entidad.Paciente paciente)
        {
            try
            {
                int existe;
                Datos.pacienteData dc = new Datos.pacienteData();
                return existe = dc.VerificarPaciente(paciente);
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

        public Entidad.Paciente ConsultarPaciente(int id_paciente)
        {
            try
            {
                Datos.pacienteData dc = new Datos.pacienteData();
                return dc.GetLista().Where(p => p.IdPaciente == id_paciente).FirstOrDefault();
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

        public List<Entidad.Paciente> ListaPacientes()
        {
            try
            {
                List<Entidad.Paciente> resp = new List<Entidad.Paciente>();
                Datos.pacienteData dc = new Datos.pacienteData();
                List<Entidad.Paciente> pacientes = dc.GetLista();
                foreach (var item in pacientes)
                {
                    Entidad.Paciente p = new Entidad.Paciente();
                    p.IdPaciente = item.IdPaciente;
                    //p.Nombres = string.Concat(item.Nombres, " ", item.Apellidos);
                    //p.Nombres = item.Nombres + " " + item.Apellidos;
                    p.Nombres = item.Nombres;
                    p.Apellidos = item.Apellidos;
                    p.Direccion = item.Direccion;
                    p.Celular = item.Celular;
                    p.Fecha_nacimiento = item.Fecha_nacimiento;
                    p.Telefono = item.Telefono;
                    resp.Add(p);
                }
                return resp;
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }            
        }

        public List<Entidad.Paciente> Pacientes()
        {
            try
            {
                List<Entidad.Paciente> resp = new List<Entidad.Paciente>();
                Datos.pacienteData dc = new Datos.pacienteData();
                List<Entidad.Paciente> pacientes = dc.GetLista();
                foreach (var item in pacientes)
                {
                    Entidad.Paciente p = new Entidad.Paciente();
                    p.IdPaciente = item.IdPaciente;
                    p.Nombres = item.Nombres + " " + item.Apellidos;
                    p.Apellidos = item.Apellidos;
                    p.Direccion = item.Direccion;
                    p.Celular = item.Celular;
                    p.Fecha_nacimiento = item.Fecha_nacimiento;
                    p.Telefono = item.Telefono;
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
