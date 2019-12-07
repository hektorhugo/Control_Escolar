using BackEnd.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Modelos.EntityManual
{
    public class Control_EscolarDBContext : DbContext
    {
        public void Refresh(RefreshMode refreshMode, IEnumerable collection) { }
        public void Refresh(RefreshMode refreshMode, params object[] entities) { }

        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Materias> Materias { get; set; }
    }

}