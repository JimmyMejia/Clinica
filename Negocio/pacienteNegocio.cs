using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class pacienteNegocio
    {

        public void InsertarPaciente(Entidad.Paciente pacienteNegocio)
        {
            try
            {
                Datos.pacienteData pd = new Datos.pacienteData();
                //pd.ValidarPaciente(pacienteNegocio);
                pd.Insert(pacienteNegocio);
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public void UpdatePaciente(Entidad.Paciente pacienteNegocio)
        {
            try
            {
                Datos.pacienteData dc = new Datos.pacienteData();
                dc.Update(pacienteNegocio);
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
