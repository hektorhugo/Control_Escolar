using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEnd.Modelos
{

    public class Materias
    {
        [Key]
        public int idMateria { get; set; }
        public string nombre { get; set; }
        public decimal costo { get; set; }
    }
}