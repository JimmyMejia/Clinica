using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class pacienteData
    {
        public List<Entidad.Paciente> GetLista()
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.Pacientes.ToList();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en GetLista" + err.Message);
            }            
        }

        public void Insert(Entidad.Paciente pacienteData)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                dc.Pacientes.AddObject(pacienteData);
                dc.SaveChanges();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en Insert" + err.Message);
            }
        }

        public int VerificarPaciente(Entidad.Paciente paciente)
        {
            try
            {
                int existe;
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Paciente hay = null;
                hay = dc.Pacientes.Where(p => p.Nombres == paciente.Nombres && p.Apellidos == paciente.Apellidos).FirstOrDefault();
                if (hay == null)
                    existe = 0;
                else
                    existe = 1;

                return existe;                
            }
            catch (Exception err)
            {
                throw new Exception("Error en ValidarPaciente " + err.Message);
            }
        }

        public void Update(Entidad.Paciente pacienteData)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Paciente db_paciente = null;
                db_paciente = dc.Pacientes.Where(p => p.IdPaciente == pacienteData.IdPaciente).FirstOrDefault();
                if (db_paciente != null)
                {
                    db_paciente.Nombres = pacienteData.Nombres;
                    db_paciente.Apellidos = pacienteData.Apellidos;
                    db_paciente.Fecha_nacimiento = pacienteData.Fecha_nacimiento;
                    db_paciente.Direccion = pacienteData.Direccion;
                    db_paciente.Telefono = pacienteData.Telefono;
                    db_paciente.Celular = pacienteData.Celular;
                    dc.SaveChanges();
                }
            }
            catch (Exception err)
            {                
                throw new Exception("Error en Update " + err.Message);
            }
        }

        public void Delete(Entidad.Paciente pacienteData)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                dc.Pacientes.DeleteObject(pacienteData);
                dc.SaveChanges();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en Delete " + err.Message) ;
            }
        }

    }
}
