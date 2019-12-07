
using BackEnd.Acceso_Datos;
using BackEnd.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Repositorio
{
    public class RepositorioMaterias
    {
        private Data_Materias dataMateria = new Data_Materias();

        // GET: Materias
        public List<Materias> Buscar(Materias entidad)
        {
            try
            {
                return dataMateria.Buscar(entidad);
            }
            catch (Exception ex)
            {
                return new List<Materias>();
            }
        }
        public List<Materias> Buscar()
        {
            try
            {
                return dataMateria.Buscar();
            }
            catch (Exception ex)
            {
                return new List<Materias>();
            }
        }
        public Materias Eliminar(Materias entidad)
        {
            try
            {
                return dataMateria.Eliminar(entidad);
            }
            catch (Exception ex)
            {
                return entidad;
            }
        }
        public List<Materias> Eliminar(List<Materias> entidad)
        {
            try
            {
                return dataMateria.Eliminar(entidad);
            }
            catch (Exception ex)
            {
                return entidad;
            }
        }
        public Materias Modificar(Materias entidad)
        {
            try
            {
                return dataMateria.Modificar(entidad);
            }
            catch (Exception ex)
            {
                return entidad;
            }
        }
        public List<Materias> Modificar(List<Materias> entidad)
        {
            try
            {
                return dataMateria.Modificar(entidad);
            }
            catch (Exception ex)
            {
                return entidad;
            }
        }
    }
}