using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class serviciosData
    {
        public List<Entidad.Cat_Servicio> GetList()
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                return dc.Cat_Servicio.ToList();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en GetList" + err.Message);
            }
        }

        public void Insert(Entidad.Cat_Servicio serviciosData)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                dc.Cat_Servicio.AddObject(serviciosData);
                dc.SaveChanges();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en Insert " + err.Message);
            }
        }

        public bool ExisteServicio(Entidad.Cat_Servicio DescServicio)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Cat_Servicio cat_servicio = null;
                cat_servicio = (from cs in dc.Cat_Servicio where cs.Descripcion.Trim() == DescServicio.Descripcion select cs).FirstOrDefault();

                if (cat_servicio != null)
                    return true;
                else
                    return false;    
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }           
        }

        public void Delete(int id_borrar)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Cat_Servicio cs = (from x in dc.Cat_Servicio where x.IdServicio == id_borrar select x).FirstOrDefault();
                dc.Cat_Servicio.DeleteObject(cs);
                dc.SaveChanges();
            }
            catch (Exception err)
            {                
                throw new Exception("Error en Delete " + err.Message);
            }
        }

        public void Update(Entidad.Cat_Servicio cs)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Cat_Servicio cs_bd = null;
                cs_bd = dc.Cat_Servicio.Where(c => c.IdServicio == cs.IdServicio).FirstOrDefault();
                if (cs_bd != null)
                {
                    cs_bd.Precio = cs.Precio;
                    cs_bd.Descripcion = cs.Descripcion;
                    dc.SaveChanges();
                }
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }

        public Entidad.Cat_Servicio Find(int id)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                Entidad.Cat_Servicio servicio = null;
                servicio = dc.Cat_Servicio.Where(s => s.IdServicio == id).FirstOrDefault();
                return servicio;
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }            
        }

        public List<Entidad.Cat_Servicio> FindDescripcion(String Descripcion)
        {
            try
            {
                Entidad.ClinicaEntities dc = new Entidad.ClinicaEntities();
                List<Entidad.Cat_Servicio> descripcion = null;
                descripcion = dc.Cat_Servicio.Where(d => d.Descripcion.Contains(Descripcion)).ToList();                
                return descripcion;
            }
            catch (Exception err)
            {                
                throw new Exception(err.Message);
            }
        }



    }
}
