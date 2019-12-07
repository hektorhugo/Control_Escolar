
using BackEnd.Acceso_Datos;
using BackEnd.Modelo.Modelos;
using System;
using System.Collections.Generic;

namespace Control_Escolar.BackEnd.Negocio
{

    public class Repository_Alumnos
    {
        private Data_Alumnos dataAlumno = new Data_Alumnos();

        // GET: Alumnos
        public List<Alumnos> Buscar(Alumnos entidad)
        {
            try
            {
                return dataAlumno.Buscar(entidad);
            }
            catch (Exception ex)
            {
                return new List<Alumnos>();
            }
        }

        public List<Alumnos> Buscar()
        {
            try
            {
                return dataAlumno.Buscar();
            }
            catch (Exception ex)
            {
                return new List<Alumnos>();
            }
        }
        public Alumnos Eliminar(Alumnos entidad)
        {
            try
            {
                return dataAlumno.Eliminar(entidad);
            }
            catch (Exception ex)
            {
                return entidad;
            }
        }
        public List<Alumnos> Eliminar(List<Alumnos> entidad)
        {
            try
            {
                return dataAlumno.Eliminar(entidad);
            }
            catch (Exception ex)
            {
                return entidad;
            }
        }
        public Alumnos Modificar(Alumnos entidad)
        {
            try
            {
                return dataAlumno.Modificar(entidad);
            }
            catch (Exception ex)
            {
                return entidad;
            }
        }
        public List<Alumnos> Modificar(List<Alumnos> entidad)
        {
            try
            {
                return dataAlumno.Modificar(entidad);
            }
            catch (Exception ex)
            {
                return entidad;
            }
        }
    }
}