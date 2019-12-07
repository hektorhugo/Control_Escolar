using BackEnd.Modelo.Modelos;
using Modelo.EntityManual;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Acceso_Datos
{
    public class Data_Materias
    {
            private Control_EscolarDBContext dbo = new Control_EscolarDBContext();

            // GET: Materias
            public List<Materias> Buscar(Materias entidad)
            {

                try
                {
                    var query = from materias in dbo.Materias
                                select materias;
                    if (entidad.idMateria != 0)
                    {

                        if (entidad.nombre.Trim().Length != 0)
                            query = query.Where(q => q.nombre == entidad.nombre.Trim());
                        if (entidad.costo != 0)
                            query = query.Where(q => q.costo == entidad.costo);

                    }
                    else
                    {
                        query = query.Where(q => q.idMateria == entidad.idMateria);

                    }


                    return query.ToList();
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
                    return dbo.Materias.ToList();
                }
                catch (Exception ex)
                {
                    return new List<Materias>();
                }
            }
            // Delete: Materias
            public Materias Eliminar(Materias entidad)
            {

                try
                {

                    dbo.Materias.Remove(entidad);
                    dbo.SaveChanges();
                    return entidad;
                }
                catch (Exception ex)
                {
                    return entidad;
                }
            }
            // Delete: Materias
            public List<Materias> Eliminar(List<Materias> entidad)
            {

                try
                {

                    dbo.Materias.RemoveRange(entidad);
                    dbo.SaveChanges();
                    return entidad;
                }
                catch (Exception ex)
                {
                    return entidad;
                }
            }
            public Materias Guardar(Materias entidad)
            {

                try
                {
                    dbo.Materias.Add(entidad);
                    dbo.SaveChanges();


                    return entidad;
                }
                catch (Exception ex)
                {
                    return new Materias();
                }
            }
            public List<Materias> Guardar(List<Materias> entidad)
            {

                try
                {
                    dbo.Materias.AddRange(entidad);
                    dbo.SaveChanges();
                    return entidad;
                }
                catch (Exception ex)
                {
                    return new List<Materias>();
                }
            }
            public List<Materias> Modificar(List<Materias> entidad)
            {

                try
                {
                    var id_materias = from ent in entidad select ent.idMateria;

                    var aux = (from materias in dbo.Materias
                               where id_materias.Contains(materias.idMateria)
                               select materias).ToList();
                    aux.Select(c =>
                    {
                        c.nombre = (from s in entidad
                                    where c.idMateria == s.idMateria
                                    select s.nombre.Trim()).FirstOrDefault() != "" ?
                                    (from s in entidad where c.idMateria == s.idMateria select s.nombre.Trim()).FirstOrDefault() : c.nombre;
                        c.costo = (from s in entidad
                                   where c.idMateria == s.idMateria
                                   select s.costo).FirstOrDefault() != 0 ?
                                    (from s in entidad where c.idMateria == s.idMateria select s.costo).FirstOrDefault() : c.costo;

                        return c;
                    }).ToList();


                    dbo.SaveChanges();


                    return entidad;
                }
                catch (Exception ex)
                {
                    return new List<Materias>();
                }
            }
            public Materias Modificar(Materias entidad)
            {

                try
                {

                    var aux = Buscar(entidad);
                    aux.Select(c =>
                    {
                        c.nombre = (entidad.nombre.Trim() != "") ? entidad.nombre : c.nombre;
                        c.costo = (entidad.costo != 0) ? entidad.costo : c.costo;
                        return c;
                    }


                        ).ToList();
                    dbo.SaveChanges();


                    return entidad;
                }
                catch (Exception ex)
                {
                    return new Materias();
                }
            }

        }
    }