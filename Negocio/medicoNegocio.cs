﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class medicoNegocio
    {

        public List<Entidad.Medico> ListaMedico()
        {
            try
            {
                Datos.medicoData dc = new Datos.medicoData();
                return dc.GetListMedico();
            }
            catch (Exception err)
            {
                throw new Exception("Error en ListaMedico: " + err.Message);
            }

        }

        public List<Entidad.Medico> Medicos()
        {
            try
            {
                List<Entidad.Medico> resp = new List<Entidad.Medico>();
                Datos.medicoData dc = new Datos.medicoData();
                List<Entidad.Medico> medicos = dc.GetListMedico();
                foreach (var item in medicos)
                {
                    Entidad.Medico p = new Entidad.Medico();
                    p.NroCedula = item.NroCedula;
                    p.Nombres = item.Nombres + " " + item.Apellidos;
                    p.Apellidos = item.Apellidos + " " + item.Nombres;
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

        public List<Entidad.Medico> ListaMedicos()
        {
            try
            {
                List<Entidad.Medico> resp = new List<Entidad.Medico>();
                Datos.medicoData dc = new Datos.medicoData();
                List<Entidad.Medico> medicos = dc.GetListMedico();
                foreach (var item in medicos)
                {
                    Entidad.Medico p = new Entidad.Medico();
                    p.NroCedula = item.NroCedula;
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

        public string ValidarFechas(Entidad.Medico med)
        {
            try
            {
                string error = "";
                /*OBTENEMOS LA FECHA DE NACIMIENTO EN UNA VARIABLE PARA TRATARLA DESPUES*/
                DateTime fecha_nac = Convert.ToDateTime(med.Fecha_nacimiento);
                /*GUARDAMOS EN UNA VARIABLE LA FECHA ACTUAL*/
                string fecha = Convert.ToString(DateTime.Now.ToString().Substring(0,10));//19/08/2014 10:00:20 a.m.
                DateTime fechaactual = Convert.ToDateTime(fecha);
                /*VERIFICAMOS QUE LA FECHA SOLICITADA PARA LA CITA NO SEA MENOR A LA FECHA ACTUAL*/
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

        public string InsertarMedico(Entidad.Medico m)
        {
            try
            {
                //string error = "";
                //Datos.medicoData dc = new Datos.medicoData();
                ///*OBTENEMOS LA FECHA DE NACIMIENTO EN UNA VARIABLE PARA TRATARLA DESPUES*/
                //DateTime fecha_nac = Convert.ToDateTime(m.Fecha_nacimiento);
                ///*GUARDAMOS EN UNA VARIABLE LA FECHA ACTUAL*/
                //string fecha = Convert.ToString(DateTime.Now.ToString().Substring(0, 10));//19/08/2014 10:00:20 a.m.
                //DateTime fechaactual = Convert.ToDateTime(fecha);
                ///*VERIFICAMOS QUE LA FECHA DIJITADA NO SEA MAYOR A LA FECHA ACTUAL*/
                //if (fecha_nac > fechaactual)
                //    //throw new Exception("La fecha de nacimiento no puede ser mayor a la fecha actual!!!");
                //    error = "La fecha de nacimiento no puede ser mayor a la fecha actual!!!";
                //else
                //{
                //    dc.InsertMedico(m);
                //}
                //return error;
                string error = "";
                Datos.medicoData dc = new Datos.medicoData();
                error = ValidarFechas(m);
                if (error == "")
                {
                    dc.InsertMedico(m);
                }
                return error;
            }
            catch (Exception err)
            {
                throw new Exception("Error en InsertarMedico: " + err.Message);
            }
        }

        public string UpdateMedico(Entidad.Medico m, string cedula_nueva)
        {
            try
            {
                string error = "";
                Datos.medicoData dc = new Datos.medicoData();
                error = ValidarFechas(m);
                if (error == "")
                {
                    dc.Update(m,cedula_nueva);
                }
                return error;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        //public void InsertarMedico(Entidad.Medico m)
        //{
        //    try
        //    {
        //        Datos.medicoData dc = new Datos.medicoData();
        //        /*OBTENEMOS LA FECHA DE NACIMIENTO EN UNA VARIABLE PARA TRATARLA DESPUES*/
        //        DateTime fecha_nac = Convert.ToDateTime(m.Fecha_nacimiento);
        //        /*GUARDAMOS EN UNA VARIABLE LA FECHA ACTUAL*/
        //        string fecha = Convert.ToString(DateTime.Now.ToString().Substring(0, 10));//19/08/2014 10:00:20 a.m.
        //        DateTime fechaactual = Convert.ToDateTime(fecha);
        //        /*VERIFICAMOS QUE LA FECHA DIJITADA NO SEA MAYOR A LA FECHA ACTUAL*/
        //        if (fecha_nac > fechaactual)
        //            throw new Exception("La fecha de nacimiento no puede ser mayor a la fecha actual!!!");
        //        else
        //            dc.InsertMedico(m);
        //    }
        //    catch (Exception err)
        //    {
        //        throw new Exception("Error en InsertarMedico: " + err.Message);
        //    }
        //}

        public int ExisteCedula(string cedula)
        {
            try
            {
                int resp;
                Datos.medicoData dc = new Datos.medicoData();
                return resp = dc.ExistCedula(cedula);                
            }
            catch (Exception err)
            {
                throw new Exception("Error en ExisteCedula: " + err.Message);
            }
        }

        public bool ValidaCedula(string Cedula)
        {
            if (Cedula.Length == 14)
            {
                try
                {
                    string[] letras = { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y" };
                    long CedNum = long.Parse(Cedula.Substring(0, 13));
                    string Cedletra = Cedula.Substring(13, 1).ToUpper();
                    for (int j = 0; j <= 22; j++)
                    {
                        if (Cedletra == letras[j])
                        {
                            j = 23;
                        }
                    }
                    long ValorEntero = CedNum / 23;
                    long IndLetra = CedNum - (ValorEntero * 23);
                    if (letras[IndLetra] != Cedletra)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception err)
                {
                    throw new Exception(err.Message);
                    //return false;
                }
            }
            else
                return false;
        }

        public Entidad.Medico ConsultarMedico(string nro_cedula)
        {
            try
            {
                Datos.medicoData dc = new Datos.medicoData();
                return dc.GetListMedico().Where(p => p.NroCedula== nro_cedula).FirstOrDefault();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }


    }
}
