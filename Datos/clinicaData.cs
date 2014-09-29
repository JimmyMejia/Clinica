using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Datos
{
    public class clinicaData
    {
        public bool ExistClinica(string clinica)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Clinica cl = null;
                cl = dc.Clinicas.Where(c => c.Nombre == clinica).FirstOrDefault();
                if (cl != null)
                    return true;
                else
                    return false;
            }
            catch (Exception err)
            {                
                throw new Exception("Error en ExistClinica, " + err.Message);
            }
        }

        public void Insert(Entidad.Clinica clinicaData)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                dc.Clinicas.AddObject(clinicaData);
                dc.SaveChanges();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en Insert, " + err.Message);
            }
        }

        public void Update(Entidad.Clinica clinicaData)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Clinica db_clinica = null;
                db_clinica = dc.Clinicas.Where(cl => cl.IdClinica == clinicaData.IdClinica).FirstOrDefault();
                if (db_clinica != null)
                {
                    db_clinica.Nombre = clinicaData.Nombre;
                    db_clinica.Direccion = clinicaData.Direccion;
                    db_clinica.Email = clinicaData.Email;
                    db_clinica.Telefono = clinicaData.Telefono;
                    db_clinica.Celular = clinicaData.Celular;
                    db_clinica.Logo = clinicaData.Logo;
                    db_clinica.Activo = clinicaData.Activo;
                }
            }
            catch (Exception err)
            {              
                throw new Exception("Error en Update," + err.Message);
            }
        }

        public void Delete(Entidad.Clinica clinicaData)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                dc.Clinicas.DeleteObject(clinicaData);
                dc.SaveChanges();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en Delete, " + err.Message);
            }
        }

        public int BuscarClinicaActiva()
        {
            try
            {
                int activa = 0;

                string sql = "SELECT COUNT(*) FROM Clinica WHERE Activo =" +  "'1'";

                SqlConnection con = new SqlConnection(Entidad.Utileria.Conexion());
                con.Open();

                SqlCommand cmd = new SqlCommand(sql,con);
                activa = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                if (activa > 0)
                    activa = 1;

                return activa;
            }
            catch (Exception err)
            {                
                throw new Exception("Error en BuscarClinicaActiva " +err.Message);
            }
        }

        public int BuscarEstadoActivo(Entidad.Clinica clinica)
        {
            try
            {
                int activa;
                Entidad.Clinica estado = null;
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                estado = (dc.Clinicas.Where(a => a.Activo == "1").FirstOrDefault());
                if (estado != null)
                    activa = 1;
                else
                    activa = 0;
                
                return activa;
            }
            catch (Exception err)
            {
                throw new Exception("Error en BuscarEstadoActivo " + err.Message);
            }
            
        }

        public List<Entidad.Clinica> GetList()
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.Clinicas.ToList();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en GetList " + err.Message);
            }
           
        }

                
        
    }
}
