using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class medicoData
    {
        public List<Entidad.Medico> GetListMedico()
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.Medicos.ToList();
            }
            catch (Exception err)
            {
                throw new Exception("Error en GetListMedico: " + err.Message);
            }
           
        }

        public void InsertMedico(Entidad.Medico m)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                dc.Medicos.AddObject(m);
                dc.SaveChanges();
            }
            catch (Exception err)
            {
                throw new Exception("Error en InsertMedico: " + err.Message);
            }            
        }

        public void Update(Entidad.Medico m, string cedula_nueva)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Medico db_medico = null;
                db_medico = dc.Medicos.Where(p => p.NroCedula == m.NroCedula).FirstOrDefault();
                if (db_medico != null)
                {                    
                    db_medico.Nombres = m.Nombres;
                    db_medico.Apellidos = m.Apellidos;
                    db_medico.Fecha_nacimiento = m.Fecha_nacimiento;
                    db_medico.Direccion = m.Direccion;
                    db_medico.Telefono = m.Telefono;
                    db_medico.Celular = m.Celular;
                    db_medico.NroCedula = cedula_nueva;
                    dc.SaveChanges();
                }
            }
            catch (Exception err)
            {
                throw new Exception("Error en Update data: " + err.Message);
            }
        }

        public int ExistCedula(string cedula)
        {
            try
            {
                int resp = 0;
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Medico ced = null;
                ced = dc.Medicos.Where(m => m.NroCedula == cedula).FirstOrDefault();
                if (ced != null)
                {
                    resp = 1;
                }
                return resp;
            }
            catch (Exception err)
            {                
                throw new Exception("Error en ExistCedula: " + err.Message);
            }
        }        

    }
}
