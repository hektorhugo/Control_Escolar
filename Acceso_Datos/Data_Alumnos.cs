using BackEnd.Modelo.Modelos;
using Modelo.EntityManual;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Acceso_Datos
{
    public class Data_Alumnos
    {
        private Control_EscolarDBContext dbo = new Control_EscolarDBContext();

    // GET: Alumnos
    public List<Alumnos> Buscar(Alumnos entidad)
    {

        try
        {
            //TEST SAVE NOT DELETE
            //var alumno1 = new Alumnos();
            //alumno1.idAlumno = 1;
            //alumno1.apellidoMaterno = "Rivera";
            //alumno1.apellidoPaterno = "Gonzalez";
            //alumno1.nombre = "Hector";

            //dbo.Alumnos.RemoveRange(dbo.Alumnos.ToList());
            //dbo.SaveChanges();
            //dbo.Alumnos.Add(alumno1);
            //dbo.SaveChanges();
            var query = from alumnos in dbo.Alumnos
                        select alumnos;
            if (entidad.idAlumno != 0)
            {

                if (entidad.nombre.Trim().Length != 0)
                    query = query.Where(q => q.nombre == entidad.nombre.Trim());
                if (entidad.apellidoMaterno.Trim().Length != 0)
                    query = query.Where(q => q.apellidoMaterno == entidad.apellidoMaterno.Trim());
                if (entidad.apellidoPaterno.Trim().Length != 0)
                    query = query.Where(q => q.apellidoPaterno == entidad.apellidoPaterno.Trim());

            }
            else
            {
                query = query.Where(q => q.idAlumno == entidad.idAlumno);

            }


            return query.ToList();
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
            return dbo.Alumnos.ToList();
        }
        catch (Exception ex)
        {
            return new List<Alumnos>();
        }
    }
    // Delete: Alumnos
    public Alumnos Eliminar(Alumnos entidad)
    {

        try
        {

            dbo.Alumnos.Remove(entidad);
            dbo.SaveChanges();
            return entidad;
        }
        catch (Exception ex)
        {
            return entidad;
        }
    }
    // Delete: Alumnos
    public List<Alumnos> Eliminar(List<Alumnos> entidad)
    {

        try
        {

            dbo.Alumnos.RemoveRange(entidad);
            dbo.SaveChanges();
            return entidad;
        }
        catch (Exception ex)
        {
            return entidad;
        }
    }
    public Alumnos Guardar(Alumnos entidad)
    {

        try
        {
            dbo.Alumnos.Add(entidad);
            dbo.SaveChanges();


            return entidad;
        }
        catch (Exception ex)
        {
            return new Alumnos();
        }
    }
    public List<Alumnos> Guardar(List<Alumnos> entidad)
    {

        try
        {
            dbo.Alumnos.AddRange(entidad);
            dbo.SaveChanges();
            return entidad;
        }
        catch (Exception ex)
        {
            return new List<Alumnos>();
        }
    }
    public List<Alumnos> Modificar(List<Alumnos> entidad)
    {

        try
        {
            var id_alumnos = from ent in entidad select ent.idAlumno;

            var aux = (from alumnos in dbo.Alumnos
                       where id_alumnos.Contains(alumnos.idAlumno)
                       select alumnos).ToList();
            aux.Select(c =>
            {
                c.nombre = (from s in entidad
                            where c.idAlumno == s.idAlumno
                            select s.nombre.Trim()).FirstOrDefault() != "" ?
                            (from s in entidad where c.idAlumno == s.idAlumno select s.nombre.Trim()).FirstOrDefault() : c.nombre;
                c.apellidoPaterno = (from s in entidad
                                     where c.idAlumno == s.idAlumno
                                     select s.apellidoPaterno.Trim()).FirstOrDefault() != "" ?
                            (from s in entidad where c.idAlumno == s.idAlumno select s.apellidoPaterno.Trim()).FirstOrDefault() : c.apellidoPaterno;

                c.apellidoMaterno = (from s in entidad
                                     where c.idAlumno == s.idAlumno
                                     select s.apellidoMaterno.Trim()).FirstOrDefault() != "" ?
                         (from s in entidad where c.idAlumno == s.idAlumno select s.apellidoMaterno.Trim()).FirstOrDefault() : c.apellidoMaterno;

                return c;
            }).ToList();


            dbo.SaveChanges();


            return entidad;
        }
        catch (Exception ex)
        {
            return new List<Alumnos>();
        }
    }
    public Alumnos Modificar(Alumnos entidad)
    {

        try
        {

            var aux = Buscar(entidad);
            aux.Select(c =>
            {
                c.nombre = (entidad.nombre.Trim() != "") ? entidad.nombre : c.nombre;
                c.apellidoPaterno = (entidad.apellidoPaterno.Trim() != "") ? entidad.apellidoPaterno : c.apellidoPaterno;
                c.apellidoMaterno = (entidad.apellidoMaterno.Trim() != "") ? entidad.apellidoMaterno : c.apellidoMaterno;
                return c;
            }


                ).ToList();
            dbo.SaveChanges();


            return entidad;
        }
        catch (Exception ex)
        {
            return new Alumnos();
        }
    }

}
}